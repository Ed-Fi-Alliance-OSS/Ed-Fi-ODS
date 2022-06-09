// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Features.Controllers;
using EdFi.Ods.Features.IdentityManagement.Models;
using EdFi.Ods.WebApi.IntegrationTests;
using EdFi.TestFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.Controllers
{
    [TestFixture]
    public class IdentitiesControllerTests
    {
        public class InvalidGetByIdRequest : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService();
                var identityServiceAsync = new TestIdentitiesService();
                _controller = new IdentitiesController(identityService, identityServiceAsync);
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (ObjectResult) await _controller.GetById("invalid");
            }

            [Test]
            public void Should_return_invalid_details()
            {
                var response = (ControllerResponse) _actionResult.Value;
                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status502BadGateway),
                    () => response.Message.ShouldBe("Invalid response from identity service: Invalid Properties: ErrorCode: InvalidId, ErrorDescription: Invalid Id specified"),
                    () => response.StatusCode.ShouldBe(IdentityStatusCode.InvalidProperties));
            }
        }
    }
}
