using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;

namespace EdFi.Ods.Generator.Database.Transformers
{
    public class IdAlternateIdentifierStripper : IDomainModelDefinitionsTransformer
    {
        public IEnumerable<DomainModelDefinitions> TransformDefinitions(IEnumerable<DomainModelDefinitions> definitions)
        {
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

                yield return domainModelDefinitions;
            }
        }
    }
}