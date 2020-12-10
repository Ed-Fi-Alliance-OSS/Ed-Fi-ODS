// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Text;

namespace EdFi.XmlLookup.Console.Application
{
    public class XmlLookupConfigurationValidator : IXmlLookupConfigurationValidator
    {
        private readonly XmlLookupConfiguration _configuration;

        public XmlLookupConfigurationValidator(XmlLookupConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ErrorText
        {
            get => GetErrorText();
        }

        public bool IsValid()
        {
            var result =
                !(
                    string.IsNullOrEmpty(_configuration.ApiUrl) ||
                    string.IsNullOrEmpty(_configuration.WorkingFolder) ||
                    string.IsNullOrEmpty(_configuration.DataFolder) ||
                    string.IsNullOrEmpty(_configuration.XsdFolder) ||
                    string.IsNullOrEmpty(_configuration.MetadataUrl) ||
                    string.IsNullOrEmpty(_configuration.OAuthKey) ||
                    string.IsNullOrEmpty(_configuration.OAuthSecret) ||
                    string.IsNullOrEmpty(_configuration.OAuthUrl)
                )
                && Directory.Exists(_configuration.DataFolder)
                && Uri.IsWellFormedUriString(_configuration.ApiUrl, UriKind.Absolute)
                && Uri.IsWellFormedUriString(_configuration.MetadataUrl, UriKind.Absolute)
                && Uri.IsWellFormedUriString(_configuration.OAuthUrl, UriKind.Absolute);

            return result;
        }

        private string GetErrorText()
        {
            var sb = new StringBuilder();

            if (string.IsNullOrEmpty(_configuration.OAuthKey))
            {
                sb.AppendLine("Option 'k:key' parse error. missing value.");
            }

            if (string.IsNullOrEmpty(_configuration.OAuthSecret))
            {
                sb.AppendLine("Option 's:secret' parse error. missing value.");
            }

            if (string.IsNullOrEmpty(_configuration.ApiUrl) ||
                !Uri.IsWellFormedUriString(_configuration.ApiUrl, UriKind.Absolute))
            {
                sb.AppendLine("Option 'a:apiurl' parse error. Provided value is not a url.");
            }

            if (string.IsNullOrEmpty(_configuration.DataFolder) || !Directory.Exists(_configuration.DataFolder))
            {
                sb.AppendLine("Option 'd:data' parse error. Provided value is not a directory.");
            }

            if (string.IsNullOrEmpty(_configuration.MetadataUrl) ||
                !Uri.IsWellFormedUriString(_configuration.MetadataUrl, UriKind.Absolute))
            {
                sb.AppendLine("Option 'metadataurl' parse error. Provided value is not a url.");
            }

            if (string.IsNullOrEmpty(_configuration.OAuthUrl) ||
                !Uri.IsWellFormedUriString(_configuration.OAuthUrl, UriKind.Absolute))
            {
                sb.AppendLine("Option 'o:oauthurl' parse error. Provided value is not a url.");
            }

            if (string.IsNullOrEmpty(_configuration.WorkingFolder) || !Directory.Exists(_configuration.WorkingFolder))
            {
                sb.AppendLine("Option 'w:working' parse error. Provided value is not a directory.");
            }

            return sb.ToString();
        }
    }
}
