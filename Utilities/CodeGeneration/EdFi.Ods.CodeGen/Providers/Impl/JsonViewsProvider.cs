// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using DatabaseSchemaReader.DataSchema;
using EdFi.Common;

namespace EdFi.Ods.CodeGen.Providers.Impl
{
    public class JsonViewsProvider : JsonFileProvider, IViewsProvider
    {
        private readonly Lazy<List<DatabaseView>> _views;

        public JsonViewsProvider(IMetadataFolderProvider metadataFolderProvider)
        {
            Preconditions.ThrowIfNull(metadataFolderProvider, nameof(metadataFolderProvider));

            _views = new Lazy<List<DatabaseView>>(
                () => Load<List<DatabaseView>>(
                    Path.Combine(metadataFolderProvider.GetStandardMetadataFolder(), "DatabaseViews.generated.json")));
        }

        public List<DatabaseView> LoadViews() => _views.Value;
    }
}
