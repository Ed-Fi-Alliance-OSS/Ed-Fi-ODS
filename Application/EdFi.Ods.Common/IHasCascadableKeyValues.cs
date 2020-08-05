// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Specialized;

namespace EdFi.Ods.Common
{
    /// <summary>
    /// Defines a method for getting and setting new primary key values (for performing 
    /// cascading updates) using an <see cref="OrderedDictionary"/>.
    /// </summary>
    public interface IHasCascadableKeyValues
    {
        /// <summary>
        /// Gets or sets the <see cref="OrderedDictionary"/> capturing the new key values that have
        /// not been modified directly on the entity.
        /// </summary>
        OrderedDictionary NewKeyValues { get; set; }
    }
}
