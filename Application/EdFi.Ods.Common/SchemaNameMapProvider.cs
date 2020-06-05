// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common
{
    public class SchemaNameMapProvider : ISchemaNameMapProvider
    {
        private static readonly Regex _stateAbbreviationRegEx = new Regex("[A-Z]{2}");
        private readonly IReadOnlyDictionary<string, SchemaNameMap> _schemaNameMapByLogicalName;
        private readonly IReadOnlyDictionary<string, SchemaNameMap> _schemaNameMapByPhysicalName;
        private readonly IReadOnlyDictionary<string, SchemaNameMap> _schemaNameMapByProperCaseName;
        private readonly IReadOnlyDictionary<string, SchemaNameMap> _schemaNameMapByUriSegment;
        private readonly IReadOnlyList<SchemaNameMap> _schemaNameMaps;

        public SchemaNameMapProvider(IEnumerable<Schema> schemas)
        {
            _schemaNameMaps = schemas
                             .Select(x => CreateNameMap(x.LogicalName, x.PhysicalName))
                             .ToList()
                             .AsReadOnly();

            if (!_schemaNameMaps.Any())
            {
                throw new Exception("No Schema information was found on the domain model");
            }

            // Uniqueness is guaranteed during model creation using validation.
            _schemaNameMapByPhysicalName = _schemaNameMaps.ToDictionary(k => k.PhysicalName, v => v, StringComparer.InvariantCultureIgnoreCase);
            _schemaNameMapByLogicalName = _schemaNameMaps.ToDictionary(k => k.LogicalName, v => v, StringComparer.InvariantCultureIgnoreCase);
            _schemaNameMapByUriSegment = _schemaNameMaps.ToDictionary(k => k.UriSegment, v => v, StringComparer.InvariantCultureIgnoreCase);
            _schemaNameMapByProperCaseName = _schemaNameMaps.ToDictionary(k => k.ProperCaseName, v => v, StringComparer.InvariantCultureIgnoreCase);
        }

        public IReadOnlyList<SchemaNameMap> GetSchemaNameMaps()
        {
            return _schemaNameMaps;
        }

        public SchemaNameMap GetSchemaMapByPhysicalName(string name) => _schemaNameMapByPhysicalName[name];

        public SchemaNameMap GetSchemaMapByLogicalName(string name) => _schemaNameMapByLogicalName[name];

        public SchemaNameMap GetSchemaMapByUriSegment(string name) => _schemaNameMapByUriSegment[name];

        public SchemaNameMap GetSchemaMapByProperCaseName(string name) => _schemaNameMapByProperCaseName[name];

        private SchemaNameMap CreateNameMap(string logicalName, string physicalName)
        {
            if (string.IsNullOrWhiteSpace(logicalName))
            {
                throw new ArgumentException($"{nameof(logicalName)} must contain a non-zero length string.", nameof(logicalName));
            }

            if (string.IsNullOrWhiteSpace(physicalName))
            {
                throw new ArgumentException($"{nameof(physicalName)} must contain a non-zero length string.", nameof(physicalName));
            }

            return new SchemaNameMap(
                logicalName,
                physicalName,
                CreateUriSegment(logicalName),
                ExtensionsConventions.GetProperCaseNameForLogicalName(logicalName));
        }

        /// <summary>
        /// Returns a string that is converted to Uri-Segment format casing, by converting all composite
        ///     terms (that are not 2 letter abbreviations) 
        ///     to camel case (hyphenated text terms are processed individually).
        /// </summary>
        /// <param name="text">Mixed-case input.</param>
        /// <returns></returns>
        private string CreateUriSegment(string text)
        {
            // Special case (preserve state-level upper-cased abbreviations)
            if (text.Length == 2 && _stateAbbreviationRegEx.IsMatch(text))
            {
                return text;
            }

            return text.NormalizeCompositeTermForDisplay(' ', '-')
                       .Replace(' ', '-')
                       .ToLowerInvariant();
        }
    }
}
