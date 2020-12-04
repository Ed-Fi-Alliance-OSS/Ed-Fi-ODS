// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Api.Models
{
    public class AssemblyData
    {
        public string Path { get; set; }

        public string AssemblyName { get; set; }

        public string TemplateSet { get; set; }

        public bool IsProfile { get; set; }

        public bool IsExtension { get; set; }

        public override string ToString()
            => $"AssemblyName: {AssemblyName}{Environment.NewLine}Path: {Path}{Environment.NewLine}TemplateSet: {TemplateSet}";
    }
}
