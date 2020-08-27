// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;

namespace EdFi.LoadTools.Engine.XmlLookupPipeline
{
    public class ComputeHashStep : ILookupPipelineStep
    {
        private readonly IHashProvider _hashProvider;

        public ComputeHashStep(IHashProvider hashProvider)
        {
            _hashProvider = hashProvider;
        }

        public Task<bool> Process(XmlLookupWorkItem item)
        {
            var hashBytes = _hashProvider.Hash(item.LookupXElement.ToString());
            var hash = _hashProvider.BytesToStr(hashBytes);
            item.HashString = hash;
            return Task.FromResult(true);
        }
    }
}
