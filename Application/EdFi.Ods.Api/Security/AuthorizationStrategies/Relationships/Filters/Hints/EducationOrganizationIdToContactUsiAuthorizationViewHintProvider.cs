// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters.Hints;

public class EducationOrganizationIdToContactUsiAuthorizationViewHintProvider : IAuthorizationViewHintProvider
{
    public string GetFailureHint(string viewName)
    {
        if (viewName.StartsWith("EducationOrganizationIdToContactUSI"))
        {
            return "You may need to create corresponding 'StudentSchoolAssociation' and 'StudentContactAssociation' resource items.";
        }

        return null;
    }
}