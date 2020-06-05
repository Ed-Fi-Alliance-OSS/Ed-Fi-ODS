// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Api.Common.Models.Identity
{
    public class Identity : IIdentity
    {
        public string UniqueId { get; set; }

        public Gender? BirthGender { get; set; }

        public DateTime? BirthDate { get; set; }

        public string FamilyNames { get; set; }

        public string GivenNames { get; set; }

        public double Weight { get; set; }

        public bool IsMatch { get; set; }

        public IIdentifier[] Identifiers { get; set; }
    }
}
