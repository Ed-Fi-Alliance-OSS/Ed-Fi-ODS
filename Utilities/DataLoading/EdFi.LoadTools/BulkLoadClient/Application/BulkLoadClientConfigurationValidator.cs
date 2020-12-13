// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Text;
using EdFi.Common.Configuration;

namespace EdFi.LoadTools.BulkLoadClient.Application
{
    public class BulkLoadClientConfigurationValidator : IBulkLoadClientConfigurationValidator
    {
        private readonly BulkLoadClientConfiguration _configuration;

        public BulkLoadClientConfigurationValidator(BulkLoadClientConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ErrorText { get; private set; }

        public bool IsValid()
        {
            bool result =
                !(string.IsNullOrEmpty(_configuration.ApiUrl)
                  || string.IsNullOrEmpty(_configuration.WorkingFolder)
                  || string.IsNullOrEmpty(_configuration.DataFolder)
                  || string.IsNullOrEmpty(_configuration.XsdFolder)
                  || string.IsNullOrEmpty(_configuration.MetadataUrl)
                  || string.IsNullOrEmpty(_configuration.OAuthKey)
                  || string.IsNullOrEmpty(_configuration.OAuthSecret)
                  || string.IsNullOrEmpty(_configuration.OauthUrl))
                && Directory.Exists(_configuration.DataFolder)
                && Uri.IsWellFormedUriString(_configuration.ApiUrl, UriKind.Absolute)
                && Uri.IsWellFormedUriString(_configuration.MetadataUrl, UriKind.Absolute)
                && Uri.IsWellFormedUriString(_configuration.OauthUrl, UriKind.Absolute);

            if (_configuration.ApiMode == ApiMode.YearSpecific)
            {
                result = result && _configuration.SchoolYear.HasValue;
            }

            if (!result)
            {
                ErrorText = CreateErrorText();
            }

            return result;
        }

        private string CreateErrorText()
        {
            var sb = new StringBuilder();

            if (string.IsNullOrEmpty(_configuration.OAuthKey))
            {
                sb.AppendLine("Option 'k:key' parse error. Missing value.");
            }

            if (string.IsNullOrEmpty(_configuration.OAuthSecret))
            {
                sb.AppendLine("Option 's:secret' parse error. Missing value.");
            }

            if (string.IsNullOrEmpty(_configuration.ApiUrl) ||
                !Uri.IsWellFormedUriString(_configuration.ApiUrl, UriKind.Absolute))
            {
                sb.AppendLine($"Option 'a:apiurl' parse error. '{_configuration.ApiUrl}' is not a url.");
            }

            if (string.IsNullOrEmpty(_configuration.DataFolder) || !Directory.Exists(_configuration.DataFolder))
            {
                sb.AppendLine($"Option 'd:data' parse error. '{_configuration.DataFolder}' is not a directory.");
            }

            if (string.IsNullOrEmpty(_configuration.MetadataUrl) ||
                !Uri.IsWellFormedUriString(_configuration.MetadataUrl, UriKind.Absolute))
            {
                sb.AppendLine($"Option 'metadataurl' parse error. '{_configuration.MetadataUrl}' is not a url.");
            }

            if (string.IsNullOrEmpty(_configuration.OauthUrl) ||
                !Uri.IsWellFormedUriString(_configuration.OauthUrl, UriKind.Absolute))
            {
                sb.AppendLine($"Option 'o:oauthurl' parse error. '{_configuration.OauthUrl}' is not a url.");
            }

            if (string.IsNullOrEmpty(_configuration.WorkingFolder) || !Directory.Exists(_configuration.WorkingFolder))
            {
                sb.AppendLine($"Option 'w:working' parse error. '{_configuration.WorkingFolder}' is not a directory.");
            }

            if (_configuration.ApiMode == ApiMode.YearSpecific && !_configuration.SchoolYear.HasValue)
            {
                sb.AppendLine($"School year is required for '{_configuration.ApiMode.DisplayName}' Mode");
            }

            return sb.ToString();
        }
    }
}
