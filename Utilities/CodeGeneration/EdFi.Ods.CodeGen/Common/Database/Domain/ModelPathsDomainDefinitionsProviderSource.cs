// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.IO;
using System.Reflection;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Generator.Common.Options;
using log4net;

namespace EdFi.Ods.Generator.Common.Database.Domain
{
    public class ModelPathsDomainDefinitionsProviderSource : IDomainModelDefinitionsProviderSource
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(ModelPathsDomainDefinitionsProviderSource));
        
        private readonly IEnumerable<string> _modelPaths;

        public ModelPathsDomainDefinitionsProviderSource(IModelOptions options)
        {
            _modelPaths = options.ModelPaths;
        }
        
        public IEnumerable<IDomainModelDefinitionsProvider> GetDomainModelDefinitionProviders()
        {
            foreach (string modelPath in _modelPaths)
            {
                string resolveModelPath = Path.IsPathRooted(modelPath)
                    ? modelPath
                    : Path.Combine(GetExecutionBasePath(), modelPath);
                
                if (!File.Exists(resolveModelPath))
                {
                    throw new FileNotFoundException("Model file not found.", resolveModelPath);
                }
                
                _logger.Info($"Loading model file '{resolveModelPath}'...");
                
                yield return new DomainModelDefinitionsJsonFileSystemProvider(modelPath);
            }

            string GetExecutionBasePath()
            {
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
        }
    }
}
