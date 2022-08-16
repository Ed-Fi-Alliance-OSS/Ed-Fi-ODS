// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Providers {
    /// <summary>
    /// Defines an interface for providing a unique identification value to be used to
    /// delineate different ODS instances.
    /// </summary>
    /// <remarks>This interface and its implementations are used to facilitate caching of
    /// values that map to specific surrogate Ids that are unique to a particular ODS. For example,
    /// the same StudentUniqueId will be associated with a different surrogate Id (StudentUSI)
    /// in each ODS.</remarks>
    public interface IEdFiOdsInstanceIdentificationProvider
    {
        /// <summary>
        /// Gets a unique identifying value for the ODS currently in context.
        /// </summary>
        /// <returns>A unique integer value for Ed-Fi ODS instance.</returns>
        ulong GetInstanceIdentification();
    }
}
