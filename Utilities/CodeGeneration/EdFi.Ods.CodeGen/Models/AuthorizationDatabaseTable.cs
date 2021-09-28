// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using DatabaseSchemaReader.DataSchema;
using System;
using System.Collections.Generic;

namespace EdFi.Ods.CodeGen.Models
{
    public class AuthorizationDatabaseTable
    {
        public string SchemaOwner { get; set; }
        public string Name { get; set; }
        public IEnumerable<AuthorizationDatabaseColumn> Columns { get; set; }
    }

    public class AuthorizationDatabaseColumn
    {
        public string Name { get; set; }
        public string DbDataType { get; set; }
        public bool IsPrimaryKey { get; set; }
        public int? Length { get; set; }
        public int? Precision { get; set; }
        public int? Scale { get; set; }
        public bool Nullable { get; set; }
    }
}
