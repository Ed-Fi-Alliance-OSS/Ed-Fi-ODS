// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EdFi.Ods.Api.Common.Models.Resources.Assessment.EdFi;
using EdFi.Ods.Api.Common.Models.Resources.AssessmentItem.EdFi;
using EdFi.Ods.Api.Common.Models.Resources.EducationOrganization.EdFi;
using EdFi.Ods.Api.Common.Models.Resources.ObjectiveAssessment.EdFi;
using EdFi.Ods.Api.Common.Models.Resources.Program.EdFi;
using EdFi.Ods.Api.Common.Models.Resources.School.EdFi;
using EdFi.Ods.Api.Common.Models.Resources.Staff.EdFi;
using EdFi.Ods.Api.Common.Models.Resources.StaffEducationOrganizationEmploymentAssociation.EdFi;
using EdFi.Ods.Api.Common.Models.Resources.Student.EdFi;
using EdFi.Ods.Api.Common.Models.Resources.StudentAssessment.EdFi;
using EdFi.Ods.Api.Common.Models.Resources.StudentSchoolAssociation.EdFi;
using Newtonsoft.Json;
using Test.Common.DataConstants;

namespace EdFi.Ods.WebApi.IntegrationTests.Helpers
{
    internal class ResourceHelper
    {
        public static string CreateStudent(string uniqueId, string lastName = null, string firstName = null)
        {
            var ticks = DateTime.Now.Ticks;

            var student = new Student
            {
                StudentUniqueId = uniqueId,
                FirstName = firstName ?? string.Format("F{0}", ticks),
                LastSurname = lastName ?? string.Format("L{0}", ticks),
                BirthDate = new DateTime(2017, 05, 31)
            };

            return JsonConvert.SerializeObject(student);
        }



    }
}
