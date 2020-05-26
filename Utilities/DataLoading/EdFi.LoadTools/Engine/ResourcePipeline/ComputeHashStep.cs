// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
namespace EdFi.LoadTools.Engine.ResourcePipeline
{
    /// <summary>
    ///     Computing the hash of the element should be done first.
    ///     Presumably we will get the elements in the same order because they come from automated systems.
    /// </summary>
    public class ComputeHashStep : IResourcePipelineStep
    {
        private readonly IHashProvider _xmlHashProvider;

        public ComputeHashStep(IHashProvider xmlHashProvider)
        {
            _xmlHashProvider = xmlHashProvider;
        }

        public bool Process(ApiLoaderWorkItem resourceWorkItem)
        {
            var hash = _xmlHashProvider.Hash(resourceWorkItem.XElement.ToString());
            resourceWorkItem.SetHash(hash);
            return true;
        }
    }
}
