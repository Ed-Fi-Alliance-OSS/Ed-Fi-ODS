// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Runtime.Serialization;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Common.Models.Resources.Staff.EdFi.Extensions.Test1
{
    [DataContract]
    public class StaffExtension
    {
        [DataMember(Name = "yearsExperience")]
        public int YearsExperience { get; set; }

        [DataMember(Name = "hasGraduateDegree")]
        public bool HasGraduateDegree { get; set; }

        [DataMember(Name = "degreeType")]
        public string DegreeType { get; set; }
    }
}

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Common.Models.Resources.Staff.EdFi.Extensions.TestArbitraryCasing
{
    [DataContract]
    public class StaffExtension
    {
        [DataMember(Name = "numberOfCats")]
        public int NumberOfCats { get; set; }
    }
}
