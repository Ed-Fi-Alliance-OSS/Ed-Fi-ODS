// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Providers.Queries;

public static class EntityExtensions
{
    private const string _baseAlias = "b";
    private const string _standardAlias = "r";

    public static string RootTableAlias(this Entity aggregateRootEntity)
    {
        return aggregateRootEntity.IsDerived ? _baseAlias : _standardAlias;
    }
}
