// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters.Hints;

public class EducationOrganizationIdToStaffUsiAuthorizationViewHintProvider : IAuthorizationViewHintProvider
{
    public string GetFailureHint(string viewName)
    {
        if (viewName.StartsWith("EducationOrganizationIdToStaffUSI", StringComparison.OrdinalIgnoreCase))
        {
            return "You may need to create corresponding 'StaffEducationOrganizationEmploymentAssociation' or 'StaffEducationOrganizationAssignmentAssociation' resource items.";
        }

        return null;
    }
}