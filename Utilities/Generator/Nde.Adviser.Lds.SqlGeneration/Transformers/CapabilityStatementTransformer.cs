using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Generator;
using EdFi.Ods.Generator.Models;
using Newtonsoft.Json;

namespace Nde.Adviser.Lds.SqlGeneration.Transformers
{
    public class CapabilityStatementTransformer : IDomainModelDefinitionsTransformer
    {
        private readonly Lazy<CapabilityStatement> _capabilityStatement;

        public CapabilityStatementTransformer(Options options)
        {
            if (!string.IsNullOrEmpty(options.CapabilityStatementPath) && !File.Exists(options.CapabilityStatementPath))
            {
                throw new FileNotFoundException($"CapabilityStatement file not found at '{options.CapabilityStatementPath}'.");
            }
            
            _capabilityStatement = new Lazy<CapabilityStatement>(()
                => JsonConvert.DeserializeObject<CapabilityStatement>(File.ReadAllText(options.CapabilityStatementPath)));
        }
        
        public IEnumerable<DomainModelDefinitions> TransformDefinitions(IEnumerable<DomainModelDefinitions> definitions)
        {
            // var domainModelDefinitionsBySchema = definitions.ToDictionary(x => x.SchemaDefinition.PhysicalName, x => x);

            var statementResourcesWithHistory = _capabilityStatement.Value
                .rest.FirstOrDefault(r => r.mode == Mode.server)
                ?.resource.Where(r => r.readHistory);

            if (statementResourcesWithHistory == null)
            {
                return definitions;
            }

            var definitionsArray = definitions.ToArray();

            // Build semantic models from definitions
            var domainModel = new DomainModelBuilder(definitionsArray).Build();
            var resourceModel = domainModel.ResourceModel;

            foreach (var statementResource in statementResourcesWithHistory)
            {
                var parts = statementResource.type.Split("/", StringSplitOptions.RemoveEmptyEntries);
                var resource = resourceModel.GetResourceByApiCollectionName(parts[0], parts[1]);

                if (resource == null)
                {
                    throw new Exception($"Resource for type '{statementResource.type}' was not found in the model.");
                }

                var entity = resource.Entity;

                dynamic entityDefinition = definitionsArray
                    .SelectMany(d => d.EntityDefinitions.Where(def => def.Schema == entity.Schema && def.Name == entity.Name))
                    .FirstOrDefault();

                if (entityDefinition != null)
                {
                    entityDefinition.ReadHistory = true;
                    // Static approach --> (entityDefinition as IDynamicModel).DynamicProperties["ReadHistory"] = true;
                }
                else
                {
                    throw new Exception($"Unable to find entity definition for entity '{entity.Name}' in schema '{entity.Schema}'.");
                }
            }

            return definitionsArray;
        }
    }
}