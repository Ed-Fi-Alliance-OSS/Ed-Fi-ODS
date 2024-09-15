// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.Partitions.Controllers;

/// <summary>
/// Defines the interface for obtaining the <see cref="QueryBuilder" /> for the main Partitions query.
/// </summary>
public interface IPartitionsQueryBuilderProvider
{
    QueryBuilder GetQueryBuilder(Entity aggregateRootEntity, int number);
}
