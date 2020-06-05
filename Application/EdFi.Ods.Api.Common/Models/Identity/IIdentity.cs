// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Api.Common.Models.Identity
{
    public interface IIdentity
    {
        string UniqueId { get; set; }

        Gender? BirthGender { get; set; }

        DateTime? BirthDate { get; set; }

        string FamilyNames { get; set; }

        string GivenNames { get; set; }

        double Weight { get; set; }

        bool IsMatch { get; set; }

        IIdentifier[] Identifiers { get; set; }
    }
}
