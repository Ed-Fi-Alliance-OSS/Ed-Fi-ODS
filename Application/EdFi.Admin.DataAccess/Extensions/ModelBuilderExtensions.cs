// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EdFi.Admin.DataAccess.Extensions;

public static class ModelBuilderExtensions
{
    public static void MakeDbObjectNamesLowercase(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (entityType.GetTableName() is not { } tableName)
            {
                continue;
            }

            entityType.SetTableName(tableName.ToLowerInvariant());

            foreach (var property in entityType.GetProperties())
            {
                property.SetColumnName(property.GetColumnName().ToLowerInvariant());
            }
        }
    }

    //  EF Core does not recognize the <navigation property name>_<principal key property name> convention
    //  for FK column names, so we update column names in the model metadata to match the database
    public static void UseUnderscoredFkColumnNames(this ModelBuilder modelBuilder)
    {
        foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            foreach (IMutableProperty foreignKeyProperty in foreignKey.Properties)
            {
                foreignKeyProperty.SetColumnName(
                    $"{foreignKey.GetNavigation(true)?.TargetEntityType.ShortName() ?? foreignKey.PrincipalKey.DeclaringEntityType.ShortName()}_{foreignKey.PrincipalKey.Properties.Single().Name}");
            }
        }
    }
}
