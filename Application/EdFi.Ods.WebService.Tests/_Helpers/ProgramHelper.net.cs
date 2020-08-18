// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
using System;
using System.Globalization;
using System.Net.Http;
using System.Text;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.WebService.Tests.Owin;

namespace EdFi.Ods.WebService.Tests._Helpers
{
    internal class ProgramHelper
    {
        internal static HttpResponseMessage CreateProgram(HttpClient client, int leaId, string name = null)
        {
            name = name ?? DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture);

            var postBody = new StringContent(ResourceHelper.CreateProgram(leaId, name), Encoding.UTF8, "application/json");

            var createResponse = client.PostAsync(OwinUriHelper.BuildOdsUri("programs"), postBody).GetResultSafely();

            return createResponse;
        }
    }
}
#endif