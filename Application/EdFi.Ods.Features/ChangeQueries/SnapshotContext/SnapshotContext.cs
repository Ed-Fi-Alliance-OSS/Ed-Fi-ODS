// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Features.ChangeQueries.SnapshotContext
{
    /// <summary>
    /// Provides contextual information related to the snapshot to be used to service the current API request.
    /// </summary>
    public class SnapshotContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SnapshotContext" /> class using the supplied snapshot identifier.
        /// </summary>
        /// <param name="snapshotIdentifier"></param>
        public SnapshotContext(string snapshotIdentifier)
        {
            SnapshotIdentifier = snapshotIdentifier;
        }

        /// <summary>
        /// Gets the snapshot identifier to be used to identify the read-only ODS database to be used
        /// to service the current API request. 
        /// </summary>
        public string SnapshotIdentifier { get; }
    }
}
