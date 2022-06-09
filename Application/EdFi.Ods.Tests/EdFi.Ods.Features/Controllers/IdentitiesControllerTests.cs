// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
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
            private IActionResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService();
                var identityServiceAsync = new TestIdentitiesService();
                _controller = new IdentitiesController(identityService, identityServiceAsync);
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = await _controller.GetById("123456");
            }

            [Test]
            public void Should_return_invalid_details()
            {
                AssertHelper.All(
                    () => _actionResult.ShouldBeOfType<ObjectResult>(),
                    () => ((ObjectResult) _actionResult).StatusCode.ShouldBe(StatusCodes.Status502BadGateway),
                    () => ((ObjectResult) _actionResult).Value.ShouldBe(new { message = "Invalid properties: blah", StatusCode = IdentityStatusCode.Incomplete}));
            }
        }
    }
}
