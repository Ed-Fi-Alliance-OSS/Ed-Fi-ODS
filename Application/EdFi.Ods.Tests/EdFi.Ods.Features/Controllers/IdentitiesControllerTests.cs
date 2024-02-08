// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Threading.Tasks;
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

using TestIdentitiesController = EdFi.Ods.Features.Controllers.IdentitiesController<EdFi.Ods.Features.IdentityManagement.Models.IdentityCreateRequest, EdFi.Ods.Features.IdentityManagement.Models.IdentitySearchRequest, EdFi.Ods.Features.IdentityManagement.Models.IdentitySearchResponse<EdFi.Ods.Features.IdentityManagement.Models.IdentityResponse>, EdFi.Ods.Features.IdentityManagement.Models.IdentityResponse>;
using TestIdentityService = EdFi.Ods.Features.IdentityManagement.Models.IIdentityService<EdFi.Ods.Features.IdentityManagement.Models.IdentityCreateRequest, EdFi.Ods.Features.IdentityManagement.Models.IdentitySearchRequest, EdFi.Ods.Features.IdentityManagement.Models.IdentitySearchResponse<EdFi.Ods.Features.IdentityManagement.Models.IdentityResponse>, EdFi.Ods.Features.IdentityManagement.Models.IdentityResponse>; 
using TestIdentityServiceAsync = EdFi.Ods.Features.IdentityManagement.Models.IIdentityServiceAsync<EdFi.Ods.Features.IdentityManagement.Models.IdentitySearchRequest, EdFi.Ods.Features.IdentityManagement.Models.IdentitySearchResponse<EdFi.Ods.Features.IdentityManagement.Models.IdentityResponse>, EdFi.Ods.Features.IdentityManagement.Models.IdentityResponse>; 
using TestIdentityResponseStatus = EdFi.Ods.Features.IdentityManagement.Models.IdentityResponseStatus<EdFi.Ods.Features.IdentityManagement.Models.IdentitySearchResponse<EdFi.Ods.Features.IdentityManagement.Models.IdentityResponse>>;
using TestIdentitySearchResponse = EdFi.Ods.Features.IdentityManagement.Models.IdentitySearchResponse<EdFi.Ods.Features.IdentityManagement.Models.IdentityResponse>;
using TestIdentitySearchResponses = EdFi.Ods.Features.IdentityManagement.Models.IdentitySearchResponses<EdFi.Ods.Features.IdentityManagement.Models.IdentityResponse>;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.Controllers
{
    [TestFixture]
    public class IdentitiesControllerTests
    {
        public class InvalidPropertiesGetByIdRequest : TestFixtureAsyncBase
        {
            private TestIdentitiesController _controller;

            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.InvalidProperties);
                _controller = new (identityService, identityService);
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
            private TestIdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.Incomplete);
                _controller = new TestIdentitiesController(identityService, identityService);
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
            private TestIdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.NotFound);
                _controller = new TestIdentitiesController(identityService, identityService);
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
            private TestIdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var urlHelper = A.Fake<IUrlHelper>();
                A.CallTo(() => urlHelper.Link(A<string>.Ignored, A<object>.Ignored)).Returns("https://localhost");

                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.Success);
                _controller = new TestIdentitiesController(identityService, identityService) { Url = urlHelper };
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
                    () => response!.UniqueId.ShouldBe("ignored"));
            }
        }

        public class InvalidPropertiesCreateRequest : TestFixtureAsyncBase
        {
            private TestIdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.InvalidProperties);
                _controller = new TestIdentitiesController(identityService, identityService);
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
            private TestIdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.Incomplete);
                _controller = new TestIdentitiesController(identityService, identityService);
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
            private TestIdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.NotFound);
                _controller = new TestIdentitiesController(identityService, identityService);
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
            private TestIdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var urlHelper = A.Fake<IUrlHelper>();
                A.CallTo(() => urlHelper.Link(A<string>.Ignored, A<object>.Ignored)).Returns("https://localhost");

                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.Success);
                _controller = new TestIdentitiesController(identityService, identityService) { Url = urlHelper };
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (ObjectResult)await _controller.Create(new IdentityCreateRequest());
            }

            [Test]
            public void Should_return_success_details()
            {
                var response = (string)_actionResult.Value;

                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status201Created),
                    () => response!.ShouldBe("ignored"));
            }
        }

        public class InvalidPropertiesFindRequest : TestFixtureAsyncBase
        {
            private TestIdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.InvalidProperties);
                _controller = new TestIdentitiesController(identityService, identityService);
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
            private TestIdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.Incomplete);
                _controller = new TestIdentitiesController(identityService, identityService);
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
            private TestIdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.NotFound);
                _controller = new TestIdentitiesController(identityService, identityService);
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
            private TestIdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var urlHelper = A.Fake<IUrlHelper>();
                A.CallTo(() => urlHelper.Link(A<string>.Ignored, A<object>.Ignored)).Returns("https://localhost");

                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.Success);
                _controller = new TestIdentitiesController(identityService, identityService) {Url = urlHelper};
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (ObjectResult)await _controller.Find(new []{ "ignored" });
            }

            [Test]
            public void Should_return_success_details()
            {
                _actionResult.StatusCode.ShouldBe(StatusCodes.Status202Accepted);
            }
        }

        public class InvalidPropertiesSearchRequest : TestFixtureAsyncBase
        {
            private TestIdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.InvalidProperties);
                _controller = new TestIdentitiesController(identityService, identityService);
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
            private TestIdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.Incomplete);
                _controller = new TestIdentitiesController(identityService, identityService);
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
            private TestIdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.NotFound);
                _controller = new TestIdentitiesController(identityService, identityService);
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
            private TestIdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var urlHelper = A.Fake<IUrlHelper>();
                A.CallTo(() => urlHelper.Link(A<string>.Ignored, A<object>.Ignored)).Returns("https://localhost");

                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.Success);
                _controller = new TestIdentitiesController(identityService, identityService) { Url = urlHelper };
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (ObjectResult)await _controller.Search(new IdentitySearchRequest[] { });
            }

            [Test]
            public void Should_return_success_details()
            {
                _actionResult.StatusCode.ShouldBe(StatusCodes.Status202Accepted);
            }
        }
        
        public class InvalidPropertiesResultRequest : TestFixtureAsyncBase
        {
            private TestIdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.InvalidProperties);
                _controller = new TestIdentitiesController(identityService, identityService);
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
            private TestIdentitiesController _controller;
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
                _controller = new TestIdentitiesController(identityService, identityService) {ControllerContext = controllerContext};
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
            private TestIdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.NotFound);
                _controller = new TestIdentitiesController(identityService, identityService);
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
            private TestIdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var urlHelper = A.Fake<IUrlHelper>();
                A.CallTo(() => urlHelper.Link(A<string>.Ignored, A<object>.Ignored)).Returns("https://localhost");

                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.Success);
                _controller = new TestIdentitiesController(identityService, identityService) { Url = urlHelper };
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _actionResult = (ObjectResult)await _controller.Result("ignored");
            }

            [Test]
            public void Should_return_success_details()
            {
                var response = (TestIdentitySearchResponse)_actionResult.Value;

                AssertHelper.All(
                    () => _actionResult.StatusCode.ShouldBe(StatusCodes.Status200OK),
                    () => response!.SearchResponses[0].Responses[0].UniqueId.ShouldBe("ignored"));
            }
        }

        public class UnknownResult : TestFixtureAsyncBase
        {
            private TestIdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.UnknownStatusCode);
                _controller = new TestIdentitiesController(identityService, identityService);
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
            private TestIdentitiesController _controller;
            private ObjectResult _actionResult;

            protected override Task ArrangeAsync()
            {
                var identityService = new TestIdentitiesService(TestIdentitiesService.ResponseBehaviour.NullErrorList);
                _controller = new TestIdentitiesController(identityService, identityService);
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
    }
}
