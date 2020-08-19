// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;

namespace EdFi.TestObjects._Extensions
{
    public static class Specifications
    {
        public static bool IsEducationOrganizationIdentifier(this string valueName)
        {
            return
                valueName.Equals("educationOrganizationId", StringComparison.InvariantCultureIgnoreCase)
                || valueName.Equals("stateAgencyId", StringComparison.InvariantCultureIgnoreCase)
                || valueName.Equals("educationServiceCenterId", StringComparison.InvariantCultureIgnoreCase)
                || valueName.Equals("localEducationAgencyId", StringComparison.InvariantCultureIgnoreCase)
                || valueName.Equals("schoolId", StringComparison.InvariantCultureIgnoreCase)
                || valueName.Equals("educationOrganizationNetworkId", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
