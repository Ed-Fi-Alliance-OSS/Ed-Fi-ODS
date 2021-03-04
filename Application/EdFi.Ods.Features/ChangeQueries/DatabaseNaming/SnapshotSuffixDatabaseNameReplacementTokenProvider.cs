// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Features.ChangeQueries.SnapshotContext;

namespace EdFi.Ods.Features.ChangeQueries.DatabaseNaming
{
    /// <summary>
    /// Implements a decorator that appends a snapshot-specific suffix to the database name
    /// to allow API requests to be serviced off a static snapshot of the ODS for the purposes
    /// of maintaining a fully isolated context for client API publishing using Change Queries.
    /// </summary>
    public class SnapshotSuffixDatabaseNameReplacementTokenProvider : IDatabaseNameReplacementTokenProvider
    {
        private readonly IDatabaseNameReplacementTokenProvider _next;
        private readonly ISnapshotContextProvider _snapshotContextProvider;

        public SnapshotSuffixDatabaseNameReplacementTokenProvider(
            IDatabaseNameReplacementTokenProvider next,
            ISnapshotContextProvider snapshotContextProvider)
        {
            _next = next;
            _snapshotContextProvider = snapshotContextProvider;
        }

        /// <summary>
        /// Gets the replacement token with a snapshot-specific suffix appended.
        /// </summary>
        /// <returns>The configured token replacement with a snapshot database suffix appended.</returns>
        /// <exception cref="FormatException">Occurs if the snapshot identifier in context
        /// is not an alphanumeric value.</exception>
        public string GetReplacementToken()
        {
            var snapshotContext = _snapshotContextProvider.GetSnapshotContext();

            if (snapshotContext == null || string.IsNullOrEmpty(snapshotContext.SnapshotIdentifier))
                return _next.GetReplacementToken();

            // To prevent possible tampering, snapshot identifier must only contain letters or numbers.
            if (snapshotContext.SnapshotIdentifier.Any(c => !(char.IsLetter(c) || char.IsDigit(c))))
                throw new FormatException("Invalid value for snapshot identifier.");

            return _next.GetReplacementToken() + $"_SS{snapshotContext.SnapshotIdentifier}";
        }
    }
}
