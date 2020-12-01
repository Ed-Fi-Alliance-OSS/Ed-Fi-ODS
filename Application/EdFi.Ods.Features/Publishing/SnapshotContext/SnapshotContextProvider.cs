// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Features.Publishing.SnapshotContext
{
    public class SnapshotContextProvider : ISnapshotContextProvider, IHttpContextStorageTransferKeys
    {
        private const string SnapshotContextKeyName = "SnapshotContextProvider.SnapshotContext";
        private readonly IContextStorage _contextStorage;

        public SnapshotContextProvider(IContextStorage contextStorage)
        {
            _contextStorage = contextStorage;
        }

        /// <summary>
        /// Gets the <see cref="SnapshotContext" /> for the current API request.
        /// </summary>
        /// <returns>The current context.</returns>
        public SnapshotContext GetSnapshotContext()
        {
            return _contextStorage.GetValue<SnapshotContext>(SnapshotContextKeyName);
        }

        /// <summary>
        /// Sets the <see cref="SnapshotContext" /> for the current API request.
        /// </summary>
        /// <param name="snapshotContext">The snapshot context to be set.</param>
        public void SetSnapshotContext(SnapshotContext snapshotContext)
        {
            _contextStorage.SetValue(SnapshotContextKeyName, snapshotContext);
        }

        /// <summary>
        /// Declare the <see cref="IContextStorage"/> keys that are read and written by the component
        /// and should be transferred from <see cref="HttpContext"/> to <see cref="CallContext"/> for background Tasks.
        /// </summary>
        /// <returns>A list of keys to be transferred from <see cref="HttpContext"/> to <see cref="CallContext"/>.</returns>
        IReadOnlyList<string> IHttpContextStorageTransferKeys.GetKeys()
        {
            return new[]
            {
                SnapshotContextKeyName
            };
        }
    }
}
