// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using NHibernate.Type;
using System;
using System.Collections.Generic;

namespace EdFi.Ods.Common.Infrastructure.SqlServer
{
    public class SqlServerStructuredMappings
    {
        public static readonly Dictionary<Type, string> StructuredTypeNameBySystemType = new()
        {
            {typeof(int), "dbo.IntTable"},
            {typeof(long), "dbo.BigIntTable"},
            {typeof(Guid), "dbo.UniqueIdentifierTable"}
        };

        public static readonly Dictionary<Type, IType> StructuredTypeBySystemType = new()
        {
            {typeof(int), new SqlServerStructured<int>()},
            {typeof(long), new SqlServerStructured<long>()},
            {typeof(Guid), new SqlServerStructured<Guid>()}
        };
    }
}
