// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;

namespace GenerateSecurityGraphs.Models.AuthorizationMetadata
{
    public class Resource
    {
        public Resource(string claimName)
        {
            ClaimName = claimName;
        }

        public string ClaimName { get; set; }

        public List<ActionAndStrategy> ActionAndStrategyPairs { get; set; } = new List<ActionAndStrategy>();

        public Resource Parent { get; set; }

        public IEnumerable<Resource> Ancestors
        {
            get
            {
                if (Parent == null)
                {
                    yield break;
                }

                yield return Parent;

                foreach (var ancestor in Parent.Ancestors)
                {
                    yield return ancestor;
                }
            }
        }

        public override string ToString()
        {
            return ClaimName + string.Format(
                       "({{{0}}})",
                       string.Join("}, {", ActionAndStrategyPairs.Select(x => x.ToString())));
        }
    }
}
