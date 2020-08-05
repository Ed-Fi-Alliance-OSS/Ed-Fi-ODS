// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace GenerateSecurityGraphs.Models.Query
{
    internal class ClaimsetResourceActionData
    {
        public string ClaimSetName { get; set; }

        public string ResourceName { get; set; }

        public string ActionName { get; set; }

        public string StrategyName { get; set; } // For future use.

        // This property implementation used for interactive testing purposes
        //public string StrategyName
        //{
        //    get
        //    {
        //        if (ClaimSetName == "SIS Vendor"
        //            && ResourceName == "course"
        //            && ActionName == "Read")
        //        {
        //            return "PrimaryRelationships";
        //            //return "NoFurtherAuthorizationRequired";
        //        }

        //        return null;
        //    }
        //    set
        //    {
        //        // Do nothing
        //    }
        //}
    }
}
