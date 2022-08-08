// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Common.Configuration;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security.Claims;
using log4net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EdFi.Ods.Api.Filters;

/// <summary>
/// An action filter that inspects the action descriptor's AttributeRouteInfo to locate
/// the <see cref="Resource" /> associated with the current data management API request.
/// </summary>
public class DataManagementRequestContextFilter : IActionFilter
{
    private readonly IDataManagementRequestContextProvider _contextProvider;
    private readonly ApiSettings _apiSettings;

    private readonly string[] _knownSchemas;

    private readonly ILog _logger = LogManager.GetLogger(typeof(DataManagementRequestContextFilter));
    private readonly IResourceModelProvider _resourceModelProvider;

    public DataManagementRequestContextFilter(
        IResourceModelProvider resourceModelProvider,
        IDataManagementRequestContextProvider contextProvider,
        ApiSettings apiSettings)
    {
        _resourceModelProvider = resourceModelProvider;

        _knownSchemas = _resourceModelProvider.GetResourceModel()
            .SchemaNameMapProvider.GetSchemaNameMaps()
            .Select(m => m.UriSegment)
            .ToArray();

        _contextProvider = contextProvider;
        _apiSettings = apiSettings;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var attributeRouteInfo = context.ActionDescriptor.AttributeRouteInfo;

        if (attributeRouteInfo != null)
        {
            string template = attributeRouteInfo.Template;
            string templatePrefix = GetTemplatePrefix();

            // e.g. data/v3/ed-fi/gradebookEntries

            // Is this a data management route?
            if (template?.StartsWith(templatePrefix) ?? false)
            {
                var parts = template.Substring(templatePrefix.Length).Split('/');

                string schema, resourceCollection;
                
                // If the schema segment is a templated route value...
                if (parts[0] == "{schema}")
                {
                    if (!context.RouteData.Values.TryGetValue("schema", out object schemaAsObject)
                        || !context.RouteData.Values.TryGetValue("resource", out object resourceAsObject))
                    {
                        return;
                    }

                    schema = (string) schemaAsObject;
                    resourceCollection = (string) resourceAsObject;
                }
                else
                {
                    // If this is NOT a known schema...
                    if (!_knownSchemas.Contains(parts[0]))
                    {
                        return;
                    }

                    schema = parts[0];
                    resourceCollection = parts[1];
                }

                // Find and capture the associated resource to context
                try
                {
                    var resource = _resourceModelProvider.GetResourceModel()
                        .GetResourceByApiCollectionName(schema, resourceCollection);

                    _contextProvider.SetResource(resource);
                }
                catch (Exception)
                {
                    _logger.Debug(
                        $"Unable to find resource based on route template value '{template.Substring(RouteConstants.DataManagementRoutePrefix.Length + 1)}'...");
                }
            }
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }

    private string GetTemplatePrefix()
    {
        string template = $"{RouteConstants.DataManagementRoutePrefix}/";

        if (_apiSettings.GetApiMode() == ApiMode.YearSpecific)
        {
            template += RouteConstants.SchoolYearFromRoute;
        }

        if (_apiSettings.GetApiMode() == ApiMode.InstanceYearSpecific)
        {
            template += RouteConstants.InstanceIdFromRoute;
            template += RouteConstants.SchoolYearFromRoute;
        }

        return template;
    }
}
