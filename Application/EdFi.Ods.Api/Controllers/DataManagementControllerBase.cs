// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Infrastructure.Pipelines.Delete;
using EdFi.Ods.Common.Infrastructure.Pipelines.GetMany;
using EdFi.Ods.Common.Logging;
using EdFi.Ods.Common.Models.Queries;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.ProblemDetails;
using EdFi.Ods.Common.Profiles;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Serialization;
using EdFi.Ods.Common.Utils.Profiles;
using EdFi.Ods.Common.Validation;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

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
        where TAggregateRoot : class, IHasIdentifier, IMappable, new()
        where TPutRequest : TResourceModel
        where TPostRequest : TResourceModel
        where TDeleteRequest : IHasIdentifier
    {
        private const string GetAllRequest = "GetAllRequest";
        private const string GetByIdRequest = "GetByIdRequest";

        private readonly IEdFiProblemDetailsProvider _problemDetailsProvider;
        private readonly IContextProvider<ProfileContentTypeContext> _profileContentTypeContextProvider;
        private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
        private readonly ILogContextAccessor _logContextAccessor;
        private readonly int _defaultPageLimitSize;
        private readonly ReverseProxySettings _reverseProxySettings;
        private ILog _logger;
        protected Lazy<DeletePipeline> DeletePipeline;
        protected Lazy<GetPipeline<TResourceModel, TAggregateRoot>> GetByIdPipeline;
        protected Lazy<GetManyPipeline<TResourceModel, TAggregateRoot>> GetManyPipeline;
        protected Lazy<PutPipeline<TResourceModel, TAggregateRoot>> PutPipeline;

        private static readonly IContextStorage _contextStorage = new CallContextStorage();

        static DataManagementControllerBase()
        {
            ResourceEntityTypeMap.SetTypes(typeof(TAggregateRoot), typeof(TResourceModel));
        }

        protected DataManagementControllerBase(
            IPipelineFactory pipelineFactory,
            IEdFiProblemDetailsProvider problemDetailsProvider,
            IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider,
            ApiSettings apiSettings,
            IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider,
            IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
            ILogContextAccessor logContextAccessor)
        {
            _problemDetailsProvider = problemDetailsProvider;
            _profileContentTypeContextProvider = profileContentTypeContextProvider;
            _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
            _logContextAccessor = logContextAccessor;
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

        private IActionResult CreateActionResultFromException(Exception exception)
        {
            HttpContext.Items.TryAdd("Exception", exception);

            // Process translations to Problem Details
            var problemDetails = _problemDetailsProvider.GetProblemDetails(exception);
            return StatusCode(problemDetails.Status, problemDetails);
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
            [FromQuery] TGetByExampleRequest request = default,
            [FromQuery] Dictionary<string, string> additionalParameters = default)
        {
            //respond quickly to DOS style requests (should we catch these earlier?  e.g. attribute filter?)

            // Store alternative auth approach decision into call context
            if (additionalParameters?.TryGetValue("useJoinAuth", out string useJoinAuth) == true)
            {
                _contextStorage.SetValue("UseJoinAuth", Convert.ToBoolean(useJoinAuth));
            }

            var queryParameters = new QueryParameters(urlQueryParametersRequest);

            if (!QueryParametersValidator.IsValid(queryParameters, _defaultPageLimitSize, out string errorMessage))
            {
                var problemDetails = new BadRequestParameterException(BadRequestException.DefaultDetail, [errorMessage])
                {
                    CorrelationId = _logContextAccessor.GetCorrelationId()
                }.AsSerializableModel();

                return BadRequest(problemDetails);
            }
            
            var internalRequestAsResource = new TResourceModel();
            var internalRequest = internalRequestAsResource as TEntityInterface;

            if (request != null)
            {
                MapAll(request, internalRequest);
            }

            // Execute the pipeline (synchronously)
            var result = await GetManyPipeline.Value
                .ProcessAsync(
                    new GetManyContext<TResourceModel, TAggregateRoot>(internalRequestAsResource, queryParameters, additionalParameters),
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
                Response.Headers.Append(HeaderConstants.TotalCount, result.ResultMetadata.TotalCount.ToString());
            }

            if (queryParameters.MinAggregateId != null && result.Resources.Count > 0)
            {
                Response.Headers.Append(HeaderConstants.NextPageToken, result.ResultMetadata.NextPageToken);
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

        [HttpPut][HttpDelete]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [Produces(MediaTypeNames.Application.Json)]
        public virtual Task<IActionResult> PutOrDelete()
        {
            MethodNotAllowedException problemDetails;

            if (Request.Method == HttpMethods.Put)
            {
                problemDetails = new MethodNotAllowedException("Resource collections cannot be replaced. To \"upsert\" an item in the collection, use POST. To update a specific item, use PUT and include the \"id\" in the route.")
                {
                    CorrelationId = _logContextAccessor.GetCorrelationId()
                };
            }
            else
            {
                problemDetails = new MethodNotAllowedException("Resource collections cannot be deleted. To delete a specific item, use DELETE and include the \"id\" in the route.")
                {
                    CorrelationId = _logContextAccessor.GetCorrelationId()
                };
            }

            return Task.FromResult<IActionResult>(
                new ObjectResult(problemDetails.AsSerializableModel()) { StatusCode = problemDetails.Status });
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(EnforceAssignedProfileUsageFilter), IsReusable = true)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [Produces(MediaTypeNames.Application.Json)]
        public virtual async Task<IActionResult> Put([FromBody] TPutRequest request, Guid id)
        {
            if (request == null)
            {
                return GetActionResultForNullRequest(_dataManagementResourceContextProvider.Get().Resource);
            }

            // Manual binding of Id to main request model
            request.Id = id;

            // Read the If-Match header and populate the resource DTO with an etag value.
            string etag;

            bool enforceOptimisticLock = Request.TryGetRequestHeader(HeaderConstants.IfMatch, out etag);

            request.ETag = Unquoted(etag);

            var validationState = new ValidationState();

            // Execute the pipeline (synchronously)
            var result = await PutPipeline.Value.ProcessAsync(
                new PutContext<TResourceModel, TAggregateRoot>(request, validationState),
                CancellationToken.None);
            
            // Check for exceptions
            if (result.Exception != null)
            {
                Logger.Error("Put", result.Exception);
                return CreateActionResultFromException(result.Exception);
            }

            // Check for validation errors
            if (!result.ValidationResults.IsValid())
            {
                return ValidationFailedResult(result.ValidationResults);
            }

            var resourceUri = new Uri(Request.ResourceUri(_reverseProxySettings));
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

        private IActionResult GetActionResultForNullRequest(Resource resource)
        {
            var problemDetails = _errorTranslator.GetProblemDetails(resource, ModelState);
            return StatusCode(problemDetails.Status, problemDetails);
        }

        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [Produces(MediaTypeNames.Application.Json)]
        public virtual Task<IActionResult> Post(Guid id)
        {
            var problemDetails = new MethodNotAllowedException("Resource items can only be updated using PUT. To \"upsert\" an item in the resource collection using POST, remove the \"id\" from the route.")
            {
                CorrelationId = _logContextAccessor.GetCorrelationId()
            };

            return Task.FromResult<IActionResult>(
                new ObjectResult(problemDetails.AsSerializableModel()) { StatusCode = problemDetails.Status });
        }

        [HttpPost]
        [ServiceFilter(typeof(EnforceAssignedProfileUsageFilter), IsReusable = true)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [Produces(MediaTypeNames.Application.Json)]
        public virtual async Task<IActionResult> Post([FromBody] TPostRequest request)
        {
            if (request == null)
            {
                return GetActionResultForNullRequest(_dataManagementResourceContextProvider.Get().Resource);
            }

            var validationState = new ValidationState();

            // Make sure Id is not already set (no client-assigned Ids)
            if (request.Id != default)
            {
                var problemDetails = new BadRequestDataException(
                    "The request data was constructed incorrectly.",
                    new[] { "Resource identifiers cannot be assigned by the client. The 'id' property should not be included in the request body." })
                {
                    CorrelationId = _logContextAccessor.GetCorrelationId()
                }.AsSerializableModel();

                return BadRequest(problemDetails);
            }

            // Read the If-Match header and populate the resource DTO with an etag value.
            string etag;

            bool enforceOptimisticLock = Request.TryGetRequestHeader(HeaderConstants.IfMatch, out etag);

            request.ETag = Unquoted(etag);

            var result = await PutPipeline.Value.ProcessAsync(
                new PutContext<TResourceModel, TAggregateRoot>(request, validationState),
                CancellationToken.None);

            // Throw an exceptions that occurred for global exception handling
            if (result.Exception != null)
            {
                Logger.Error("Post", result.Exception);
                return CreateActionResultFromException(result.Exception);
            }

            // Check for validation errors
            if (!result.ValidationResults.IsValid())
            {
                return ValidationFailedResult(result.ValidationResults);
            }

            var resourceUri = new Uri($"{Request.ResourceUri(_reverseProxySettings)}/{result.ResourceId.GetValueOrDefault():n}");
            Response.GetTypedHeaders().Location = resourceUri;
            Response.GetTypedHeaders().ETag = GetEtag(result.ETag);

            if (result.ResourceWasCreated)
            {
                return Created(resourceUri, null);
            }
            else
            {
                return Ok();
            }
        }

        // ReSharper disable once StaticMemberInGenericType
        private static readonly ErrorTranslator _errorTranslator = new(new ModelStateKeyConverter());

        private IActionResult ValidationFailedResult(IEnumerable<ValidationResult> validationResults)
        {
            var problemDetails = _errorTranslator.GetProblemDetails(
                _dataManagementResourceContextProvider.Get().Resource,
                validationResults);

            problemDetails.CorrelationId = _logContextAccessor.GetCorrelationId();

            return BadRequest(problemDetails);
        }

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
                return CreateActionResultFromException(result.Exception);
            }

            //Return 204 (according to RFC 2616, if the delete action has been enacted but the response does not include an entity, the return code should be 204).
            return NoContent();
        }

        private EntityTagHeaderValue GetEtag(string etagValue)
        {
            return new EntityTagHeaderValue(Quoted(etagValue));
        }

        private static string Quoted(string text) => "\"" + text + "\"";

        private static string Unquoted(string text) => text?.Trim('"');
    }
}
