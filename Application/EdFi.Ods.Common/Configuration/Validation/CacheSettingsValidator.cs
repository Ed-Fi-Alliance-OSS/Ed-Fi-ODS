// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using FluentValidation;

namespace EdFi.Ods.Common.Configuration.Validation;

public class CacheSettingsValidator : AbstractValidator<CacheSettings>
{
    public CacheSettingsValidator(ApiSettings apiSettings)
    {
        RuleFor(x => x.ExternalCacheProvider)
            .IsEnumName(typeof(ExternalCacheProviderOption), caseSensitive: false)
            .When(cacheSettings => cacheSettings.IsExternalCacheIsInUse())
            .WithMessage(cacheSettings => 
                $"External caching has been enabled, but the specified cache provider '{cacheSettings.ExternalCacheProvider}' is not valid.");
    }
}
