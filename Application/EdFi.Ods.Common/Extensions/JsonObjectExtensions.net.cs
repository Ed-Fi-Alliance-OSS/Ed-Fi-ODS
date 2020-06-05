#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace EdFi.Ods.Common.Extensions
{
    public static class JsonObjectExtensions
    {
        public static bool EqualsEntity(
            this JArray jsonObject,
            object entity,
            IEnumerable<PropertyInfo> scalarSignatureProperties)
        {
            foreach (PropertyInfo scalarSignatureProperty in scalarSignatureProperties)
            {
                // TODO: May need to do special handling of dates?
                string entityValue = scalarSignatureProperty.GetValue(entity)
                                                            .ToString();

                if (jsonObject[scalarSignatureProperty.Name.ToCamelCase()]
                       .Value<string>() != entityValue)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ContainsKey(this JObject jsonObject, string key)
        {
            return jsonObject.Property(key) != null;
        }

        public static IEnumerable<JArray> ArrayObjects(this JObject jsonObject)
        {
            foreach (var obj in jsonObject)
            {
                var val = obj.Value;

                if (val.Type == JTokenType.Array)
                {
                    yield return val.Value<JArray>();
                }
            }
        }
    }
}
#endif