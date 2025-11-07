// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Security.Cryptography;
using EdFi.Ods.Common.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EdFi.Ods.Api.Security.Authentication;

public class OpenIddictKeyManager
{
    private readonly OpenIddictSettings _conifg;
    public OpenIddictKeyManager(ApiSettings config) => _conifg = config.Services.OpenIddict;

    public SecurityKey GetPublicKey()
    {
        var key = File.ReadAllBytes(_conifg.PublicKeyPath);
        var publicKeyString = System.Text.Encoding.UTF8.GetString(key);
        var decodedKey = Convert.FromBase64String(publicKeyString);

        var rsa = RSA.Create();
        rsa.ImportRSAPublicKey(key, out _);

        return new RsaSecurityKey(rsa.ExportParameters(true));
    }

    public SecurityKey GetPrivateKey(string path)
    {
        var key = File.ReadAllBytes(_conifg.PrivateKeyPath);
        var rsa = RSA.Create();
        rsa.ImportRSAPrivateKey(key, out _);
        return new RsaSecurityKey(rsa) { CryptoProviderFactory = { CacheSignatureProviders = false } };
    }
}
