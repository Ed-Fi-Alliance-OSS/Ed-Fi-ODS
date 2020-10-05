// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using EdFi.Common.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Standard;

namespace EdFi.Ods.WebApi.ProfileSpecFlowTests
{
    public static class StepsHelper
    {
        public static List<string> GetPropertyNames(Dictionary<string, object> data)
        {
            if (data == null)
            {
                return new List<string>();
            }

            var propertyNames = data.Keys

                // Don't ever include boilerplate properties in the count
                .Where(p => !IsETag(p) && !IsExtension(p) && !p.EndsWithIgnoreCase("CreatedByOwnershipTokenId"))
                .OrderBy(x => x)
                .ToList();

            return propertyNames;
        }

        public static bool IsETag(string propertyName)
            => propertyName.EqualsIgnoreCase("ETag")
               || propertyName.EqualsIgnoreCase("_etag");

        public static bool IsExtension(string propertyName)
            => propertyName.EqualsIgnoreCase("Extension")
               || propertyName.EqualsIgnoreCase("_ext");

        public static MethodInfo GetMapperMethod<TEntity>()
        {
            string entityName = typeof(TEntity).Name;

            string mapperTypeName =
                $"{EdFiConventions.BuildNamespace(Namespaces.Entities.Common.BaseNamespace, EdFiConventions.ProperCaseName)}.{entityName}Mapper";

            // Embedded convention - Mapper type namespace
            var mapperType = Type.GetType($"{mapperTypeName}, {typeof(Marker_EdFi_Ods_Standard).Assembly.GetName().Name}");

            const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

            var mapperMethod = mapperType.GetMethod("MapTo", bindingFlags);

            if (mapperMethod != null)
            {
                return mapperMethod;
            }

            mapperMethod = mapperType.GetMethod("MapDerivedTo", bindingFlags);

            if (mapperMethod == null)
            {
                throw new Exception($"Unable to find MapTo or MapDerivedTo method on type '{mapperType.FullName}'.");
            }

            return mapperMethod;
        }
    }
}
