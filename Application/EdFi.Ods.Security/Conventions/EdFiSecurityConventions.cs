// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common;

namespace EdFi.Ods.Security.Conventions
{
    public static class EdFiSecurityConventions
    {
        private static readonly string[] _profileSuffixes = {"_Readable", "_Writable"};
        
        /// <summary>
        /// Parses the proper-case schema name from the namespace of the resource <see cref="Type" />. 
        /// </summary>
        /// <param name="resourceType">The resource <see cref="Type" /> whose namespace is to be parsed.</param>
        /// <returns>The proper-case representation of the resource's schema.</returns>
        public static string ParseResourceSchemaProperCaseName(this Type resourceType)
        {
            string @namespace = resourceType.Namespace;

            return ParseResourceSchemaProperCaseName(@namespace);
        }

        /// <summary>
        /// Parses the proper-case schema name from the namespace of the resource <see cref="Type" />. 
        /// </summary>
        /// <param name="resourceTypeNamespace">The <see cref="Type.Namespace" /> of the <see cref="Type" /> of the resource whose namespace is to be parsed.</param>
        /// <returns>The proper-case representation of the resource's schema.</returns>
        public static string ParseResourceSchemaProperCaseName(string resourceTypeNamespace)
        {
            if (resourceTypeNamespace == null || !resourceTypeNamespace.StartsWith(Namespaces.Resources.BaseNamespace))
            {
                throw new ArgumentException("Supplied type's namespace does not start with the expected namespace used for Ed-Fi API resource classes.");
            }

            if (resourceTypeNamespace.Contains(".Extensions."))
            {
                throw new ArgumentException("Resource extensions are not authorizable so schema name extraction from the class namespace is not supported.");
            }

            int startPos = Namespaces.Resources.BaseNamespace.Length + 1;
            int[] indices = IndicesOf(resourceTypeNamespace.Substring(startPos), ".");

            // Detect Profile-based resource
            string schema;
	
            foreach (string profileSuffix in _profileSuffixes)
            {
                if (TryParseSchemaFromProfileNamespace(resourceTypeNamespace, indices, profileSuffix, out schema))
                {
                    return schema;
                }
            }
	
            if (indices.Length != 1)
            {
                throw new Exception($"Unexpected number of namespace segments while extracting schema name from namespace '{resourceTypeNamespace}'.");
            }
	
            return resourceTypeNamespace.Substring(startPos + 1 + indices[0]);
        }
        
        private static bool TryParseSchemaFromProfileNamespace(string @namespace, int[] indices, string profileSuffix, out string schema)
        {
            int startPos = Namespaces.Resources.BaseNamespace.Length + 1;

            if (@namespace.Contains(profileSuffix))
            {
                if (!@namespace.EndsWith(profileSuffix))
                {
                    throw new Exception("Resource classes with a base resource context for a Profile are not authorizable so schema name extraction from class namespace is not supported.");
                }
		
                schema = @namespace.Substring(startPos + indices[0] + 1, indices[1] - indices[0] - 1);
                return true;
            }

            schema = null;	
            return false;
        }

        private static int[] IndicesOf(string value, string separator)
        {
            return GetIndicesOf(value, separator).ToArray();
        }

        private static IEnumerable<int> GetIndicesOf(string value, string separator)
        {
            int pos = -1;
	
            do
            {
                pos = value.IndexOf(separator, pos + 1);
		
                if (pos >= 0)
                {
                    yield return pos;
                }
            } while (pos >= 0);
        }
    }
}
