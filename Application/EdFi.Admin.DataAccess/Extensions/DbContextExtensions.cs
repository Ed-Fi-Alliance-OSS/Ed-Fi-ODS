// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EdFi.Admin.DataAccess.Extensions
{
    public static class DbContextExtensions
    {
        public static void DeleteAll<T>(this DbContext context) where T : class
        {
            foreach (var p in context.Set<T>().ToList())
            {
                context.Entry(p).State = EntityState.Deleted;
            }
        }
    }
}
