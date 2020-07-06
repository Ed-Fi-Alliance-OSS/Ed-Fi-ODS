// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Text;
using EdFi.LoadTools.Engine;

namespace EdFi.LoadTools.BulkLoadClient.Application
{
    public class Configuration : IApiConfiguration, IHashCacheConfiguration,
                                 IDataConfiguration, IOAuthTokenConfiguration, IApiMetadataConfiguration, IXsdConfiguration,
                                 IInterchangeOrderConfiguration
    {
        public string ApiUrl { get; set; }

        public string OauthKey { get; set; }

        public string OauthSecret { get; set; }

        public string OauthUrl { get; set; }

        public string DataFolder { get; set; }

        public string WorkingFolder { get; set; }

        public bool Metadata { get; set; }

        public string MetadataUrl { get; set; }

        public string XsdFolder { get; set; }

        internal string Token { get; set; }

        public string InterchangeOrderFolder { get; set; }

        public bool LoadModelMetadata => !string.IsNullOrEmpty(MetadataUrl);

        public bool DoNotValidateXml { get; set; }

        public string DependenciesUrl { get; set; }

        public bool IsValid
        {
            get
            {
                var result =
                    !(string.IsNullOrEmpty(ApiUrl) || string.IsNullOrEmpty(WorkingFolder) || string.IsNullOrEmpty(DataFolder) ||
                      string.IsNullOrEmpty(XsdFolder) || string.IsNullOrEmpty(MetadataUrl) || string.IsNullOrEmpty(OauthKey) ||
                      string.IsNullOrEmpty(OauthSecret) || string.IsNullOrEmpty(OauthUrl))
                    && Directory.Exists(DataFolder)
                    && Uri.IsWellFormedUriString(ApiUrl, UriKind.Absolute)
                    && Uri.IsWellFormedUriString(MetadataUrl, UriKind.Absolute)
                    && Uri.IsWellFormedUriString(OauthUrl, UriKind.Absolute);

                return result;
            }
        }

        public string ErrorText => CreateErrorText();

        public int MaxSimultaneousRequests { get; set; }

        public int Retries { get; set; }

        public int? SchoolYear { get; set; }

        public int ConnectionLimit { get; set; }

        public string Profile { get; set; }

        public int TaskCapacity { get; set; }

        string IApiConfiguration.Url => ApiUrl;

        bool IApiMetadataConfiguration.Force => Metadata;

        string IApiMetadataConfiguration.Folder => WorkingFolder;

        string IApiMetadataConfiguration.Url => MetadataUrl;

        string IApiMetadataConfiguration.DependenciesUrl
            => !string.IsNullOrEmpty(DependenciesUrl)
                ? DependenciesUrl
                : null;

        string IDataConfiguration.Folder => DataFolder;

        string IHashCacheConfiguration.Folder => WorkingFolder;

        string IInterchangeOrderConfiguration.Folder => InterchangeOrderFolder;

        string IOAuthTokenConfiguration.Url => OauthUrl;

        string IOAuthTokenConfiguration.Key => OauthKey;

        string IOAuthTokenConfiguration.Secret => OauthSecret;

        string IXsdConfiguration.Folder => XsdFolder;

        bool IXsdConfiguration.DoNotValidateXml => DoNotValidateXml;

        public bool IncludeStats { get; set; }

        private string CreateErrorText()
        {
            var sb = new StringBuilder();

            if (string.IsNullOrEmpty(OauthKey))
            {
                sb.AppendLine("Option 'k:key' parse error. missing value.");
            }

            if (string.IsNullOrEmpty(OauthSecret))
            {
                sb.AppendLine("Option 's:secret' parse error. missing value.");
            }

            if (string.IsNullOrEmpty(ApiUrl) || !Uri.IsWellFormedUriString(ApiUrl, UriKind.Absolute))
            {
                sb.AppendLine($"Option 'a:apiurl' parse error. \"{ApiUrl}\" is not a url.");
            }

            if (string.IsNullOrEmpty(DataFolder) || !Directory.Exists(DataFolder))
            {
                sb.AppendLine($"Option 'd:data' parse error. \"{DataFolder}\" is not a directory.");
            }

            if (string.IsNullOrEmpty(MetadataUrl) || !Uri.IsWellFormedUriString(MetadataUrl, UriKind.Absolute))
            {
                sb.AppendLine($"Option 'metadataurl' parse error. \"{MetadataUrl}\" is not a url.");
            }

            if (string.IsNullOrEmpty(OauthUrl) || !Uri.IsWellFormedUriString(OauthUrl, UriKind.Absolute))
            {
                sb.AppendLine($"Option 'o:oauthurl' parse error. \"{OauthUrl}\" is not a url.");
            }

            if (string.IsNullOrEmpty(WorkingFolder) || !Directory.Exists(WorkingFolder))
            {
                sb.AppendLine($"Option 'w:working' parse error. \"{WorkingFolder}\" is not a directory.");
            }

            return sb.ToString();
        }
    }
}
