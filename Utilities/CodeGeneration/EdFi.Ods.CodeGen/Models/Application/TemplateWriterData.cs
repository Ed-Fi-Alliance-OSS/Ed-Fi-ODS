// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using EdFi.Ods.CodeGen.Models.Configuration;

namespace EdFi.Ods.CodeGen.Models.Application
{
    public class TemplateWriterData
    {
        public TemplateSet TemplateSet { get; set; }

        public object Model { get; set; }

        public string OutputPath { get; set; }
    }
}
