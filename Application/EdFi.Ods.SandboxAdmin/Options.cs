// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using CommandLine;

namespace EdFi.Ods.SandboxAdmin
{
    public sealed class Options
    {
        [Option(
            "exitAfterSandboxCreation",
            Default = false,
            HelpText = "exit the application after sandbox creation is complete (default: false)"
        )]
        public bool ExitAfterSandboxCreation { get; set; }
        
        [Option(
            'e',
            "environment",
            Default = "production",
            HelpText = "the execution environment (default: production)")]
        public string CommandLineEnvironment { get; set; }
    }
}
