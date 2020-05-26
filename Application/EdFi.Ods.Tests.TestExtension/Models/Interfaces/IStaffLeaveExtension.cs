// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using EdFi.Ods.Common;
using EdFi.Ods.Entities.Common.EdFi;

namespace EdFi.Ods.Tests.TestExtension.Models.Interfaces
{
    public interface IStaffLeaveExtension : ISynchronizable, IMappable
    {
        // Primary Key properties 
        [NaturalKeyMember]
        IStaffLeave StaffLeave { get; set; }

        // Non-PK properties 
        DateTime? ExtensionDate { get; set; }

        void SuspendReferenceAssignmentCheck();
    }
}
