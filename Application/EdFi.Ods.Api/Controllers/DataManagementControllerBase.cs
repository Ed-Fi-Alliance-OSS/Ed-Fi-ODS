﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Filters;
using EdFi.Ods.Api.Infrastructure.Pipelines.Factories;
using EdFi.Ods.Api.Infrastructure.Pipelines.Get;
using EdFi.Ods.Api.Infrastructure.Pipelines.GetMany;
using EdFi.Ods.Api.Infrastructure.Pipelines.Put;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Infrastructure.Pipelines.Delete;
using EdFi.Ods.Common.Infrastructure.Pipelines.GetMany;
using EdFi.Ods.Common.Models.Queries;
using EdFi.Ods.Common.Profiles;
using EdFi.Ods.Common.Utils.Profiles;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Polly;
using Polly.Retry;

namespace EdFi.Ods.Api.Controllers
{
    // TAggregateRoot,  (EdFi.Ods.Entities.NHibernate.StudentAggregate.Student)
    // TResourceModel,  (EdFi.Ods.Api.Models.Resources.Student.Student)
    // TGetByIdsRequest,  (Requests.Students.StudentGetByIds)
    // TPostRequest,  (Requests.Students.StudentPost)
    // TPutRequest,  (Requests.Students.StudentPut)
    // TDeleteRequest,  (TDeleteRequest)
    // TPatchRequest (Requests.Students.StudentPatch)
    public abstract class DataManagementControllerBase<TResourceModel, TEntityInterface, TAggregateRoot,
            TPutRequest, TPostRequest,
            TDeleteRequest, TGetByExampleRequest>
        : ControllerBase
        where TResourceModel : IHasIdentifier, IHasETag, new()
        where TEntityInterface : class
        where TAggregateRoot : class, IHasIdentifier, new()
        where TPutRequest : TResourceModel
        where TPostRequest : TResourceModel
        where TDeleteRequest : IHasIdentifier
    {
        private const string GetAllRequest = "GetAllRequest";
        private const string GetByIdRequest = "GetByIdRequest";

        private readonly IRESTErrorProvider _restErrorProvider;
        private readonly IContextProvider<ProfileContentTypeContext> _profileContentTypeContextProvider;
        private readonly int _defaultPageLimitSize;
        private readonly ReverseProxySettings _reverseProxySettings;
        private ILog _logger;
        protected Lazy<DeletePipeline> DeletePipeline;
        protected Lazy<GetPipeline<TResourceModel, TAggregateRoot>> GetByIdPipeline;

        protected Lazy<GetManyPipeline<TResourceModel, TAggregateRoot>> GetManyPipeline;

        protected Lazy<PutPipeline<TResourceModel, TAggregateRoot>> PutPipeline;

        //protected IRepository<TAggregateRoot> repository;
        protected ISchoolYearContextProvider SchoolYearContextProvider;

        // ReSharper disable once StaticMemberInGenericType
        private static readonly AsyncRetryPolicy<PutResult> _retryPolicy;

        static DataManagementControllerBase()
        {
            const int RetryCount = 5;
            const int RetryStartingDelayMilliseconds = 100;

            _retryPolicy = Policy.HandleResult<PutResult>(res => res.ShouldRetry())
                .WaitAndRetryAsync(
                    RetryCount,
                    (retryNumber, context) =>
                    {
                        var waitDuration = TimeSpan.FromMilliseconds(RetryStartingDelayMilliseconds * (Math.Pow(2, retryNumber)));

                        (context["Logger"] as Lazy<ILog>)?.Value.Warn(
                            $"Deadlock exception encountered during '{typeof(TAggregateRoot).Name}' entity persistence. Retrying transaction (retry #{retryNumber} of {RetryCount} after {waitDuration.TotalMilliseconds:N0}ms))...");

                        return waitDuration;
                    },
                    onRetry: (res, ts, context) => { });
        }

        protected DataManagementControllerBase(
            IPipelineFactory pipelineFactory,
            ISchoolYearContextProvider schoolYearContextProvider,
            IRESTErrorProvider restErrorProvider,
            IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider,
            ApiSettings apiSettings,
            IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
        {
            //this.repository = repository;
            SchoolYearContextProvider = schoolYearContextProvider;
            _restErrorProvider = restErrorProvider;
            _profileContentTypeContextProvider = profileContentTypeContextProvider;
            _defaultPageLimitSize = defaultPageSizeLimitProvider.GetDefaultPageSizeLimit();
            _reverseProxySettings = apiSettings.GetReverseProxySettings();

            GetByIdPipeline = new Lazy<GetPipeline<TResourceModel, TAggregateRoot>>
                (pipelineFactory.CreateGetPipeline<TResourceModel, TAggregateRoot>);

            GetManyPipeline = new Lazy<GetManyPipeline<TResourceModel, TAggregateRoot>>
                (pipelineFactory.CreateGetManyPipeline<TResourceModel, TAggregateRoot>);

            PutPipeline = new Lazy<PutPipeline<TResourceModel, TAggregateRoot>>
                (pipelineFactory.CreatePutPipeline<TResourceModel, TAggregateRoot>);

            DeletePipeline = new Lazy<DeletePipeline>
                (pipelineFactory.CreateDeletePipeline<TResourceModel, TAggregateRoot>);
        }

        protected ILog Logger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = LogManager.GetLogger(GetType());
                }

                return _logger;
            }
        }

        private IActionResult CreateActionResultFromException(
            Exception exception,
            bool enforceOptimisticLock = false)
        {
            var restError = _restErrorProvider.GetRestErrorFromException(exception);
            HttpContext.Items.Add("Exception", exception);

            if (exception is ConcurrencyException && enforceOptimisticLock)
            {
                // See RFC 5789 - Conflicting modification (with "If-Match" header)
                restError.Code = StatusCodes.Status412PreconditionFailed;
                restError.Message = "Resource was modified by another consumer.";
            }

            return string.IsNullOrWhiteSpace(restError.Message)
                ? (IActionResult) StatusCode(restError.Code)
                : StatusCode(restError.Code, ErrorTranslator.GetErrorMessage(restError.Message));
        }

        protected abstract void MapAll(TGetByExampleRequest request, TEntityInterface specification);

        private string GetReadContentType()
        {
            var profilesContext = _profileContentTypeContextProvider.Get();

            if (profilesContext == null)
            {
                return MediaTypeNames.Application.Json;
            }

            return ProfilesContentTypeHelper.CreateContentType(
                profilesContext.ResourceName,
                profilesContext.ProfileName,
                profilesContext.ContentTypeUsage);
        }

        [HttpGet]
        [ServiceFilter(typeof(EnforceAssignedProfileUsageFilter), IsReusable = true)]
        public virtual async Task<IActionResult> GetAll(
            [FromQuery] UrlQueryParametersRequest urlQueryParametersRequest,
            [FromQuery] TGetByExampleRequest request = default(TGetByExampleRequest))
        {
            //respond quickly to DOS style requests (should we catch these earlier?  e.g. attribute filter?)
            if (urlQueryParametersRequest.Limit != null &&
                (urlQueryParametersRequest.Limit < 0 || urlQueryParametersRequest.Limit > _defaultPageLimitSize))
            {
                return BadRequest(
                    ErrorTranslator.GetErrorMessage(
                        "Limit must be omitted or set to a value between 1 and max value defined in configuration file (defaultPageSizeLimit)."));
            }

            var internalRequestAsResource = new TResourceModel();
            var internalRequest = internalRequestAsResource as TEntityInterface;

            if (request != null)
            {
                MapAll(request, internalRequest);
            }

            var queryParameters = new QueryParameters(urlQueryParametersRequest);

            // Execute the pipeline (synchronously)
            var result = await GetManyPipeline.Value
                .ProcessAsync(
                    new GetManyContext<TResourceModel, TAggregateRoot>(internalRequestAsResource, queryParameters),
                    new CancellationToken());

            // Handle exception result
            if (result.Exception != null)
            {
                Logger.Error(GetAllRequest, result.Exception);
                return CreateActionResultFromException(result.Exception);
            }

            // Return multiple results
            if (queryParameters.TotalCount)
            {
                Response.Headers.Add(HeaderConstants.TotalCount, result.ResultMetadata.TotalCount.ToString());
            }

            Response.GetTypedHeaders().ContentType = new MediaTypeHeaderValue(GetReadContentType());
            return Ok(result.Resources);
        }

        [HttpGet("{id:guid}")]
        [ServiceFilter(typeof(EnforceAssignedProfileUsageFilter), IsReusable = true)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            // Read the incoming ETag header, if present
            Request.TryGetRequestHeader(HeaderConstants.IfNoneMatch, out string etagValue);

            // Execute the pipeline (synchronously)
            var result = await GetByIdPipeline.Value.ProcessAsync(
                new GetContext<TAggregateRoot>(id, etagValue), CancellationToken.None);

            // Handle exception result
            if (result.Exception != null)
            {
                Logger.Error(GetByIdRequest, result.Exception);
                return CreateActionResultFromException(result.Exception);
            }

            // Handle success result
            var responseHeaders = Response.GetTypedHeaders();
            
            // Set content type appropriately
            responseHeaders.ContentType = new MediaTypeHeaderValue(GetReadContentType());
            
            // Add ETag header for the resource
            responseHeaders.ETag = GetEtag(result.Resource.ETag);
            return Ok(result.Resource);
        }

        [CheckModelForNull]
        [HttpPut("{id}")]
        [ServiceFilter(typeof(EnforceAssignedProfileUsageFilter), IsReusable = true)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [Produces(MediaTypeNames.Application.Json)]
        public virtual async Task<IActionResult> Put([FromBody] TPutRequest request, Guid id)
        {
            // Manual binding of Id to main request model
            request.Id = id;

            // Read the If-Match header and populate the resource DTO with an etag value.
            string etag;

            bool enforceOptimisticLock = Request.TryGetRequestHeader(HeaderConstants.IfMatch, out etag);

            request.ETag = Unquoted(etag);

            var validationState = new ValidationState();

            // Execute the pipeline (synchronously)
            var result = await _retryPolicy.ExecuteAsync(
                (ctx) => PutPipeline.Value.ProcessAsync(
                    new PutContext<TResourceModel, TAggregateRoot>(request, validationState),
                    CancellationToken.None),
                contextData: new Dictionary<string, object>() { { "Logger", new Lazy<ILog>(() => Logger) } });

            // Check for exceptions
            if (result.Exception != null)
            {
                Logger.Error("Put", result.Exception);
                return CreateActionResultFromException(result.Exception, enforceOptimisticLock);
            }

            var resourceUri = new Uri(GetResourceUrl());
            Response.GetTypedHeaders().Location = resourceUri;
            Response.GetTypedHeaders().ETag = GetEtag(result.ETag);

            if (result.ResourceWasCreated)
            {
                HttpContext.Items.Add("createdResourceUri", resourceUri.ToString());
                return (IActionResult)Created(resourceUri, null);
            }
            else
            {
                return NoContent();
            }
        }

        [CheckModelForNull]
        [HttpPost]
        [ServiceFilter(typeof(EnforceAssignedProfileUsageFilter), IsReusable = true)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [Produces(MediaTypeNames.Application.Json)]
        public virtual async Task<IActionResult> Post([FromBody] TPostRequest request)
        {
            var validationState = new ValidationState();

            // Make sure Id is not already set (no client-assigned Ids)
            if (request.Id != default(Guid))
            {
                return BadRequest(ErrorTranslator.GetErrorMessage("Resource identifiers cannot be assigned by the client."));
            }

            // Read the If-Match header and populate the resource DTO with an etag value.
            string etag;

            bool enforceOptimisticLock = Request.TryGetRequestHeader(HeaderConstants.IfMatch, out etag);

            request.ETag = Unquoted(etag);

            var result = await _retryPolicy.ExecuteAsync(
                (ctx) => PutPipeline.Value.ProcessAsync(
                    new PutContext<TResourceModel, TAggregateRoot>(request, validationState),
                    CancellationToken.None),
                contextData: new Dictionary<string, object>() { { "Logger", new Lazy<ILog>(() => Logger) } });

            // Throw an exceptions that occurred for global exception handling
            if (result.Exception != null)
            {
                Logger.Error("Post", result.Exception);
                return CreateActionResultFromException(result.Exception, enforceOptimisticLock);
            }

            var resourceUri = new Uri($"{GetResourceUrl()}/{result.ResourceId.GetValueOrDefault():n}");
            Response.GetTypedHeaders().Location = resourceUri;
            Response.GetTypedHeaders().ETag = GetEtag(result.ETag);

            if (result.ResourceWasCreated)
            {
                return (IActionResult)Created(resourceUri, null);
            }
            else
            {
                return Ok();
            }
        }

        [CheckModelForNull]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [Produces(MediaTypeNames.Application.Json)]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            // Read the If-Match header and populate the delete context based on the value (or lack of one)
            var enforceOptimisticLock = Request.TryGetRequestHeader(HeaderConstants.IfMatch, out string etag);
            etag = Unquoted(etag);

            var deleteContext = enforceOptimisticLock
                ? new DeleteContext(id, etag)
                : new DeleteContext(id);

            // Manual binding of Id to main request model
            var result = await DeletePipeline.Value.ProcessAsync(deleteContext, CancellationToken.None);

            // Throw an exceptions that occurred for global exception handling
            if (result.Exception != null)
            {
                Logger.Error("Delete", result.Exception);
                return CreateActionResultFromException(result.Exception, enforceOptimisticLock);
            }

            //Return 204 (according to RFC 2616, if the delete action has been enacted but the response does not include an entity, the return code should be 204).
            return NoContent();
        }

        private EntityTagHeaderValue GetEtag(string etagValue)
        {
            return new EntityTagHeaderValue(Quoted(etagValue));
        }

        protected string GetResourceUrl()
        {
            try
            {
                var uriBuilder = new UriBuilder(
                    Request.Scheme(this._reverseProxySettings),
                    Request.Host(this._reverseProxySettings),
                    Request.Port(this._reverseProxySettings),
                    Request.PathBase.Add(Request.Path));

                return uriBuilder.Uri.ToString().TrimEnd('/');
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to parse API base URL from request.", ex);
            }
        }

        private static string Quoted(string text) => "\"" + text + "\"";

        private static string Unquoted(string text) => text?.Trim('"');
    }
}
