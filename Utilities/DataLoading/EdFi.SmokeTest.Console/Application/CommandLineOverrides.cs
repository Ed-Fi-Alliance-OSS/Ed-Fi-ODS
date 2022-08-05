// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using CommandLine;

namespace EdFi.SmokeTest.Console.Application
{
    public class CommandLineOverrides
    {
        [Option('b', "baseUrl", Required = false, HelpText = "The base url")]
        public string BaseUrl { get; set; }

        [Option('a', "apiurl", Required = false, HelpText = "(deprecated) The web API url (i.e. http://server/)")]
        public string ApiUrl { get; set; }

        [Option('k', "key", Required = false, HelpText = "The web API OAuth key")]
        public string OAuthKey { get; set; }

        [Option('l', "library", Required = false, HelpText = "The complete path to a compiled Ed-Fi SDK library")]
        public string Library { get; set; }

        [Option('m', "metadataurl", Required = false, HelpText = "(deprecated) The metadata url (i.e. http://server/metadata)")]
        public string MetadataUrl { get; set; }

        [Option(
            'n', "namespace", Required = false,
            HelpText = "Override the URI to use when generating namespace values (i.e. uri://ed-fi.org)")]
        public string Namespace { get; set; }

        [Option('o', "oauthurl", Required = false, HelpText = "(deprecated) The OAuth url (i.e. http://server/oauth)")]
        public string OAuthUrl { get; set; }

        [Option('s', "secret", Required = false, HelpText = "The web API OAuth secret")]
        public string OAuthSecret { get; set; }

        [Option(
            't', "testset", Required = false,
            HelpText = "The test set to run (i.e. NonDestructiveApi, NonDestructiveSdk, DestructiveSdk)")]
        public string TestSet { get; set; }

        [Option('y', "year", Required = false, HelpText = "The target school year for the web API (i.e. 2016)")]
        public int? SchoolYear { get; set; }

        [Option("instance-id", Required = false, HelpText = "ODS Instance id (e.g. District Id)")]
        public string InstanceId { get; set; }

        public static IDictionary<string, string> SwitchingMapping()
            => new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
            {
                {"-b", "OdsApi:Url"},
                {"-a", "OdsApi:ApiUrl"},
                {"-k", "OdsApi:Key"},
                {"-l", "SdkLibraryPath"},
                {"-m", "OdsApi:MetadataUrl"},
                {"-n", "NamespacePrefix"},
                {"-o", "OdsApi:OAuthUrl"},
                {"-s", "OdsApi:Secret"},
                {"-t", "TestSet"},
                {"-y", "OdsApi:SchoolYear"},
                {"--apiurl", "OdsApi:ApiUrl"},
                {"--key", "OdsApi:Key"},
                {"--library", "SdkLibraryPath"},
                {"--metadataurl", "OdsApi:MetadataUrl"},
                {"--namespace", "NamespacePrefix"},
                {"--oauthurl", "OdsApi:OAuthUrl"},
                {"--secret", "OdsApi:Secret"},
                {"--testset", "TestSet"},
                {"--year", "OdsApi:SchoolYear"},
                {"--instance-id", "OdsApi:InstanceId"},
                {"--baseurl", "OdsApi:Url"},
            };
    }
}
