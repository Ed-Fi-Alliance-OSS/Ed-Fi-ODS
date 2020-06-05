// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Net;
using System.Net.Http;
using System.Threading;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Factories;
using EdFi.Ods.Api.Common.Models.Queries;
using EdFi.Ods.Api.Common.Models.Resources.Student.EdFi;
using EdFi.Ods.Api.Services.Controllers.Students.EdFi;
using EdFi.Ods.Common.Extensions;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.WebApi.Controllers
{
    public class StudentGetManyTests
    {
        [TestFixture]
        public class When_getting_students : TestBase
        {
            private HttpResponseMessage _responseMessage;

            [OneTimeSetUp]
            public void Setup()
            {
                var container = TestControllerBuilder.GetWindsorContainer();

                var pipelineFactory =
                    new PipelineFactory(
                        container, null, new SingleStepPipelineProviderForTest(typeof(SimpleGetManyResourceCreationStep<,,,>)),
                        null, null, null);

                var controller = TestControllerBuilder.GetController<StudentsController>(pipelineFactory);

                _responseMessage = controller.GetAll(new UrlQueryParametersRequest())
                    .GetResultSafely()
                    .ExecuteAsync(new CancellationToken())
                    .GetResultSafely();
            }

            [Test]
            public void Should_return_student()
            {
                _responseMessage.StatusCode.ShouldBe(HttpStatusCode.OK);

                var result = _responseMessage.Content.ReadAsStringAsync()
                    .Result;

                var students = DefaultTestJsonSerializer.DeserializeObject<Student[]>(result);
                students.Length.ShouldBe(25);
            }
        }

        [TestFixture]
        public class When_getting_students_with_upper_limit : TestBase
        {
            private HttpResponseMessage _responseMessage;

            [OneTimeSetUp]
            public void Setup()
            {
                var container = TestControllerBuilder.GetWindsorContainer();

                var pipelineFactory =
                    new PipelineFactory(
                        container, null, new SingleStepPipelineProviderForTest(typeof(SimpleGetManyResourceCreationStep<,,,>)),
                        null, null, null);

                var controller = TestControllerBuilder.GetController<StudentsController>(pipelineFactory);

                _responseMessage = controller
                    .GetAll(new UrlQueryParametersRequest {Limit = 10})
                    .GetResultSafely()
                    .ExecuteAsync(new CancellationToken())
                    .GetResultSafely();
            }

            [Test]
            public void Should_return_student()
            {
                _responseMessage.StatusCode.ShouldBe(HttpStatusCode.OK);

                var result = _responseMessage.Content.ReadAsStringAsync()
                    .Result;

                var students = DefaultTestJsonSerializer.DeserializeObject<Student[]>(result);
                students.Length.ShouldBe(10);
            }
        }

        [TestFixture]
        public class When_getting_students_with_upper_limit_past_max : TestBase
        {
            private HttpResponseMessage _responseMessage;

            [OneTimeSetUp]
            public void Setup()
            {
                var container = TestControllerBuilder.GetWindsorContainer();

                var pipelineFactory =
                    new PipelineFactory(
                        container, null, new SingleStepPipelineProviderForTest(typeof(SimpleGetManyResourceCreationStep<,,,>)),
                        null, null, null);

                var controller = TestControllerBuilder.GetController<StudentsController>(pipelineFactory);

                _responseMessage = controller
                    .GetAll(new UrlQueryParametersRequest {Limit = 1000})
                    .GetResultSafely()
                    .ExecuteAsync(new CancellationToken())
                    .GetResultSafely();
            }

            [Test]
            public void Should_return_student()
            {
                _responseMessage.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
            }
        }

        [TestFixture]
        public class When_getting_students_unauthorized : TestBase
        {
            private HttpResponseMessage _responseMessage;

            [OneTimeSetUp]
            public void Setup()
            {
                var container = TestControllerBuilder.GetWindsorContainer();

                var pipelineFactory =
                    new PipelineFactory(
                        container, null, new SingleStepPipelineProviderForTest(typeof(EdFiSecurityExceptionStep<,,,>)), null,
                        null, null);

                var controller = TestControllerBuilder.GetController<StudentsController>(pipelineFactory);

                _responseMessage = controller
                    .GetAll(new UrlQueryParametersRequest())
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
        public class When_unhandled_exception_getting_students : TestBase
        {
            private HttpResponseMessage _responseMessage;

            [OneTimeSetUp]
            public void Setup()
            {
                var container = TestControllerBuilder.GetWindsorContainer();

                var pipelineFactory =
                    new PipelineFactory(
                        container, null, new SingleStepPipelineProviderForTest(typeof(UnhandledExceptionStep<,,,>)), null, null,
                        null);

                var controller = TestControllerBuilder.GetController<StudentsController>(pipelineFactory);

                _responseMessage = controller
                    .GetAll(new UrlQueryParametersRequest())
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
