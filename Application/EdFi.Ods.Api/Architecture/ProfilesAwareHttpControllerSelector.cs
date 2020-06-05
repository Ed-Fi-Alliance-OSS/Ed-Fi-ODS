// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using EdFi.Ods.Api.Common.Models;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Inflection;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Utils.Profiles;

namespace EdFi.Ods.Api.Architecture
{
    public class ProfilesAwareHttpControllerSelector : DefaultHttpControllerSelector
    {
        private const string ControllerKey = "controller";
        private const string ResourceOwnerKey = "schema";
        private const string CompositeControllerName = "CompositeResource";

        private readonly HttpConfiguration _configuration;
        private readonly Lazy<Dictionary<string, HttpControllerDescriptor>> _controllers;
        private readonly HashSet<string> _duplicates;
        private readonly IProfileResourceNamesProvider _profileResourceNamesProvider;
        private readonly ISchemaNameMapProvider _schemaNameMapProvider;

        public ProfilesAwareHttpControllerSelector(
            HttpConfiguration config,
            IProfileResourceNamesProvider profileResourceNamesProvider,
            ISchemaNameMapProvider schemaNameMapProvider)
            : base(config)
        {
            _configuration = config;
            _profileResourceNamesProvider = profileResourceNamesProvider;
            _duplicates = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            _controllers = new Lazy<Dictionary<string, HttpControllerDescriptor>>(InitializeControllerDictionary);
            _schemaNameMapProvider = schemaNameMapProvider;
        }

        private Dictionary<string, HttpControllerDescriptor> InitializeControllerDictionary()
        {
            var dictionary = new Dictionary<string, HttpControllerDescriptor>(StringComparer.OrdinalIgnoreCase);

            // Create a lookup table where key is "namespace.controller". The value of "namespace" is the
            // full namespace where the controller resides.
            // EdFi.Ods.Api.Services.Controllers.AcademicHonorCategoryTypes.AcademicHonorCategoryTypes
            IAssembliesResolver assembliesResolver = _configuration.Services.GetAssembliesResolver();
            IHttpControllerTypeResolver controllersResolver = _configuration.Services.GetHttpControllerTypeResolver();

            ICollection<Type> controllerTypes = controllersResolver.GetControllerTypes(assembliesResolver);

            foreach (Type t in controllerTypes)
            {
                var key = FullyQualifiedControllerNamespace(t.Namespace, t.Name);

                // Check for duplicate keys.
                if (dictionary.Keys.Contains(key))
                {
                    _duplicates.Add(key);
                }
                else
                {
                    dictionary[key] = new HttpControllerDescriptor(_configuration, t.Name, t);
                }
            }

            // Remove any duplicates from the dictionary, because these create ambiguous matches. 
            // For example, "Foo.V1.ProductsController" and "Bar.V1.ProductsController" both map to "v1.products".
            foreach (string s in _duplicates)
            {
                dictionary.Remove(s);
            }

            return dictionary;
        }

        private string FullyQualifiedControllerNamespace(string controllerNamespace, string controllerName)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}.{1}",
                controllerNamespace,

