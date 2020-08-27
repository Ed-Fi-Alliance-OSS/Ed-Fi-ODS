// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.CodeGen.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.CodeGen.Generators
{
    public class EntityRecordInterfaces : GeneratorBase
    {
        protected override object Build()
        {
            return new
            {
                CommonRecordsNamespace =
                    EdFiConventions.BuildNamespace(
                        Namespaces.Entities.Records.BaseNamespace,
                        TemplateContext.SchemaProperCaseName),
                Interfaces =
                    TemplateContext.DomainModelProvider.GetDomainModel()
                        .Entities
                        .Where(TemplateContext.ShouldRenderEntity)
                        .Select(
                            e => new
                            {
                                e.Schema,
                                AggregateRootName = e.Aggregate.AggregateRoot.Name,
                                EntityName = e.Name,
                                EntityProperties = e.EntityRecordInterfaceUnifiedProperties()
                                    .OrderBy(
                                        p => p.PropertyName)
                                    .Select(
                                        p => new
                                        {
                                            PropertyType = p.PropertyType.ToCSharp(true),
                                            CSharpSafePropertyName =
                                                p.PropertyName.MakeSafeForCSharpClass(e.Name)
                                        })
                            })
            };
        }
    }
}
