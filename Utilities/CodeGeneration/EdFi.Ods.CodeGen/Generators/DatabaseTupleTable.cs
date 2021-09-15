// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.CodeGen.Providers;
using Newtonsoft.Json;

namespace EdFi.Ods.CodeGen.Generators
{
    public class DatabaseTupleTable : GeneratorBase
    {
        private readonly ITupleTableProvider _tupleTableProvider;

        public DatabaseTupleTable(ITupleTableProvider tablesProvider)
        {
            _tupleTableProvider = tablesProvider;
        }

        protected override object Build()
        {
            var dataTupleTable = _tupleTableProvider.LoadTupleTable();

            var tupleTable = new
            {
                SchemaOwner = dataTupleTable.SchemaOwner,
                Name = dataTupleTable.Name,
                Columns = dataTupleTable.Columns.Select(
                    c => new
                    {
                        Name = c.Name,
                        DbDataType = c.DbDataType,
                        IsPrimaryKey = c.IsPrimaryKey,
                        Length = c.Length,
                        Precision = c.Precision,
                        Scale = c.Scale,
                        Nullable = c.Nullable
                    }),
            };

            return new {Tables = JsonConvert.SerializeObject(tupleTable, Formatting.Indented)};
        }
    }
}
