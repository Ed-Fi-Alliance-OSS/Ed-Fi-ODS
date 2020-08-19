// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
namespace EdFi.LoadTools.Engine.ResourcePipeline
{
    /// <summary>
    ///     Filter resources fourth, because any additional work on the resource is unnecessary.
    /// </summary>
    public class FilterResourceStep : IResourcePipelineStep
    {
        private readonly IResourceHashCache _hashCache;

        public FilterResourceStep(IResourceHashCache xmlResourceHashCache)
        {
            _hashCache = xmlResourceHashCache;
        }

        public bool Process(ApiLoaderWorkItem resourceWorkItem)
        {
            if (_hashCache.Exists(resourceWorkItem.Hash))
            {
                return false;
            }

            _hashCache.Visited(resourceWorkItem.Hash);
            return true;
        }
    }
}
