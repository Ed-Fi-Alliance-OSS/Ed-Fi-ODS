using System.Linq;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Dynamic;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Generator.Common.Database.NamingConventions;
using EdFi.Ods.Generator.Common.Database.TemplateModelProviders;
using EdFi.Ods.Generator.Common.Options;

namespace EdFi.Ods.SqlGeneration.Enhancers
{
    public class AuthorizationTriggersEnhancer : ITableEnhancer
    {
        private readonly IDatabaseNamingConvention _databaseNamingConvention;

        public AuthorizationTriggersEnhancer(
            IDatabaseNamingConventionFactory databaseNamingConventionFactory,
            IDatabaseOptions databaseOptions)
        {
            _databaseNamingConvention = databaseNamingConventionFactory.CreateNamingConvention(databaseOptions.DatabaseEngine);
        }

        public Table EnhanceTable(Entity entity, Table table, dynamic tableProps)
        {
            if (!entity.IsEducationOrganizationDerivedEntity())
            {
                return table;
            }
            
            dynamic authorization = tableProps.Authorization ??= new DynamicModel();

            // Set trigger names
            authorization.InsertTriggerName = _databaseNamingConvention.TriggerName(entity, TriggerType.Insert);
            authorization.UpdateTriggerName = _databaseNamingConvention.TriggerName(entity, TriggerType.Update);
            authorization.DeleteTriggerName = _databaseNamingConvention.TriggerName(entity, TriggerType.Delete);

            // Identify parent key(s) for the EdOrg hierarchy 
            var parentEducationOrganizationProperties = entity.Properties.Where(p => 
                p.IncomingAssociations.Any(a => 
                    a.AssociationType == AssociationViewType.ManyToOne
                    && (a.OtherEntity.IsEducationOrganizationBaseEntity() 
                        || a.OtherEntity.IsEducationOrganizationDerivedEntity())))
                .ToArray();
                
            var parentEducationOrganizationColumns = parentEducationOrganizationProperties
                .Select((p, i) =>
                {
                    // Find the column for the property
                    dynamic column = table.ForeignKeys
                        .SelectMany(fk => fk.ThisColumns)
                        .First(c => ModelComparers.EntityPropertyNameOnly.Equals(c.EntityProperty, p));

                    // Create an Authorization model object to provide the iteration context
                    column.Authorization ??= new DynamicModel();
                    column.Authorization.IsFirst = (i == 0);

                    return column as Column;
                })
                .ToArray();

            authorization.HasParentEducationOrganizationColumns = parentEducationOrganizationColumns.Any();
            authorization.ParentEducationOrganizationColumns = parentEducationOrganizationColumns;
            
            return table;
        }
    }
}