// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.IO;
using System.Text;
using EdFi.LoadTools;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.SmokeTest;

namespace EdFi.SmokeTest.Console.Application
{
    public class Configuration : IApiConfiguration, IApiMetadataConfiguration, IOAuthTokenConfiguration,
                                 IOAuthSessionToken, ISdkLibraryConfiguration, IDestructiveTestConfiguration
    {
        public string ApiUrl { get; internal set; }

        public bool CommandLine { get; internal set; }

        public string OAuthKey { get; internal set; }

        public string OAuthSecret { get; internal set; }

        public string OAuthUrl { get; internal set; }

        public int? SchoolYear { get; internal set; }

        public string MetadataUrl { get; internal set; }

        public string SdkLibraryPath { get; internal set; }

        public TestSet TestSet { get; internal set; }

        private bool ValidApiUrl => Uri.IsWellFormedUriString(ApiUrl, UriKind.Absolute);

        private bool ValidOAuthUrl => Uri.IsWellFormedUriString(OAuthUrl, UriKind.Absolute);

        private bool ValidMetadataUrl => TestSet == TestSet.NonDestructiveSdk || Uri.IsWellFormedUriString(MetadataUrl, UriKind.Absolute);

        private bool ValidSdkLibraryPath => TestSet == TestSet.NonDestructiveApi || File.Exists(SdkLibraryPath);

        private bool ValidNamespacePrefix => TestSet != TestSet.NonDestructiveApi || Uri.IsWellFormedUriString(NamespacePrefix, UriKind.Absolute);

        public bool IsValid => ValidApiUrl && ValidOAuthUrl && ValidMetadataUrl && ValidSdkLibraryPath &&
                               ValidNamespacePrefix;

        public string ErrorText
        {
            get
            {
                var builder = new StringBuilder();

                if (!ValidApiUrl)
                {
                    builder.AppendLine("'a: apiurl is not a valid URL");
                }

                if (!ValidOAuthUrl)
                {
                    builder.AppendLine("o: oauthurl is not a valid URL");
                }

                if (!ValidMetadataUrl)
                {
                    builder.AppendLine("m: metadataurl is not a valid URL");
                }

                if (!ValidSdkLibraryPath)
                {
                    builder.AppendLine("l: library is not a valid file path");
                }

                if (!ValidNamespacePrefix)
                {
                    builder.AppendLine("n: namespace is not a valid URI");
                }

                return builder.ToString();
            }
        }

        // IApiConfiguration
        string IApiConfiguration.Profile => string.Empty;

        int IApiConfiguration.Retries => 1;

        int IThrottleConfiguration.MaxSimultaneousRequests => 1;

        int? IApiConfiguration.SchoolYear => SchoolYear;

        string IApiConfiguration.Url => ApiUrl;

        public int ConnectionLimit { get; set; }

        public int TaskCapacity { get; set; }

        // IApiMetadataConfiguration
        bool IApiMetadataConfiguration.Force => true;

        string IApiMetadataConfiguration.Url => SchoolYear.HasValue
            ? MetadataUrl.AddPath(SchoolYear.ToString())
            : MetadataUrl;

        string IApiMetadataConfiguration.DependenciesUrl => SchoolYear.HasValue
             ? GetPath(MetadataUrl, $"/data/v3/{SchoolYear}/dependencies")
             : GetPath(MetadataUrl, "/data/v3/dependencies");

        private static string GetPath(string basePath, string relativeUrl)
                => !string.IsNullOrWhiteSpace(basePath)
                ? basePath.AddPath(relativeUrl)
                : null;

        string IApiMetadataConfiguration.Folder => Directory.GetCurrentDirectory();

        public string NamespacePrefix { get; internal set; }

        string IOAuthSessionToken.SessionToken { get; set; }

        // IOAuthTokenConfiguration
        string IOAuthTokenConfiguration.Key => OAuthKey;

        string IOAuthTokenConfiguration.Secret => OAuthSecret;

        string IOAuthTokenConfiguration.Url => OAuthUrl;

        // ISdkLibraryConfiguration
        string ISdkLibraryConfiguration.Path => SdkLibraryPath;
    }
}
