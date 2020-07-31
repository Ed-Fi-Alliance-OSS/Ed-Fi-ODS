// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;

namespace EdFi.Ods.WebService.Tests
{
    public class RouteTester
    {
        private readonly HttpConfiguration _config;
        private HttpControllerContext _controllerContext;
        private IHttpControllerSelector _controllerSelector;
        private HttpRequestMessage _request;
        private IHttpRouteData _routeData;

        public RouteTester(HttpConfiguration conf)
        {
            _config = conf;
        }

        public string ValidateRoutingForUrl(string method, string url, Type controller, string action)
        {
            _request = new HttpRequestMessage(GetMethod(method), url);

            _routeData = _config.Routes.GetRouteData(_request);

            if (_routeData == null)
            {
                return url + " failed to resolve to any controller";
            }

            _request.Properties[HttpPropertyKeys.HttpRouteDataKey] = _routeData;

            // TODO JSM - We actually the ProfilesAwareControllerSelector and this is brittle and should be refactored.
            _controllerSelector = new DefaultHttpControllerSelector(_config);

            _controllerContext = new HttpControllerContext(_config, _routeData, _request);
            var resolvedController = GetControllerType();

            if (controller != resolvedController)
            {
                return url + " resolved to " + resolvedController + " instead of " + controller.Name
                       + string.Format(" using route template '{0}'.", _routeData.Route.RouteTemplate);
            }

            var resolvedAction = GetActionName();

            if (action != resolvedAction)
            {
                return url + " resolved to " + resolvedAction + " instead of " + action
                       + string.Format(" using route template '{0}'.", _routeData.Route.RouteTemplate);
            }

            return string.Empty;
        }

        private HttpMethod GetMethod(string method)
        {
            if (method.Equals("GET"))
            {
                return HttpMethod.Get;
            }

            if (method.Equals("POST"))
            {
                return HttpMethod.Post;
            }

            return HttpMethod.Get; //default
        }

        private Type GetControllerType()
        {
            try
            {
                var descriptor = _controllerSelector.SelectController(_request);
                _controllerContext.ControllerDescriptor = descriptor;
                return descriptor.ControllerType;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                return typeof(object);
            }
        }

        private string GetActionName()
        {
            try
            {
                if (_controllerContext.ControllerDescriptor == null)
                {
                    GetControllerType();
                }

                var actionSelector = new ApiControllerActionSelector();
                var descriptor = actionSelector.SelectAction(_controllerContext);
                return descriptor.ActionName;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                return "<Null>";
            }
        }
    }
}
