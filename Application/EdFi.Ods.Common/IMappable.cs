// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common
{
    /// <summary>
    /// Defines a method for creating an exact copy (property for property) of a second, uninitialized
    /// instance of the same abstract entity type.
    /// </summary>
    public interface IMappable
    {
        /// <summary>
        /// Copies all properties of the current object to an uninitialized object of the same entity abstraction.
        /// </summary>
        /// <param name="target">An uninitialized instance (of the same abstract entity type) to be mapped from the current object.</param>
        void Map(object target);
    }
}
