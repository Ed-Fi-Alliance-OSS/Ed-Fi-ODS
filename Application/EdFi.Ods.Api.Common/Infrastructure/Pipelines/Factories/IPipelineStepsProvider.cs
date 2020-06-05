// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Api.Common.Infrastructure.Pipelines.Factories
{
    public interface IPipelineStepsProvider
    {
        Type[] GetSteps();
    }

    public interface IGetPipelineStepsProvider : IPipelineStepsProvider { }

    public interface IGetBySpecificationPipelineStepsProvider : IPipelineStepsProvider { }
    public interface IGetDeletedResourceIdsPipelineStepsProvider : IPipelineStepsProvider { }
    public interface IPutPipelineStepsProvider : IPipelineStepsProvider { }

    public interface IDeletePipelineStepsProvider : IPipelineStepsProvider { }
}
