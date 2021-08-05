// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CommandLine;
using EdFi.Ods.Generator.Database;

namespace EdFi.Ods.Generator
{
    public interface IGeneratorOptions
    {
        string OutputPath { get; set; }
        IEnumerable<string> Properties { get; set; }
        IEnumerable<string> Plugins { get; set; }
        IDictionary<string, string> PropertyByName { get; }
        // IDictionary<string, string> ContextValueByName { get; }
    }

    public interface IModelOptions
    {
        IEnumerable<string> ModelPaths { get; set; }
        string CapabilityStatementPath { get; set; }
    }

    public interface IDatabaseOptions
    {
        string DatabaseEngine { get; set; }
        
        string SchemaFilter { get; set; }
    }

    public interface IRenderingPropertiesEnhancer
    {
        void EnhanceProperties(IDictionary<string, string> properties);
    }
    
    public class Options : IGeneratorOptions, IModelOptions, IDatabaseOptions
    {
        private readonly Lazy<IDictionary<string, string>> _propertyByName;
        // private readonly Lazy<IDictionary<string, string>> _contextValueByName;

        public Options()
        {
            _propertyByName = new Lazy<IDictionary<string, string>>(
                () =>
                {
                    return Properties.Select(p => p.Split('='))
                        .Where(x => x.Length == 2)
                        .ToDictionary(x => x[0], x => x[1], StringComparer.OrdinalIgnoreCase);
                });
            
            // _contextValueByName = new Lazy<IDictionary<string, string>>(
            //     () =>
            //     {
            //         var generalContextValues = Context.Select(p => p.Split('='))
            //             .Where(x => x.Length == 2);
            //             
            //         var argsContextValues = this.GetType().GetInterfaces().Where(i => i.Name.EndsWith("Options"))
            //             .SelectMany(i => i.GetProperties().Where(p => p.GetCustomAttribute<RenderingContextAttribute>() != null && p.PropertyType == typeof(string)))
            //             .Select(p => new[] { p.Name, (string) p.GetValue(this)})
            //             .Where(x => !string.IsNullOrEmpty(x[1]));
            //         
            //         return generalContextValues
            //                 .Concat(argsContextValues)
            //                 .ToDictionary(x => x[0], x => x[1], StringComparer.OrdinalIgnoreCase);
            //     });
        }
        
        [Option('o', "outputPath", Required = true, HelpText = "The base path for rendered output files.")]
        public string OutputPath { get; set; }
        
        [Option('p', "property", HelpText = "Provides a named value to a template for rendering.")]
        public IEnumerable<string> Properties { get; set; }

        [Option('c', "context", HelpText = "Provides a named context value for determining which templates should be rendered.")]
        public IEnumerable<string> Context { get; set; }

        [Option('p', "plugin")]
        public IEnumerable<string> Plugins { get; set; }

        public IDictionary<string, string> PropertyByName
        {
            get => _propertyByName.Value;
        }
        
        // public IDictionary<string, string> ContextValueByName
        // {
        //     get => _contextValueByName.Value;
        // }
        
        // IDatabaseOptions
        [Option("databaseEngine", Required = false, HelpText = "The target database engine (e.g. SqlServer or PostgreSql).", Default = "SqlServer")]
        public string DatabaseEngine { get; set; }
        
        [Option("schemaFilter", Required = false, HelpText = "The schema whose artifacts should be included in code generation.", Default = "edfi")]
        public string SchemaFilter { get; set; }

        // IModelOptions
        [Option("model", HelpText = "The path to the API model file from MetaEd.")]
        public IEnumerable<string> ModelPaths { get; set; }

        [Option("capabilities", Required = false, HelpText = "Path to the capability statement to use for model-based generation.")]
        public string CapabilityStatementPath { get; set; }
    }

    // [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    // sealed class RenderingContextAttribute : Attribute { }
}
