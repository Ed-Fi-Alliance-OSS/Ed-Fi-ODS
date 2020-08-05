// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common
{
    /// <summary>
    /// Defines a method for implicitly created entity extension classes to indicate whether
    /// a given instance contains any data.
    /// </summary>
    public interface IImplicitEntityExtension
    {
        /// <summary>
        /// Indicates whether the implicitly created entity extension has child collections with items
        /// or non-null embedded object references.
        /// </summary>
        /// <returns><b>true</b> if the entity extension class has data; otherwise <b>false</b>.</returns>
        bool IsEmpty();
    }
}