                // Strip "Controller" from the end of the type name.
                // This matches the behavior of DefaultHttpControllerSelector.
                controllerName.EndsWith(ControllerSuffix)
                    ? controllerName.Remove(
                        controllerName.Length - ControllerSuffix.Length)
                    : controllerName);
        }

        // Get a value from the route data, if present.
        private static T GetRouteVariable<T>(IHttpRouteData routeData, string name)
        {
            object result = null;

            if (routeData.Values.TryGetValue(name, out result))
            {
                return (T) result;
            }

            return default(T);
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            if (_duplicates.Any())
            {
                throw new HttpResponseException(
                    request.CreateErrorResponse(
                        HttpStatusCode.InternalServerError,
                        $@"Duplicate controllers have been detected. 
                           Due to ambiguity, no requests will be served until this is resolved.  
                           The following controllers have been detected as duplicates: {string.Join(", ", _duplicates)}"));
            }

            IHttpRouteData routeData = request.GetRouteData();

            if (routeData == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            string controllerName = GetRouteVariable<string>(routeData, ControllerKey);

            // schema section of url ie /data/v3/{schema}/{resource} ex: /data/v3/ed-fi/schools
            string resourceSchema = GetRouteVariable<string>(routeData, ResourceOwnerKey);

            if (ShouldUseDefaultSelectController(controllerName, resourceSchema))
            {
                // If there's no controller or schema name, defer to the base class for direct route handling
                // Also if the controller is a composite controller we defer to base class.
                return base.SelectController(request);
            }

            string resourceSchemaNamespace = string.Empty;

            if (controllerName.EqualsIgnoreCase("deletes"))
            {
                resourceSchemaNamespace = "EdFi.Ods.ChangeQueries.Controllers";
            }
            else
            {
                try
                {
                    string properCaseName = _schemaNameMapProvider
                        .GetSchemaMapByUriSegment(resourceSchema)
                        .ProperCaseName;

                    // for now the check is including the ignore case due to the way the schema name map provider is implemented
                    // this should be address on the changes in phase 4 where the map provider is using dictionaries.
                    resourceSchemaNamespace =
                        EdFiConventions.BuildNamespace(
                            Namespaces.Api.Controllers,
                            properCaseName,
                            controllerName,
                            !EdFiConventions.ProperCaseName.EqualsIgnoreCase(properCaseName));
                }
                // Quietly ignore any failure to find the schema name, allowing NotFound response logic below to run
                catch (KeyNotFoundException) {}
            }

            // Verify org section matches a known resource owner derived from any assembly implementing ISchemaNameMap
            if (string.IsNullOrEmpty(resourceSchemaNamespace))
            {
                throw new HttpResponseException(
                    request.CreateErrorResponse(
                        HttpStatusCode.NotFound,
                        "Resource schema value provided in uri does not match any known values."));
            }

            ProfileContentTypeDetails profileContentTypeDetails = null;

            // http method type determines where the profile specific content type will be sent.
            if (request.Method == HttpMethod.Get)
            {
                profileContentTypeDetails =
                    (from a in request.Headers.Accept
                     where a.MediaType.StartsWith("application/vnd.ed-fi.")
                     let details = a.MediaType.GetContentTypeDetails()
                     select details)
                   .SingleOrDefault();
            }
            else if (request.Method == HttpMethod.Put || request.Method == HttpMethod.Post)
            {
                if (request.Content != null)
                {
                    var contentType = request.Content.Headers.ContentType;

                    // check that there was a content type on the request
                    if (contentType != null)
                    {
                        // check if the content type is a profile specific content type
                        if (contentType.MediaType.StartsWith("application/vnd.ed-fi."))
                        {
                            // parse the profile specific content type string into the object.
                            profileContentTypeDetails = contentType.MediaType.GetContentTypeDetails();

                            // Was a profile-specific content type for the controller/resource found and was it parseable?
                            // if it was not parsable but started with "application/vnd.ed-fi." then throw an error
                            if (profileContentTypeDetails == null)
                            {
                                throw new HttpResponseException(
                                    BadRequestHttpResponseMessage(
                                        request,
                                        "Content type not valid on this resource."));
                            }
                        }
                    }
                }
            }

            HttpControllerDescriptor controllerDescriptor;
            string key;
            bool profileControllerNotFound = false;

            // Was a profile-specific content type for the controller/resource found?
            if (profileContentTypeDetails != null)
            {
                // Ensure that the content type resource matchs requested resource
                if (!profileContentTypeDetails.Resource
                                              .EqualsIgnoreCase(CompositeTermInflector.MakeSingular(controllerName)))
                {
                    throw new HttpResponseException(
                        BadRequestHttpResponseMessage(
                            request,
                            "The resource is not accessible through the profile specified by the content type."));
                }

                // Ensure that if the method is get that the profile specific content type sent readable
                if (request.Method == HttpMethod.Get && profileContentTypeDetails.Usage != ContentTypeUsage.Readable)
                {
                    throw new HttpResponseException(
                        BadRequestHttpResponseMessage(
                            request,
                            "The resource is not accessible through the profile specified by the content type."));
                }

                // Ensure that if the http method is PUT or POST that the profile specific type sent was writable
                if ((request.Method == HttpMethod.Put || request.Method == HttpMethod.Post)
                    && profileContentTypeDetails.Usage != ContentTypeUsage.Writable)
                {
                    throw new HttpResponseException(
                        BadRequestHttpResponseMessage(
                            request,
                            "The resource is not accessible through the profile specified by the content type."));
                }

                // Use the profile name as the namespace for controller matching
                string profileName = profileContentTypeDetails.Profile.Replace('-', '_'); // + "_" + profileContentTypeDetails.Usage;

                // Find a matching controller.
                // ex : EdFi.Ods.Api.Services.Controllers.AcademicHonorCategoryTypes.Academic_Week_Readable_Excludes_Optional_References.AcademicHonorCategoryTypes
                key = string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}.{1}.{2}",
                    resourceSchemaNamespace,
                    profileName,
                    controllerName);

                if (_controllers.Value.TryGetValue(key, out controllerDescriptor))
                {
                    return controllerDescriptor;
                }

                profileControllerNotFound = true;
            }

            // Find a matching controller.
            // ex : EdFi.Ods.Api.Services.Controllers.AcademicHonorCategoryTypes.AcademicHonorCategoryTypes
            key = string.Format(
                CultureInfo.InvariantCulture,
                "{0}.{1}",
                resourceSchemaNamespace,
                controllerName);

            if (_controllers.Value.TryGetValue(key, out controllerDescriptor))
            {
                // If there is a controller, just not with the content type specified, it's a bad request
                if (profileControllerNotFound)
                {
                    // If the profile does not exist in this installation of the api throw an error dependent on the http method
                    if (!ProfileExists(profileContentTypeDetails.Profile))
                    {
                        if (request.Method == HttpMethod.Get)
                        {
                            throw new HttpResponseException(NotAcceptableHttpResponseMessage(request));
                        }

                        if (request.Method == HttpMethod.Put || request.Method == HttpMethod.Post)
                        {
                            throw new HttpResponseException(UnsupportedMediaTypeHttpResponseMessage(request));
                        }
                    }

                    // The profile exists but the resource doesnt exist under it
                    throw new HttpResponseException(
                        BadRequestHttpResponseMessage(
                            request,
                            string.Format(
                                "The '{0}' resource is not accessible through the '{1}' profile specified by the content type.",
                                CompositeTermInflector.MakeSingular(controllerName),
                                profileContentTypeDetails.Profile)));
                }

                return controllerDescriptor;
            }

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        private static bool ShouldUseDefaultSelectController(string controllerName, string resourceSchema)
        {
            // TODO - JSM ODS-1699 changed the routes to include the edfi schema name, which implies that composites will only be Ed-Fi specific.
            // StartupBase has the route defined as a parameter in composites so in the future this may need to be abstracted appropriately.
            return controllerName == null
                   || resourceSchema == null
                   || controllerName.EqualsIgnoreCase(CompositeControllerName);
        }

        private bool ProfileExists(string profileName)
        {
            return _profileResourceNamesProvider.GetProfileResourceNames()
                                                .Any(x => x.ProfileName.EqualsIgnoreCase(profileName));
        }

        private HttpResponseMessage BadRequestHttpResponseMessage(HttpRequestMessage request, string message)
        {
            return request.CreateResponse(
                HttpStatusCode.BadRequest,
                new RESTError
                {
                    Code = (int) HttpStatusCode.BadRequest, Type = "Bad Request", Message = message
                });
        }

        private HttpResponseMessage NotAcceptableHttpResponseMessage(HttpRequestMessage request)
        {
            return request.CreateResponse(
                HttpStatusCode.NotAcceptable,
                new RESTError
                {
                    Code = (int) HttpStatusCode.NotAcceptable, Type = "Not Acceptable",
                    Message = "the profile specified by the content type is not supported by this host"
                });
        }

        private HttpResponseMessage UnsupportedMediaTypeHttpResponseMessage(HttpRequestMessage request)
        {
            return request.CreateResponse(
                HttpStatusCode.UnsupportedMediaType,
                new RESTError
                {
                    Code = (int) HttpStatusCode.UnsupportedMediaType, Type = "Unsupported Media Type",
                    Message = "the profile specified by the content type is not supported by this host"
                });
        }

        public override IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            return _controllers.Value;
        }
    }
}
