// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Factories;
using EdFi.Ods.Api.Common.Models.Resources.Student.EdFi;
using EdFi.Ods.Api.Services.Controllers.Students.EdFi;
using EdFi.Ods.Common.Extensions;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.WebApi.Controllers
{
    public class StudentGetByIdTests
    {
        [TestFixture]
        public class When_getting_student_by_id : TestBase
        {
            private Guid _id;
            private HttpResponseMessage _responseMessage;

            [OneTimeSetUp]
            public void Setup()
            {
                var container = TestControllerBuilder.GetWindsorContainer();

                var pipelineFactory =
                    new PipelineFactory(container, new SingleStepPipelineProviderForTest(typeof(SimpleResourceCreationStep<,,,>)), null, null, null, null);

                var controller = TestControllerBuilder.GetController<StudentsController>(pipelineFactory);
                _id = Guid.NewGuid();

                _responseMessage = controller.Get(_id)
                    .GetResultSafely()
                    .ExecuteAsync(new CancellationToken())
                    .GetResultSafely();
            }

            [Test]
            public void Should_return_student()
            {
                _responseMessage.StatusCode.ShouldBe(HttpStatusCode.OK);

                var result = _responseMessage.Content.ReadAsStringAsync()
                                             .GetResultSafely();

                var resource = DefaultTestJsonSerializer.DeserializeObject<Student>(result);
                resource.Id.ShouldBe(_id);
            }
        }

        [TestFixture]
        public class When_getting_student_by_id_not_found : TestBase
        {
            private Guid _id;
            private HttpResponseMessage _responseMessage;

            [OneTimeSetUp]
            public void Setup()
            {
                var container = TestControllerBuilder.GetWindsorContainer();

                var pipelineFactory =
                    new PipelineFactory(container, new SingleStepPipelineProviderForTest(typeof (NotFoundExceptionStep<,,,>)), null, null, null, null);

                var controller = TestControllerBuilder.GetController<StudentsController>(pipelineFactory);
                _id = Guid.NewGuid();

                _responseMessage = controller.Get(_id)
                    .GetResultSafely()
                    .ExecuteAsync(new CancellationToken())
                    .GetResultSafely();
            }

            [Test]
            public void Should_contain_error_message_in_content()
            {
                var result = _responseMessage.Content.ReadAsStringAsync()
                                             .Result;

                var resource = JsonConvert.DeserializeObject<HttpError>(result);
                resource.Message.ShouldBe("Exception for testing");
            }

            [Test]
            public void Should_return_not_found()
            {
                _responseMessage.StatusCode.ShouldBe(HttpStatusCode.NotFound);
            }
        }

        [TestFixture]
        public class When_getting_student_by_id_not_modified : TestBase
        {
            private Guid _id;
            private HttpResponseMessage _responseMessage;

            [OneTimeSetUp]
            public void Setup()
            {
                var container = TestControllerBuilder.GetWindsorContainer();

                var pipelineFactory =
                    new PipelineFactory(container, new SingleStepPipelineProviderForTest(typeof(NotModifiedExceptionStep<,,,>)), null, null, null, null);

                var controller = TestControllerBuilder.GetController<StudentsController>(pipelineFactory);
                _id = Guid.NewGuid();

                _responseMessage = controller.Get(_id)
                    .GetResultSafely()
                    .ExecuteAsync(new CancellationToken())
                    .GetResultSafely();
            }

            [Test]
            public void Should_return_not_modified()
            {
                _responseMessage.StatusCode.ShouldBe(HttpStatusCode.NotModified);
            }
        }

        [TestFixture]
        public class When_getting_student_by_id_unauthorized : TestBase
        {
            private Guid _id;
            private HttpResponseMessage _responseMessage;

            [OneTimeSetUp]
            public void Setup()
            {
                var container = TestControllerBuilder.GetWindsorContainer();

                var pipelineFactory =
                    new PipelineFactory(container, new SingleStepPipelineProviderForTest(typeof(EdFiSecurityExceptionStep<,,,>)), null, null, null, null);

                var controller = TestControllerBuilder.GetController<StudentsController>(pipelineFactory);
                _id = Guid.NewGuid();

                _responseMessage = controller.Get(_id)
                    .GetResultSafely()
                    .ExecuteAsync(new CancellationToken())
                    .GetResultSafely();
            }

            [Test]
            public void Should_return_forbidden()
            {
                _responseMessage.StatusCode.ShouldBe(HttpStatusCode.Forbidden);
            }
        }

        [TestFixture]
        public class When_unhandled_exception_getting_student_by_id : TestBase
        {
            private Guid _id;
            private HttpResponseMessage _responseMessage;

            [OneTimeSetUp]
            public void Setup()
            {
                var container = TestControllerBuilder.GetWindsorContainer();

                var pipelineFactory =
                    new PipelineFactory(container, new SingleStepPipelineProviderForTest(typeof(UnhandledExceptionStep<,,,>)), null, null, null, null);

                var controller = TestControllerBuilder.GetController<StudentsController>(pipelineFactory);
                _id = Guid.NewGuid();

                _responseMessage = controller.Get(_id)
                    .GetResultSafely()
                    .ExecuteAsync(new CancellationToken())
                    .GetResultSafely();
            }

            [Test]
            public void Should_return_internal_server_error()
            {
                _responseMessage.StatusCode.ShouldBe(HttpStatusCode.InternalServerError);
            }
        }
    }
}
