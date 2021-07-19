using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;

namespace Nde.Adviser.Lds.SqlGeneration.Transformers
{
    public class MetaEdModelBoilerplateStripper : IDomainModelDefinitionsTransformer
    {
        public void TransformDefinitions(IEnumerable<DomainModelDefinitions> definitions)
        {
            // Build cohesive domain model
            // var domainModel = new DomainModelBuilder(definitions).Build();

            foreach (DomainModelDefinitions domainModelDefinitions in definitions)
            {
                foreach (var entityDefinition in domainModelDefinitions.EntityDefinitions)
                {
                    // entityDefinition.LocallyDefinedProperties = entityDefinition.LocallyDefinedProperties
                    //     .Where(p => !p.PropertyName.IsBoilerplate())
                    //     .ToArray();
                        
                    // Remove the alternate identifier provided for boilerplate "Id" property
                    entityDefinition.Identifiers = entityDefinition.Identifiers.Where(
                            i => i.IsPrimary
                                || !(i.IdentifyingPropertyNames.Length == 1 && i.IdentifyingPropertyNames.Single() == "Id"))
                        .ToArray();
                }
            }
        }
    }
}