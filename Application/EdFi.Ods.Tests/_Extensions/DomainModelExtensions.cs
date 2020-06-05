// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Reflection;
using EdFi.Ods.Api.Common.Attributes;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Tests._Extensions
{
    public static class DomainModelExtensions
    {
        public static Entity GetEntity<TEntity>(this DomainModel domainModel)
        {
            var attribute = typeof(TEntity).GetCustomAttribute<SchemaAttribute>();

            return domainModel.EntityByFullName[new FullName(attribute.Schema, typeof(TEntity).Name)];
        }
    }
}
