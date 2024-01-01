// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.ExceptionHandling.Translators;
using EdFi.Ods.Common.Exceptions;
using NHibernate;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.ExceptionHandling.Translators;

[TestFixture]
public class NonUniqueObjectExceptionTranslatorTests
{
    private const string MatchingMessage =
        "a different object with the same identifier value was already associated with the session: SUBJECT: 123, ENTITYNAME: PROPERTY: 2, of entity: ENTITYFULLNAME";

    [Test]
    public void TryTranslate_WithNonUniqueObjectException_ShouldReturnTrueAndSetProblemDetails()
    {
        // Arrange
        var translator = new NonUniqueObjectExceptionTranslator();
        var nonUniqueObjectException = new NonUniqueObjectException(MatchingMessage, 1, "EntityName");

        // Act
        var result = translator.TryTranslate(nonUniqueObjectException, out var problemDetails);

        // Assert
        result.ShouldBeTrue();
        problemDetails.ShouldNotBeNull();
        problemDetails.ShouldBeOfType<ConflictException>();
        problemDetails.Detail.ShouldBe("A problem occurred while processing the request.");

        problemDetails.Errors.ShouldContain(
            "Two SUBJECT entities with the same identifier were associated with the session. See log for additional details.");
    }

    [Test]
    public void TryTranslate_WithNonUniqueObjectExceptionAndInvalidRegexMatch_ShouldReturnFalseAndSetNullProblemDetails()
    {
        // Arrange
        var translator = new NonUniqueObjectExceptionTranslator();
        var nonUniqueObjectException = new NonUniqueObjectException("Invalid exception message format", 1, "EntityName");

        // Act
        var result = translator.TryTranslate(nonUniqueObjectException, out var problemDetails);

        // Assert
        result.ShouldBeFalse();
        problemDetails.ShouldBeNull();
    }
}
