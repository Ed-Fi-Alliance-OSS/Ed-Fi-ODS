// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using EdFi.Common;
using EdFi.Ods.CodeGen.Models;

namespace EdFi.Ods.CodeGen.Providers.Impl
{
    public class JsonViewsProvider : JsonFileProvider, IAuthorizationDatabaseTableViewsProvider
    {
        private readonly Lazy<List<AuthorizationDatabaseTable>> _views;

        public JsonViewsProvider(IMetadataFolderProvider metadataFolderProvider)
        {
            Preconditions.ThrowIfNull(metadataFolderProvider, nameof(metadataFolderProvider));

            _views = new Lazy<List<AuthorizationDatabaseTable>>(
                () => Load<List<AuthorizationDatabaseTable>>(
                    Path.Combine(metadataFolderProvider.GetStandardMetadataFolder(), "DatabaseViews.generated.json")));
        }

        public List<AuthorizationDatabaseTable> LoadViews() => _views.Value;
    }
}
