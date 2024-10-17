// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Api.Security.Authorization.AuthorizationBasis;
using EdFi.Ods.Common.Security.Claims;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization.AuthorizationBasis;

[TestFixture]
public class AuthorizationContextValidatorTests
{
    [SetUp]
    public void SetUp()
    {
        _validator = new AuthorizationContextValidator();
    }

    private AuthorizationContextValidator _validator;

    [Test]
    public void Validate_ShouldThrowException_WhenResourceClaimUrisIsNull()
    {
        // Arrange
        IList<string> resourceClaimUris = null;
        var requestAction = "Read";

        // Act & Assert
        var ex = Should.Throw<AuthorizationContextException>(() => _validator.Validate(resourceClaimUris, requestAction));

        ex.Message.ShouldBe("Authorization can only be performed if a resource is specified.");
    }

    [Test]
    public void Validate_ShouldThrowException_WhenResourceClaimUrisIsEmpty()
    {
        // Arrange
        var resourceClaimUris = new List<string>();
        var requestAction = "Update";

        // Act & Assert
        var ex = Should.Throw<AuthorizationContextException>(() => _validator.Validate(resourceClaimUris, requestAction));

        ex.Message.ShouldBe("Authorization can only be performed if a resource is specified.");
    }

    [Test]
    public void Validate_ShouldThrowException_WhenAllResourceClaimUrisAreWhitespace()
    {
        // Arrange
        var resourceClaimUris = new List<string>
        {
            "   ",
            "\t"
        };

        var requestAction = "Delete";

        // Act & Assert
        var ex = Should.Throw<AuthorizationContextException>(() => _validator.Validate(resourceClaimUris, requestAction));

        ex.Message.ShouldBe("Authorization can only be performed if a resource is specified.");
    }

    [Test]
    public void Validate_ShouldThrowException_WhenResourceClaimUrisHasMoreThanTwoItems()
    {
        // Arrange
        var resourceClaimUris = new List<string>
        {
            "Resource1",
            "Resource2",
            "Resource3"
        };

        var requestAction = "Create";

        // Act & Assert
        var ex = Should.Throw<AuthorizationContextException>(() => _validator.Validate(resourceClaimUris, requestAction));

        ex.Message.ShouldBe(
            "Unexpected number of Resource URIs found in the authorization context. Expected up to 2, but found 3.");
    }

    [Test]
    public void Validate_ShouldThrowException_WhenRequestActionIsNull()
    {
        // Arrange
        var resourceClaimUris = new List<string> { "Resource1" };
        string requestAction = null;

        // Act & Assert
        var ex = Should.Throw<AuthorizationContextException>(() => _validator.Validate(resourceClaimUris, requestAction));

        ex.Message.ShouldBe("Authorization can only be performed if an action is specified.");
    }

    [Test]
    public void Validate_ShouldThrowException_WhenRequestActionIsEmpty()
    {
        // Arrange
        var resourceClaimUris = new List<string> { "Resource1" };
        var requestAction = "";

        // Act & Assert
        var ex = Should.Throw<AuthorizationContextException>(() => _validator.Validate(resourceClaimUris, requestAction));

        ex.Message.ShouldBe("Authorization can only be performed if an action is specified.");
    }

    [Test]
    public void Validate_ShouldNotThrowException_WhenResourceClaimUrisAndRequestActionAreValid()
    {
        // Arrange
        var resourceClaimUris = new List<string>
        {
            "Resource1",
            "Resource2"
        };

        var requestAction = "Read";

        // Act & Assert
        Should.NotThrow(() => _validator.Validate(resourceClaimUris, requestAction));
    }
}
