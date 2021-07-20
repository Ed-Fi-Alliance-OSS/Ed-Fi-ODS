// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.IO;
using System.Reflection;
using EdFi.Ods.Common.Models;

namespace EdFi.Ods.Generator.Database.Domain
{
    public class ModelPathsDomainDefinitionsProviderSource : IDomainModelDefinitionsProviderSource
    {
        private readonly IEnumerable<string> _modelPaths;

        public ModelPathsDomainDefinitionsProviderSource(IModelOptions options)
        {
            _modelPaths = options.ModelPaths;
        }
        
        public IEnumerable<IDomainModelDefinitionsProvider> GetDomainModelDefinitionProviders()
        {
            var executionPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            
            foreach (string modelPath in _modelPaths)
            {
                string resolveModelPath = Path.IsPathRooted(modelPath)
                    ? modelPath
                    : Path.Combine(executionPath, modelPath);
                
                if (!File.Exists(resolveModelPath))
                {
                    throw new FileNotFoundException("Model file not found.", resolveModelPath);
                }
                
                yield return new DomainModelDefinitionsJsonFileSystemProvider(modelPath);
            }
        }
    }
}
