// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using CommandLine;

namespace EdFi.BulkLoadClient.Console.Application
{
    public class CommandLineOverrides
    {
        [Option('a', "apiurl", Required = false, HelpText = "(deprecated) The web API url (i.e. http://server/)")]
        public string ApiUrl { get; set; }

        [Option('y', "year", Required = false, HelpText = "The target school year for the web API (i.e. 2016)")]
        public int? SchoolYear { get; set; }

        [Option('r', "retries", Required = false, HelpText = "The number of times to retry submitting a resource")]
        public int? MaxRetries { get; set; }

        [Option('d', "data", Required = false, HelpText = "Path to folder containing the data files to be submitted")]
        public string DataFolder { get; set; }

        [Option('k', "key", Required = false, HelpText = "The web API OAuth key")]
        public string OAuthKey { get; set; }

        [Option('s', "secret", Required = false, HelpText = "The web API OAuth secret")]
        public string OAuthSecret { get; set; }

        [Option('f', "force", Required = false, Default = false, HelpText = "Force reload of metadata from metadata url")]
        public bool ForceMetadata { get; set; }

        [Option('m', "metadataurl", Required = false, HelpText = "(deprecated) The metadata url (i.e. http://server/metadata)")]
        public string MetadataUrl { get; set; }

        [Option('o', "oauthurl", Required = false, HelpText = "(deprecated) The OAuth url (i.e. http://server/oauth)")]
        public string OAuthUrl { get; set; }

        [Option('p', "profile", Required = false, HelpText = "The name of an API profile to use (optional)")]
        public string Profile { get; set; }

        [Option('w', "working", Required = false, HelpText = "Path to a writable folder containing the working files")]
        public string WorkingFolder { get; set; }

        [Option('x', "xsd", Required = false, HelpText = "Path to a folder containing the Ed-Fi Xsd Schema files")]
        public string XsdFolder { get; set; }

        [Option(
            'n', "novalidation", Required = false, Default = false,
            HelpText = "Do not validate incoming XML documents against the XSD Schema")]
        public bool DoNotValidateXml { get; set; }

        [Option('c', "connectionlimit", Required = false, HelpText = "Max number of simultaneous API requests")]
        public int? ConnectionLimit { get; set; }

        [Option('t', "taskcapacity", Required = false, HelpText = "Maximum concurrent tasks to be buffered")]
        public int? TaskCapacity { get; set; }

        [Option('l', "maxRequests", Required = false, HelpText = "Max number of simultaneous API requests")]
        public int? MaxSimultaneousRequests { get; set; }

        [Option('g', "dependenciesurl", Required = false, HelpText = "The Dependencies endpoint url")]
        public string DependenciesUrl { get; set; }

        [Option("include-stats", Required = false, Default = false, HelpText = "(deprecated) Include timing stats")]
        public bool IncludeStats { get; set; }

        [Option('b', "baseUrl", Required = false, HelpText = "The base url")]
        public string BaseUrl { get; set; }

        [Option("instance-id", Required = false, HelpText = "ODS Instance id (e.g. District Id)")]
        public string InstanceId { get; set; }

        [Option('e', "extension", Required = false, HelpText = "The extension name to download Xsd Schema files for")]
        public string Extension { get; set; }

        public static IDictionary<string, string> SwitchingMapping()
            => new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
            {
                {"-a", "OdsApi:ApiUrl"},
                {"-y", "OdsApi:SchoolYear"},
                {"-r", "Concurrency:MaxRetries"},
                {"-d", "Folders:Data"},
                {"-k", "OdsApi:Key"},
                {"-s", "OdsApi:Secret"},
                {"-m", "OdsApi:MetadataUrl"},
                {"-o", "OdsApi:OAuthUrl"},
                {"-p", "OdsApi:Profile"},
                {"-w", "Folders:Working"},
                {"-x", "Folders:Xsd"},
                {"-c", "Concurrency:MaxSimultaneousApiRequests"},
                {"-t", "Concurrency:TaskCapacity"},
                {"-l", "Concurrency:MaxSimultaneousApiRequests"},
                {"-g", "OdsApi:DependenciesUrl"},
                {"-b", "OdsApi:Url"},
                {"-e", "OdsApi:Extension"},
                {"--apiurl", "OdsApi:ApiUrl"},
                {"--year", "OdsApi:SchoolYear"},
                {"--retries", "Concurrency:MaxRetries"},
                {"--data", "Folders:Data"},
                {"--key", "OdsApi:Key"},
                {"--secret", "OdsApi:Secret"},
                {"--metadataurl", "OdsApi:MetadataUrl"},
                {"--oauthurl", "OdsApi:OAuthUrl"},
                {"--profile", "OdsApi:Profile"},
                {"--working", "Folders:Working"},
                {"--xsd", "Folders:Xds"},
                {"--connectionlimit", "Concurrency:MaxSimultaneousApiRequests"},
                {"--taskcapacity", "Concurrency:TaskCapacity"},
                {"--maxrequests", "Concurrency:MaxSimultaneousApiRequests"},
                {"--dependenciesurl", "OdsApi:DependenciesUrl"},
                {"--baseurl", "OdsApi:Url"},
                {"--extension", "OdsApi:Extension"},
                {"--instance-id", "OdsApi:InstanceId"},
            };
    }
}
