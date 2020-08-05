// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common
{
    /// <summary>
    /// Defines a method for setting a back-reference to a child entity's parent.
    /// </summary>
    public interface IChildEntity
    {
        /// <summary>
        /// Set the child entity's parent reference.
        /// </summary>
        /// <param name="value">The parent reference for the current child entity.</param>
        void SetParent(object value);
    }
}
