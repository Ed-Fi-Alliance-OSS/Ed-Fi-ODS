// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Configuration;

public class SecuritySettings
{
    public string AccessTokenType { get; set; } = "guid";
    public string SigningKey { get; set; }

    public const string AccessTokenTypeGuid = "guid";
    public const string AccessTokenTypeJwt = "jwt";
    public const string OneRosterScopePrefix = "https://purl.imsglobal.org/spec/or/v1p1/scope/";
}
