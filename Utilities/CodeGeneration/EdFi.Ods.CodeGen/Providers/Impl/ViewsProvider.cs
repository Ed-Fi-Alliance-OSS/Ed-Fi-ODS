// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using DatabaseSchemaReader.DataSchema;
using EdFi.Ods.Common;

namespace EdFi.Ods.CodeGen.Providers.Impl
{
    public class ViewsProvider : JsonFileProvider, IViewsProvider
    {
        private readonly string _path;
        private List<DatabaseView> _views;

        public ViewsProvider(IMetadataFolderProvider metadataFolderProvider)
        {
            Preconditions.ThrowIfNull(metadataFolderProvider, nameof(metadataFolderProvider));
            _path = $@"{metadataFolderProvider.GetStandardMetadataFolder()}\DatabaseViews.generated.json";
        }

        public List<DatabaseView> LoadViews()
        {
            if (_views != null)
            {
                return _views;
            }

            return Load<List<DatabaseView>>(_path);
        }
    }
}
