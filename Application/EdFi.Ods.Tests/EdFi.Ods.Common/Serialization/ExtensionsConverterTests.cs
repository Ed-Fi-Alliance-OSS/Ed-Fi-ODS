// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using EdFi.Ods.Common.Utils.Extensions;
using EdFi.Ods.Tests.EdFi.Ods.Api.Common.Models.Resources.Staff.EdFi;
using EdFi.Ods.Tests.EdFi.Ods.Api.Common.Models.Resources.Staff.EdFi.Extensions.Test1;
using EdFi.TestFixture;
using KellermanSoftware.CompareNetObjects;
using Newtonsoft.Json;
using NUnit.Framework;
using Test.Common;
using StaffExtension2 = EdFi.Ods.Tests.EdFi.Ods.Api.Common.Models.Resources.Staff.EdFi.Extensions.TestArbitraryCasing.StaffExtension;
using StaffLanguageExtension2 = EdFi.Ods.Tests.EdFi.Ods.Api.Common.Models.Resources.Staff.EdFi.Extensions.TestArbitraryCasing.StaffLanguageExtension;
using StaffLanguageUseExtension2 = EdFi.Ods.Tests.EdFi.Ods.Api.Common.Models.Resources.Staff.EdFi.Extensions.TestArbitraryCasing.StaffLanguageUseExtension;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Serialization
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ExtensionConverterTests
    {

        private static Dictionary<string, object> CreateTransformedDictionary(IDictionary input, Func<string, string> keyTransform = null)
        {
            var result = new Dictionary<string, object>();

            foreach (var key in input.Keys)
            {
                var stringKey = key.ToString();
                result.Add(keyTransform != null ? keyTransform(stringKey) : stringKey, input[stringKey]);
            }

            return result;
        }
        private static Staff CreateStaffWithExtensions()
        {
            return new Staff
                   {
                       Id = new Guid("70DCA6F6-8A60-40D8-AC3D-00D0013F1CAF"), FirstName = "John", LastSurname = "Smith", Extensions = new Dictionary<string, object>
                                                                                                    {
                                                                                                        {
                                                                                                            "Test1", new StaffExtension
                                                                                                                     {
                                                                                                                         HasGraduateDegree = true,
                                                                                                                         DegreeType = "Hard",
                                                                                                                         YearsExperience = 16
                                                                                                                     }
                                                                                                        },
                                                                                                        {
                                                                                                            "TestArbitraryCasing", new StaffExtension2
                                                                                                                     {
                                                                                                                         NumberOfCats = 7
                                                                                                                     }
                                                                                                        }
                                                                                                    },
                       StaffLanguages = new List<StaffLanguage>
                                        {
                                            new StaffLanguage
                                            {
                                                LanguageDescriptor = "Something", Extensions = new Dictionary<string, object>
                                                                                               {
                                                                                                   {
                                                                                                       "Test1", new StaffLanguageExtension
                                                                                                                {
                                                                                                                    IsIndoEuropeanLanguage = true,
                                                                                                                    MostUnderstoodDialectOfLanguage =
                                                                                                                        "Simbo"
                                                                                                                }
                                                                                                   },
                                                                                                   {
                                                                                                       "TestArbitraryCasing", new StaffLanguageExtension2
                                                                                                                {
                                                                                                                    IsFictional = true
                                                                                                                }
                                                                                                   }
                                                                                               },
                                                StaffLanguageUses = new List<StaffLanguageUse>
                                                                    {
                                                                        new StaffLanguageUse
                                                                        {
                                                                            LanguageUseType = "Spoken", Extensions = new Dictionary<string, object>
                                                                                                                     {
                                                                                                                         {
                                                                                                                             "Test1",
                                                                                                                             new
                                                                                                                             StaffLanguageUseExtension
                                                                                                                             {
                                                                                                                                 HasTaughtWithLanguage
                                                                                                                                     = true,
                                                                                                                                 YearsTaughtWithLanguage
                                                                                                                                     = 4
                                                                                                                             }
                                                                                                                         },
                                                                                                                         {
                                                                                                                             "TestArbitraryCasing",
                                                                                                                             new
                                                                                                                             StaffLanguageUseExtension2
                                                                                                                             {
                                                                                                                                 HasSpokenUsingPigLatin
                                                                                                                                     = true
                                                                                                                             }
                                                                                                                         }
                                                                                                                     }
                                                                        }
                                                                    }
                                            }
                                        }
                   };
        }

        [DataContract]
        public class NonExistingObject
        {
            [DataMember(Name = "name")]
            public string Name { get; set; }

            [DataMember(Name = "otherObjects")]
            public IList<NonExistingObject> OtherNonExistingObjects { get; set; }
        }

        private static Staff CreateStaffWithUnknownExtensions()
        {
            return new Staff
                   {
                       Id = new Guid("F4285610-2927-4A1A-99D6-8301AEBDFCBB"), FirstName = "John", LastSurname = "Smith", Extensions = new Dictionary<string, object>
                                                                                                    {
                                                                                                        {
                                                                                                            "NonExisting", new NonExistingObject
                                                                                                                           {
                                                                                                                               Name =
                                                                                                                                   "LevelOne-ItemOne",
                                                                                                                               OtherNonExistingObjects
                                                                                                                                   = new List<
                                                                                                                                         NonExistingObject
                                                                                                                                     >
                                                                                                                                     {
                                                                                                                                         new
                                                                                                                                         NonExistingObject
                                                                                                                                         {
                                                                                                                                             Name =
                                                                                                                                                 "LevelTwo-ItemOne"
                                                                                                                                         },
                                                                                                                                         new
                                                                                                                                         NonExistingObject
                                                                                                                                         {
                                                                                                                                             Name =
                                                                                                                                                 "LevelTwo-ItemTwo"
                                                                                                                                         }
                                                                                                                                     }
                                                                                                                           }
                                                                                                        },
                                                                                                        {
                                                                                                            "Test1", new StaffExtension
                                                                                                                     {
                                                                                                                         HasGraduateDegree = true,
                                                                                                                         DegreeType = "Hard",
                                                                                                                         YearsExperience = 16
                                                                                                                     }
                                                                                                        },
                                                                                                        {
                                                                                                            "AnotherNonExisting",
                                                                                                            new NonExistingObject
                                                                                                            {
                                                                                                                Name = "LevelOne-ItemOne",
                                                                                                                OtherNonExistingObjects =
                                                                                                                    new List<NonExistingObject>
                                                                                                                    {
                                                                                                                        new NonExistingObject
                                                                                                                        {
                                                                                                                            Name = "LevelTwo-ItemOne"
                                                                                                                        },
                                                                                                                        new NonExistingObject
                                                                                                                        {
                                                                                                                            Name = "LevelTwo-ItemTwo"
                                                                                                                        }
                                                                                                                    }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                   };
        }

        public class When_deserializing_a_resource_with_extensions_at_multiple_levels : TestFixtureBase
        {
            private Staff _suppliedStaff;

            private Staff _actualStaff;

            protected override void Arrange()
            {
                // Construct a Staff instance with strongly-typed extensions at all levels
                _suppliedStaff = CreateStaffWithExtensions();
            }

            protected override void Act()
            {
                var serializerSettings = new JsonSerializerSettings
                                         {
                                             NullValueHandling = NullValueHandling.Ignore
                                         };

                // Serialize the supplied Staff to JSON
                string json = JsonConvert.SerializeObject(_suppliedStaff, serializerSettings);

                // Deserialize the JSON using the converter (with override namespace/assembly behavior still based on conventions)
                _actualStaff = JsonConvert.DeserializeObject<Staff>(json, new JsonSerializerSettings());
            }

            [Test]
            public void Should_deserialize_the_extensions_in_the_JSON_to_the_corresponding_strongly_typed_extension_classes()
            {
                var comparisonResult = new CompareLogic().Compare(_suppliedStaff, _actualStaff);

                Assert.That(comparisonResult.AreEqual, Is.True, comparisonResult.DifferencesString);
            }
        }

        public class When_deserializing_JSON_with_unknown_extensions_flanking_a_known_extension : TestFixtureBase
        {
            private Staff _suppliedStaff;

            private Staff _actualStaff;

            protected override void Arrange()
            {
                // Construct a Staff instance with strongly-typed extensions at all levels
                _suppliedStaff = CreateStaffWithUnknownExtensions();
            }

            protected override void Act()
            {
                var serializerSettings = new JsonSerializerSettings
                                         {
                                             NullValueHandling = NullValueHandling.Ignore
                                         };

                // Serialize the supplied Staff to JSON
                string json = JsonConvert.SerializeObject(_suppliedStaff, serializerSettings);

                // Deserialize the JSON using the converter (with override namespace/assembly behavior still based on conventions)
                _actualStaff = JsonConvert.DeserializeObject<Staff>(json, new JsonSerializerSettings());
            }

            [Assert]
            public void Should_not_throw_an_exception()
            {
                Assert.That(ActualException, Is.Null);
            }

            [Assert]
            public void Should_skip_the_unknown_extensions()
            {
                Assert.That(_actualStaff.Extensions, Has.Count.EqualTo(1));
            }

            [Test]
            public void Should_deserialize_the_KNOWN_extension_in_the_JSON_to_the_corresponding_strongly_typed_extension_classes()
            {
                Assert.That(_actualStaff.Extensions.Contains("Test1"), Is.True, "Extensions did not include the known extension.");

                var extension = (StaffExtension) _actualStaff.Extensions["Test1"];

                Assert.That(extension.DegreeType, Is.EqualTo("Hard"));
            }
        }

        public class When_deserializing_a_resource_with_extensions_at_multiple_levels_all_lower_case : TestFixtureBase
        {
            private Staff _suppliedStaff;

            private Staff _actualStaff;

            protected override void Arrange()
            {
                // Construct a Staff instance with strongly-typed extensions at all levels
                _suppliedStaff = CreateStaffWithExtensions();
            }

            protected override void Act()
            {
                var serializerSettings = new JsonSerializerSettings
                                         {
                                             NullValueHandling = NullValueHandling.Ignore
                                         };

                // Force all the extension keys to be all lower case to reflect potential input from clients
                var adjustedStaff = CreateStaffWithExtensions();
                var toLowerFunction = new Func<string, string>(s => s.ToLower());
                adjustedStaff.Extensions = CreateTransformedDictionary(adjustedStaff.Extensions, toLowerFunction);
                adjustedStaff.StaffLanguages.ForEach(sl => sl.Extensions = CreateTransformedDictionary(sl.Extensions, toLowerFunction));
                adjustedStaff.StaffLanguages.SelectMany(sl => sl.StaffLanguageUses)
                             .ForEach(slu => slu.Extensions = CreateTransformedDictionary(slu.Extensions, toLowerFunction));

                // Serialize the supplied Staff to JSON
                string json = JsonConvert.SerializeObject(adjustedStaff, serializerSettings);

                // Deserialize the JSON using the converter (with override namespace/assembly behavior still based on conventions)
                _actualStaff = JsonConvert.DeserializeObject<Staff>(json, new JsonSerializerSettings());
            }

            [Test]
            public void Should_deserialize_the_extensions_in_the_JSON_to_the_corresponding_strongly_typed_extension_classes()
            {
                var comparisonResult = new CompareLogic().Compare(_suppliedStaff, _actualStaff);

                Assert.That(comparisonResult.AreEqual, Is.True, comparisonResult.DifferencesString);
            }
        }

        public class When_deserializing_a_resource_with_extensions_at_multiple_levels_all_upper_case : TestFixtureBase
        {
            private Staff _suppliedStaff;

            private Staff _actualStaff;

            protected override void Arrange()
            {
                // Construct a Staff instance with strongly-typed extensions at all levels
                _suppliedStaff = CreateStaffWithExtensions();
            }

            protected override void Act()
            {
                var serializerSettings = new JsonSerializerSettings
                                         {
                                             NullValueHandling = NullValueHandling.Ignore
                                         };

                // Force all the extension keys to be all lower case to reflect potential input from clients
                var adjustedStaff = CreateStaffWithExtensions();
                var toUpperFunction = new Func<string, string>(s => s.ToUpper());
                adjustedStaff.Extensions = CreateTransformedDictionary(adjustedStaff.Extensions, toUpperFunction);
                adjustedStaff.StaffLanguages.ForEach(sl => sl.Extensions = CreateTransformedDictionary(sl.Extensions, toUpperFunction));
                adjustedStaff.StaffLanguages.SelectMany(sl => sl.StaffLanguageUses)
                             .ForEach(slu => slu.Extensions = CreateTransformedDictionary(slu.Extensions, toUpperFunction));

                // Serialize the supplied Staff to JSON
                string json = JsonConvert.SerializeObject(adjustedStaff, serializerSettings);

                // Deserialize the JSON using the converter (with override namespace/assembly behavior still based on conventions)
                _actualStaff = JsonConvert.DeserializeObject<Staff>(json, new JsonSerializerSettings());
            }

            [Test]
            public void Should_deserialize_the_extensions_in_the_JSON_to_the_corresponding_strongly_typed_extension_classes()
            {
                var comparisonResult = new CompareLogic().Compare(_suppliedStaff, _actualStaff);

                Assert.That(comparisonResult.AreEqual, Is.True, comparisonResult.DifferencesString);
            }
        }
    }
}
