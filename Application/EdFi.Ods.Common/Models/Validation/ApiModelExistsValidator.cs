// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using FluentValidation;

namespace EdFi.Ods.Common.Models.Validation
{
    public class ApiModelExistsValidator : AbstractValidator<string>
    {
        public ApiModelExistsValidator()
        {
            var regex = new Regex(@"ApiModel.*.json");

            RuleFor(extensionFolder => extensionFolder)
                .Must(
                    e =>
                    {
                        var metaDataFolder = Path.Combine(e, "Artifacts", "Metadata");
                        return Directory
                            .GetFiles(metaDataFolder)
                            .Any(s => regex.IsMatch(s));
                    }).WithMessage(m => "ApiModel file does not exists");
        }
    }
}
