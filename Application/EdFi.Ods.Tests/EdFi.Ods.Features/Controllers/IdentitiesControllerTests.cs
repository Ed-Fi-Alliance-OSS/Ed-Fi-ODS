﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Features.Controllers;
using EdFi.Ods.Features.IdentityManagement.Models;
using EdFi.Ods.Tests.EdFi.Ods.Features.Helpers;
using EdFi.TestFixture;
using FakeItEasy;
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
        public class InvalidPropertiesGetByIdRequest : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.InvalidProperties);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings());
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (ObjectResult) await _controller.GetById("ignored");
            }

            [Test]
            public void Should_return_invalid_properties_details()
            {
                var response = (ErrorResponse) _actionResult.Value;
                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status502BadGateway),
                    () => response!.IdentitySystemStatusCode.ShouldBe(Enum.GetName(IdentityStatusCode.InvalidProperties)),
                    () => response!.Message.ShouldBe("Invalid response from identity service: Invalid Id specified."),
                    () => response!.IdentitySystemErrors.Count().ShouldBe(1),
                    () => response!.IdentitySystemErrors.Single().Code.ShouldBe("InvalidId"),
                    () => response!.IdentitySystemErrors.Single().Description.ShouldBe("Invalid Id specified"));
            }
        }

        public class IncompleteGetByIdRequest : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.Incomplete);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings());
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (ObjectResult)await _controller.GetById("ignored");
            }

            [Test]
            public void Should_return_incomplete_details()
            {
                var response = (ErrorResponse)_actionResult.Value;
                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status502BadGateway),
                    () => response!.IdentitySystemStatusCode.ShouldBe(Enum.GetName(IdentityStatusCode.Incomplete)),
                    () => response!.Message.ShouldBe("Invalid response from identity service: The search results are not ready yet."),
                    () => response!.IdentitySystemErrors.Count().ShouldBe(1),
                    () => response!.IdentitySystemErrors.Single().Code.ShouldBe("Incomplete"),
                    () => response!.IdentitySystemErrors.Single().Description.ShouldBe("The search results are not ready yet"));
            }
        }

        public class NotFoundGetByIdRequest : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.NotFound);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings());
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (ObjectResult)await _controller.GetById("ignored");
            }

            [Test]
            public void Should_return_not_found_details()
            {
                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status404NotFound),
                    () => _actionResult.ShouldBeOfType<NotFoundObjectResult>());
            }
        }

        public class SuccessGetByIdRequest : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.Success);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings());
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (ObjectResult)await _controller.GetById("ignored");
            }

            [Test]
            public void Should_return_success_details()
            {
                var response = (IdentityResponse)_actionResult.Value;

                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status200OK),
                    () => response!.UniqueId.ShouldBe("some-id"));
            }
        }

        public class InvalidPropertiesCreateRequest : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.InvalidProperties);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings());
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (ObjectResult)await _controller.Create(new IdentityCreateRequest());
            }

            [Test]
            public void Should_return_invalid_properties_details()
            {
                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status400BadRequest));
            }
        }

        public class IncompleteCreateRequest : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.Incomplete);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings());
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (ObjectResult)await _controller.Create(new IdentityCreateRequest());
            }

            [Test]
            public void Should_return_incomplete_details()
            {
                var response = (ErrorResponse)_actionResult.Value;
                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status502BadGateway),
                    () => response!.IdentitySystemStatusCode.ShouldBe(Enum.GetName(IdentityStatusCode.Incomplete)),
                    () => response!.Message.ShouldBe("Invalid response from identity service: The search results are not ready yet."),
                    () => response!.IdentitySystemErrors.Count().ShouldBe(1),
                    () => response!.IdentitySystemErrors.Single().Code.ShouldBe("Incomplete"),
                    () => response!.IdentitySystemErrors.Single().Description.ShouldBe("The search results are not ready yet"));
            }
        }

        public class NotFoundCreateRequest : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.NotFound);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings());
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (ObjectResult)await _controller.Create(new IdentityCreateRequest());
            }

            [Test]
            public void Should_return_not_found_details()
            {
                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status404NotFound),
                    () => _actionResult.ShouldBeOfType<NotFoundObjectResult>());
            }
        }

        public class SuccessCreateRequest : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private CreatedResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.Success);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings());
                _controller.ControllerContext = BuildFakeControllerContext();

                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (CreatedResult)await _controller.Create(new IdentityCreateRequest());
            }

            [Test]
            public void Should_return_success_details()
            {
                var response = (string)_actionResult.Value;

                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status201Created),
                    () => _actionResult.Location.ShouldBe("http://some-host/some-path-base/some-path/some-id"),
                    () => response!.ShouldBe("some-id"));
            }
        }

        public class SuccessCreateRequestWithReverseProxySettings : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private CreatedResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.Success);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings(useReverseProxyHeaders: true));
                _controller.ControllerContext = BuildFakeControllerContext(useReverseProxyHeaders: true);

                return Task.CompletedTask;
            }
            protected override async Task ActAsync()
            {
                _actionResult = (CreatedResult)await _controller.Create(new IdentityCreateRequest());
            }

            [Test]
            public void Should_return_success_details()
            {
                var response = (string)_actionResult.Value;
                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status201Created),
                    () => _actionResult.Location.ShouldBe("https://some-forwarded-host/some-path-base/some-path/some-id"),
                    () => response!.ShouldBe("some-id"));
            }
        }

        public class InvalidPropertiesFindRequest : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.InvalidProperties);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings());
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (ObjectResult) await _controller.Find(new[] { "ignored" });
            }

            [Test]
            public void Should_return_invalid_properties_details()
            {
                var response = (ErrorResponse)_actionResult.Value;
                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status502BadGateway),
                    () => response!.IdentitySystemStatusCode.ShouldBe(Enum.GetName(IdentityStatusCode.InvalidProperties)),
                    () => response!.Message.ShouldBe("Invalid response from identity service: Invalid Id specified."),
                    () => response!.IdentitySystemErrors.Count().ShouldBe(1),
                    () => response!.IdentitySystemErrors.Single().Code.ShouldBe("InvalidId"),
                    () => response!.IdentitySystemErrors.Single().Description.ShouldBe("Invalid Id specified"));
            }
        }

        public class IncompleteFindRequest : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.Incomplete);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings());
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (ObjectResult)await _controller.Find(new[] { "ignored" });
            }

            [Test]
            public void Should_return_incomplete_details()
            {
                var response = (ErrorResponse)_actionResult.Value;
                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status502BadGateway),
                    () => response!.IdentitySystemStatusCode.ShouldBe(Enum.GetName(IdentityStatusCode.Incomplete)),
                    () => response!.Message.ShouldBe("Invalid response from identity service: The search results are not ready yet."),
                    () => response!.IdentitySystemErrors.Count().ShouldBe(1),
                    () => response!.IdentitySystemErrors.Single().Code.ShouldBe("Incomplete"),
                    () => response!.IdentitySystemErrors.Single().Description.ShouldBe("The search results are not ready yet"));
            }
        }

        public class NotFoundFindRequest : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.NotFound);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings());
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (ObjectResult)await _controller.Find(new [] { "ignored" });
            }

            [Test]
            public void Should_return_not_found_details()
            {
                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status404NotFound),
                    () => _actionResult.ShouldBeOfType<NotFoundObjectResult>());
            }
        }

        public class SuccessFindRequest : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private AcceptedResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.Success);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings());
                _controller.ControllerContext = BuildFakeControllerContext();
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (AcceptedResult)await _controller.Find(new[] { "ignored" });
            }

            [Test]
            public void Should_return_success_details()
            {
                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status202Accepted),
                    () => _actionResult.Location.ShouldBe("http://some-host/some-path-base/results/some-id"));
            }
        }

        public class SuccessFindRequestWithReverseProxySettings : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private AcceptedResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.Success);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings(useReverseProxyHeaders: true));
                _controller.ControllerContext = BuildFakeControllerContext(useReverseProxyHeaders: true);
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (AcceptedResult)await _controller.Find(new [] { "ignored" });
            }

            [Test]
            public void Should_return_success_details()
            {
                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status202Accepted),
                    () => _actionResult.Location.ShouldBe("https://some-forwarded-host/some-path-base/results/some-id"));
            }
        }

        public class InvalidPropertiesSearchRequest : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.InvalidProperties);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings());
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (ObjectResult) await _controller.Search(new IdentitySearchRequest[] { });
            }

            [Test]
            public void Should_return_invalid_properties_details()
            {
                var response = (ErrorResponse)_actionResult.Value;
                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status502BadGateway),
                    () => response!.IdentitySystemStatusCode.ShouldBe(Enum.GetName(IdentityStatusCode.InvalidProperties)),
                    () => response!.Message.ShouldBe("Invalid response from identity service: Invalid Id specified."),
                    () => response!.IdentitySystemErrors.Count().ShouldBe(1),
                    () => response!.IdentitySystemErrors.Single().Code.ShouldBe("InvalidId"),
                    () => response!.IdentitySystemErrors.Single().Description.ShouldBe("Invalid Id specified"));
            }
        }

        public class IncompleteSearchRequest : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.Incomplete);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings());
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (ObjectResult)await _controller.Search(new IdentitySearchRequest[] { });
            }

            [Test]
            public void Should_return_incomplete_details()
            {
                var response = (ErrorResponse)_actionResult.Value;
                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status502BadGateway),
                    () => response!.IdentitySystemStatusCode.ShouldBe(Enum.GetName(IdentityStatusCode.Incomplete)),
                    () => response!.Message.ShouldBe("Invalid response from identity service: The search results are not ready yet."),
                    () => response!.IdentitySystemErrors.Count().ShouldBe(1),
                    () => response!.IdentitySystemErrors.Single().Code.ShouldBe("Incomplete"),
                    () => response!.IdentitySystemErrors.Single().Description.ShouldBe("The search results are not ready yet"));
            }
        }

        public class NotFoundSearchRequest : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.NotFound);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings());
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (ObjectResult)await _controller.Search(new IdentitySearchRequest[] { });
            }

            [Test]
            public void Should_return_not_found_details()
            {
                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status404NotFound),
                    () => _actionResult.ShouldBeOfType<NotFoundObjectResult>());
            }
        }

        public class SuccessSearchRequest : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private AcceptedResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.Success);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings());
                _controller.ControllerContext = BuildFakeControllerContext();
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (AcceptedResult)await _controller.Search(new IdentitySearchRequest[] { });
            }

            [Test]
            public void Should_return_success_details()
            {
                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status202Accepted),
                    () => _actionResult.Location.ShouldBe("http://some-host/some-path-base/results/some-id"));
            }
        }

        public class SuccessSearchRequestWithReverseProxySettings : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private AcceptedResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.Success);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings(useReverseProxyHeaders: true));
                _controller.ControllerContext = BuildFakeControllerContext(useReverseProxyHeaders: true);
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (AcceptedResult)await _controller.Search(new IdentitySearchRequest[] { });
            }

            [Test]
            public void Should_return_success_details()
            {
                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status202Accepted),
                    () => _actionResult.Location.ShouldBe("https://some-forwarded-host/some-path-base/results/some-id"));
            }
        }
        
        public class InvalidPropertiesResultRequest : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.InvalidProperties);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings());
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (ObjectResult) await _controller.Result("ignored");
            }

            [Test]
            public void Should_return_invalid_properties_details()
            {
                var response = (ErrorResponse)_actionResult.Value;
                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status502BadGateway),
                    () => response!.IdentitySystemStatusCode.ShouldBe(Enum.GetName(IdentityStatusCode.InvalidProperties)),
                    () => response!.Message.ShouldBe("Invalid response from identity service: Invalid Id specified."),
                    () => response!.IdentitySystemErrors.Count().ShouldBe(1),
                    () => response!.IdentitySystemErrors.Single().Code.ShouldBe("InvalidId"),
                    () => response!.IdentitySystemErrors.Single().Description.ShouldBe("Invalid Id specified"));
            }
        }

        public class IncompleteResultRequest : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var controllerContext =
                    new ControllerContext
                    {
                        HttpContext = new DefaultHttpContext()
                        {
                            Request =
                            {
                                Scheme = "http",
                                Host = HostString.FromUriComponent("localhost")
                            }
                        }
                    };

                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.Incomplete);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings()) {ControllerContext = controllerContext};
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (ObjectResult)await _controller.Result("ignored");
            }

            [Test]
            public void Should_return_incomplete_details()
            {
                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status200OK));
            }
        }

        public class NotFoundResultRequest : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.NotFound);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings());
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (ObjectResult)await _controller.Result("ignored");
            }

            [Test]
            public void Should_return_not_found_details()
            {
                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status404NotFound),
                    () => _actionResult.ShouldBeOfType<NotFoundObjectResult>());
            }
        }

        public class SuccessResultRequest : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.Success);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings());
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (ObjectResult)await _controller.Result("ignored");
            }

            [Test]
            public void Should_return_success_details()
            {
                var response = (IdentitySearchResponse)_actionResult.Value;

                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status200OK),
                    () => response!.SearchResponses[0].Responses[0].UniqueId.ShouldBe("some-id"));
            }
        }

        public class UnknownResult : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.UnknownStatusCode);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings());
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (ObjectResult)await _controller.Create(new IdentityCreateRequest());
            }

            [Test]
            public void Should_return_success_details()
            {
                var response = (ErrorResponse)_actionResult.Value;

                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status502BadGateway),
                    () => response!.IdentitySystemStatusCode.ShouldBe("Unknown"),
                    () => response!.IdentitySystemErrors.Count().ShouldBe(2),
                    () => response!.Message.ShouldBe("Invalid response from identity service: An unknown error occurred, An second unknown error occurred."));
            }
        }

        public class NullErrorListResult : TestFixtureAsyncBase
        {
            private IdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.NullErrorList);
                _controller = new IdentitiesController(identityService, identityService, BuildAppSettings());
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (ObjectResult)await _controller.Create(new IdentityCreateRequest());
            }

            [Test]
            public void Should_return_success_details()
            {
                var response = (ErrorResponse)_actionResult.Value;

                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status502BadGateway),
                    () => response!.IdentitySystemStatusCode.ShouldBe(Enum.GetName(IdentityStatusCode.Incomplete)),
                    () => response!.IdentitySystemErrors.ShouldBe(null),
                    () => response!.Message.ShouldBe("Invalid response from identity service: ."));
            }
        }

        private static ControllerContext BuildFakeControllerContext(bool useReverseProxyHeaders = false)
        {
            var request = A.Fake<HttpRequest>();
            request.Scheme = "http";
            request.Host = new HostString("some-host", 80);
            request.PathBase = "/some-path-base";
            request.Path = "/some-path";

            if (useReverseProxyHeaders)
            {
                A.CallTo(() => request.Headers).Returns(new HeaderDictionary() {
                    { HeaderConstants.XForwardedProto, "https" },
                    { HeaderConstants.XForwardedHost, "some-forwarded-host"},
                    { HeaderConstants.XForwardedPort, "443"},
                });
            }

            var httpContext = A.Fake<HttpContext>();
            A.CallTo(() => httpContext.Request).Returns(request);

            return new ControllerContext()
            {
                HttpContext = httpContext,
            };
        }

        private static ApiSettings BuildAppSettings(bool useReverseProxyHeaders = false)
        {
            return new ApiSettings()
            {
                UseReverseProxyHeaders = useReverseProxyHeaders
            };
        }
    }
}
