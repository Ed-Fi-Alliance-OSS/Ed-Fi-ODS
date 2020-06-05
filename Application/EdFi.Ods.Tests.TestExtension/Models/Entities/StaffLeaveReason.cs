// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using EdFi.Ods.Api.Common.Dtos;
using EdFi.Ods.Common;
using EdFi.Ods.Entities.NHibernate.StaffLeaveAggregate.EdFi;
using EdFi.Ods.Tests.TestExtension.Models.Interfaces;

namespace EdFi.Ods.Entities.NHibernate.StaffLeaveAggregate.TestExtension
{
    public class StaffLeaveReason : EntityWithCompositeKey, IChildEntity, IStaffLeaveReason
    {
        public virtual StaffLeave StaffLeave { get; set; }

        public void SetParent(object value)
        {
            throw new NotImplementedException();
        }

        public string Reason { get; set; }

        IStaffLeaveExtension IStaffLeaveReason.LeaveEventExtension { get; set; }

        public bool Synchronize(object target)
        {
            throw new NotImplementedException();
        }

        public void Map(object target)
        {
            throw new NotImplementedException();
        }

        public void SuspendReferenceAssignmentCheck()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return true;
        }

        public override int GetHashCode()
        {
            return new object().GetHashCode();
        }
    }
}
