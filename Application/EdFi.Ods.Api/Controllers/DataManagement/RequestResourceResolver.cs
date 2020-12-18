using System;
using System.Linq;
using System.Net.Http;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Utils.Profiles;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Controllers.DataManagement
{
    public class RequestResourceResolver : IRequestResourceResolver
    {
        private readonly IProfileResourceModelProvider _profileResourceModelProvider;
        private readonly IResourceModelProvider _resourceModelProvider;

        public RequestResourceResolver(
            IProfileResourceModelProvider profileResourceModelProvider,
            IResourceModelProvider resourceModelProvider)
        {
            _profileResourceModelProvider = profileResourceModelProvider;
            _resourceModelProvider = resourceModelProvider;
        }
        
        public ValueTuple<Resource, RESTError> GetResourceForRequest(HttpRequest request)
        {
            string schemaUriSegment = (string) request.RouteValues["schema"];
            string resourceCollectionName = (string) request.RouteValues["resourceCollection"];

            var resourceModel = _resourceModelProvider.GetResourceModel();

            var resource = resourceModel.GetResourceByApiCollectionName(schemaUriSegment, resourceCollectionName);

            if (resource == null)
            {
                return (null, new RESTError {Code = 404});
            }
            
            // TODO: Simple API - Move this to a decorator
            if (TryGetProfileContentType(request, out string profileContentType))
            {
                var contentTypeDetails = profileContentType.GetContentTypeDetails();

                if (!contentTypeDetails.Resource.EqualsIgnoreCase(resource.FullName.Name))
                {
                    // TODO: Should review current implementation for actual matching message here.
                    return (null, new RESTError { Code = 400, Message = "Invalid content type for resource."});
                }
            
                var profileResourceModel = _profileResourceModelProvider.GetProfileResourceModel(contentTypeDetails.Profile);
                
                return (profileResourceModel.GetResourceByName(resource.FullName), null);
            }

            return (resourceModel.GetResourceByFullName(resource.FullName), null);
                
            bool TryGetProfileContentType(HttpRequest request, out string profileContentType)
            {
                profileContentType = null;

                // If the method is GET then retrieve the content type from the accept header if it is a profile content type
                if (request.Method.EqualsIgnoreCase(HttpMethod.Get.ToString()))
                {
                    if (request.Headers.TryGetValue("Accept", out var acceptValues))
                    {
                        profileContentType = acceptValues.FirstOrDefault(x => x.StartsWith("application/vnd.ed-fi"));
                    }
                }

                //if the method is put or post then retrieve the content type from the content type header if it is a profile type
                if (request.Method.EqualsIgnoreCase(HttpMethod.Put.Method) || request.Method.EqualsIgnoreCase(HttpMethod.Post.Method))
                {
                    if (request.ContentType.StartsWith("application/vnd.ed-fi"))
                    {
                        profileContentType = request.ContentType;
                    }
                }

                return !string.IsNullOrEmpty(profileContentType);
            }
        }
    }
}