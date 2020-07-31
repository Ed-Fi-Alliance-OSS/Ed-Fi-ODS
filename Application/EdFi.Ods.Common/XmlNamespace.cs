// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common
{
    public static class XmlNamespace
    {
        static XmlNamespace()
        {
            Namespace = "http://ed-fi.org/3.2.0-c";
            ExtensionPrefix = "EXTENSION";
        }

        public static string ExtensionPrefix { get; set; }

        public static string Namespace { get; set; }
    }
}
