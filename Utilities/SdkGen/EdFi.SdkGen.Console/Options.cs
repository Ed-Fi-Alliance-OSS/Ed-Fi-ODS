﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using CommandLine;
using CommandLine.Text;

namespace EdFi.SdkGen.Console
{
    public sealed class Options
    {
        private const string SdkCodeGenExecuteable = "sdk-generate.jar";
        private const string SdkCodegenVersionKey = "swagger-codgen-version";
        private const string SwaggerCodegeCliJarName = "swagger-codegen-cli";
        private const string CliDownloadUri = "https://oss.sonatype.org/content/repositories/releases/io/swagger/swagger-codegen-cli";

        [Option(
            'm',
            "metaDataEndpoint",
            Default = "http://localhost:54746/metadata?sdk=true",
            HelpText = "the swagger metadata endpoint to download"
        )]
        public string MetaDataEndpoint { get; set; }

        [Option(
            'v',
            "cliVersion",
            Default = "2.4.13",
            HelpText = "the version of swagger-codegen-cli to download")]
        public string CliVersion { get; set; }

        [Option(
            'n',
            "namespace",
            Default = "EdFi.OdsApi.Sdk",
            HelpText = "the root namespace for the generated SDK (default: EdFi.OdsApi.Sdk)")]
        public string Namespace { get; set; }

        [Option(
            'o',
            "output",
            Default = "./csharp",
            HelpText = "the output folder for the swagger generation")]
        public string OutputFolder { get; set; }

        [Option(
            'f',
            "forceCliUpdate",
            Default = false,
            HelpText = "force the update of the swagger-codgen-cli to the version specified")]
        public bool Force { get; set; }

        [Option(
            'p',
            "include-profiles",
            Default = false,
            HelpText = "include profiles in the generation of the assembly")]
        public bool IncludeProfiles { get; set; }

        [Option(
            'c',
            "include-composites",
            Default = false,
            HelpText = "include composites in the generation of the assembly")]
        public bool IncludeComposites { get; set; }

        [Option(
            'i',
            "include-identity",
            Default = false,
            HelpText = "include identity in the generation of the assembly")]
        public bool IncludeIdentity { get; set; }

        [Option(
            'k',
            "core-only",
            Default = false,
            HelpText = "include only Ed-Fi namespace in the generation of the assembly")]
        public bool CoreOnly { get; set; }
      
        public string CliVersionText() => $"{SdkCodegenVersionKey}:{CliVersion}";

        public string CliDownloadUrl() => $"{CliDownloadUri}/{CliVersion}/{SwaggerCodegeCliJarName}-{CliVersion}.jar";

        public string CliExecutableFullName() => Path.Combine(Environment.CurrentDirectory, SdkCodeGenExecuteable);
    }
}
