// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using CommandLine;

namespace EdFi.XmlLookup.Console.Application
{
    public class CommandLineOverrides
    {
        [Option('b', "baseUrl", Required = false, HelpText = "The base url")]
        public string BaseUrl { get; set; }

        [Option('a', "apiurl", Required = false, HelpText = "(deprecated) The web API url (i.e. http://server/)")]
        public string ApiUrl { get; set; }

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

        [Option('x', "xsd", Required = false, HelpText = "(deprecated) Path to a folder containing the Ed-Fi Xsd Schema files")]
        public string XsdFolder { get; set; }

        [Option('z', "xsdmetadataurl", Required = false, HelpText = "The XSD metadata url (i.e. http://server/metadata)")]
        public string XsdMetadataUrl { get; set; }

        public static IDictionary<string, string> SwitchingMapping()
            => new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
            {
                {"-b", "OdsApi:Url"},
                {"-a", "OdsApi:ApiUrl"},
                {"-d", "Folders:Data"},
                {"-k", "OdsApi:Key"},
                {"-f", "ForceMetadata"},
                {"-s", "OdsApi:Secret"},
                {"-m", "OdsApi:MetadataUrl"},
                {"-z", "OdsApi:XsdMetadataUrl"},
                {"-o", "OdsApi:OAuthUrl"},
                {"-p", "OdsApi:Profile"},
                {"-w", "Folders:Working"},
                {"-x", "Folders:Xsd"},
                {"--apiurl", "OdsApi:ApiUrl"},
                {"--data", "Folders:Data"},
                {"--key", "OdsApi:Key"},
                {"--secret", "OdsApi:Secret"},
                {"--metadataurl", "OdsApi:MetadataUrl"},
                {"--xsdmetadataurl", "OdsApi:XsdMetadataUrl"},
                {"--oauthurl", "OdsApi:OAuthUrl"},
                {"--profile", "OdsApi:Profile"},
                {"--working", "Folders:Working"},
                {"--xsd", "Folders:Xds"},
                {"--force", "ForceMetadata"},
                {"--baseurl", "OdsApi:Url"}
            };
    }
}
