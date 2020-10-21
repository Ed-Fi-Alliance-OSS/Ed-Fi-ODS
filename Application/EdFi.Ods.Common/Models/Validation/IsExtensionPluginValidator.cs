// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.IO;
using FluentValidation;

namespace EdFi.Ods.Common.Models.Validation
{
    public class IsExtensionPluginValidator : AbstractValidator<string>
    {
        public IsExtensionPluginValidator()
        {
            RuleFor(extensionFolder => extensionFolder)
                .Must(
                    e =>
                    {
                        var apiModelExtensionFile = Path.Combine(e, "Artifacts", "Metadata", "ApiModel-EXTENSION.json");

                        return File.Exists(apiModelExtensionFile);
                    }).WithMessage(m => $"ApiModel-EXTENSION.json file does not exists");

        }
    }
}
