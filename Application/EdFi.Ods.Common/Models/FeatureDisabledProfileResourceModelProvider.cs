// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Common.Models;

public class FeatureDisabledProfileResourceModelProvider : IProfileResourceModelProvider
{
    public ProfileResourceModel GetProfileResourceModel(string profileName)
    {
        // Force a bad request if a profile claim exists and profiles are disabled.
        throw new BadRequestException($"Profiles feature is not enabled.");
    }
}
