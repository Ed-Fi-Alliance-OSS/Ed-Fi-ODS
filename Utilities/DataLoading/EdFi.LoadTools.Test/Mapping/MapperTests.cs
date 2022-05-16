// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.LoadTools.Mapping;
using EdFi.OdsApi.Sdk.Models.All;
using NUnit.Framework;
using Newtonsoft.Json;

namespace EdFi.LoadTools.Test.Mapping
{
    [TestFixture]
    public class MapperTests
    {
#region StaffJson

        private const string StaffJson = @"{
    ""id"": ""81c35732eb2249f9a496ebc6153a2dbb"",
    ""staffUniqueId"": ""207288"",
    ""personalTitlePrefix"": ""Mr"",
    ""firstName"": ""Barry"",
    ""lastSurname"": ""Tanner"",
    ""sexType"": ""Male"",
    ""birthDate"": ""1965-08-19T00:00:00"",
    ""hispanicLatinoEthnicity"": false,
    ""oldEthnicityType"": ""Hispanic"",
    ""highestCompletedLevelOfEducationDescriptor"": ""Master's"",
    ""yearsOfPriorProfessionalExperience"": 30,
    ""loginId"": ""btanner"",
    ""addresses"": [],
    ""credentials"": [],
    ""electronicMails"": [
      {
        ""electronicMailTypeDescriptor"": ""Work"",
        ""electronicMailAddress"": ""BarryTanner@edfi.org""
      }
    ],
    ""identificationCodes"": [
      {
        ""staffIdentificationSystemDescriptor"": ""State"",
        ""identificationCode"": ""207288""
      }
    ],
    ""identificationDocuments"": [
      {
        ""personalInformationVerificationDescriptor"": ""State-issued ID"",
        ""identificationDocumentUseDescriptor"": ""Personal Information Verification""
      }
    ],
    ""internationalAddresses"": [],
    ""languages"": [],
    ""otherNames"": [],
    ""races"": [
      {
        ""raceDescriptor"": ""American Indian - Alaskan Native""
      }
    ],
    ""telephones"": [],
    ""visas"": [],
    ""_etag"": ""635696331693100000""
  }";

#endregion

        [Test]
        public void MappingTests_should_resolve_properties()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SourceA, TargetA>());
            config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();

            var source = new SourceA
            {
                PropertyA = "property A",
                SourceB = new SourceB {PropertyB = "property B"},
                List = new List<SourceC> {new SourceC {PropertyC = "property C"}},
                SourceD = new SourceD {PropertyD = "property D"}
            };

            var target = mapper.Map<SourceA, TargetA>(source);
            Assert.AreEqual(source.PropertyA, target.PropertyA);
            Assert.AreEqual(source.SourceB.PropertyB, target.PropertyB);
            Assert.AreEqual(source.List.First().PropertyC, target.PropertyC);
            Assert.AreEqual(source.SourceD?.PropertyD, target.TargetB?.PropertyD);
        }

        [Test]
        public void MappingTests_for_EdFi_models()
        {
            var config = new MapperConfiguration(
                cfg =>
                    cfg.CreateMap<EdFiStaff, EdFiStaffReference>());

            config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();
            var source = JsonConvert.DeserializeObject<EdFiStaff>(StaffJson);
            var result = mapper.Map<EdFiStaff, EdFiStaffReference>(source);
        }

        public class SourceA
        {
            public string PropertyA { get; set; }

            public SourceB SourceB { get; set; }

            public List<SourceC> List { get; set; }

            public SourceD SourceD { get; set; }
        }

        public class SourceB
        {
            public string PropertyB { get; set; }
        }

        public class SourceC
        {
            public string PropertyC { get; set; }
        }

        public class SourceD
        {
            public string PropertyD { get; set; }
        }

        public class TargetA
        {
            public string PropertyA { get; set; }

            public string PropertyB { get; set; }

            public string PropertyC { get; set; }

            public TargetB TargetB { get; set; }
        }

        public class TargetB
        {
            public string PropertyD { get; set; }
        }
    }
}
