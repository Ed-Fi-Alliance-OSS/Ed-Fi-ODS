// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.IO;
using System.Text.RegularExpressions;
using EdFi.Common.Configuration;
using EdFi.LoadTools.Engine;
using Microsoft.Extensions.Configuration;

namespace EdFi.LoadTools.BulkLoadClient.Application
{
    public class BulkLoadClientConfiguration : IApiConfiguration, IHashCacheConfiguration,
        IDataConfiguration, IOAuthTokenConfiguration, IApiMetadataConfiguration, IXsdConfiguration,
        IInterchangeOrderConfiguration
    {
        public ApiMode ApiMode { get; private set; }

        public string ApiUrl { get; set; }

        public string OAuthKey { get; set; }

        public string OAuthSecret { get; set; }

        public string OauthUrl { get; set; }

        public string DataFolder { get; set; }

        public string WorkingFolder { get; set; }


        public string MetadataUrl { get; set; }

        public string XsdFolder { get; set; }

        public string InterchangeOrderFolder { get; set; }

        public bool DoNotValidateXml { get; set; }

        public string DependenciesUrl { get; set; }

        public bool IncludeStats { get; set; }

        public int MaxSimultaneousRequests { get; set; }

        public int Retries { get; set; }

        public int? SchoolYear { get; set; }

        public int ConnectionLimit { get; set; }

        public string Profile { get; set; }

        public int TaskCapacity { get; set; }

        string IApiConfiguration.Url
        {
            get => ApiUrl;
        }

        bool IApiMetadataConfiguration.Force
        {
            get => ForceMetadata;
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
            get => !string.IsNullOrEmpty(DependenciesUrl)
                ? DependenciesUrl
                : null;
        }

        string IDataConfiguration.Folder
        {
            get => DataFolder;
        }

        string IHashCacheConfiguration.Folder
        {
            get => WorkingFolder;
        }

        string IInterchangeOrderConfiguration.Folder
        {
            get => InterchangeOrderFolder;
        }

        string IOAuthTokenConfiguration.Url
        {
            get => OauthUrl;
        }

        string IOAuthTokenConfiguration.Key
        {
            get => OAuthKey;
        }

        string IOAuthTokenConfiguration.Secret
        {
            get => OAuthSecret;
        }

        string IXsdConfiguration.Folder
        {
            get => XsdFolder;
        }

        bool IXsdConfiguration.DoNotValidateXml
        {
            get => DoNotValidateXml;
        }

        public string Extension { get; set; }

        public string XsdMetadataUrl { get; set; }

        public bool ForceMetadata { get; set; }

        public static BulkLoadClientConfiguration Create(IConfiguration configuration)
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            ApiMode.TryParse(configuration.GetValue<string>("OdsApi:ApiMode"), out ApiMode apiMode);

            string workingFolder = string.IsNullOrEmpty(configuration.GetValue<string>("Folders:Working"))
                ? currentDirectory
                : Path.GetFullPath(configuration.GetValue<string>("Folders:Working"));

            var xsdFolder = string.IsNullOrEmpty(configuration.GetValue<string>("Folders:Xsd"))
                ? Path.Combine(workingFolder, "Schemas")
                : Path.GetFullPath(configuration.GetValue<string>("Folders:Xsd"));

            return new BulkLoadClientConfiguration
            {
                ConnectionLimit = configuration.GetValue("Concurrency:ConnectionLimit", 100),
                DataFolder = configuration.GetValue("Folders:Data", currentDirectory),
                DoNotValidateXml = !configuration.GetValue<bool>("ValidateSchema"),
                Profile = configuration.GetValue<string>("OdsApi:Profile"),
                ForceMetadata = configuration.GetValue<bool>("ForceMetadata"),
                Retries = configuration.GetValue("Concurrency:MaxRetries", 3),
                IncludeStats = configuration.GetValue<bool>("IncludeStats"),
                OAuthKey = configuration.GetValue<string>("OdsApi:Key"),
                OAuthSecret = configuration.GetValue<string>("OdsApi:Secret"),
                SchoolYear = configuration.GetValue<int?>("OdsApi:SchoolYear"),
                TaskCapacity = configuration.GetValue("Concurrency:TaskCapacity", 50),
                WorkingFolder = workingFolder,
                XsdFolder = xsdFolder,
                InterchangeOrderFolder = configuration.GetValue("Folders:Interchange", currentDirectory),
                MaxSimultaneousRequests = configuration.GetValue("Concurrency:MaxSimultaneousApiRequests", 500),
                ApiUrl = ResolvedUrl(configuration.GetValue<string>("OdsApi:ApiUrl")),
                MetadataUrl = ResolvedUrl(configuration.GetValue<string>("OdsApi:MetadataUrl")),
                DependenciesUrl = ResolvedUrl(configuration.GetValue<string>("OdsApi:DependenciesUrl")),
                OauthUrl = configuration.GetValue<string>("OdsApi:OAuthUrl"),
                XsdMetadataUrl = configuration.GetValue<string>("OdsApi:XsdMetadataUrl"),
                Extension = configuration.GetValue<string>("OdsApi:Extension"),
                ApiMode =  apiMode
            };

            string ResolvedUrl(string url)
            {
                return apiMode == ApiMode.YearSpecific
                    ? Regex.Replace(

                        // https://regex101.com/r/lgugB1/1
                        url, @"\/(?<year>\b\d{4}\b)", configuration.GetValue<string>("OdsApi:SchoolYear"), RegexOptions.None)
                    : url;
            }
        }
    }
}
