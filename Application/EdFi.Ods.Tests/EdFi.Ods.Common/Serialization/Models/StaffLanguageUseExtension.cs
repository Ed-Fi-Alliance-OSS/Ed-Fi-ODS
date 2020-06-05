// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Runtime.Serialization;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Common.Models.Resources.Staff.EdFi.Extensions.Test1
{
    [DataContract]
    public class StaffLanguageUseExtension
    {
        [DataMember(Name = "hasTaughtWithLanguage")]
        public bool HasTaughtWithLanguage { get; set; }

        [DataMember(Name = "yearsTaughtWithLanguage")]
        public int YearsTaughtWithLanguage { get; set; }
    }
}

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Common.Models.Resources.Staff.EdFi.Extensions.TestArbitraryCasing
{
    [DataContract]
    public class StaffLanguageUseExtension
    {
        [DataMember(Name = "hasSpokenUsingPigLatin")]
        public bool HasSpokenUsingPigLatin { get; set; }
    }
}
