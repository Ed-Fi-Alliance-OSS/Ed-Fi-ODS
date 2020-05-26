// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EdFi.LoadTools.Engine.Mapping
{
    public class MetadataMapping
    {
        public string RootName { get; set; } = string.Empty;

        public string SourceName { get; set; }

        public string TargetName { get; set; }

        public List<PropertyMapping> Properties { get; set; } = new List<PropertyMapping>();
    }

    public class PropertyMapping
    {
        public string SourceName { get; set; }

        public string SourceType { get; set; }

        public string TargetName { get; set; }

        public string TargetType { get; set; }

        public bool IsArray { get; set; }

        public string MappingStrategyType
        {
            get { return MappingStrategy.GetType().AssemblyQualifiedName; }
            set
            {
                var type = Type.GetType(value);

                if (type != null)
                {
                    MappingStrategy = (IMappingStrategy) Activator.CreateInstance(type);
                }
            }
        }

        [JsonIgnore]
        public IMappingStrategy MappingStrategy { get; set; }
    }
}
