// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.IO;
using EdFi.LoadTools.Engine;
using log4net;
using Newtonsoft.Json;

namespace EdFi.LoadTools
{
    public static class LogContext
    {
        public static string JsonPrettify(string json)
        {
            using (var stringReader = new StringReader(json))
               using (var stringWriter = new StringWriter())
               {
                   var jsonReader = new JsonTextReader(stringReader);
                   var jsonWriter = new JsonTextWriter(stringWriter) {Formatting = Formatting.Indented};
                   jsonWriter.WriteToken(jsonReader);
                   return stringWriter.ToString();
               }
        }

        public static string BuildContextPrefix(ApiLoaderWorkItem resourceWorkItem)
        {
            return BuildContextPrefix(
                resourceWorkItem.SourceFileName, resourceWorkItem.ElementName, resourceWorkItem.LineNumber,
                resourceWorkItem.Level);
        }

        public static string BuildContextPrefix(string fileName = null,
                                                string resourceName = null,
                                                int? lineNumber = null,
                                                int? level = null)
        {
            var contextParts = new List<string>();

            if (!string.IsNullOrWhiteSpace(fileName))
            {
                contextParts.Add(Path.GetFileName(fileName));
            }

            if (!string.IsNullOrWhiteSpace(resourceName))
            {
                contextParts.Add(resourceName);
            }

            if (lineNumber.HasValue)
            {
                contextParts.Add($"Line {lineNumber}");
            }

            if (level.HasValue)
            {
                contextParts.Add("Level: " + level.Value);
            }

            return string.Join(" ", contextParts);
        }

        public static IDisposable SetInterchangeName(string interchangeName)
        {
            return SetThreadContext(interchangeName);
        }

        public static IDisposable SetFileName(string fileName)
        {
            return SetThreadContext(fileName);
        }

        public static IDisposable SetResourceName(string resourceName)
        {
            return SetThreadContext(resourceName);
        }

        public static IDisposable SetResourceHash(string resourceHash)
        {
            return SetThreadContext(resourceHash);
        }

        private static IDisposable SetThreadContext(string message, string context = "NDC")
        {
            return ThreadContext.Stacks[context].Push(message);
        }
    }
}
