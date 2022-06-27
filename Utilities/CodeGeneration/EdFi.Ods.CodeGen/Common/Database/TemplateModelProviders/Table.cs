using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Dynamic;

namespace EdFi.Ods.Generator.Common.Database.TemplateModelProviders
{
    public class Table : DynamicModel
    {
        public string Schema { get; set; }

        public string TableName { get; set; }

        public bool HasPrimaryKeyColumns
        {
            get => PrimaryKeyColumns.Any();
        }

        public IReadOnlyList<Column> PrimaryKeyColumns { get; set; }

        public bool HasContextualPrimaryKeyColumns
        {
            get => ContextualPrimaryKeyColumns.Any();
        }

        public IReadOnlyList<Column> ContextualPrimaryKeyColumns { get; set; }

        public IReadOnlyList<Column> ParentPrimaryKeyColumns
        {
            get =>
                PrimaryKeyColumns.Where(pkc => !ContextualPrimaryKeyColumns.Any(c => c.ColumnName == pkc.ColumnName))
                    .Select(
                        (pkc, i) => new Column
                        {
                            ColumnName = pkc.ColumnName,
                            DataType = pkc.DataType,
                            IsNullable = pkc.IsNullable,
                            IsFirst = i == 0,
                        }).ToArray();
        }

        public bool IsAggregateRoot { get; set; }

        public bool HasNonPrimaryOrForeignKeyColumns
        {
            get => NonPrimaryOrForeignKeyColumns.Any();
        }

        // TODO: ODS-5296 - Review for removal
        // public bool HasNonPrimaryOrForeignKeyColumnsOrReferences
        // {
        //     get => NonPrimaryOrForeignKeyColumns.Any(); // || References.Any();
        // }

        /// <summary>
        /// Gets the columns that are not part of any primary or foreign key.
        /// </summary>
        public IReadOnlyList<Column> NonPrimaryOrForeignKeyColumns { get; set; }

        public bool HasBoilerplateColumns
        {
            get => BoilerplateColumns.Any();
        }

        public bool HasDiscriminatorColumn => DiscriminatorColumn != null;
        
        public Column DiscriminatorColumn { get; set; }

        public IReadOnlyList<Column> BoilerplateColumns { get; set; }
        public IReadOnlyList<Column> BoilerplateColumnsUnsorted { get; set; }

        public string PrimaryKeyConstraintName { get; set; }

        public bool HasNonPrimaryKeyColumns => NonPrimaryKeyColumns.Any();

        /// <summary>
        /// Gets all columns that are not part of the primary key, but are also not the boilerplate columns.
        /// </summary>
        public IReadOnlyList<Column> NonPrimaryKeyColumns { get; set; }

        public IReadOnlyList<ForeignKey> ForeignKeys { get; set; }

        public string IdIndexName { get; set; }

        public bool IsDerived { get; set; }
        
        public bool IsBase { get; set; }

        public bool HasAlternateKey { get; set; }

        public string AlternateKeyConstraintName { get; set; }

        public bool HasServerAssignedSurrogateId { get; set; }

        public Column SurrogateIdColumn { get; set; }

        public IReadOnlyList<Column> AlternateKeyColumns { get; set; }

        public bool IsDescriptorTable { get; set; }

        public bool IsDescriptorBaseTable { get; set; }
        
        public bool IsEducationOrganizationDerivedTable { get; set; }

        public bool IsEducationOrganizationBaseTable { get; set; }

        public FullName FullName { get; set; }

        public bool IsPersonTypeTable { get; set; }

        // TODO: Move to LDS plugin
        public bool IsTemporalTable { get; set; }

        // TODO: Move to ChangeQueries plugin
        public bool KeyValuesCanChange { get; set; }
        
        public string BaseTableSchema { get; set; }
        public string BaseTableName { get; set; }
        public string BaseAlternateKeyConstraintName { get; set; }
        public IReadOnlyList<Column> BaseAlternateKeyColumns { get; set; }
        public Table AggregateRootTable { get; set; }

        // /// <summary>
        // /// Gets the reference back to the parent.
        // /// </summary>
        // public HashReference ParentReference { get; set; }
    }
}