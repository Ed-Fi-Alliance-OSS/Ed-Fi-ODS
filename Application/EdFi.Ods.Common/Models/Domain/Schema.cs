// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Common.Models.Domain
{
    public class Schema
    {
        /// <summary>
        /// Initializes a <see cref="Schema"/> for the domain model.
        /// </summary>
        /// <param name="logicalName">The friendly name of the schema.</param>
        /// <param name="physicalName">The database schema name.</param>
        /// <param name="version">The database schema version.</param>
        public Schema(string logicalName, string physicalName, string version = null)
        {
            if (logicalName == null)
            {
                throw new ArgumentNullException(nameof(logicalName));
            }

            if (physicalName == null)
            {
                throw new ArgumentNullException(nameof(physicalName));
            }

            if (string.IsNullOrWhiteSpace(logicalName))
            {
                throw new ArgumentException($"{nameof(logicalName)} must a be non-empty string.", nameof(logicalName));
            }

            if (string.IsNullOrWhiteSpace(physicalName))
            {
                throw new ArgumentException($"{nameof(physicalName)} must a be non-empty string.", nameof(physicalName));
            }

            LogicalName = logicalName;
            PhysicalName = physicalName;
            Version = version;
        }

        public string LogicalName { get; }

        public string PhysicalName { get; }

        public string Version { get; }

        public override string ToString()
        {
            return $"{LogicalName} ({PhysicalName})";
        }
    }
}
