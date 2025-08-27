// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Threading.Tasks;
using EdFi.LoadTools.ApiClient;
using FakeItEasy;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Assert = NUnit.Framework.Legacy.ClassicAssert;

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

        [Test]
        public async Task GetBearerTokenAsync_WhenCalledFirstTime_ShouldCallTokenRetriever()
        {
            // Arrange
            var fakeTokenRetriever = A.Fake<ITokenRetriever>();
            var expectedToken = new BearerToken
            {
                Access_token = "test-access-token",
                Token_type = "Bearer",
                Expires_in = 3600
            };

            A.CallTo(() => fakeTokenRetriever.ObtainNewBearerToken())
                .Returns(Task.FromResult(expectedToken));

            var tokenHandler = new OAuthTokenHandler(fakeTokenRetriever);

            // Act
            var result = await tokenHandler.GetBearerTokenAsync();

            // Assert
            Assert.AreEqual("test-access-token", result);
            A.CallTo(() => fakeTokenRetriever.ObtainNewBearerToken()).MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task GetBearerTokenAsync_WhenCalledMultipleTimesWithValidToken_ShouldUseCachedToken()
        {
            // Arrange
            var fakeTokenRetriever = A.Fake<ITokenRetriever>();
            var expectedToken = new BearerToken
            {
                Access_token = "cached-token",
                Token_type = "Bearer",
                Expires_in = 3600 // 1 hour
            };

            A.CallTo(() => fakeTokenRetriever.ObtainNewBearerToken())
                .Returns(Task.FromResult(expectedToken));

            var tokenHandler = new OAuthTokenHandler(fakeTokenRetriever);

            // Act - First call
            var firstResult = await tokenHandler.GetBearerTokenAsync();
            
            // Act - Second call (should use cached token)
            var secondResult = await tokenHandler.GetBearerTokenAsync();

            // Assert
            Assert.AreEqual("cached-token", firstResult);
            Assert.AreEqual("cached-token", secondResult);
            Assert.AreEqual(firstResult, secondResult);
            
            // Token retriever should only be called once
            A.CallTo(() => fakeTokenRetriever.ObtainNewBearerToken()).MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task GetBearerTokenAsync_WhenTokenIsExpired_ShouldRetrieveNewToken()
        {
            // Arrange
            var fakeTokenRetriever = A.Fake<ITokenRetriever>();
            
            // First token with very short expiration (effectively expired)
            var expiredToken = new BearerToken
            {
                Access_token = "expired-token",
                Token_type = "Bearer",
                Expires_in = 0 // Expired immediately
            };

            var newToken = new BearerToken
            {
                Access_token = "new-token",
                Token_type = "Bearer",
                Expires_in = 3600
            };

            A.CallTo(() => fakeTokenRetriever.ObtainNewBearerToken())
                .ReturnsNextFromSequence(
                    Task.FromResult(expiredToken),
                    Task.FromResult(newToken));

            var tokenHandler = new OAuthTokenHandler(fakeTokenRetriever);

            // Act - First call gets expired token
            var firstResult = await tokenHandler.GetBearerTokenAsync();
            
            // Wait a moment to ensure token is considered expired
            await Task.Delay(100);
            
            // Act - Second call should get new token due to expiration
            var secondResult = await tokenHandler.GetBearerTokenAsync();

            // Assert
            Assert.AreEqual("expired-token", firstResult);
            Assert.AreEqual("new-token", secondResult);
            Assert.AreNotEqual(firstResult, secondResult);
            
            // Token retriever should be called twice
            A.CallTo(() => fakeTokenRetriever.ObtainNewBearerToken()).MustHaveHappenedTwiceExactly();
        }

        [Test]
        public void GetBearerToken_SynchronousCall_ShouldReturnTokenFromAsyncMethod()
        {
            // Arrange
            var fakeTokenRetriever = A.Fake<ITokenRetriever>();
            var expectedToken = new BearerToken
            {
                Access_token = "sync-test-token",
                Token_type = "Bearer",
                Expires_in = 3600
            };

            A.CallTo(() => fakeTokenRetriever.ObtainNewBearerToken())
                .Returns(Task.FromResult(expectedToken));

            var tokenHandler = new OAuthTokenHandler(fakeTokenRetriever);

            // Act
            var result = tokenHandler.GetBearerToken();

            // Assert
            Assert.AreEqual("sync-test-token", result);
            A.CallTo(() => fakeTokenRetriever.ObtainNewBearerToken()).MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task GetBearerTokenAsync_ConcurrentCalls_ShouldOnlyCallTokenRetrieverOnce()
        {
            // Arrange
            var fakeTokenRetriever = A.Fake<ITokenRetriever>();
            var expectedToken = new BearerToken
            {
                Access_token = "concurrent-token",
                Token_type = "Bearer",
                Expires_in = 3600
            };

            // Add a small delay to simulate network call
            A.CallTo(() => fakeTokenRetriever.ObtainNewBearerToken())
                .Returns(Task.Delay(50).ContinueWith(_ => expectedToken));

            var tokenHandler = new OAuthTokenHandler(fakeTokenRetriever);

            // Act - Make multiple concurrent calls
            var task1 = tokenHandler.GetBearerTokenAsync();
            var task2 = tokenHandler.GetBearerTokenAsync();
            var task3 = tokenHandler.GetBearerTokenAsync();

            await Task.WhenAll(task1, task2, task3);

            // Assert
            Assert.AreEqual("concurrent-token", task1.Result);
            Assert.AreEqual("concurrent-token", task2.Result);
            Assert.AreEqual("concurrent-token", task3.Result);
            
            // Despite multiple concurrent calls, token retriever should only be called once
            A.CallTo(() => fakeTokenRetriever.ObtainNewBearerToken()).MustHaveHappenedOnceExactly();
        }
    }
}
