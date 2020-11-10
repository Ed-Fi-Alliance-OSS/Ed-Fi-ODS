// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdFi.Common.Inflection;

namespace EdFi.LoadTools.Common
{
    public static class PropertyInfoExtensions
    {
        public static IOrderedEnumerable<string> PossiblePropertyNames(this PropertyInfo propertyInfo,
            IEnumerable<string> schemaNames = null)
        {
            var possibleNames = new Func<PropertyInfo, string[]>[]
            {
                p => new[] {Inflector.MakeInitialUpperCase(p.DeclaringType?.Name) + Inflector.MakeInitialUpperCase(p.Name)},
                p => PrefixWithSchemaName(p.Name)
                    .ToArray(),
                p => new[] {Inflector.MakeInitialUpperCase(p.Name)},
                p => new[] {Inflector.CollapseNames(p.DeclaringType?.Name, p.Name)},
                p => Inflector.StripLeftTerms(p.Name)
                    .ToArray()
            };

            // Important: The IOrderedEnumerable and OrderBy clause here preserves the naming precedence in possible names
            return possibleNames.SelectMany(f => f(propertyInfo)).OrderBy(x => true);

            IEnumerable<string> PrefixWithSchemaName(string name)
            {
                if (schemaNames == null)
                {
                    yield break;
                }

                foreach (var schemaName in schemaNames)
                {
                    yield return Inflector.MakeInitialUpperCase(schemaName) + name;
                }
            }
        }
    }
}
