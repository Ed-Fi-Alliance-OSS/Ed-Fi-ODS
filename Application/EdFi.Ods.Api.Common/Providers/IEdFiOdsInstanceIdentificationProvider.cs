// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Common.Providers {
    /// <summary>
    /// Defines an interface for providing a unique identification value to be used to
    /// delineate different ODS instances.
    /// </summary>
    /// <remarks>This interface and its implementations are used to facilitate caching of
    /// values that are unique to a particular ODS.  For example, different sandbox ODSs may be
    /// based on the "minimal" template or the "populated" template with different types and
    /// descriptors values, and when there are year-specific ODSs, they will have different
    /// USI values for people.</remarks>
    public interface IEdFiOdsInstanceIdentificationProvider
    {
        /// <summary>
        /// Gets a unique identifying value for the ODS currently in context.
        /// </summary>
        /// <returns>A unique integer value (likely the GetHashCode value for the connection string).</returns>
        int GetInstanceIdentification();
    }
}
