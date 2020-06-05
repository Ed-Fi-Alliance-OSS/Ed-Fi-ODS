// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Specialized;

namespace EdFi.Ods.Common
{
    /// <summary>
    /// Defines an interface for obtaining alternate key values (unique key values which are not the primary key) in the form of an <see cref="OrderedDictionary"/>.
    /// </summary>
    public interface IHasAlternateKeyValues
    {
        /// <summary>
        /// Gets the alternate key values (unique key values which are not the primary key), in the form of an <see cref="OrderedDictionary"/>.
        /// </summary>
        /// <returns>The dictionary containing the name/value pairs of the alternate key fields.</returns>
        OrderedDictionary GetAlternateKeyValues();
    }
}
