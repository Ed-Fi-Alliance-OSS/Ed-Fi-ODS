// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using EdFi.LoadTools.ApiClient;

namespace EdFi.LoadTools
{
    public static class ApiLoaderExtensions
    {
        public static string AddPath(this string first, string second)
        {
            if (string.IsNullOrEmpty(second))
            {
                return first;
            }

            if (string.IsNullOrEmpty(first))
            {
                return second;
            }

            return $"{first.TrimEnd('/')}/{second.TrimStart('/')}";
        }

        public static IEnumerable<string> GetUnorderedElementNames(this XmlSchemaObject obj)
        {
            var result = new List<string>();

            if (obj is XmlSchemaComplexType)
            {
                var ct = (XmlSchemaComplexType)obj;
                obj = ct.ContentTypeParticle;
            }

            if (obj is XmlSchemaChoice)
            {
                var choice = (XmlSchemaChoice)obj;

                foreach (var item in choice.Items.Cast<XmlSchemaObject>())
                {
                    result.AddRange(item.GetUnorderedElementNames());
                }
            }
            else if (obj is XmlSchemaSequence)
            {
                var seq = (XmlSchemaSequence)obj;

                foreach (var item in seq.Items.Cast<XmlSchemaObject>())
                {
                    result.AddRange(item.GetUnorderedElementNames());
                }
            }
            else if (obj is XmlSchemaElement)
            {
                var ele = (XmlSchemaElement)obj;
                result.Add(ele.Name);
            }

            return result;
        }
    }
}
