// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Models.Definitions
{
    public class SchemaDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaDefinition" /> class.
        /// </summary>
        public SchemaDefinition() { }

        /// <summary>
        /// Initializes a <see cref="SchemaDefinition"/> for the domain model.
        /// </summary>
        /// <param name="logicalName">The friendly name of the schema.</param>
        /// <param name="physicalName">The database schema name.</param>
        /// <param name="version">The database schema version.</param>
        public SchemaDefinition(string logicalName, string physicalName, string version = null)
        {
            LogicalName = logicalName;
            PhysicalName = physicalName;
            Version = string.IsNullOrWhiteSpace(version) ? null : version;
        }

        public string LogicalName { get; set; }

        public string PhysicalName { get; set; }

        public string Version { get; set; }
    }
}
