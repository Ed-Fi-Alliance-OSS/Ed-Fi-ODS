// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EdFi.LoadTools.Engine.XmlLookupPipeline
{
    public class AvoidDuplicateLookupsStep : ILookupPipelineStep
    {
        private readonly IDictionary<string, XElement> _hashIdentities;

        public AvoidDuplicateLookupsStep(IDictionary<string, XElement> hashIdentities)
        {
            _hashIdentities = hashIdentities;
        }

#pragma warning disable 1998
        public async Task<bool> Process(XmlLookupWorkItem item)
#pragma warning restore 1998
        {
            if (_hashIdentities.ContainsKey(item.HashString))
            {
                return false;
            }

            _hashIdentities.Add(item.HashString, item.IdentityXElement);
            return true;
        }
    }
}
