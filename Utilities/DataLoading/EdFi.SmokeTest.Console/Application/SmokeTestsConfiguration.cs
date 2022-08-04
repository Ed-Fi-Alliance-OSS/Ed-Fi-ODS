// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using EdFi.Common.Configuration;
using EdFi.LoadTools;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.SmokeTest;
using Microsoft.Extensions.Configuration;

namespace EdFi.SmokeTest.Console.Application
{
    public class SmokeTestsConfiguration : IApiConfiguration, IApiMetadataConfiguration, IOAuthTokenConfiguration,
        IOAuthSessionToken, ISdkLibraryConfiguration, IDestructiveTestConfiguration
    {
        public ApiMode ApiMode { get; set; }

        public string ApiUrl { get; set; }

        public string OAuthKey { get; set; }

        public string OAuthSecret { get; set; }

        public string OAuthUrl { get; set; }

        public int? SchoolYear { get; set; }

        public string MetadataUrl { get; set; }

        public string SdkLibraryPath { get; set; }

        public TestSet TestSet { get; set; }

        public string DependenciesUrl { get; set; }

        // IApiConfiguration
        string IApiConfiguration.Profile
        {
            get => string.Empty;
        }

        public int Retries { get; set; }

        public int MaxSimultaneousRequests { get; set; }

        int? IApiConfiguration.SchoolYear
        {
            get => SchoolYear;
        }

        string IApiConfiguration.Url
        {
            get => ApiUrl;
        }

        public int ConnectionLimit { get; set; }

        public int TaskCapacity { get; set; }

        // IApiMetadataConfiguration
        bool IApiMetadataConfiguration.Force
        {
            get => true;
        }

        string IApiMetadataConfiguration.Url
        {
            get => MetadataUrl;
        }

        string IApiMetadataConfiguration.DependenciesUrl
        {
            get => DependenciesUrl;
        }

        string IApiMetadataConfiguration.Folder
        {
            get => Directory.GetCurrentDirectory();
        }

        public string NamespacePrefix { get; set; }
        
        public IReadOnlyDictionary<string, int> EducationOrganizationIdOverrides { get; set; }

        public IEnumerable<string> UnifiedProperties { get; set; }

        string IOAuthSessionToken.SessionToken { get; set; }

        // IOAuthTokenConfiguration
        string IOAuthTokenConfiguration.Key
        {
            get => OAuthKey;
        }

        string IOAuthTokenConfiguration.Secret
        {
            get => OAuthSecret;
        }

        string IOAuthTokenConfiguration.Url
        {
            get => OAuthUrl;
        }

        // ISdkLibraryConfiguration
        string ISdkLibraryConfiguration.Path
        {
            get => SdkLibraryPath;
        }

        private static string GetPath(string basePath, string relativeUrl)
            => !string.IsNullOrWhiteSpace(basePath)
                ? basePath.AddPath(relativeUrl)
                : null;

        public static SmokeTestsConfiguration Create(IConfigurationRoot configuration)
        {
            if (!TestSet.TryParse(configuration.GetValue<string>("TestSet"), out TestSet testSet))
            {
                throw new ArgumentException($"Unknown TestSet '{configuration.GetValue<string>("TestSet")}'");
            }

            ApiMode.TryParse(configuration.GetValue<string>("OdsApi:ApiMode"), out ApiMode apiMode);

            return new SmokeTestsConfiguration
            {
                ApiUrl = ResolvedUrl(configuration.GetValue<string>("OdsApi:ApiUrl")),
                MetadataUrl = ResolvedUrl(configuration.GetValue<string>("OdsApi:MetadataUrl")),
                DependenciesUrl = ResolvedUrl(configuration.GetValue<string>("OdsApi:DependenciesUrl")),
                OAuthUrl = configuration.GetValue<string>("OdsApi:OAuthUrl"),
                OAuthKey = configuration.GetValue<string>("OdsApi:Key"),
                OAuthSecret = configuration.GetValue<string>("OdsApi:Secret"),
                SchoolYear = configuration.GetValue<int?>("OdsApi:SchoolYear"),
                NamespacePrefix = configuration.GetValue<string>("NamespacePrefix"),
                EducationOrganizationIdOverrides =
                    configuration.GetSection("EducationOrganizationIdOverrides").Get<IReadOnlyDictionary<string, int>>(),
                UnifiedProperties = configuration.GetSection("UnifiedProperties").Get<IEnumerable<string>>(),
                SdkLibraryPath = configuration.GetValue<string>("SdkLibraryPath"),
                TestSet = testSet,
                ApiMode = apiMode
            };

            string ResolvedUrl(string url)
            {
                return apiMode == ApiMode.YearSpecific
                    ? Regex.Replace(

                        // https://regex101.com/r/KywmUK/1
                        url, @"\/(?<year>\b\d{4}\b)", $"/{configuration.GetValue<string>("OdsApi:SchoolYear")}", RegexOptions.None)
                    : url;
            }
        }
    }
}
