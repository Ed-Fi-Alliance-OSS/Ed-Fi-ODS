// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Reflection;

namespace EdFi.Ods.Common.Expando
{
    internal static class Utilities
    {
        /// <summary>
        /// Helper routine that looks up a type name and tries to retrieve the
        /// full type reference in the actively executing assemblies.
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static Type GetTypeFromName(string typeName)
        {
            Type type = null;

            // try to find manually
            foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = ass.GetType(typeName, false);

                if (type != null)
                {
                    break;
                }
            }

            return type;
        }

        /// <summary>
        /// Converts a .NET type into an XML compatible type - roughly
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string MapTypeToXmlType(Type type)
        {
            if (type == typeof(string) || type == typeof(char))
            {
                return "string";
            }

            if (type == typeof(int) || type == typeof(int))
            {
                return "integer";
            }

            if (type == typeof(long) || type == typeof(long))
            {
                return "long";
            }

            if (type == typeof(bool))
            {
                return "boolean";
            }

            if (type == typeof(DateTime))
            {
                return "datetime";
            }

            if (type == typeof(float))
            {
                return "float";
            }

            if (type == typeof(decimal))
            {
                return "decimal";
            }

            if (type == typeof(double))
            {
                return "double";
            }

            if (type == typeof(float))
            {
                return "single";
            }

            if (type == typeof(byte))
            {
                return "byte";
            }

            if (type == typeof(byte[]))
            {
                return "base64Binary";
            }

            return null;

            // *** hope for the best
            //return type.ToString().ToLower();
        }

        public static Type MapXmlTypeToType(string xmlType)
        {
            xmlType = xmlType.ToLower();

            if (xmlType == "string")
            {
                return typeof(string);
            }

            if (xmlType == "integer")
            {
                return typeof(int);
            }

            if (xmlType == "long")
            {
                return typeof(long);
            }

            if (xmlType == "boolean")
            {
                return typeof(bool);
            }

            if (xmlType == "datetime")
            {
                return typeof(DateTime);
            }

            if (xmlType == "float")
            {
                return typeof(float);
            }

            if (xmlType == "decimal")
            {
                return typeof(decimal);
            }

            if (xmlType == "double")
            {
                return typeof(double);
            }

            if (xmlType == "single")
            {
                return typeof(float);
            }

            if (xmlType == "byte")
            {
                return typeof(byte);
            }

            if (xmlType == "base64binary")
            {
                return typeof(byte[]);
            }

            // return null if no match is found
            // don't throw so the caller can decide more efficiently what to do 
            // with this error result
            return null;
        }
    }
}
