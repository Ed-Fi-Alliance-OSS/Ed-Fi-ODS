// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using EdFi.LoadTools.ApiClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;

namespace EdFi.LoadTools.Test
{
    /// <summary>
    ///     These tests are meant to be RunManually with a functioning API
    /// </summary>
    [TestFixture]
    public class OAuthTokenHandlerTests
    {
        private IConfigurationRoot _configuration;

        [SetUp]
        public void Setup()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }

        [Test]
        [Category("RunManually")]
        public void ShouldSuccessfullyRetrieveBearerToken()
        {
            var config = new TestOAuthConfiguration
            {
                Url = _configuration["OdsApi:OAuthUrl"],
                Key = _configuration["OdsApi:Key"],
                Secret = _configuration["OdsApi:Secret"]
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
