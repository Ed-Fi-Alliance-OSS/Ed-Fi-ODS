// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Text;
using EdFi.Common.Extensions;
using EdFi.Ods.Common;

namespace EdFi.Ods.Api.Models
{
    public class XsdFileInformation
    {
        public string AssemblyName { get; set; }

        public string Version { get; set; }

        public SchemaNameMap SchemaNameMap { get; set; }

        public string[] SchemaFiles { get; set; }

        public bool IsCore() => SchemaNameMap.PhysicalName.EqualsIgnoreCase("edfi");

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"AssemblyName -> {AssemblyName}");
            sb.AppendLine($"Version -> {Version}");
            sb.AppendLine($"UrlSegment -> {SchemaNameMap.UriSegment}");

            return sb.ToString();
        }
    }
}
