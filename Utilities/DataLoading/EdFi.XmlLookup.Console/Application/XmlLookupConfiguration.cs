// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.IO;
using System.Text.RegularExpressions;
using EdFi.Common.Configuration;
using EdFi.LoadTools.Engine;
using Microsoft.Extensions.Configuration;

namespace EdFi.XmlLookup.Console.Application
{
    public class XmlLookupConfiguration : IApiConfiguration, IDataConfiguration, IOAuthTokenConfiguration,
        IApiMetadataConfiguration, IXsdConfiguration
    {
        private string _dataFolder;
        private string _workingFolder;
        private string _xsdFolder;

        public string ApiUrl { get; set; }

        public string OAuthKey { get; set; }

        public string OAuthSecret { get; set; }

        public string OAuthUrl { get; set; }

        public bool DoNotValidateXml { get; set; }

        public string Extension { get; }

        public string XsdMetadataUrl { get; set; }

        public string DataFolder
        {
            get => Path.GetFullPath(_dataFolder);
            set => _dataFolder = value;
        }

        public string WorkingFolder
        {
            get => Path.GetFullPath(_workingFolder);
            set => _workingFolder = value;
        }

        public bool Metadata { get; set; }

        public string MetadataUrl { get; set; }

        public string XsdFolder
        {
            get => Path.GetFullPath(_xsdFolder);
            set => _xsdFolder = value;
        }

        internal string Token { get; set; }

        public bool LoadModelMetadata
        {
            get => !string.IsNullOrEmpty(MetadataUrl);
        }

        public ApiMode ApiMode { get; set; }

        public int Retries { get; set; }

        public int MaxSimultaneousRequests { get; set; }

        public int? SchoolYear { get; set; }

        public string InstanceId { get; set; }

        public string Profile { get; set; }

        string IApiConfiguration.Url
        {
            get => ApiUrl;
        }

        public int ConnectionLimit
        {
            get => MaxSimultaneousRequests;
        }

        public int TaskCapacity { get; set; }

        bool IApiMetadataConfiguration.Force
        {
            get => Metadata;
        }

        string IApiMetadataConfiguration.Folder
        {
            get => WorkingFolder;
        }

        string IApiMetadataConfiguration.Url
        {
            get => MetadataUrl;
        }

        string IApiMetadataConfiguration.DependenciesUrl
        {
            get => null;
        }

        string IDataConfiguration.Folder
        {
            get => DataFolder;
        }

        string IOAuthTokenConfiguration.Url
        {
            get => OAuthUrl;
        }

        string IOAuthTokenConfiguration.Key
        {
            get => OAuthKey;
        }

        string IOAuthTokenConfiguration.Secret
        {
            get => OAuthSecret;
        }

        bool IXsdConfiguration.DoNotValidateXml
        {
            get => DoNotValidateXml;
        }

        string IXsdConfiguration.Folder
        {
            get => XsdFolder;
        }

        public static XmlLookupConfiguration Create(IConfiguration configuration)
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            ApiMode.TryParse(configuration.GetValue<string>("OdsApi:ApiMode"), out ApiMode apiMode);

            return new XmlLookupConfiguration
            {
                DataFolder = configuration.GetValue("Folders:Data", currentDirectory),
                DoNotValidateXml = configuration.GetValue<bool>("ValidateSchema"),
                Profile = configuration.GetValue<string>("OdsApi:Profile"),
                Metadata = configuration.GetValue<bool>("ForceMetadata"),
                Retries = configuration.GetValue("Concurrency:MaxRetries", 3),
                OAuthKey = configuration.GetValue<string>("OdsApi:Key"),
                OAuthSecret = configuration.GetValue<string>("OdsApi:Secret"),
                SchoolYear = configuration.GetValue<int?>("OdsApi:SchoolYear"),
                InstanceId = configuration.GetValue<string>("OdsApi:Instanceid"),
                TaskCapacity = configuration.GetValue("Concurrency:TaskCapacity", 50),
                WorkingFolder = configuration.GetValue("Folders:Working", currentDirectory),
                XsdFolder = configuration.GetValue("Folders:Xsd", currentDirectory),
                MaxSimultaneousRequests = configuration.GetValue("Concurrency:MaxSimultaneousApiRequests", 500),
                ApiUrl = ResolvedUrl(configuration.GetValue<string>("OdsApi:ApiUrl")),
                MetadataUrl = ResolvedUrl(configuration.GetValue<string>("OdsApi:MetadataUrl")),
                XsdMetadataUrl = ResolvedUrl(configuration.GetValue<string>("OdsApi:XsdMetadataUrl")),
                OAuthUrl = ResolvedUrl(configuration.GetValue<string>("OdsApi:OAuthUrl")),
                ApiMode = apiMode
            };

            string ResolvedUrl(string url)
            {
				if (url == null)
                {
                    return null;
                }
				
                if (apiMode == ApiMode.YearSpecific)
                {
                    // https://regex101.com/r/KywmUK/1
                    return Regex.Replace(
                        url,
                        @"\/(?<year>\b\d{4}\b)", $"/{configuration.GetValue<string>("OdsApi:SchoolYear")}", RegexOptions.None
                    );
                }
                else if (apiMode == ApiMode.InstanceYearSpecific)
                {
                    url = Regex.Replace(
                        url,
                        @"\/(?<year>\b\d{4}\b)", $"/{configuration.GetValue<string>("OdsApi:SchoolYear")}", RegexOptions.None
                    );

                    return url.Replace("{instance}", configuration.GetValue<string>("OdsApi:InstanceId"));
                }
                else
                    return url;
            }
        }
    }
}
