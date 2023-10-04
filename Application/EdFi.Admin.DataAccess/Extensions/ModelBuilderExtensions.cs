// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EdFi.Admin.DataAccess.Extensions;

public static class ModelBuilderExtensions
{
    public static void MakeDbObjectNamesLowercase(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (entityType.GetTableName() is { } tableName)
            {
                entityType.SetTableName(tableName.ToLowerInvariant());
            }

            foreach (var property in entityType.GetProperties())
            {
                property.SetColumnName(property.GetColumnName().ToLowerInvariant());
            }
        }
    }

    public static void UseUnderscoredFkColumnNames(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            //  EF Core does not support the <navigation property name>_<principal key property name> convention
            //  for FK column names, so we have to do it manually update column names in the model to match the database
            foreach (var foreignKey in entityType.GetForeignKeys())
            {
                foreach (IMutableProperty foreignKeyProperty in foreignKey.Properties)
                {
                    foreignKeyProperty.SetColumnName(
                        $"{foreignKey.GetNavigation(true)?.TargetEntityType.ShortName() ?? foreignKey.PrincipalKey.DeclaringEntityType.ShortName()}_{foreignKey.PrincipalKey.Properties.Single().Name}");
                }
            }
        }
    }
}
