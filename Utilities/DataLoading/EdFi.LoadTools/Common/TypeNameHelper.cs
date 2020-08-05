// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Inflection;

namespace EdFi.LoadTools.Common
{
    public static class TypeNameHelper
    {
        public static bool CompareTypeNames(string resource, string key, string separator,
                                            IEnumerable<string> schemaNames = null)
        {
            var resourceName = CompositeTermInflector.MakeSingular(resource.Split('/').Last());

            if (schemaNames != null && schemaNames.Any())
            {
                return schemaNames.Any(
                    schemaName => key.Equals(
                        schemaName.Trim() + separator + resourceName,
                        StringComparison.InvariantCultureIgnoreCase));
            }

            return key.Equals(resourceName, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
