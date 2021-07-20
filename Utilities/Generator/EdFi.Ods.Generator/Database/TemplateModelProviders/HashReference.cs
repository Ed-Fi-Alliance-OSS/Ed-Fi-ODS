using System.Collections.Generic;

namespace EdFi.Ods.Generator.Database.TemplateModelProviders
{
    // TODO: Move to NDE plugin, add as dynamic
    public class HashReference
    {
        public string ReferencedTableSchema { get; set; }

        public string ReferencedTableName { get; set; }

        public Column Column { get; set; }

        public string ConstraintName { get; set; }

        public string ReferenceMemberName { get; set; } // TODO: This needs to be processed for Postgres naming limitations

        /// <summary>
        /// The physical columns whose values are composed into the hash key.
        /// </summary>
        public IEnumerable<Column> ReferenceColumns { get; set; }

        public bool IsFirst { get; set; }

        public string IndexName { get; set; }
    }
}