﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Api.Infrastructure.Pipelines.Steps;
using EdFi.Ods.Common.Infrastructure.Pipelines;

namespace EdFi.Ods.Api.Infrastructure.Pipelines.Factories
{
    /// <summary>
    /// Provides the core Ed-Fi ODS API steps for "GetById" access.
    /// </summary>
    public class GetPipelineStepsProvider : IGetPipelineStepsProvider
    {
        /// <summary>
        /// Provides the core Ed-Fi ODS API steps for "GetById" access.
        /// </summary>
        public Type[] GetSteps()
        {
            return new[]
                   {
                       typeof(GetEntityModelById<,,,>), 
                       typeof(DetectUnmodifiedEntityModel<,,,>), 
                       typeof(ResolveUniqueIds<,,,>),
                       typeof(MapEntityModelToResourceModel<,,,>)
                   };
        }
    }

    /// <summary>
    /// Provides the core Ed-Fi ODS API steps for "GetBySpecification" access.
    /// </summary>
    public class GetBySpecificationPipelineStepsProvider : IGetBySpecificationPipelineStepsProvider
    {
        public Type[] GetSteps()
        {
            return new[]
                   {
                       typeof(MapResourceModelToEntityModel<,,,>),
                       typeof(ResolveUsis<,,,>),
                       typeof(GetEntityModelsBySpecification<,,,>),
                       typeof(ResolveUniqueIds<,,,>),
                       typeof(MapEntityModelsToResourceModels<,,,>)
            };
        }
    }

    /// <summary>
    /// Provides the core Ed-Fi ODS API steps for "Upsert" persistence.
    /// </summary>
    public class UpsertPipelineStepsProvider : IUpsertPipelineStepsProvider
    {
        public virtual Type[] GetSteps()
        {
            return new[]
                   {
                       typeof(ValidateResourceModel<,,,>), 
                       typeof(ResolveUsis<,,,>),
                       typeof(MapResourceModelToEntityModel<,,,>), 
                       typeof(PersistEntityModel<,,,>)
                   };
        }
    }

    /// <summary>
    /// Provides the core Ed-Fi ODS API steps for "Delete" persistence.
    /// </summary>
    public class DeletePipelineStepsProvider : IDeletePipelineStepsProvider
    {
        public Type[] GetSteps()
        {
            return new[]
                   {
                       typeof(DeleteEntityModel<,,,>)
                   };
        }
    }
}
