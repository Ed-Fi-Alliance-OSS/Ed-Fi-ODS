// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EdFi.LoadTools.Engine.XmlLookupPipeline
{
    /// <summary>
    ///     When we hit this step, we have an identity to replace the lookup; save it for later.
    /// </summary>
    public class StoreIdentityForWritingStep : ILookupPipelineStep
    {
        private readonly IDictionary<string, XElement> _hashIdentities;

        public StoreIdentityForWritingStep(IDictionary<string, XElement> hashIdentities)
        {
            _hashIdentities = hashIdentities;
        }

        public Task<bool> Process(XmlLookupWorkItem item)
        {
            _hashIdentities[item.HashString] = item.IdentityXElement;
            return Task.FromResult(true);
        }
    }
}
