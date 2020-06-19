// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.LoadTools.Engine;
using NUnit.Framework;

namespace EdFi.LoadTools.Test
{
    [TestFixture]
    public class PercentMatchToTests
    {
        private static Map[] CreateMappings(IEnumerable<string> xml, IEnumerable<string> json)
        {
            return xml.SelectMany(
                           x => json.Select(
                               j => new Map
                                    {
                                        X = x, J = j, M = x.PercentMatchTo(j)
                                    }))
                      .OrderByDescending(m => m.M).ToArray();
        }

        private static IEnumerable<Map> CompressMappings(IEnumerable<Map> mappings)
        {
            var maps = mappings.Where(m => m.M > 0).ToList();

            while (maps.Count > 0)
            {
                var map = maps.First();
                yield return map;

                maps.RemoveAll(m => m.X == map.X || m.J == map.J);
            }
        }

        private static void WriteMaps(string description, IEnumerable<Map> maps)
        {
            Console.WriteLine($"---{description}---");

            foreach (var map in maps)
            {
                Console.WriteLine($"\t{map.M}\r\t\t{map.X}\r\t\t{map.J}");
            }
        }

        private static void PerformTest(IReadOnlyList<string> xml, IReadOnlyList<string> json)
        {
            var mappings = CreateMappings(xml, json);
            WriteMaps("Unmatched", mappings);

            // it is important that all the json properties are mapped
            var maps = CompressMappings(mappings).ToList();
            WriteMaps("Matched", maps);

            for (var i = 0; i < json.Count; i++)
            {
                var map = maps.SingleOrDefault(m => m.X == xml[i] && m.J == json[i]);
                Assert.IsNotNull(map);
                Assert.IsTrue(map.M > 0);
            }
        }

        [Test]
        public void Descriptor_Values()
        {
            string[] xml =
            {
                "AcademicSubjectMap", "CodeValue", "Description", "EffectiveBeginDate", "EffectiveEndDate", "Namespace", "ShortDescription"
            };

            string[] json =
            {
                "academicSubjectType", "codeValue", "description", "effectiveBeginDate", "effectiveEndDate", "namespace", "shortDescription"
            };

            PerformTest(xml, json);
        }

        [Test]
        public void AssessmentFamilyTitle_to_title()
        {
            string[] xml =
            {
                "AssessmentTitle", "AssessmentFamilyReference/AssessmentFamilyIdentity/AssessmentFamilyTitle"
            };

            string[] json =
            {
                "title", "assessmentFamilyReference/title"
            };

            PerformTest(xml, json);
        }

        [Test]
        public void CohortScope_to_scopeType()
        {
            string[] xml =
            {
                "CohortScope", "scopeType"
            };

            string[] json =
            {
                "CohortType", "type"
            };

            PerformTest(xml, json);
        }

        [Test]
        public void KeyConsolidation()
        {
            string[] xml =
            {
                "StudentSectionAssociationReference/StudentSectionAssociationIdentity/SectionReference/SectionIdentity/CourseOfferingReference/CourseOfferingIdentity/SessionReference/SessionIdentity/SchoolYear",
                "StudentSectionAssociationReference/StudentSectionAssociationIdentity/SectionReference/SectionIdentity/ClassPeriodReference/ClassPeriodIdentity/SchoolReference/SchoolIdentity/SchoolId",
                "StudentSectionAssociationReference/StudentSectionAssociationIdentity/SectionReference/SectionIdentity/CourseOfferingReference/CourseOfferingIdentity/SessionReference/SessionIdentity/SchoolReference/SchoolIdentity/SchoolId",
                "StudentSectionAssociationReference/StudentSectionAssociationIdentity/SectionReference/SectionIdentity/CourseOfferingReference/CourseOfferingIdentity/SchoolReference/SchoolIdentity/SchoolId"
            };

            string[] json =
            {
                "studentSectionAssociationReference/schoolYear"
            };

            PerformTest(xml, json);
        }

        [Test]
        public void CalendarDateReference()
        {
            string[] xml =
            {
                "CalendarDateReference/CalendarDateIdentity/SchoolReference/SchoolIdentity/SchoolId", "SchoolReference/SchoolIdentity/SchoolId"
            };

            string[] json =
            {
                "calendarDateReference/schoolId"
            };

            PerformTest(xml, json);
        }

        [Test]
        public void URI_to_uri()
        {
            string[] xml =
            {
                "URI"
            };

            string[] json =
            {
                "uri"
            };

            PerformTest(xml, json);
        }

        private class Map
        {
            public string J;
            public double M;
            public string X;
        }
    }
}
