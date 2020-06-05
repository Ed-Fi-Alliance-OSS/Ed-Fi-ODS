// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Common.Models.Identity
{
    public enum IdentifierType
    {
        SSN = 1,
        PartialSSN = 2,
        WeakSSN = 3,
        LeaStudentId = 4,
        DriversLicense = 5,
        StudentSchoolName = 6,
        StudentSchoolLea = 7,
        StudentSchoolYear = 8
    }
}
