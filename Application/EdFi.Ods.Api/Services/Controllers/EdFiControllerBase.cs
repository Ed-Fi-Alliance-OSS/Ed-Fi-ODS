// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Castle.MicroKernel.Internal;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Api.Exceptions;
using EdFi.Ods.Api.Services.Authentication;
using EdFi.Ods.Api.Services.CustomActionResults;
using EdFi.Ods.Api.ChangeQueries.Pipelines.GetDeletedResource;
using EdFi.Ods.Api.Services.Extensions;
using EdFi.Ods.Api.Services.Filters;
using EdFi.Ods.Api.Services.Queries;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Pipelines.Delete;
using EdFi.Ods.Pipelines.Factories;
using EdFi.Ods.Pipelines.Get;
using EdFi.Ods.Pipelines.GetMany;
using EdFi.Ods.Pipelines.Put;
using log4net;

namespace EdFi.Ods.Api.Services.Controllers
{
    // TAggregateRoot,  (EdFi.Ods.Entities.NHibernate.StudentAggregate.Student)
    // TResourceModel,  (EdFi.Ods.Api.Models.Resources.Student.Student)
    // TGetByIdsRequest,  (Requests.Students.StudentGetByIds)
    // TPostRequest,  (Requests.Students.StudentPost)
    // TPutRequest,  (Requests.Students.StudentPut)
    // TDeleteRequest,  (TDeleteRequest)
    // TPatchRequest (Requests.Students.StudentPatch)

