// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using DatabaseSchemaReader.DataSchema;
using EdFi.Common;

namespace EdFi.Ods.CodeGen.Providers.Impl
{
    public class JsonTupleTableProvider : JsonFileProvider, ITupleTableProvider
    {
        private readonly Lazy<DatabaseTable> _tupleTable;

        public JsonTupleTableProvider(IMetadataFolderProvider metadataFolderProvider)
        {
            Preconditions.ThrowIfNull(metadataFolderProvider, nameof(metadataFolderProvider));

            _tupleTable = new Lazy<DatabaseTable>(
                () => Load<DatabaseTable>(
                    Path.Combine(metadataFolderProvider.GetStandardMetadataFolder(), "DatabaseTupleTable.generated.json")));
        }

        public DatabaseTable LoadTupleTable() => _tupleTable.Value;
    }
}
