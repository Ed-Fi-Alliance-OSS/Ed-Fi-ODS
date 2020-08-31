// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Xml.Linq;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Features.Composites {
    public interface ICompositeDefinitionProcessor<in TBuilderContext, out TBuildResult>
        where TBuildResult : class
    {
        TBuildResult Process(
            XElement compositeDefinition,
            IResourceModel resourceModel,
            TBuilderContext builderContext);
    }
}