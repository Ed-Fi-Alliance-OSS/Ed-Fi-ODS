// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using FluentValidation;

namespace EdFi.Ods.Common.Configuration.Validation;

public class ApiSettingsValidator : AbstractValidator<ApiSettings>
{
    public ApiSettingsValidator()
    {
        RuleFor(x => x.Services).SetValidator(apiSettings => new ServiceSettingsValidator(apiSettings));
        RuleFor(x => x.Caching).SetValidator(apiSettings => new CacheSettingsValidator(apiSettings));
    }
}
