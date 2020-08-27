// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Common.Models.Resource
{
    /// <summary>
    /// Defines methods related to obtaining Parent references.
    /// </summary>
    public interface IHasParent
    {
        /// <summary>
        /// Gets the parent resource of the current item (for resource members, this represents the containing Resource class).
        /// </summary>
        ResourceClassBase Parent { get; }

        /// <summary>
        /// Gets the lineage of the current item (inclusive) within the current Resource (for resource members, the lineage ends with the containing Resource class). 
        /// </summary>
        /// <returns>A collection of resource classes from the Resource to the current resource class (or resource class containing the current member).</returns>
        IEnumerable<ResourceClassBase> GetLineage();
    }
}
