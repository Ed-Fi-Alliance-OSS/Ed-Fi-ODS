// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using EdFi.Ods.Common.Models.Definitions;
using FluentValidation;
using Newtonsoft.Json;

namespace EdFi.Ods.Common.Models.Validation
{
    public class IsApiVersionValidValidator : AbstractValidator<string>
    {
        private readonly string _apiVersion;

        public IsApiVersionValidValidator(string apiVersion)
        {
            var regex = new Regex(@"ApiModel.*.json");

            _apiVersion = apiVersion;

            RuleFor(extensionFolder => extensionFolder)
                .Must(
                    e =>
                    {
                        var metaDataFolder = Path.Combine(e, "Artifacts", "Metadata");

                        var apiModelFile = Directory
                            .GetFiles(metaDataFolder).Where(s => regex.IsMatch(s))
                            .ToList()
                            .SingleOrDefault();

                        return apiModelFile != null && IsValidApiVersion(apiModelFile);
                    }).WithMessage(m => "Extension version does not match ODS/API version");
        }

        private bool IsValidApiVersion(string apiModelFile)
        {
            var domainModelDefinitions = JsonConvert.DeserializeObject<DomainModelDefinitions>(File.ReadAllText(apiModelFile));

            return _apiVersion.Equals(domainModelDefinitions.OdsApiVersion);
        }
    }
}
