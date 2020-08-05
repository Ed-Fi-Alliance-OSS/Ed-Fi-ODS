// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using EdFi.LoadTools.ApiClient;

namespace EdFi.LoadTools.Engine
{
    public class XmlReferenceCacheFactory : IXmlReferenceCacheFactory, IXmlReferenceCacheProvider
    {
        private readonly ConcurrentDictionary<string, IXmlReferenceCache> _caches =
            new ConcurrentDictionary<string, IXmlReferenceCache>();

        private readonly IEnumerable<XmlModelMetadata> _metadata;

        public XmlReferenceCacheFactory(IEnumerable<XmlModelMetadata> metadata)
        {
            _metadata = metadata;
        }

        public void InitializeCache(string fileName)
        {
            if (!_caches.TryAdd(fileName, new XmlReferenceCache(_metadata)))
            {
                throw new Exception($"Failed to set up XmlReferenceCache for file {fileName}.");
            }
        }

        public void Cleanup()
        {
            _caches.Clear();
        }

        public IXmlReferenceCache GetXmlReferenceCache(string fileName)
        {
            IXmlReferenceCache result;

            if (!_caches.TryGetValue(fileName, out result))
            {
                throw new Exception($"Failed to find XmlReferenceCache for file {fileName}.");
            }

            return result;
        }
    }
}
