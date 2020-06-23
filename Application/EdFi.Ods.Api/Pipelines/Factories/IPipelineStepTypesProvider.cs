// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;

namespace EdFi.Ods.Api.Pipelines.Factories
{
    public interface IPipelineStepTypesProvider
    {
        Type[] GetSteps();
    }

    public interface IGetPipelineStepTypesProvider : IPipelineStepTypesProvider { }

    public interface IGetBySpecificationPipelineStepTypesProvider : IPipelineStepTypesProvider { }
    
    public interface IGetDeletedResourceIdsPipelineStepTypesProvider : IPipelineStepTypesProvider { }
    
    public interface IPutPipelineStepTypesProvider : IPipelineStepTypesProvider { }

    public interface IDeletePipelineStepTypesProvider : IPipelineStepTypesProvider { }
}
