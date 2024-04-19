// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Net;
using System.Threading.Tasks;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Features.ChangeQueries.ActionResults
{
    /// <summary>
    /// Represents an action result providing a message indicating that the snapshots are
    /// read-only, based on an <see cref="ObjectResult" /> with a status code of
    /// <see cref="HttpStatusCode.MethodNotAllowed" /> and with an "Allow" response header of "GET".
    /// </summary>
    public class SnapshotsAreReadOnlyResult : IActionResult
    {
        private readonly string _correlationId;

        public SnapshotsAreReadOnlyResult(string correlationId)
        {
            _correlationId = correlationId;
        }
        
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var problemDetails = new SnapshotsAreReadOnlyException("scenario101.")
            {
                CorrelationId = _correlationId
            }.AsSerializableModel();

            var objectResult = new ObjectResult(problemDetails)
            {
                StatusCode = problemDetails.Status
            };

            context.HttpContext.Response.Headers.Append("Allow", "GET");

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
