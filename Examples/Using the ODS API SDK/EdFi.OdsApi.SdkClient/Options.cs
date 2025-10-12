// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using CommandLine;

namespace EdFi.OdsApi.SdkClient
{
    internal class Options
    {
        [Option('u', "url", Required = true, HelpText = "The base URL of the ODS API.")]
        public required string OdsApiUrl { get; set; }

        [Option('k', "key", Required = true, HelpText = "The client key.")]
        public required string ClientKey { get; set; }

        [Option('s', "secret", Required = true, HelpText = "The client secret.")]
        public required string ClientSecret { get; set; }
    }
}
