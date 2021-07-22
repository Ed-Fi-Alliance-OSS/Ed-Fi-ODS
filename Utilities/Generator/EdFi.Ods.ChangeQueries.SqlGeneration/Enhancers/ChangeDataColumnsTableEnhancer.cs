using System.Linq;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Generator;
using EdFi.Ods.Generator.Database.DataTypes;
using EdFi.Ods.Generator.Database.NamingConventions;
using EdFi.Ods.Generator.Database.TemplateModelProviders;

namespace EdFi.Ods.ChangeQueries.SqlGeneration.Enhancers
{
    public class ChangeDataColumnsTableEnhancer : ITableEnhancer
    {
        private readonly IDatabaseNamingConvention _databaseNamingConvention;
        private readonly IDatabaseTypeTranslator _databaseTypeTranslator;

        public ChangeDataColumnsTableEnhancer(
            IDatabaseNamingConventionFactory databaseNamingConventionFactory,
            IDatabaseTypeTranslatorFactory databaseTypeTranslatorFactory,
            IDatabaseOptions options)
        {
            string databaseEngine = options.DatabaseEngine;
            
            _databaseNamingConvention = databaseNamingConventionFactory.CreateNamingConvention(databaseEngine);
            _databaseTypeTranslator = databaseTypeTranslatorFactory.CreateTranslator(databaseEngine);
        }
        
        public Table EnhanceTable(Entity entity, Table table, dynamic tableProps)
        {
            if (entity.IsDerived)
            {
                tableProps.ChangeDataColumns = ChangeQueriesHelpers.GetChangeQueriesPropertiesForColumns(entity)
                    .SelectMany((p, i) => p.ExpandForApiResourceData(i, _databaseNamingConvention, _databaseTypeTranslator))
                    // .Select((c, i) => new SimpleColumn(c.ColumnName, c.DataType, c.SelectExpression))
                    .ToArray();
                    // .Select(
                    //     c => new Dictionary<string, object>()
                    //     {
                    //         { "ColumnName", c.ColumnName },
                    //         { "ColumnDataType", c.ColumnDataType },
                    //     });
            }
            else
            {
                tableProps.ChangeDataColumns = ChangeQueriesHelpers.GetChangeQueriesPropertiesForColumns(entity)
                    .SelectMany((p, i) => p.ExpandForApiResourceData(i, _databaseNamingConvention, _databaseTypeTranslator))
                    .Select(
                        (c, i) => new SimpleColumn
                        {
                            IsFirst = i == 0,
                            ColumnName = c.ColumnName,
                            DataType = c.DataType,
                            SelectExpression = c.SelectExpression,
                        })
                    .ToArray();

                tableProps.Joins = ChangeQueriesHelpers.GetChangeQueriesPropertiesForColumns(entity)
                    .SelectMany((p, i) => p.JoinForApiResourceData(i, _databaseNamingConvention))
                    .ToArray();
            }
            
            return table;
        }
    }
}