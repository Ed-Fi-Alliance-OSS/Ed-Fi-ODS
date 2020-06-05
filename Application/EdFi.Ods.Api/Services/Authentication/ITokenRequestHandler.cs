// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Net.Http;
using System.Web.Http;
using EdFi.Ods.Api.Common.Models.Tokens;

namespace EdFi.Ods.Api.Services.Authentication
{
    public interface ITokenRequestHandler
    {
        bool Handle(HttpRequestMessage httpRequest, TokenRequest tokenRequest, out IHttpActionResult actionResult);
    }
}
