// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using EdFi.Ods.Common.Specifications;

namespace Test.Common.DataConstants
{
    /// <summary>
    /// Test class for accessing populated template descriptor values which are assumed to exist,
    /// to consolidate them all into one place for easier update
    /// </summary>
    public class KnownDescriptors
    {
        public static AcademicSubjectDescriptor AcademicSubject => new AcademicSubjectDescriptor();

        public static AssessmentIdentificationSystemDescriptor AssessmentIdentificationSystem
            => new AssessmentIdentificationSystemDescriptor();

        public static CourseIdentificationSystemDescriptor CourseIdentificationSystem
            => new CourseIdentificationSystemDescriptor();

        public static ElectronicMailTypeDescriptor ElectronicMailType => new ElectronicMailTypeDescriptor();

        public static EmploymentStatusDescriptor EmploymentStatus => new EmploymentStatusDescriptor();

        public static GradeLevelDescriptor GradeLevel => new GradeLevelDescriptor();

        public static LevelOfEducationDescriptor LevelOfEducation => new LevelOfEducationDescriptor();

        public static OtherNameTypeDescriptor OtherNameType => new OtherNameTypeDescriptor();

        public static ProgramAssignmentDescriptor ProgramAssignment => new ProgramAssignmentDescriptor();

        public static ProgramSponsorDescriptor ProgramSponsor => new ProgramSponsorDescriptor();

        public static ProgramTypeDescriptor ProgramType => new ProgramTypeDescriptor();

        public static ReasonExitedDescriptor ReasonExited => new ReasonExitedDescriptor();

        public static SexDescriptor Sex => new SexDescriptor();

        public static StaffClassificationDescriptor StaffClassification => new StaffClassificationDescriptor();

        public static StaffIdentificationSystemDescriptor StaffIdentificationSystem => new StaffIdentificationSystemDescriptor();

        public static TelephoneNumberTypeDescriptor TelephoneNumberType => new TelephoneNumberTypeDescriptor();

        public static TitleIPartAParticipantDescriptor TitleIPartAParticipant => new TitleIPartAParticipantDescriptor();
    }

    public abstract class KnownDescriptorBase
    {
        public const string EdFiNamspacePrefix = "uri://ed-fi.org/";

        public string DescriptorName
            => GetType()
                .Name;

        public string DescriptorNamespacePrefix => EdFiNamspacePrefix + DescriptorName;

        public string GetCodeValue(string descriptorUriReference)
        {
            // This may need refactoring later if there's additional need to get just the code value
            // potentially moving into the EdFiDescriptorReferenceSpecification long term
            if (!descriptorUriReference.StartsWith(DescriptorNamespacePrefix))
            {
                throw new Exception(
                    $"Invalid descriptor reference, descriptor references are expected to start with {DescriptorNamespacePrefix}");
            }

            // Remove the namespace and separator character to get code value back out
            return descriptorUriReference.Replace(DescriptorNamespacePrefix, string.Empty)
                .Substring(1);
        }

        protected string GetRef(string codeValue)
        {
            return EdFiDescriptorReferenceSpecification.GetFullyQualifiedDescriptorReference(
                DescriptorNamespacePrefix,
                codeValue);
        }
    }

    public class AcademicSubjectDescriptor : KnownDescriptorBase
    {
        public string Mathematics => GetRef("Mathematics");

        public string Science => GetRef("Science");
    }

    public class AssessmentIdentificationSystemDescriptor : KnownDescriptorBase
    {
        public string School => GetRef("School");
    }

    public class CourseIdentificationSystemDescriptor : KnownDescriptorBase
    {
        public string LEACourseCode => GetRef("LEA course code");
    }

    public class ElectronicMailTypeDescriptor : KnownDescriptorBase
    {
        public string Other => GetRef("Other");
    }

    public class EmploymentStatusDescriptor : KnownDescriptorBase
    {
        public string TenuredOrPermanent => GetRef("Tenured or permanent");
    }

    public class GradeLevelDescriptor : KnownDescriptorBase
    {
        public string ThirdGrade => GetRef("Third grade");

        public string FourthGrade => GetRef("Fourth grade");

        public string SixthGrade => GetRef("Sixth grade");

        public string NinthGrade => GetRef("Ninth grade");
    }

    public class LevelOfEducationDescriptor : KnownDescriptorBase
    {
        public string Bachelors => GetRef("Bachelor's");
    }

    public class OtherNameTypeDescriptor : KnownDescriptorBase
    {
        public string Alias => GetRef("Alias");
    }

    public class ProgramAssignmentDescriptor : KnownDescriptorBase
    {
        public string RegularEducation => GetRef("Regular Education");
    }

    public class ProgramSponsorDescriptor : KnownDescriptorBase
    {
        public string School => GetRef("School");
    }

    public class ProgramTypeDescriptor : KnownDescriptorBase
    {
        public string Athletics => GetRef("Athletics");

        public string CollegePreparatory => GetRef("College Preparatory");
    }

    public class ReasonExitedDescriptor : KnownDescriptorBase
    {
        public string MovedOutOfState => GetRef("Moved out of state");

        public string GraduatedWithAHighSchoolDiploma => GetRef("Graduated with a high school diploma");
    }

    public class SexDescriptor : KnownDescriptorBase
    {
        public string Male => GetRef("Male");

        public string Female => GetRef("Female");
    }

    public class StaffClassificationDescriptor : KnownDescriptorBase
    {
        public string Teacher => GetRef("Teacher");
    }

    public class StaffIdentificationSystemDescriptor : KnownDescriptorBase
    {
        public string State => GetRef("State");
    }

    public class TelephoneNumberTypeDescriptor : KnownDescriptorBase
    {
        public string Home => GetRef("Home");
    }

    public class TitleIPartAParticipantDescriptor : KnownDescriptorBase
    {
        public string LocalNeglectedProgram => GetRef("Local Neglected Program");

        public string PublicSchoolwideProgram => GetRef("Public Schoolwide Program");
    }
}
