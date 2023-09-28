// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Net;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Logging;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.ExceptionHandling
{
    [TestFixture]
    public class RESTErrorProviderTests
    {
        [Test]
        public void GetRestErrorFromException_ShouldUseTranslator_WhenExceptionIsTranslatable()
        {
            // Arrange
            var translators = new List<IExceptionTranslator>
            {
                new FakeExceptionTranslator(
                    true,
                    new RESTError
                    {
                        Code = 400,
                        Type = "Bad Request",
                        Message = "Invalid request"
                    })
            };

            var logContextAccessor = A.Fake<ILogContextAccessor>();
            A.CallTo(() => logContextAccessor.GetValue(CorrelationConstants.LogContextKey)).Returns("12345");

            var exception = new Exception("Test exception");
            var restErrorProvider = new RESTErrorProvider(translators, logContextAccessor);

            // Act
            var restError = restErrorProvider.GetRestErrorFromException(exception);

            // Assert
            restError.Code.ShouldBe(400);
            restError.Type.ShouldBe("Bad Request");
            restError.Message.ShouldBe("Invalid request");
            restError.CorrelationId.ShouldBe("12345");
        }

        [Test]
        public void GetRestErrorFromException_ShouldUseDefaultError_WhenExceptionIsNotTranslatable()
        {
            // Arrange
            var translators = new List<IExceptionTranslator> { new FakeExceptionTranslator(false, null) };

            var logContextAccessor = A.Fake<ILogContextAccessor>();
            A.CallTo(() => logContextAccessor.GetValue(CorrelationConstants.LogContextKey)).Returns("54321");

            var exception = new Exception("Test exception");
            var restErrorProvider = new RESTErrorProvider(translators, logContextAccessor);

            // Act
            var restError = restErrorProvider.GetRestErrorFromException(exception);

            // Assert
            restError.Code.ShouldBe((int)HttpStatusCode.InternalServerError);
            restError.Type.ShouldBe("Internal Server Error");
            restError.Message.ShouldBe("An unexpected error occurred on the server.");
            restError.CorrelationId.ShouldBe("54321");
        }

        [Test]
        public void GetRestErrorFromException_ShouldUseDefaultErrorWithNoCorrelationId_WhenExceptionIsNotTranslatableAndNoCorrelationHasBeenSet()
        {
            // Arrange
            var translators = new List<IExceptionTranslator> { new FakeExceptionTranslator(false, null) };

            var logContextAccessor = A.Fake<ILogContextAccessor>();
            A.CallTo(() => logContextAccessor.GetValue(CorrelationConstants.LogContextKey)).Returns(null);

            var exception = new Exception("Test exception");
            var restErrorProvider = new RESTErrorProvider(translators, logContextAccessor);

            // Act
            var restError = restErrorProvider.GetRestErrorFromException(exception);

            // Assert
            restError.Code.ShouldBe((int)HttpStatusCode.InternalServerError);
            restError.Type.ShouldBe("Internal Server Error");
            restError.Message.ShouldBe("An unexpected error occurred on the server.");
            restError.CorrelationId.ShouldBeNull();
        }
    }

    public class FakeExceptionTranslator : IExceptionTranslator
    {
        private readonly bool _canTranslate;
        private readonly RESTError _translatedError;

        public FakeExceptionTranslator(bool canTranslate, RESTError translatedError)
        {
            _canTranslate = canTranslate;
            _translatedError = translatedError;
        }

        public bool TryTranslateMessage(Exception ex, out RESTError webServiceError)
        {
            webServiceError = _canTranslate
                ? _translatedError
                : null;

            return _canTranslate;
        }
    }
}
