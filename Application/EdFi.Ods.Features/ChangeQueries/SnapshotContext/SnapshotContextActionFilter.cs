// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Features.ChangeQueries.ActionResults;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace EdFi.Ods.Features.ChangeQueries.SnapshotContext
{
    /// <summary>
    /// Implements an action filter that sets the <see cref="SnapshotUsage" /> based on the
    /// "Use-Snapshot" header value supplied on the current API request.
    /// </summary>
    public class SnapshotContextActionFilter : IAsyncActionFilter
    {
        private const string UseSnapshotHeaderName = "Use-Snapshot";

        private readonly IContextProvider<SnapshotUsage> _snapshotContextProvider;

        public SnapshotContextActionFilter(IContextProvider<SnapshotUsage> snapshotContextProvider)
        {
            _snapshotContextProvider = snapshotContextProvider;
        }

        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.Request.Headers.TryGetValue(UseSnapshotHeaderName, out StringValues values))
            {
                // Ensure attempts to modify the snapshot are prevented
                if (!context.HttpContext.Request.Method.EqualsIgnoreCase(HttpMethod.Get.ToString())
                    && !context.HttpContext.Request.Method.EqualsIgnoreCase(HttpMethod.Options.ToString()))
                {
                    context.Result = new SnapshotsAreReadOnlyResult();
                    return Task.CompletedTask;
                }

                var snapshotContext = Enum.Parse<SnapshotUsage>(values.FirstOrDefault());
                _snapshotContextProvider.Set(snapshotContext);
            }

            return next();
        }
    }
}
