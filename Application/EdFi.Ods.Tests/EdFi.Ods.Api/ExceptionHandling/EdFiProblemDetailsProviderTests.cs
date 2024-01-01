// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Net;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Logging;
using EdFi.Ods.Common.ProblemDetails;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.ExceptionHandling
{
    [TestFixture]
    public class EdFiProblemDetailsProviderTests
    {
        [Test]
        public void GetProblemDetailsFromException_ShouldUseTranslator_WhenExceptionIsTranslatable()
        {
            // Arrange
            var translators = new List<IProblemDetailsExceptionTranslator>
            {
                new FakeExceptionTranslator(
                    true,
                    new EdFiProblemDetails()
                    {
                        Status = 400,
                        Type = "Bad Request",
                        Detail = "Invalid request."
                    })
            };

            var logContextAccessor = A.Fake<ILogContextAccessor>();
            A.CallTo(() => logContextAccessor.GetValue(CorrelationConstants.LogContextKey)).Returns("12345");

            var exception = new Exception("Test exception");
            var restErrorProvider = new EdFiProblemDetailsProvider(translators, logContextAccessor);

            // Act
            var restError = restErrorProvider.GetProblemDetails(exception);

            // Assert
            restError.Status.ShouldBe(400);
            restError.Type.ShouldBe("Bad Request");
            restError.Detail.ShouldBe("Invalid request.");
            restError.CorrelationId.ShouldBe("12345");
        }

        [Test]
        public void GetProblemDetailsFromException_ShouldUseDefaultError_WhenExceptionIsNotTranslatable()
        {
            // Arrange
            var translators = new List<IProblemDetailsExceptionTranslator> { new FakeExceptionTranslator(false, null) };

            var logContextAccessor = A.Fake<ILogContextAccessor>();
            A.CallTo(() => logContextAccessor.GetValue(CorrelationConstants.LogContextKey)).Returns("54321");

            var exception = new Exception("Test exception");
            var restErrorProvider = new EdFiProblemDetailsProvider(translators, logContextAccessor);

            // Act
            var restError = restErrorProvider.GetProblemDetails(exception);

            // Assert
            restError.ShouldSatisfyAllConditions(
                () => restError.Status.ShouldBe((int)HttpStatusCode.InternalServerError),
                () => restError.Type.ShouldBe(string.Join(':', EdFiProblemDetailsExceptionBase.BaseTypePrefix, "system")),
                () => restError.Detail.ShouldBe("An unexpected problem has occurred."),
                () => restError.CorrelationId.ShouldBe("54321")
            );
        }

        [Test]
        public void GetProblemDetailsFromException_ShouldUseDefaultErrorWithNoCorrelationId_WhenExceptionIsNotTranslatableAndNoCorrelationHasBeenSet()
        {
            // Arrange
            var translators = new List<IProblemDetailsExceptionTranslator> { new FakeExceptionTranslator(false, null) };

            var logContextAccessor = A.Fake<ILogContextAccessor>();
            A.CallTo(() => logContextAccessor.GetValue(CorrelationConstants.LogContextKey)).Returns(null);

            var exception = new Exception("Test exception");
            var restErrorProvider = new EdFiProblemDetailsProvider(translators, logContextAccessor);

            // Act
            var restError = restErrorProvider.GetProblemDetails(exception);

            // Assert
            restError.ShouldSatisfyAllConditions(
                () => restError.Status.ShouldBe((int)HttpStatusCode.InternalServerError),
                () => restError.Type.ShouldBe(string.Join(':', EdFiProblemDetailsExceptionBase.BaseTypePrefix, "system")),
                () => restError.Detail.ShouldBe("An unexpected problem has occurred."),
                () => restError.CorrelationId.ShouldBeNull()
            );
        }
    }

    public class FakeExceptionTranslator : IProblemDetailsExceptionTranslator
    {
        private readonly bool _canTranslate;
        private readonly IEdFiProblemDetails _translatedError;

        public FakeExceptionTranslator(bool canTranslate, IEdFiProblemDetails translatedError)
        {
            _canTranslate = canTranslate;
            _translatedError = translatedError;
        }

        public bool TryTranslate(Exception ex, out IEdFiProblemDetails problemDetails)
        {
            problemDetails = _canTranslate
                ? _translatedError
                : null;

            return _canTranslate;
        }
    }
}
