// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.Engine.Mapping;

namespace EdFi.LoadTools.Test.MappingFactories
{
    public class MockMetadataMappingFactory : IMetadataMappingFactory
    {
        private readonly MetadataMapping[] _mappings;

        public MockMetadataMappingFactory(IEnumerable<MetadataMapping> mappings)
        {
            _mappings = mappings.ToArray();
        }

        public IEnumerable<MetadataMapping> GetMetadataMappings()
        {
            return _mappings;
        }
    }
}
