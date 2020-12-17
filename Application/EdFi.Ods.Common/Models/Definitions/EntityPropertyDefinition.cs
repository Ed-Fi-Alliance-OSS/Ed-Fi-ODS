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

namespace EdFi.Ods.Common.Models.Definitions
{
    public class EntityPropertyDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityPropertyDefinition" /> class.
        /// </summary>
        public EntityPropertyDefinition() { }

        /// <summary>
        /// Initializes an <see cref="EntityPropertyDefinition"/> for adding to the domain model.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <param name="propertyType">The property type <see cref="PropertyType"/> for the property.</param>
        /// <param name="columnNameByDatabaseEngine">The dictionary that provides physical column names by database engine.</param>
        /// <param name="description">The description of the property.</param>
        /// <param name="isIdentifying">If the property is an identifier.</param>
        /// <param name="isServerAssigned">If the property is assigned by the server.</param>
        /// <param name="isDeprecated">If the property is deprecated.</param>
        /// <param name="deprecationReasons">The deprecation reason messages.</param>
        public EntityPropertyDefinition(
            string propertyName,
            PropertyType propertyType,
            string description = null,
            bool isIdentifying = false,
            bool isServerAssigned = false,
            bool isDeprecated = false,
            string[] deprecationReasons = null,
            IDictionary<DatabaseEngine, string> columnNameByDatabaseEngine = null)
        {
            PropertyName = propertyName;
            ColumnNames = columnNameByDatabaseEngine ?? new Dictionary<DatabaseEngine, string>();
            PropertyType = propertyType;
            Description = description;
            IsIdentifying = isIdentifying;
            IsServerAssigned = isServerAssigned;
            IsDeprecated = isDeprecated;
            DeprecationReasons = deprecationReasons;
        }

        private IDictionary<DatabaseEngine, string> _columnNames;

        [JsonConverter(typeof(DictionaryStringByDatabaseEngine))]
        public IDictionary<DatabaseEngine, string> ColumnNames
        {
            get
            {
                if (_columnNames == null)
                {
                    _columnNames = new Dictionary<DatabaseEngine, string> {{DatabaseEngine.SqlServer, PropertyName}};
                }

                return _columnNames;
            }
            set => _columnNames = value;
        }
        
        public string PropertyName { get; set; }

        public PropertyType PropertyType { get; set; }

        public string Description { get; set; }

        public bool IsIdentifying { get; set; }

        public bool IsServerAssigned { get; set; }

        public bool IsDeprecated { get; set; }

        public string[] DeprecationReasons { get; set; }
    }
}
