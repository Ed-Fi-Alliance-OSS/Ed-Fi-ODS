// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.LoadTools.ApiClient;

namespace EdFi.LoadTools.Engine.Mapping
{
    public abstract class DoNotMapPropertyMapper : IMetadataMapper
    {
        protected abstract UnmappedProperty[] JsonProperties { get; }

        protected abstract UnmappedProperty[] XmlProperties { get; }

        public void CreateMetadataMappings(MetadataMapping mapping, List<ModelMetadata> sourceModels,
                                           List<ModelMetadata> targetModels)
        {
            targetModels.RemoveAll(
                j =>
                    JsonProperties.Any(m => j.Model == m.Model && m.PropertyPaths.Any(p => p == j.PropertyPath)));

            sourceModels.RemoveAll(
                x =>
                    XmlProperties.Any(m => x.Model == m.Model && m.PropertyPaths.Any(p => p == x.PropertyPath)));
        }

        protected class UnmappedProperty
        {
            public UnmappedProperty(string model, params string[] propertyPaths)
            {
                Model = model;
                PropertyPaths = propertyPaths;
            }

            public string Model { get; }

            public string[] PropertyPaths { get; }
        }
    }
}
