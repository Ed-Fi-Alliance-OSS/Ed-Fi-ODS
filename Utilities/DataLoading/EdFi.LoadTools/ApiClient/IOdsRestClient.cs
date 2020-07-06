// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Net.Http;
using System.Threading.Tasks;

namespace EdFi.LoadTools.ApiClient
{
    public interface IOdsRestClient
    {
        Task<HttpResponseMessage> GetAll(string elementName, int offset = 0);

        Task<HttpResponseMessage> GetResourceByExample(string json, string elementName);

        Task<HttpResponseMessage> PostResource(string json, string elementName,
            string elementSchemaName = "", bool refreshToken = false);
    }
}
