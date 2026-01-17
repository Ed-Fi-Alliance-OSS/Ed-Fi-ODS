// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Configuration;

public class SecuritySettings
{
    // Constants
    public const string AccessTokenTypeGuid = "guid";
    public const string AccessTokenTypeJwt = "jwt";
    public const string OneRosterScopePrefix = "https://purl.imsglobal.org/spec/or/v1p1/scope/";

    // Access token type (jwt or guid)
    public string AccessTokenType { get; set; } = AccessTokenTypeGuid;

    // Begin JWT configuration   
    public JwtSettings Jwt { get; set; }

    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string[] Audiences { get; set; }
        public SigningKeySettings SigningKey { get; set; }
    }

    public class SigningKeySettings
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
    }
}
