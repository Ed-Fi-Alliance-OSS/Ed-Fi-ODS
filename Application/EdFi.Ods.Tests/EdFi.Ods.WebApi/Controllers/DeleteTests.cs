// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web.Http;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Factories;
using EdFi.Ods.Api.Services.Controllers.Students.EdFi;
using EdFi.Ods.Api.Services.Extensions;
using EdFi.Ods.Common.Extensions;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.WebApi.Controllers
{
    internal class StudentDeleteTests
    {
        [TestFixture]
        public class When_deleting_existing_student : TestBase
        {
            private Guid _id;
            private HttpResponseMessage _responseMessage;

            [OneTimeSetUp]
            public void Setup()
            {
                var container = TestControllerBuilder.GetWindsorContainer();

                var pipelineFactory =
                    new PipelineFactory(container, null, null, null, null, new SingleStepPipelineProviderForTest(typeof(EmptyResourceStep<,,,>)));

                var controller = TestControllerBuilder.GetController<StudentsController>(pipelineFactory);
                _id = Guid.NewGuid();

                _responseMessage = controller.Delete(_id)
                    .GetResultSafely()
                    .ExecuteAsync(new CancellationToken())
                    .GetResultSafely();
            }

            [Test]
            public void Should_return_empty_content()
            {
                _responseMessage.Content.ShouldBeNull();
            }

            [Test]
            public void Should_return_no_content()
            {
                _responseMessage.StatusCode.ShouldBe(HttpStatusCode.NoContent);
            }
        }

        [TestFixture]
        public class When_deleting_student_not_found : TestBase
        {
            private Guid _id;
            private HttpResponseMessage _responseMessage;

            [OneTimeSetUp]
            public void Setup()
            {
                var container = TestControllerBuilder.GetWindsorContainer();

                var pipelineFactory =
                    new PipelineFactory(container, null, null, null, null, new SingleStepPipelineProviderForTest(typeof(NotFoundExceptionStep<,,,>)));

                var controller = TestControllerBuilder.GetController<StudentsController>(pipelineFactory);
                _id = Guid.NewGuid();

                _responseMessage = controller.Delete(_id).GetResultSafely()
                    .ExecuteAsync(new CancellationToken())
                    .GetResultSafely();
            }

            [Test]
            public void Should_return_not_found()
            {
                _responseMessage.StatusCode.ShouldBe(HttpStatusCode.NotFound);
            }
        }

        [TestFixture]
        public class When_deleting_a_student_causes_referencial_exception : TestBase
        {
            private Guid _id;
            private HttpResponseMessage _responseMessage;

            [OneTimeSetUp]
            public void Setup()
            {
                var container = TestControllerBuilder.GetWindsorContainer();

                var pipelineFactory =
                    new PipelineFactory(container, null, null, null, null, new SingleStepPipelineProviderForTest(typeof(DeleteReferentialExceptionStep<,,,>)));
                var controller = TestControllerBuilder.GetController<StudentsController>(pipelineFactory, this._id.ToString("N"));
                _id = Guid.NewGuid();
                _responseMessage = controller.Delete(_id)
                    .GetResultSafely()
                    .ExecuteAsync(new CancellationToken())
                    .GetResultSafely();

            }

            [Test]
            public void Should_return_conflict()
            {
                _responseMessage.StatusCode.ShouldBe(HttpStatusCode.Conflict);
            }

            [Test]
            public void Should_return_message()
            {
                var result = _responseMessage.Content.ReadAsStringAsync()
                                             .GetResultSafely();

                var resource = JsonConvert.DeserializeObject<HttpError>(result);
                resource.Message.ShouldContain("The resource (or a subordinate entity of the resource) cannot be deleted because it is a dependency");
            }
        }

        [TestFixture]
        public class When_deleting_student_unauthorized : TestBase
        {
            [Test]
            public void Should_return_forbidden()
            {
                var id = Guid.NewGuid();
                var container = TestControllerBuilder.GetWindsorContainer();

                var pipelineFactory =
                    new PipelineFactory(container, null, null, null, null, new SingleStepPipelineProviderForTest(typeof(EdFiSecurityExceptionStep<,,,>)));

                var controller = TestControllerBuilder.GetController<StudentsController>(pipelineFactory, id.ToString("N"));

                var responseMessage = controller.Delete(id)
                    .GetResultSafely()
                    .ExecuteAsync(new CancellationToken())
                    .GetResultSafely();

                responseMessage.StatusCode.ShouldBe(HttpStatusCode.Forbidden);
            }
        }

        [TestFixture]
        public class When_deleting_student_throws_unhandled_exception : TestBase
        {
            private Guid _id;
            private HttpResponseMessage _responseMessage;

            [OneTimeSetUp]
            public void Setup()
            {
                _id = Guid.NewGuid();
                var container = TestControllerBuilder.GetWindsorContainer();

                var pipelineFactory =
                    new PipelineFactory(container, null, null, null, null, new SingleStepPipelineProviderForTest(typeof(UnhandledExceptionStep<,,,>)));

                var controller = TestControllerBuilder.GetController<StudentsController>(pipelineFactory, this._id.ToString("N"));
                _responseMessage = controller.Delete(_id)
                    .GetResultSafely()
                    .ExecuteAsync(new CancellationToken())
                    .GetResultSafely();
            }

            [Test]
            public void Should_return_internal_server_error()
            {
                _responseMessage.StatusCode.ShouldBe(HttpStatusCode.InternalServerError);
            }

            [Test]
            public void Should_return_message()
            {
                var result = _responseMessage.Content.ReadAsStringAsync()
                                             .GetResultSafely();

                var resource = JsonConvert.DeserializeObject<HttpError>(result);
                resource.Message.ShouldBe("An unexpected error occurred on the server.");
            }
        }

        [TestFixture]
        public class When_deleting_a_student_that_has_been_modified : TestBase
        {
            private Guid _id;
            private HttpResponseMessage _responseMessage;

            [OneTimeSetUp]
            public void Setup()
            {
                var container = TestControllerBuilder.GetWindsorContainer();

                var pipelineFactory =
                    new PipelineFactory(container, null, null, null, null, new SingleStepPipelineProviderForTest(typeof(ConcurrencyExceptionStep<,,,>)));

                var controller = TestControllerBuilder.GetController<StudentsController>(pipelineFactory, this._id.ToString("N"));
                _id = Guid.NewGuid();
                controller.Request.Headers.IfMatch.Add(new EntityTagHeaderValue(this._id.ToString("N").Quoted()));

                _responseMessage = controller.Delete(this._id)
                    .GetResultSafely()
                    .ExecuteAsync(new CancellationToken())
                    .GetResultSafely();
            }

            [Test]
            public void Should_return_message()
            {
                var result = _responseMessage.Content.ReadAsStringAsync()
                                             .GetResultSafely();

                var resource = JsonConvert.DeserializeObject<HttpError>(result);
                resource.Message.ShouldBe("Resource was modified by another consumer.");
            }

            [Test]
            public void Should_return_precondition_failed()
            {
                _responseMessage.StatusCode.ShouldBe(HttpStatusCode.PreconditionFailed);
            }
        }
    }
}
