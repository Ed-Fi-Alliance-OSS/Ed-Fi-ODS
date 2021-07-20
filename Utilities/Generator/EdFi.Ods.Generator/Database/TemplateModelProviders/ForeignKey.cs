using System.Collections.Generic;

namespace EdFi.Ods.Generator.Database.TemplateModelProviders
{
    public class ForeignKey
    {
        public string ConstraintName { get; set; }

        public string ThisSchema { get; set; }
        public string ThisTableName { get; set; }
        public IEnumerable<Column> ThisColumns { get; set; }
        public string OtherSchema { get; set; }
        public string OtherTableName { get; set; }
        public IEnumerable<Column> OtherColumns { get; set; }

        public bool IsFromBase { get; set; }

        // public bool IsIdentifying { get; set; }

        public bool IsNavigable { get; set; }

        public bool IsUpdatable { get; set; }

        public bool IsOneToOne { get; set; }
    }
}