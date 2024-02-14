// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using FluentValidation;

namespace EdFi.Ods.Common.Configuration.Validation;

public class ServiceSettingsValidator : AbstractValidator<ServiceSettings>
{
    public ServiceSettingsValidator(ApiSettings apiSettings)
    {
        RuleFor(serviceSettings => serviceSettings.Redis.Configuration)
            .NotEmpty()
            .When(serviceSettings => apiSettings.Caching.IsExternalCacheIsInUse()
                    && apiSettings.Caching.ExternalCacheProviderOption == ExternalCacheProviderOption.Redis)
            .WithMessage("External caching has been enabled with Redis, but the Redis configuration string has not been provided.");
    }
}
