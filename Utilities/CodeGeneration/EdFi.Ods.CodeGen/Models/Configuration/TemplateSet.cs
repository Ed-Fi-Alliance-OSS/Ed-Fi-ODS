﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EdFi.Ods.CodeGen.Models.Configuration
{
    public class TemplateSet
    {
        public string Name { get; set; }

        public string Driver { get; set; }

        public string OutputPath { get; set; }

        [JsonConverter(typeof(DatabaseEngineConverter))]
        public DatabaseEngine DatabaseEngine { get; set; }

        public override string ToString()
            => $@"
Name:        {Name}
Driver:      {Driver}
DatabaseEngine: {DatabaseEngine.Value}
OutputPath:  {OutputPath}
";
    }
}
