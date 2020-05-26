// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Linq;

namespace EdFi.Ods.CodeGen.Helpers
{
    public static class NamespaceHelper
    {
        public static string GetRelativeNamespace(string contextualNamespace, string fullNamespace)
        {
            string[] contextualNamespaceSegments = contextualNamespace.Split('.');
            string[] fullNamespaceSegments = fullNamespace.Split('.');

            return string.Join(".", fullNamespaceSegments.SkipWhile((x, i) => contextualNamespaceSegments[i] == x));
        }
    }
}
