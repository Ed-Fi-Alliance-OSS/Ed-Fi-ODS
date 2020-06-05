// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Template;

namespace EdFi.Ods.Api.NetCore.Routing
{
    public class RouteMatcher
    {
        public bool TryMatch(string routeTemplate, string requestPath, out RouteValueDictionary values)
        {
            var template = TemplateParser.Parse(routeTemplate);

            var routeValueDictionary = GetDefaults(template);
            var matcher = new TemplateMatcher(template, routeValueDictionary);

            if (matcher.TryMatch(requestPath, routeValueDictionary))
            {
                values = routeValueDictionary;
                return true;
            }

            values = null;
            return false;
        }

        // This method extracts the default argument values from the template.
        private RouteValueDictionary GetDefaults(RouteTemplate parsedTemplate)
        {
            var result = new RouteValueDictionary();

            foreach (var parameter in parsedTemplate.Parameters)
            {
                if (parameter.DefaultValue != null)
                {
                    result.Add(parameter.Name, parameter.DefaultValue);
                }
            }

            return result;
        }
    }
}
#endif
