// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.LoadTools.ApiClient;

namespace EdFi.LoadTools.Engine.Factories
{
    public class JsonMetadataFactory : IMetadataFactory<JsonModelMetadata>
    {
        private readonly ISwaggerMetadataRetriever _swaggerMetadata;

        public JsonMetadataFactory(ISwaggerMetadataRetriever swaggerMetadata)
        {
            _swaggerMetadata = swaggerMetadata;
        }

        public IEnumerable<JsonModelMetadata> GetMetadata()
        {
            var task = _swaggerMetadata.GetMetadata().ConfigureAwait(false);

            var result = task.GetAwaiter().GetResult().ToList();

            return result
                .Where(
                    j => j.Property != "_etag"
                         && j.Property != "id"
                         && j.Property != "link"
                         && j.Property != "priorDescriptorId"
                         && j.Property != "_lastModifiedDate"
                         && !(j.Model.EndsWith("Descriptor") && j.Property == $"{j.Model}Id")
                )
                .Distinct(new ModelMetadataEqualityComparer<JsonModelMetadata>());
        }
    }
}
