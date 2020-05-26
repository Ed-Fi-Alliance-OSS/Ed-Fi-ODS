// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.IO;
using System.Text;
using EdFi.LoadTools.Engine;
using log4net;

namespace EdFi.LoadTools
{
    public static class LogContext
    {
        public static string BuildContextPrefix(ApiLoaderWorkItem resourceWorkItem)
        {
            return BuildContextPrefix(
                resourceWorkItem.InterchangeName, resourceWorkItem.SourceFileName,
                resourceWorkItem.ElementName, resourceWorkItem.HashString);
        }

        public static string BuildContextPrefix(string interchangeName, string fileName = null,
                                                string resourceName = null,
                                                string resourceHash = null)
        {
            var response = new StringBuilder();
            response.Append(interchangeName);

            if (!string.IsNullOrWhiteSpace(fileName))
            {
                response.Append(" " + Path.GetFileName(fileName));
            }

            if (!string.IsNullOrWhiteSpace(resourceName))
            {
                response.Append(" " + resourceName);
            }

            if (!string.IsNullOrWhiteSpace(resourceHash))
            {
                response.Append(" " + resourceHash);
            }

            response.Append(" ");
            return response.ToString();
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
