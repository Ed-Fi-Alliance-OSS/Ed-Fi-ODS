// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.IO;
using System.Text;
using EdFi.LoadTools.Engine;

namespace EdFi.XmlLookup.Console.Application
{
    public class Configuration : IApiConfiguration, IDataConfiguration, IOAuthTokenConfiguration,
                                 IApiMetadataConfiguration, IXsdConfiguration
    {
        private string _dataFolder;
        private string _workingFolder;
        private string _xsdFolder;

        public string ApiUrl { get; set; }

        public string OauthKey { get; set; }

        public string OauthSecret { get; set; }

        public string OauthUrl { get; set; }

        public bool DoNotValidateXml { get; set; }

        public string DataFolder
        {
            get { return Path.GetFullPath(_dataFolder); }
            set { _dataFolder = value; }
        }

        public string WorkingFolder
        {
            get { return Path.GetFullPath(_workingFolder); }
            set { _workingFolder = value; }
        }

        public bool Metadata { get; set; }

        public string MetadataUrl { get; set; }

        public string XsdFolder
        {
            get { return Path.GetFullPath(_xsdFolder); }
            set { _xsdFolder = value; }
        }

        internal string Token { get; set; }

        public bool LoadModelMetadata => !string.IsNullOrEmpty(MetadataUrl);

        public bool IsValid
        {
            get
            {
                var result =
                    !(
                        string.IsNullOrEmpty(ApiUrl) ||
                        string.IsNullOrEmpty(WorkingFolder) ||
                        string.IsNullOrEmpty(DataFolder) ||
                        string.IsNullOrEmpty(XsdFolder) ||
                        string.IsNullOrEmpty(MetadataUrl) ||
                        string.IsNullOrEmpty(OauthKey) ||
                        string.IsNullOrEmpty(OauthSecret) ||
                        string.IsNullOrEmpty(OauthUrl)
                    )
                    && Directory.Exists(DataFolder)
                    && Uri.IsWellFormedUriString(ApiUrl, UriKind.Absolute)
                    && Uri.IsWellFormedUriString(MetadataUrl, UriKind.Absolute)
                    && Uri.IsWellFormedUriString(OauthUrl, UriKind.Absolute);

                return result;
            }
        }

        public string ErrorText
        {
            get
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
                    sb.AppendLine("Option 'a:apiurl' parse error. Provided value is not a url.");
                }

                if (string.IsNullOrEmpty(DataFolder) || !Directory.Exists(DataFolder))
                {
                    sb.AppendLine("Option 'd:data' parse error. Provided value is not a directory.");
                }

                if (string.IsNullOrEmpty(MetadataUrl) || !Uri.IsWellFormedUriString(MetadataUrl, UriKind.Absolute))
                {
                    sb.AppendLine("Option 'metadataurl' parse error. Provided value is not a url.");
                }

                if (string.IsNullOrEmpty(OauthUrl) || !Uri.IsWellFormedUriString(OauthUrl, UriKind.Absolute))
                {
                    sb.AppendLine("Option 'o:oauthurl' parse error. Provided value is not a url.");
                }

                if (string.IsNullOrEmpty(WorkingFolder) || !Directory.Exists(WorkingFolder))
                {
                    sb.AppendLine("Option 'w:working' parse error. Provided value is not a directory.");
                }

                return sb.ToString();
            }
        }

        public int Retries { get; set; }

        public int MaxSimultaneousRequests { get; set; }

        public int? SchoolYear { get; set; }

        public string Profile { get; set; }

        string IApiConfiguration.Url => Path.Combine(
            ApiUrl, SchoolYear != null
                ? SchoolYear + "/"
                : string.Empty, "ed-fi");

        public int ConnectionLimit => MaxSimultaneousRequests;

        public int TaskCapacity { get; set; }

        bool IApiMetadataConfiguration.Force => Metadata;

        string IApiMetadataConfiguration.Folder => WorkingFolder;

        string IApiMetadataConfiguration.Url => MetadataUrl;

        string IDataConfiguration.Folder => DataFolder;

        string IOAuthTokenConfiguration.Url => OauthUrl;

        string IOAuthTokenConfiguration.Key => OauthKey;

        string IOAuthTokenConfiguration.Secret => OauthSecret;

        bool IXsdConfiguration.DoNotValidateXml => DoNotValidateXml;

        string IXsdConfiguration.Folder => XsdFolder;

        string IApiMetadataConfiguration.DependenciesUrl
        {
            get => null;
        }
    }
}
