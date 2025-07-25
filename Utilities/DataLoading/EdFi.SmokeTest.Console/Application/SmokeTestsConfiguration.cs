﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using EdFi.LoadTools;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.SmokeTest;
using Microsoft.Extensions.Configuration;

namespace EdFi.SmokeTest.Console.Application
{
    public class SmokeTestsConfiguration : IApiConfiguration, IApiMetadataConfiguration, IOAuthTokenConfiguration,
        IOAuthSessionToken, ISdkLibraryConfiguration, IDestructiveTestConfiguration
    {
        public string ApiUrl { get; set; }

        public string OAuthKey { get; set; }

        public string OAuthSecret { get; set; }

        public string OAuthUrl { get; set; }

        public string MetadataUrl { get; set; }

        public string XsdMetadataUrl { get; set; }

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

        public string SdkNamespacePrefix { get; set; }

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

        string ISdkLibraryConfiguration.SdkNamespacePrefix
        {
            get => SdkNamespacePrefix;
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

            return new SmokeTestsConfiguration
            {
                ApiUrl = ResolvedUrl(configuration.GetValue<string>("OdsApi:ApiUrl")),
                MetadataUrl = $"{ResolvedUrl(configuration.GetValue<string>("OdsApi:MetadataUrl"))}",
                XsdMetadataUrl = ResolvedUrl(configuration.GetValue<string>("OdsApi:XsdMetadataUrl")),
                DependenciesUrl = ResolvedUrl(configuration.GetValue<string>("OdsApi:DependenciesUrl")),
                OAuthUrl = ResolvedUrl(configuration.GetValue<string>("OdsApi:OAuthUrl")),
                OAuthKey = configuration.GetValue<string>("OdsApi:Key"),
                OAuthSecret = configuration.GetValue<string>("OdsApi:Secret"),
                NamespacePrefix = configuration.GetValue<string>("NamespacePrefix"),
                SdkNamespacePrefix = configuration.GetValue<string>("SdkNamespacePrefix"),
                EducationOrganizationIdOverrides =
                    configuration.GetSection("EducationOrganizationIdOverrides").Get<IReadOnlyDictionary<string, int>>(),
                UnifiedProperties = configuration.GetSection("UnifiedProperties").Get<IEnumerable<string>>(),
                SdkLibraryPath = configuration.GetValue<string>("SdkLibraryPath"),
                TestSet = testSet
            };

            string ResolvedUrl(string url)
            {
                if (url == null)
                {
                    return null;
                }

                return url;
            }
        }
    }
}
