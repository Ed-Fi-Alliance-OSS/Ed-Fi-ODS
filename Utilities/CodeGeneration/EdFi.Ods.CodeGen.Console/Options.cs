// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using CommandLine;
using EdFi.Ods.CodeGen.Models;

namespace EdFi.Ods.CodeGen.Console
{
    public class Options
    {
        [Option('r', "repositoryPath", Required = false, HelpText = "Path to the code repository where the ODS is located.")]
        public string CodeRepositoryPath { get; set; }

        [Option('e', "engine", Required = false, HelpText = "Database engine type: SQLServer or PostgreSQL.", Default = EngineType.SQLServer)]
        public EngineType Engine { get; set; }

        [Option('v', "viewsFromDatabase", Required = false, HelpText = "Request view metadata from an existing empty database.", Default = false)]
        public bool ViewsFromDatabase { get; set; }
    }
}
