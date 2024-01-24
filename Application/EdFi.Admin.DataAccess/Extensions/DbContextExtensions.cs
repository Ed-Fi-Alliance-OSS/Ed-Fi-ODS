// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Text.RegularExpressions;

namespace EdFi.Admin.DataAccess.Extensions
{
    public static class DbContextExtensions
    {
        public static string GetTableName<T>(this DbContext context)
            where T : class
        {
            var objectContext = ((IObjectContextAdapter) context).ObjectContext;

            return objectContext.GetTableName<T>();
        }

        public static string GetTableName<T>(this ObjectContext context)
            where T : class
        {
            var sql = context.CreateObjectSet<T>()
                             .ToTraceString();

            var regex = new Regex("FROM (?<table>.*) AS");
            var match = regex.Match(sql);

            var table = match.Groups["table"]
                             .Value;

            return table;
        }

        public static void DeleteAll<T>(this DbContext context) where T : class
        {
            foreach (var p in context.Set<T>())
            {
                context.Entry(p).State = EntityState.Deleted;
            }
        }
    }
}
