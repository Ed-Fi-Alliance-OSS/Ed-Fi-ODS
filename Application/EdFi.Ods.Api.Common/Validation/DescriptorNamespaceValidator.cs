// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Text.RegularExpressions;
using EdFi.Ods.Common;
using FluentValidation;

namespace EdFi.Ods.Api.Common.Validation
{
    public class DescriptorNamespaceValidator : AbstractValidator<IEdFiDescriptor>
    {
        private const string RequiredMessage = "{PropertyName} is required.";
        private const string InvalidFormatMessage = "{PropertyName} has invalid format.";
        private const string ValidNamespaceFormatMessage =
            " Valid namespace format is uri://[organization name]/[descriptor name]. Example: 'uri://ed-fi.org/AcademicSubjectDescriptor'";
        private const string BaseMessage = "'{PropertyValue}' is not a valid value for {PropertyName}. ";
        private const string InvalidUriSchemeMessage = BaseMessage + "Namespaces must be prefixed with 'uri://'.";
        private const string InvalidOrganizationNameMessage =
            BaseMessage + "Organization names may only contain alphanumeric and these special characters \"$-_.+!*'(),\".";
        private const string InvalidDescriptorNameMessage = BaseMessage + "Descriptor names may only contain alphanumeric characters.";
        private const string InvalidCodeValueMessage = BaseMessage + "Code values may not contain '#'.";

        // https://regex101.com/r/RrZqpL/5
        private readonly Regex CaptureNamespaceGroups = new Regex("^(?<scheme>.*)?(?:://)(?<organizationName>[^/]+)?(?:/)?(?<descriptorName>.+)*$");
        private readonly Regex InvalidCodeValueCharacters = new Regex("[#]");
        private readonly Regex InvalidDescriptorNameCharacters = new Regex("[^a-zA-Z0-9]");

        // alphanumeric and special characters: "$-_.+!*'(),'" are not encoded (http://www.ietf.org/rfc/rfc1738.txt)
        private readonly Regex InvalidOrganizationNameCharacters = new Regex("[^a-zA-Z0-9$-_.+!*'(),]");
        private readonly Regex ValidScheme = new Regex("uri");

        public DescriptorNamespaceValidator()
        {
            ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Namespace)
               .Must(NotBeNullOrWhitespace)
               .WithMessage(RequiredMessage)
               .Must(BeValidNamespaceFormat)
               .WithMessage(InvalidFormatMessage + ValidNamespaceFormatMessage);

            RuleFor(
                    x => CaptureNamespaceGroups.Match(x.Namespace)
                                               .Groups["scheme"]
                                               .Value)
               .Must(NotBeNullOrWhitespace)
               .When(IsValidDescriptorNamespaceFormat)
               .WithMessage(RequiredMessage + ValidNamespaceFormatMessage)
               .Must(x => ValidScheme.IsMatch(x))
               .When(IsValidDescriptorNamespaceFormat)
               .WithName("namespace scheme")
               .WithMessage(InvalidUriSchemeMessage);

            RuleFor(
                    x => CaptureNamespaceGroups.Match(x.Namespace)
                                               .Groups["organizationName"]
                                               .Value)
               .Must(NotBeNullOrWhitespace)
               .When(IsValidDescriptorNamespaceFormat)
               .WithMessage(RequiredMessage + ValidNamespaceFormatMessage)
               .Must(x => !InvalidOrganizationNameCharacters.IsMatch(x))
               .When(IsValidDescriptorNamespaceFormat)
               .WithName("organization name")
               .WithMessage(InvalidOrganizationNameMessage);

            RuleFor(
                    x => CaptureNamespaceGroups.Match(x.Namespace)
                                               .Groups["descriptorName"]
                                               .Value)
               .Must(NotBeNullOrWhitespace)
               .When(IsValidDescriptorNamespaceFormat)
               .WithMessage(RequiredMessage + ValidNamespaceFormatMessage)
               .Must(x => !InvalidDescriptorNameCharacters.IsMatch(x))
               .When(IsValidDescriptorNamespaceFormat)
               .WithName("descriptor name")
               .WithMessage(InvalidDescriptorNameMessage);

            RuleFor(x => x.CodeValue)
               .Must(NotBeNullOrWhitespace)
               .WithMessage(RequiredMessage)
               .Must(x => !InvalidCodeValueCharacters.IsMatch(x))
               .WithMessage(InvalidCodeValueMessage);
        }

        private bool NotBeNullOrWhitespace(string s) => !string.IsNullOrWhiteSpace(s);

        private bool BeValidNamespaceFormat(string s) => CaptureNamespaceGroups.IsMatch(s);

        private bool IsValidDescriptorNamespaceFormat(IEdFiDescriptor descriptor)
            => NotBeNullOrWhitespace(descriptor.Namespace) && BeValidNamespaceFormat(descriptor.Namespace);
    }
}
