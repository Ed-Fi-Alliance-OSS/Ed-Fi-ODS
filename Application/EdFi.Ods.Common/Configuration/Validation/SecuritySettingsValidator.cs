// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using FluentValidation;

namespace EdFi.Ods.Common.Configuration.Validation;

public class SecuritySettingsValidator : AbstractValidator<SecuritySettings>
{
    public SecuritySettingsValidator()
    {
        RuleFor(x => x.AccessTokenType)
            .Matches($"^({SecuritySettings.AccessTokenTypeGuid}|{SecuritySettings.AccessTokenTypeJwt})$")
            .WithMessage($"{{PropertyName}}: Invalid access token type. Must be '{SecuritySettings.AccessTokenTypeGuid}' or '{SecuritySettings.AccessTokenTypeJwt}'.");

        RuleFor(x => x.Jwt)
            .NotNull()
            .When(x => x.AccessTokenType == SecuritySettings.AccessTokenTypeJwt);
        
        RuleFor(x => x.Jwt).SetValidator(new JwtSettingsValidator());
    }
}

public class JwtSettingsValidator : AbstractValidator<SecuritySettings.JwtSettings>
{
    public JwtSettingsValidator()
    {
        RuleFor(x => x.Audiences).NotEmpty();
        RuleFor(x => x.Issuer).NotEmpty();
        RuleFor(x => x.SigningKey).NotNull().WithName(nameof(SecuritySettings.JwtSettings.SigningKey));
        RuleFor(x => x.SigningKey).SetValidator(new SigningKeySettingsValidator());
    }
}

public class SigningKeySettingsValidator : AbstractValidator<SecuritySettings.SigningKeySettings>
{
    public SigningKeySettingsValidator()
    {
        RuleFor(x => x.PublicKey).NotNull().WithName(nameof(SecuritySettings.SigningKeySettings.PublicKey));
        RuleFor(x => x.PrivateKey).NotNull().WithName(nameof(SecuritySettings.SigningKeySettings.PrivateKey));
    }
}
