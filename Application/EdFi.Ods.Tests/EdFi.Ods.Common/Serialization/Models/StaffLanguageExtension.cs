// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Runtime.Serialization;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Common.Models.Resources.Staff.EdFi.Extensions.Test1
{
    [DataContract]
    public class StaffLanguageExtension
    {
        [DataMember(Name = "isIndoEuropeanLanguage")]
        public bool IsIndoEuropeanLanguage { get; set; }

        [DataMember(Name = "mostUnderstoodDialectOfLanguage")]
        public string MostUnderstoodDialectOfLanguage { get; set; }
    }
}

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Common.Models.Resources.Staff.EdFi.Extensions.TestArbitraryCasing
{
    [DataContract]
    public class StaffLanguageExtension
    {
        [DataMember(Name = "isFictional")]
        public bool IsFictional { get; set; }
    }
}
