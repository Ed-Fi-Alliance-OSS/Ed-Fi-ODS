// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;
using EdFi.Ods.Generator.Database;

namespace EdFi.Ods.Generator
{
    public class Options
    {
        private readonly Lazy<IDictionary<string, string>> _propertyByName;

        public Options()
        {
            _propertyByName = new Lazy<IDictionary<string, string>>(
                () =>
                {
                    return Properties.Select(p => p.Split('='))
                        .Where(x => x.Length == 2)
                        .ToDictionary(x => x[0], x => x[1], StringComparer.OrdinalIgnoreCase);
                });
        }
        
        [Option('o', "outputPath", Required = true, HelpText = "The base path for rendered output files.")]
        public string OutputPath { get; set; }
        
        [Option('d', "databaseEngine", Required = false, HelpText = "Database engine type: SqlServer or PostgreSql.", Default = "SqlServer")]
        public string DatabaseEngine { get; set; }

        [Option('c', "capabilityStatement", Required = false, HelpText = "Path to the capability statement to use for model-based generation.")]
        public string CapabilityStatementPath { get; set; }

        [Option('m', "model", HelpText = "The path to the API model file from MetaEd.")]
        public IEnumerable<string> ModelPaths { get; set; }
        
        [Option('p', "property")]
        public IEnumerable<string> Properties { get; set; }

        [Option("plugin")]
        public IEnumerable<string> Plugins { get; set; }

        public IDictionary<string, string> PropertyByName
        {
            get => _propertyByName.Value;
        }
    }
}
