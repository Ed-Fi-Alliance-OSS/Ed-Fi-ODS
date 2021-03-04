// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Features.ChangeQueries.SnapshotContext
{
    /// <summary>
    /// Defines methods for getting and setting <see cref="SnapshotContext" /> for the current API request.
    /// </summary>
    public interface ISnapshotContextProvider
    {
        /// <summary>
        /// Gets the <see cref="SnapshotContext" /> for the current API request.
        /// </summary>
        /// <returns>The current context.</returns>
        SnapshotContext GetSnapshotContext();

        /// <summary>
        /// Sets the <see cref="SnapshotContext" /> for the current API request.
        /// </summary>
        /// <param name="snapshotContext">The snapshot context to be set.</param>
        void SetSnapshotContext(SnapshotContext snapshotContext);
    }
}
