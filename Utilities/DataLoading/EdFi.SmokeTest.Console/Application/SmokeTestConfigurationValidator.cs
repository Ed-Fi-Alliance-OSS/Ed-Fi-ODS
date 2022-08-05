// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Linq;
using System.Text;
using EdFi.Common.Configuration;
using EdFi.LoadTools.SmokeTest;

namespace EdFi.SmokeTest.Console.Application
{
    public class SmokeTestConfigurationValidator : ISmokeTestConfigurationValidator
    {
        private readonly SmokeTestsConfiguration _configuration;

        public SmokeTestConfigurationValidator(SmokeTestsConfiguration configuration)
        {
            _configuration = configuration;
        }

        private bool ValidApiUrl
        {
            get => Uri.IsWellFormedUriString(_configuration.ApiUrl, UriKind.Absolute);
        }

        private bool ValidOAuthUrl
        {
            get => Uri.IsWellFormedUriString(_configuration.OAuthUrl, UriKind.Absolute);
        }

        private bool ValidMetadataUrl
        {
            get => _configuration.TestSet == TestSet.NonDestructiveSdk ||
                   Uri.IsWellFormedUriString(_configuration.MetadataUrl, UriKind.Absolute);
        }

        private bool ValidSdkLibraryPath
        {
            get => _configuration.TestSet == TestSet.NonDestructiveApi || File.Exists(_configuration.SdkLibraryPath);
        }

        private bool ValidNamespacePrefix
        {
            get => _configuration.TestSet != TestSet.NonDestructiveApi ||
                   Uri.IsWellFormedUriString(_configuration.NamespacePrefix, UriKind.Absolute);
        }

        private bool ValidEducationOrganizationIdOverrides
        {
            get => _configuration.TestSet != TestSet.DestructiveSdk ||
                   (_configuration.EducationOrganizationIdOverrides != null &&
                    _configuration.EducationOrganizationIdOverrides.Any() && !_configuration.EducationOrganizationIdOverrides
                        .GroupBy(kv => kv.Value).Any(g => g.Count() > 1));
        }

        private bool ValidUnifiedProperties
        {
            get => _configuration.TestSet != TestSet.DestructiveSdk ||
                   (_configuration.UnifiedProperties != null && _configuration.UnifiedProperties.Any());
        }

        public string ErrorText { get; private set; }

        public bool IsValid()
        {
            var isValid = ValidApiUrl && ValidOAuthUrl && ValidMetadataUrl && ValidSdkLibraryPath &&
                          ValidNamespacePrefix && ValidEducationOrganizationIdOverrides && ValidUnifiedProperties;

            if (_configuration.ApiMode == ApiMode.YearSpecific)
            {
                isValid = isValid && _configuration.SchoolYear.HasValue;
            }

            if (!isValid)
            {
                ErrorText = CreateErrorText();
            }

            return isValid;
        }

        private string CreateErrorText()
        {
            var sb = new StringBuilder();

            if (!ValidApiUrl)
            {
                sb.AppendLine("'a:apiurl is not a valid URL");
            }

            if (!ValidOAuthUrl)
            {
                sb.AppendLine("o:oauthurl is not a valid URL");
            }

            if (!ValidMetadataUrl)
            {
                sb.AppendLine("m:metadataurl is not a valid URL");
            }

            if (!ValidSdkLibraryPath)
            {
                sb.AppendLine("l:library is not a valid file path");
            }

            if (!ValidNamespacePrefix)
            {
                sb.AppendLine("n:namespace is not a valid URI");
            }

            if (!ValidEducationOrganizationIdOverrides)
            {
                sb.AppendLine("EducationOrganizationIdOverrides is required and all its ids must be distinct.");
            }

            if (!ValidUnifiedProperties)
            {
                sb.AppendLine("UnifiedProperties is required");
            }

            if (_configuration.ApiMode == ApiMode.YearSpecific && !_configuration.SchoolYear.HasValue)
            {
                sb.AppendLine($"School year is required for '{_configuration.ApiMode.DisplayName}' Mode");
            }

            return sb.ToString();
        }
    }
}