    [Authenticate]
    public abstract class EdFiControllerBase<TResourceReadModel, TResourceWriteModel, TEntityInterface, TAggregateRoot, TPutRequest, TPostRequest,
                                             TDeleteRequest, TGetByExampleRequest>
        : ApiController
        where TResourceReadModel : IHasIdentifier, IHasETag, new()
        where TResourceWriteModel : IHasIdentifier, IHasETag, new()
        where TEntityInterface : class
        where TAggregateRoot : class, IHasIdentifier, new()
        where TPutRequest : TResourceWriteModel
        where TPostRequest : TResourceWriteModel
        where TDeleteRequest : IHasIdentifier
    {
        private static string applicationUrl;
        private readonly IRESTErrorProvider restErrorProvider;

        private ILog _logger;
        protected Lazy<DeletePipeline> deletePipeline;
        protected Lazy<GetPipeline<TResourceReadModel, TAggregateRoot>> getByIdPipeline;
        protected Lazy<GetManyPipeline<TResourceReadModel, TAggregateRoot>> getManyPipeline;
        protected Lazy<GetDeletedResourcePipeline<TAggregateRoot>> getDeletedResourcePipeline;

        protected Lazy<PutPipeline<TResourceWriteModel, TAggregateRoot>> putPipeline;

        //protected IRepository<TAggregateRoot> repository;
        protected ISchoolYearContextProvider schoolYearContextProvider;
        protected IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider;

        protected EdFiControllerBase(
            IPipelineFactory pipelineFactory,
            ISchoolYearContextProvider schoolYearContextProvider,
            IRESTErrorProvider restErrorProvider,
            IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider) //IRepository<TAggregateRoot> repository, 
        {
            //this.repository = repository;
            this.schoolYearContextProvider = schoolYearContextProvider;
            this.restErrorProvider = restErrorProvider;
            this.defaultPageSizeLimitProvider = defaultPageSizeLimitProvider;

            getByIdPipeline = new Lazy<GetPipeline<TResourceReadModel, TAggregateRoot>>
                (pipelineFactory.CreateGetPipeline<TResourceReadModel, TAggregateRoot>);

            getManyPipeline = new Lazy<GetManyPipeline<TResourceReadModel, TAggregateRoot>>
                (pipelineFactory.CreateGetManyPipeline<TResourceReadModel, TAggregateRoot>);

            getDeletedResourcePipeline = new Lazy<GetDeletedResourcePipeline<TAggregateRoot>>
                (pipelineFactory.CreateGetDeletedResourcePipeline<TResourceReadModel, TAggregateRoot>);

            putPipeline = new Lazy<PutPipeline<TResourceWriteModel, TAggregateRoot>>
                (pipelineFactory.CreatePutPipeline<TResourceWriteModel, TAggregateRoot>);

            deletePipeline = new Lazy<DeletePipeline>
                (pipelineFactory.CreateDeletePipeline<TResourceReadModel, TAggregateRoot>);
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

        private IHttpActionResult CreateActionResultFromException(
            Exception exception,
            bool enforceOptimisticLock = false)
        {
            var restError = restErrorProvider.GetRestErrorFromException(exception);

            if (exception is ConcurrencyException && enforceOptimisticLock)
            {
                // See RFC 5789 - Conflicting modification (with "If-Match" header)
                restError.Code = (int) HttpStatusCode.PreconditionFailed;
                restError.Message = "Resource was modified by another consumer.";
            }

            return string.IsNullOrWhiteSpace(restError.Message)
                ? new StatusCodeResult((HttpStatusCode) restError.Code, this)
                : new StatusCodeResult((HttpStatusCode) restError.Code, this).WithError(restError.Message);
        }

        protected abstract void MapAll(TGetByExampleRequest request, TEntityInterface specification);

        public virtual async Task<IHttpActionResult> GetAll(
            [FromUri] UrlQueryParametersRequest urlQueryParametersRequest,
            [FromUri] TGetByExampleRequest request = default(TGetByExampleRequest))
        {
            var defaultPageSizeLimit = defaultPageSizeLimitProvider.GetDefaultPageSizeLimit();

            //respond quickly to DOS style requests (should we catch these earlier?  e.g. attribute filter?)
            if (urlQueryParametersRequest.Limit != null &&
                (urlQueryParametersRequest.Limit <= 0 || urlQueryParametersRequest.Limit > defaultPageSizeLimit))
            {
                return BadRequest($"Limit must be omitted or set to a value between 1 and max value defined in configuration file (defaultPageSizeLimit).");
            }

            var internalRequestAsResource = new TResourceReadModel();
            var internalRequest = internalRequestAsResource as TEntityInterface;

            if (request != null)
            {
                MapAll(request, internalRequest);
            }

            //TODO: Add support for If-None-Match; current implementation cannot verify value without going to the db
            // Read the incoming ETag header, if present
            TryGetRequestHeader("If-None-Match", out string etagValue);

            var queryParameters = new QueryParameters(urlQueryParametersRequest);

            // Execute the pipeline (synchronously)
            var result = await getManyPipeline.Value
                .ProcessAsync(
                    new GetManyContext<TResourceReadModel, TAggregateRoot>(internalRequestAsResource, queryParameters),
                    new CancellationToken());

            // Handle exception result
            if (result.Exception != null)
            {
                Logger.Error("GetAllRequest", result.Exception);
                return CreateActionResultFromException(result.Exception);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK, result.Resources);

            // Return multiple results

            if (queryParameters.TotalCount)
            {
                response.Headers.Add("Total-Count", result.ResultMetadata.TotalCount.ToString());
            }

            return new ResponseMessageResult(response).WithContentType(GetReadContentType());
        }

        public virtual async Task<IHttpActionResult> Get(Guid id)
        {
            // Read the incoming ETag header, if present
            TryGetRequestHeader("If-None-Match", out string etagValue);

            // Execute the pipeline (synchronously)
            var result = await getByIdPipeline.Value.ProcessAsync(new GetContext<TAggregateRoot>(id, etagValue), CancellationToken.None);

            // Handle exception result
            if (result.Exception != null)
            {
                Logger.Error("GetByIdRequest", result.Exception);
                return CreateActionResultFromException(result.Exception);
            }

            // Handle success result
            // Add ETag header for the resource
            var resource = result.Resource;

            var okResult = Ok(resource)
               .WithContentType(GetReadContentType());

            return AddOutboundEtagForSingleResult(okResult, resource);
        }

        [CheckModelForNull]
        public virtual async Task<IHttpActionResult> Put([FromBody] TPutRequest request, [FromUri] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Manual binding of Id to main request model
            request.Id = id;

            // Read the If-Match header and populate the resource DTO with an etag value.
            string etag;

            bool enforceOptimisticLock = TryGetRequestHeader("If-Match", out etag);

            request.ETag = etag.Unquoted();

            var validationState = new ValidationState();

            // Execute the pipeline (synchronously)
            var result = await putPipeline.Value.ProcessAsync(new PutContext<TResourceWriteModel, TAggregateRoot>(request, validationState), CancellationToken.None);

            // Check for exceptions
            if (result.Exception != null)
            {
                Logger.Error("Put", result.Exception);
                return CreateActionResultFromException(result.Exception, enforceOptimisticLock);
            }

            var status = result.ResourceWasCreated
                ? HttpStatusCode.Created
                : HttpStatusCode.NoContent;

            return
                StatusCode(status)
                   .With(
                        x =>
                        {
                            x.Headers.ETag = GetEtag(result.ETag);
                            x.Headers.Location = new Uri(GetResourceUrl(result.ResourceId.GetValueOrDefault()));
                        });
        }

        [CheckModelForNull]
        public virtual async Task<IHttpActionResult> Post([FromBody] TPostRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var validationState = new ValidationState();
            PutResult result;

            // Make sure Id is not already set (no client-assigned Ids)
            if (request.Id != default(Guid))
            {
                result = new PutResult
                         {
                             Exception = new BadRequestException("Resource identifiers cannot be assigned by the client.")
                         };
            }
            else
            {
                result = await putPipeline.Value.ProcessAsync(new PutContext<TResourceWriteModel, TAggregateRoot>(request, validationState), CancellationToken.None);
            }

            // Throw an exceptions that occurred for global exception handling
            if (result.Exception != null)
            {
                Logger.Error("Post", result.Exception);
                return CreateActionResultFromException(result.Exception);
            }

            //Once here either the resource was created or it already existed and it was updated
            //NEW GUY QUESTION: Is this the expected behavior?  Should a create fail if the resource exists?
            var status = result.ResourceWasCreated
                ? HttpStatusCode.Created
                : HttpStatusCode.OK;

            return
                StatusCode(status)
                   .With(
                        x =>
                        {
                            x.Headers.ETag = GetEtag(result.ETag);
                            x.Headers.Location = new Uri(GetResourceUrl(result.ResourceId.GetValueOrDefault()));
                        });
        }

        [CheckModelForNull]
        public async Task<IHttpActionResult> Delete([FromUri] Guid id)
        {
            // Read the If-Match header and populate the delete context based on the value (or lack of one)
            string etag;

            var enforceOptimisticLock = TryGetRequestHeader("If-Match", out etag);
            etag = etag.Unquoted();

            var deleteContext = enforceOptimisticLock
                ? new DeleteContext(id, etag)
                : new DeleteContext(id);

            // Manual binding of Id to main request model
            var result = await deletePipeline.Value.ProcessAsync(deleteContext, CancellationToken.None);

            // Throw an exceptions that occurred for global exception handling
            if (result.Exception != null)
            {
                Logger.Error("Delete", result.Exception);
                return CreateActionResultFromException(result.Exception, enforceOptimisticLock);
            }

            //Return 204 (according to RFC 2616, if the delete action has been enacted but the response does not include an entity, the return code should be 204).
            return StatusCode(HttpStatusCode.NoContent);
        }

        protected virtual string GetReadContentType()
        {
            return "application/json";
        }

        // Support methods
        protected bool TryGetRequestHeader(string headerName, out string value)
        {
            IEnumerable<string> values;
            value = null;

            if (Request == null || !Request.Headers.TryGetValues(headerName, out values))
            {
                return false;
            }

            value = values.FirstOrDefault();

            return !string.IsNullOrEmpty(value);
        }

        protected bool TryProcessEtagHeader<TRequest>(TRequest request, string headerName, Action<TRequest, DateTime> setLastModifiedDate)
        {
            // Check for optimistic locking "opt-in" header value
            IEnumerable<string> values;

            if (!Request.Headers.TryGetValues(headerName, out values))
            {
                return false;
            }

            string etag = values.FirstOrDefault();

            long etagValue = 0;

            if (etag != null && long.TryParse(etag, out etagValue))
            {
                setLastModifiedDate(request, DateTime.FromBinary(etagValue));
                return true;
            }

            return false;
        }

        protected IHttpActionResult AddOutboundEtagForSingleResult(IHttpActionResult response, IHasETag dto)
        {
            var etag = dto.ETag;

            // Add the etag header
            var responseWithEtag = response.With(x => x.Headers.ETag = new EntityTagHeaderValue(etag.Quoted()));

            // Suppress the "_etag" value from the serialized body of the response (to remove redundant data for single responses)
            dto.ETag = null;
            return responseWithEtag;
        }

        private EntityTagHeaderValue GetEtag(string etagValue)
        {
            return new EntityTagHeaderValue(etagValue.Quoted());
        }

        protected abstract string GetResourceCollectionName();

        protected string GetResourceUrl(Guid id)
        {
            if (applicationUrl == null)
            {
                try
                {
                    // rebuild the base uri using segments to remove the need of the magic string
                    var baseUri = string.Join(
                        "",
                        Request.RequestUri.Segments.TakeWhile(
                            x => !string.Equals(
                                x.TrimEnd('/'),
                                GetResourceCollectionName(),
                                StringComparison.InvariantCultureIgnoreCase)));

                    applicationUrl = string.Format(
                        "{0}://{1}{2}{3}",
                        Request.RequestUri.Scheme,
                        Request.RequestUri.Host,
                        baseUri,
                        GetResourceCollectionName());
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to parse API base URL from request.", ex);
                }
            }

            //since we removed the school year from the route, we can use use the base uri as our response.
            return string.Format("{0}/{1}", applicationUrl, id.ToString("n"));
        }
    }
}
