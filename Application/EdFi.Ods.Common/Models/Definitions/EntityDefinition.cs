// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Common.Configuration;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EdFi.Ods.Common.Models.Definitions
{
    public class EntityDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityDefinition" /> class.
        /// </summary>
        public EntityDefinition() { }

        /// <summary>
        /// Initializes an <see cref="EntityDefinition"/> for adding to the domain model.
        /// </summary>
        /// <param name="schema">The name of the schema containing the entity.</param>
        /// <param name="name">The name of the entity.</param>
        /// <param name="locallyDefinedProperties">All the locally defined properties (properties not defined in other tables migrated through associations).</param>
        /// <param name="identifiers">The identifiers of the entity (i.e. primary and alternate keys).</param>
        /// <param name="tableNameByDatabaseEngine">The mapping of physical table names, by database engine.</param>
        /// <param name="isAbstract">Indicates whether or not the entity is abstract.</param>
        /// <param name="description">Documentation for the entity.</param>
        /// <param name="isDeprecated">If the property is deprecated.</param>
        /// <param name="deprecationReasons">The deprecation reason messages.</param>
        public EntityDefinition(
            string schema,
            string name,
            EntityPropertyDefinition[] locallyDefinedProperties,
            EntityIdentifierDefinition[] identifiers,
            bool isAbstract = false,
            string description = "",
            bool isDeprecated = false,
            string[] deprecationReasons = null,
            IDictionary<DatabaseEngine, string> tableNameByDatabaseEngine = null)
        {
            Schema = schema;
            Name = name;
            TableNames = tableNameByDatabaseEngine ?? new Dictionary<DatabaseEngine, string> { { DatabaseEngine.SqlServer, name } };
            LocallyDefinedProperties = locallyDefinedProperties;
            Identifiers = identifiers;
            IsAbstract = isAbstract;
            Description = description;
            IsDeprecated = isDeprecated;
            DeprecationReasons = deprecationReasons;
        }

        public string Schema { get; set; }

        public string Name { get; set; }

        private IDictionary<DatabaseEngine, string> _tableNames;

        [JsonConverter(typeof(DictionaryStringByDatabaseEngine))]
        public IDictionary<DatabaseEngine, string> TableNames
        {
            get
            {
                if (_tableNames == null)
                {
                    _tableNames = new Dictionary<DatabaseEngine, string> {{DatabaseEngine.SqlServer, Name}};
                }

                return _tableNames;
            }
            set
            {
                _tableNames = value;
            }
        }

        public EntityPropertyDefinition[] LocallyDefinedProperties { get; set; }

        public EntityIdentifierDefinition[] Identifiers { get; set; }

        public bool IsAbstract { get; set; }

        public string Description { get; set; }

        public bool IsDeprecated { get; set; }

        public string[] DeprecationReasons { get; set; }

        public override string ToString() => new FullName(Schema, Name).ToString();
    }
}
