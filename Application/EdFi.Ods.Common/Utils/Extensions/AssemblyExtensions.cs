// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.IO;
using System.Reflection;

namespace EdFi.Ods.Common.Utils.Extensions
{
    public static class AssemblyExtensions
    {
        public static string ReadResource(this Assembly assembly, string fullyQualifiedResourceName)
        {
            string result;

            using (var stream = assembly.GetManifestResourceStream(fullyQualifiedResourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }

            return result;
        }
    }
}
