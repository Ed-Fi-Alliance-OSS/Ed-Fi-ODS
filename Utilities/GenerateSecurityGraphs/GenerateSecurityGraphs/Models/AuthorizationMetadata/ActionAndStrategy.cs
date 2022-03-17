// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;

namespace GenerateSecurityGraphs.Models.AuthorizationMetadata
{
    public class ActionAndStrategy
    {
        public static readonly ActionAndStrategy Empty = new ActionAndStrategy();

        public HashSet<string> AuthorizationStrategy { get; set; }

        public string ActionName { get; set; }

        public Dictionary<string, HashSet<string>> StrategyOverridesByClaimSetName { get; } 
            = new Dictionary<string, HashSet<string>>();

        public override string ToString()
        {
            return $"{ActionName} ({(AuthorizationStrategy == null ? "*No Strategy*" : string.Join(", ", AuthorizationStrategy))})";
        }
    }
}
