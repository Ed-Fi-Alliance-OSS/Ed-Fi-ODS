// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace EdFi.Ods.Api.Attributes
{
    /// <summary>
    /// The original implementation of profiles does implements a new controller and is
    /// instantiated by using a custom route controller. The custom route controller was removed in net core, and to have
    /// the same behavior the action constraint is used instead.
    /// </summary>
    public class ProfileContentTypeAttribute : Attribute, IActionConstraint
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(ProfileContentTypeAttribute));

        public int Order { get; set; } = 0;

        public string MediaTypeName { get; }

        public ProfileContentTypeAttribute(string mediaTypeName)
        {
            MediaTypeName = mediaTypeName;
        }

        public bool Accept(ActionConstraintContext context)
        {
            var requestHeaders = context.RouteContext.HttpContext.Request.GetTypedHeaders();

            // Route to the controller for get requests
            bool isReadable = requestHeaders.Accept != null
                              && requestHeaders.Accept
                                  .Where(x => x.MediaType.HasValue)
                                  .Select(x => x.MediaType.Value)
                                  .Any(x => x.Contains(MediaTypeName, StringComparison.InvariantCultureIgnoreCase))
                              && context.RouteContext.HttpContext.Request.Method == HttpMethods.Get;

            // Ideally we want to use the consumes attribute, however, this does not work in this use case because we do not
            // augment the original controller. Instead we will just route to the controller for put and post requests.
            bool isWritable = requestHeaders.ContentType?.MediaType != null
                              && requestHeaders.ContentType.MediaType.HasValue
                              && requestHeaders.ContentType.MediaType.Value
                                  .Contains(MediaTypeName, StringComparison.InvariantCultureIgnoreCase)
                              && (context.RouteContext.HttpContext.Request.Method == HttpMethods.Post
                                  || context.RouteContext.HttpContext.Request.Method == HttpMethods.Put);

            if (isReadable || isWritable)
            {
                _logger.Debug($"Profile is being applied to request {context.RouteContext.HttpContext.Request.GetDisplayUrl()}");
            }

            return isReadable || isWritable;
        }
    }
}
