// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.WebApi.CompositeSpecFlowTests.Dtos
{
    public class StudentSchoolKeyInformation
    {
        public Guid Id { get; set; }

        public string StudentUniqueId { get; set; }

        public long SchoolId { get; set; }

        public DateTime EntryDate { get; set; }
    }
}
