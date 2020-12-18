// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Dapper;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Api.Controllers.DataManagement.ResponseBuilding
{
    public class ResourceClassQuery
    {
        public ResourceClassQuery(ResourceClassBase resourceClass, SqlBuilder.Template template)
        {
            ResourceClass = resourceClass;
            Template = template;
        }

        public ResourceClassBase ResourceClass { get; set; }
        
        public SqlBuilder.Template Template { get; set; }
    }
}
