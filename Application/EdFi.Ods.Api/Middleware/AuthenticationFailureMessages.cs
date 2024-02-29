// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Middleware;

public class AuthenticationFailureMessages
{
    public const string UnknownAuthorizationHeaderScheme = "Unknown Authorization header scheme.";
    public const string MissingAuthorizationHeaderBearerTokenValue = "Missing Authorization header bearer token value.";
    public const string InvalidAuthorizationHeader = "Invalid Authorization header.";
}
