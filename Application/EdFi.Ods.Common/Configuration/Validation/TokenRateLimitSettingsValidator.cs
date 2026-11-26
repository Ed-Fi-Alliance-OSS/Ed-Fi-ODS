// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using FluentValidation;

namespace EdFi.Ods.Common.Configuration.Validation;

public class TokenRateLimitSettingsValidator : AbstractValidator<TokenRateLimitSettings>
{
    public TokenRateLimitSettingsValidator()
    {
        When(
            settings => settings.Enabled,
            () =>
            {
                RuleFor(x => x.PermitsPerIpAddress)
                    .GreaterThan(0)
                    .WithMessage("ApiSettings:TokenRateLimit:PermitsPerIpAddress must be greater than 0.");

                RuleFor(x => x.FailedAttemptsPerClientId)
                    .GreaterThan(0)
                    .WithMessage("ApiSettings:TokenRateLimit:FailedAttemptsPerClientId must be greater than 0.");

                RuleFor(x => x.WindowSeconds)
                    .GreaterThan(0)
                    .WithMessage("ApiSettings:TokenRateLimit:WindowSeconds must be greater than 0.");
            });
    }
}
