// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Test.Properties;
using NUnit.Framework;

namespace EdFi.LoadTools.Test
{
    /// <summary>
    ///     These tests are meant to be run manually with a functioning API
    /// </summary>
    [TestFixture]
    public class OAuthTokenHandlerTests
    {
        [Test]
        [Category("Run Manually")]
        public void ShouldSuccessfullyRetrieveBearerToken()
        {
            var sandboxCredentials = SandboxCredentialsHelper.GetMinimalSandboxCredential();

            var config = new TestOAuthConfiguration
                         {
                             Url = Settings.Default.OauthUrl, Key = sandboxCredentials.Key, Secret = sandboxCredentials.Secret
                         };

            Console.WriteLine(config.Url);
            Console.WriteLine($"key:    {config.Key}");
            Console.WriteLine($"secret: {config.Secret}");

            var tokenRetriever = new TokenRetriever(config);
            var tokenHandler = new OAuthTokenHandler(tokenRetriever);

            var token = tokenHandler.GetBearerToken();

            Console.WriteLine($"token:  {token}");

            Assert.IsTrue(!string.IsNullOrEmpty(token));
        }
    }
}
