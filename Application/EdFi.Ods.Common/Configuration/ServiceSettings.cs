// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Configuration;

public class ServiceSettings
{
    public RedisConfiguration Redis { get; set; } = new();
    public OpenIddictSettings OpenIddict { get; set; } = new();
}

public class RedisConfiguration
{
    public string Configuration { get; set; }
}

public class OpenIddictSettings
{
    public string Issuer { get; set; }
    public string Audience { get; set; }

    public string PrivateKeyPath { get; set; }
    public string PublicKeyPath { get; set; }
}
