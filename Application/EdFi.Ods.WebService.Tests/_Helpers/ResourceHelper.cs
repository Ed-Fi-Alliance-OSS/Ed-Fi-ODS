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
using EdFi.Ods.Api.Common.Models.Resources.Parent.EdFi;
using EdFi.Ods.Api.Common.Models.Resources.Program.EdFi;
using EdFi.Ods.Api.Common.Models.Resources.School.EdFi;
using EdFi.Ods.Api.Common.Models.Resources.Staff.EdFi;
using EdFi.Ods.Api.Common.Models.Resources.StaffEducationOrganizationEmploymentAssociation.EdFi;
using EdFi.Ods.Api.Common.Models.Resources.Student.EdFi;
using EdFi.Ods.Api.Common.Models.Resources.StudentAssessment.EdFi;
using EdFi.Ods.Api.Common.Models.Resources.StudentSchoolAssociation.EdFi;
using Newtonsoft.Json;
using Test.Common.DataConstants;

namespace EdFi.Ods.WebService.Tests._Helpers
{
    internal class ResourceHelper
    {
        public static string CreateStudent(string uniqueId, string lastName = null, string firstName = null)
        {
            var ticks = DateTime.Now.Ticks;

            var student = new Student
                          {
                              StudentUniqueId = uniqueId, FirstName = firstName ?? string.Format("F{0}", ticks),
                              LastSurname = lastName ?? string.Format("L{0}", ticks), BirthDate = new DateTime(2017, 05, 31)
                          };

            return JsonConvert.SerializeObject(student);
        }

        public static string CreateStudentSchoolAssociation(string uniqueId, int schoolId, string gradeLevelDescriptor = null)
        {
            if (gradeLevelDescriptor == null)
            {
                gradeLevelDescriptor = KnownDescriptors.GradeLevel.FourthGrade;
            }

            var association = new StudentSchoolAssociation
                              {
                                  StudentReference = new StudentReference
                                                     {
                                                         StudentUniqueId = uniqueId
                                                     },
                                  SchoolReference = new SchoolReference
                                                    {
                                                        SchoolId = schoolId
                                                    },
                                  EntryDate = DateTime.Today.AddYears(-1), EntryGradeLevelDescriptor = gradeLevelDescriptor
                              };

            return JsonConvert.SerializeObject(association);
        }

        public static string CreateAssessment(
            string assessmentIdentifier,
            string assessmentNamespace,
            string assessmentTitle = "Assessment",
            string[] academicSubjectDescriptors = null)
        {
            var assessment = new Assessment
                             {
                                 // identity
                                 AssessmentIdentifier = assessmentIdentifier, Namespace = assessmentNamespace,

                                 // required
                                 AssessmentTitle = assessmentTitle, AssessmentAcademicSubjects =
                                     (academicSubjectDescriptors ?? new[]
                                                                    {
                                                                        KnownDescriptors.AcademicSubject.Mathematics
                                                                    })
                                    .Select(
                                         d => new AssessmentAcademicSubject
                                              {
                                                  AcademicSubjectDescriptor = d
                                              })
                                    .ToList()
                             };

            return JsonConvert.SerializeObject(assessment);
        }

        public static string CreateAssessmentItem(string assessmentIdentifier, string assessmentNamespace, string identificationCode)
        {
            var assessmentItem = new AssessmentItem
                                 {
                                     AssessmentReference = AssessmentReference(assessmentIdentifier, assessmentNamespace),
                                     IdentificationCode = identificationCode
                                 };

            return JsonConvert.SerializeObject(assessmentItem);
        }

        public static string CreateObjectiveAssessment(string assessmentIdentifier, string assessmentNamespace, string identificationCode)
        {
            var objectiveAssessment = new ObjectiveAssessment
                                      {
                                          AssessmentReference = AssessmentReference(assessmentIdentifier, assessmentNamespace),
                                          IdentificationCode = identificationCode
                                      };

            return JsonConvert.SerializeObject(objectiveAssessment);
        }

