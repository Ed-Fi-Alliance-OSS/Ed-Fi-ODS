// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Configuration.Validation;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Configuration.Validation;

[TestFixture]
public class ApiSettingsValidatorTests
{
    [Test]
    public void RedisExternalCacheSettingsAreComplete_Validate_ShouldIndicateSuccess()
    {
        // Arrange
        var apiSettings = new ApiSettings()
        {
            Services = new ()
            {
                Redis = new()
                {
                    Configuration = "xyz" // Configuration provided
                }
            },
            Caching = new()
            {
                ExternalCacheProvider = "Redis", // Redis selected
                Descriptors = new()
                {
                    UseExternalCache = true, // External cache in use
                }
            }
        };

        // Act
        var validator = new ApiSettingsValidator();
        var validationResult = validator.Validate(apiSettings);
        
        // Assert
        validationResult.IsValid.ShouldBeTrue();
    }
    
    [Test]
    public void RedisProviderNotSelected_Validate_ShouldFail()
    {
        // Arrange
        var apiSettings = new ApiSettings()
        {
            Services = new ()
            {
                Redis = new()
                {
                    Configuration = "xyz" // Redis configuration provided
                }
            },
            Caching = new()
            {
                ExternalCacheProvider = string.Empty, // No provider selected
                Descriptors = new()
                {
                    UseExternalCache = true, // External caching in use
                }
            }
        };

        // Act
        var validator = new ApiSettingsValidator();
        var validationResult = validator.Validate(apiSettings);

        // Assert
        validationResult.IsValid.ShouldBeFalse();
        validationResult.ToString().ShouldBe("External caching has been enabled, but the specified cache provider '' is not valid.");
    }

    [Test]
    public void RedisConfigurationNotSpecified_Validate_ShouldFail()
    {
        // Arrange
        var apiSettings = new ApiSettings()
        {
            Services = new ()
            {
                Redis = new()
                {
                    Configuration = null // Not defined
                }
            },
            Caching = new()
            {
                ExternalCacheProvider = "Redis", // Redis selected
                Descriptors = new()
                {
                    UseExternalCache = true, // External caching is in use
                }
            }
        };

        // Act
        var validator = new ApiSettingsValidator();
        var validationResult = validator.Validate(apiSettings);
        
        // Assert
        validationResult.IsValid.ShouldBeFalse();
        validationResult.ToString().ShouldBe("External caching has been enabled with Redis, but the Redis configuration string has not been provided.");
    }

    [Test]
    public void UnknownProviderSpecified_Validate_ShouldFail()
    {
        // Arrange
        var apiSettings = new ApiSettings()
        {
            Services = new ()
            {
                Redis = new()
                {
                    Configuration = "xyz" // Redis configuration provided
                }
            },
            Caching = new()
            {
                ExternalCacheProvider = "NotDefined", // Unknown provider
                Descriptors = new()
                {
                    UseExternalCache = true, // External caching in use
                }
            }
        };

        // Act
        var validator = new ApiSettingsValidator();
        var validationResult = validator.Validate(apiSettings);

        // Assert
        validationResult.IsValid.ShouldBeFalse();
        validationResult.ToString().ShouldBe("External caching has been enabled, but the specified cache provider 'NotDefined' is not valid.");
    }

    [TestCase("xyz", "Redis")]
    [TestCase("xyz", "")]
    [TestCase("xyz", "Unknown")]
    [TestCase(null, "Redis")]
    [TestCase(null, "")]
    [TestCase(null, "Unknown")]
    public void CachingNotInUse_Validate_ShouldSucceed(string configuration, string providerName)
    {
        // Arrange
        var apiSettings = new ApiSettings()
        {
            Services = new ()
            {
                Redis = new()
                {
                    Configuration = configuration // Redis configuration
                }
            },
            Caching = new()
            {
                ExternalCacheProvider = providerName, // Provider name
                Descriptors = new()
                {
                    UseExternalCache = false, // External caching NOT in use
                }
            }
        };

        // Act
        var validator = new ApiSettingsValidator();
        var validationResult = validator.Validate(apiSettings);

        // Assert
        validationResult.IsValid.ShouldBeTrue();
    }
}
