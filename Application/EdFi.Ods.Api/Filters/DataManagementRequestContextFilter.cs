// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Conventions;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security.Claims;
using log4net;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace EdFi.Ods.Api.Filters;

/// <summary>
/// A resource filter that inspects the action descriptor's AttributeRouteInfo to locate
/// the <see cref="Resource" /> associated with the current data management API request.
/// </summary>
public class DataManagementRequestContextFilter : IAsyncResourceFilter
{
    private static readonly char[] _pathDelimiters = { '/' };
    private readonly IContextProvider<DataManagementResourceContext> _contextProvider;

    private readonly Lazy<string> _dataManagementTemplatePrefix;
    private readonly Lazy<string[]> _knownSchemaUriSegments;

    private readonly ILog _logger = LogManager.GetLogger(typeof(DataManagementRequestContextFilter));
    private readonly IResourceModelProvider _resourceModelProvider;
    private readonly IRouteRootTemplateProvider _routeRootTemplateProvider;

    public DataManagementRequestContextFilter(
        IResourceModelProvider resourceModelProvider,
        IContextProvider<DataManagementResourceContext> contextProvider,
        IRouteRootTemplateProvider routeRootTemplateProvider)
    {
        _resourceModelProvider = resourceModelProvider;
        _contextProvider = contextProvider;
        _routeRootTemplateProvider = routeRootTemplateProvider;

        _knownSchemaUriSegments = new Lazy<string[]>(
            () => _resourceModelProvider.GetResourceModel()
                .SchemaNameMapProvider.GetSchemaNameMaps()
                .Select(m => m.UriSegment)
                .ToArray());

        _dataManagementTemplatePrefix = new Lazy<string>(
            () =>
            {
                string routeRootTemplate = _routeRootTemplateProvider.GetRouteRootTemplate(RouteContextType.Ods);

                // Normalize the double braces used by ASP.NET for inline regex constraints
                if (routeRootTemplate?.Contains(":regex") ?? false)
                {
                    if (routeRootTemplate.Contains("[["))
                    {
                        routeRootTemplate = routeRootTemplate.Replace("[[", "[");
                    }

                    if (routeRootTemplate.Contains("]]"))
                    {
                        routeRootTemplate = routeRootTemplate.Replace("]]", "]");
                    }
                }

                return $"{routeRootTemplate}{RouteConstants.DataManagementRoutePrefix}/";
            });
    }

    public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
    {
        var attributeRouteInfo = context.ActionDescriptor.AttributeRouteInfo;

        if (attributeRouteInfo != null)
        {
            // Is this a data management route?
            if (attributeRouteInfo.Template?.StartsWith(_dataManagementTemplatePrefix.Value) ?? false)
            {
                // e.g. data/v3/ed-fi/courses
                string template = attributeRouteInfo.Template;

                var templateSegment = new StringSegment(template);

                var parts = templateSegment.Subsegment(
                        template.IndexOf(_dataManagementTemplatePrefix.Value) + _dataManagementTemplatePrefix.Value.Length)
                    .Split(_pathDelimiters);

                using var partsEnumerator = parts.GetEnumerator();
                partsEnumerator.MoveNext();

                string schema, resourceCollection;

                // If the schema segment is a templated route value...
                if (partsEnumerator.Current == "{schema}")
                {
                    if (!context.RouteData.Values.TryGetValue("schema", out object schemaAsObject)
                        || !context.RouteData.Values.TryGetValue("resource", out object resourceAsObject))
                    {
                        await next();

                        return;
                    }

                    schema = (string) schemaAsObject;
                    resourceCollection = (string) resourceAsObject;
                }
                else
                {
                    // If this is NOT a known schema URI segment...
                    if (!_knownSchemaUriSegments.Value.Contains(partsEnumerator.Current))
                    {
                        await next();

                        return;
                    }

                    schema = partsEnumerator.Current.Value;

                    partsEnumerator.MoveNext();
                    resourceCollection = partsEnumerator.Current.Value;
                }

                // Find and capture the associated resource to context
                try
                {
                    var resource = _resourceModelProvider.GetResourceModel()
                        .GetResourceByApiCollectionName(schema, resourceCollection);

                    _contextProvider.Set(new DataManagementResourceContext(resource, context.HttpContext.Request.Method));
                }
                catch (Exception)
                {
                    _logger.Debug(
                        $"Unable to find resource based on route template value '{template.Substring(RouteConstants.DataManagementRoutePrefix.Length + 1)}'...");
                }
            }
        }

        await next();
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}