        public static string CreateStudentAssessment(
            string assessmentIdentifier,
            string assessmentNamespace,
            string studentAssessmentIdentifier,
            string studentUniqueId,
            DateTime? administrationDate = null)
        {
            var studentAssessment = new StudentAssessment
                                    {
                                        AssessmentReference = AssessmentReference(assessmentIdentifier, assessmentNamespace),
                                        StudentAssessmentIdentifier = studentAssessmentIdentifier,
                                        AdministrationDate = administrationDate.GetValueOrDefault(DateTime.UtcNow), StudentReference =
                                            new StudentReference
                                            {
                                                StudentUniqueId = studentUniqueId
                                            }
                                    };

            return JsonConvert.SerializeObject(studentAssessment);
        }

        public static AssessmentReference AssessmentReference(string assessmentIdentifier, string assessmentNamespace)
        {
            return new AssessmentReference
                   {
                       AssessmentIdentifier = assessmentIdentifier, Namespace = assessmentNamespace
                   };
        }

        public static string CreateParent(string uniqueId, string lastName = null, string firstName = null)
        {
            var ticks = DateTime.Now.Ticks;

            var parent = new Parent
                         {
                             ParentUniqueId = uniqueId, FirstName = firstName ?? string.Format("F{0}", ticks),
                             LastSurname = lastName ?? string.Format("L{0}", ticks), SexDescriptor = ticks % 2 == 0
                                 ? KnownDescriptors.Sex.Male
                                 : KnownDescriptors.Sex.Female
                         };

            return JsonConvert.SerializeObject(parent);
        }

        public static string CreateProgram(int educationOrganizationId)
        {
            var program = new Program
                          {
                              EducationOrganizationReference = new EducationOrganizationReference
                                                               {
                                                                   EducationOrganizationId = educationOrganizationId
                                                               },
                              ProgramTypeDescriptor = KnownDescriptors.ProgramType.Athletics, ProgramSponsors = new List<ProgramSponsor>
                                                                                                                {
                                                                                                                    new ProgramSponsor
                                                                                                                    {
                                                                                                                        ProgramSponsorDescriptor =
                                                                                                                            KnownDescriptors
                                                                                                                               .ProgramSponsor.School
                                                                                                                    }
                                                                                                                },
                              ProgramName = DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture),
                              ProgramId = DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture)
                          };

            return JsonConvert.SerializeObject(program);
        }

        public static string CreateProgram(int educationOrganizationId, string name)
        {
            var program = new Program
                          {
                              EducationOrganizationReference = new EducationOrganizationReference
                                                               {
                                                                   EducationOrganizationId = educationOrganizationId
                                                               },
                              ProgramTypeDescriptor = KnownDescriptors.ProgramType.Athletics, ProgramSponsors = new List<ProgramSponsor>
                                                                                                                {
                                                                                                                    new ProgramSponsor
                                                                                                                    {
                                                                                                                        ProgramSponsorDescriptor =
                                                                                                                            KnownDescriptors
                                                                                                                               .ProgramSponsor.School
                                                                                                                    }
                                                                                                                },
                              ProgramName = name, ProgramId = DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture)
                          };

            return JsonConvert.SerializeObject(program);
        }

        public static string CreateStaff(string uniqueId, string lastName = null, string firstName = null)
        {
            var ticks = DateTime.Now.Ticks;

            var staff = new Staff
                        {
                            StaffUniqueId = uniqueId, FirstName = firstName ?? string.Format("F{0}", ticks),
                            LastSurname = lastName ?? string.Format("L{0}", ticks), SexDescriptor = ticks % 2 == 0
                                ? KnownDescriptors.Sex.Male
                                : KnownDescriptors.Sex.Female
                        };

            return JsonConvert.SerializeObject(staff);
        }

        public static string CreateStaffEducationOrganizationEmploymentAssociation(string staffUniqueId, int educationOrganizationId)
        {
            var association = new StaffEducationOrganizationEmploymentAssociation
                              {
                                  StaffReference = new StaffReference
                                                   {
                                                       StaffUniqueId = staffUniqueId
                                                   },
                                  EducationOrganizationReference = new EducationOrganizationReference
                                                                   {
                                                                       EducationOrganizationId = educationOrganizationId
                                                                   },
                                  EmploymentStatusDescriptor = KnownDescriptors.EmploymentStatus.TenuredOrPermanent,
                                  HireDate = DateTime.Now.AddYears(-2)
                              };

            return JsonConvert.SerializeObject(association);
        }
    }
}
