// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Ods.Features.ChangeQueries.ActionResults;
using EdFi.Ods.Features.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace EdFi.Ods.Features.ChangeQueries.SnapshotContext
{
    /// <summary>
    /// Implements an action filter that sets the <see cref="SnapshotContext" /> based on the
    /// "Snapshot-Identifier" header value supplied on the current API request, if applicable.
    /// </summary>
    public class SnapshotContextActionFilter : IAsyncActionFilter
    {
        private const string SnapshotIdentifierHeaderName = "Snapshot-Identifier";
        
        private readonly ISnapshotContextProvider _snapshotContextProvider;

        public SnapshotContextActionFilter(ISnapshotContextProvider snapshotContextProvider)
        {
            _snapshotContextProvider = snapshotContextProvider;
        }
        
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Don't process "snapshot" requests against a snapshot database
            if (context.Controller is SnapshotsController)
            {
                return next();
            }

            if (context.HttpContext.Request.Headers.TryGetValue(SnapshotIdentifierHeaderName, out StringValues values))
            {
                // Ensure attempts to modify the snapshot are prevented
                if (!context.HttpContext.Request.Method.EqualsIgnoreCase(HttpMethod.Get.ToString())
                    && !context.HttpContext.Request.Method.EqualsIgnoreCase(HttpMethod.Options.ToString()))
                {
                    context.Result = new SnapshotsAreReadOnlyResult();
                    return Task.CompletedTask;
                }
                
                _snapshotContextProvider.SetSnapshotContext(
                    new SnapshotContext(values.FirstOrDefault()));
            }

            return next();
        }
    }
}
