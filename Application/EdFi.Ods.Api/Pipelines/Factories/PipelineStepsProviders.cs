// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Api.Pipelines.Steps;

namespace EdFi.Ods.Api.Pipelines.Factories
{
    /// <summary>
    /// Provides the core Ed-Fi ODS API steps for "GetById" access.
    /// </summary>
    public class GetPipelineStepTypesProvider : IGetPipelineStepTypesProvider
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
                typeof(MapEntityModelToResourceModel<,,,>)
            };
        }
    }

    /// <summary>
    /// Provides the core Ed-Fi ODS API steps for "GetBySpecification" access.
    /// </summary>
    public class GetBySpecificationPipelineStepTypesProvider : IGetBySpecificationPipelineStepTypesProvider
    {
        public Type[] GetSteps()
        {
            return new[]
            {
                typeof(MapResourceModelToEntityModel<,,,>),
                typeof(GetEntityModelsBySpecification<,,,>),
                typeof(MapEntityModelsToResourceModels<,,,>)
            };
        }
    }

    /// <summary>
    /// Provides the core Ed-Fi ODS API steps for "Upsert" persistence.
    /// </summary>
    public class PutPipelineStepTypesProvider : IPutPipelineStepTypesProvider
    {
        public virtual Type[] GetSteps()
        {
            return new[]
            {
                typeof(ValidateResourceModel<,,,>),
                typeof(MapResourceModelToEntityModel<,,,>),
                typeof(PersistEntityModel<,,,>)
            };
        }
    }

    /// <summary>
    /// Provides the core Ed-Fi ODS API steps for "Delete" persistence.
    /// </summary>
    public class DeletePipelineStepTypesProvider : IDeletePipelineStepTypesProvider
    {
        public Type[] GetSteps()
        {
            return new[] {typeof(DeleteEntityModel<,,,>)};
        }
    }
}
