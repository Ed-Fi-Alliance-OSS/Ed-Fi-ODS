// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Configuration;
using System.Linq;
using EdFi.Common.Utils.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EdFi.Security.DataAccess.Contexts
{
    public class PostgresSecurityContext : SecurityContext
    {
        public PostgresSecurityContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.IsForeignKey())
                    {
                        //property.GetContainingForeignKeys().ForEach(fk => fk.SetConstraintName(fk.GetConstraintName()?.ToLowerInvariant()));
                    }

                    //property.SetColumnName(property.Name.ToLowerInvariant());
                }

                entityType.SetSchema("dbo");
            }
        }
    }
}
