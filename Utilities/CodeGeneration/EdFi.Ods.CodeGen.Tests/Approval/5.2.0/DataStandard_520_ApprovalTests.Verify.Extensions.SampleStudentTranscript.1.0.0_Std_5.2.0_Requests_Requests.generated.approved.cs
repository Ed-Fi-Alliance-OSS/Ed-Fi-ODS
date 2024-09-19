using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Attributes;

namespace EdFi.Ods.Api.Common.Models.Requests.SampleStudentTranscript.InstitutionControlDescriptors
{

    [ExcludeFromCodeCoverage]
    public class InstitutionControlDescriptorGetByExample
    {
        public string CodeValue { get; set; }
        public string Description { get; set; }
        public DateTime EffectiveBeginDate { get; set; }
        public DateTime EffectiveEndDate { get; set; }
        public Guid Id { get; set; }
        public int InstitutionControlDescriptorId { get; set; }
        public string Namespace { get; set; }
        public string ShortDescription { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InstitutionControlDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public InstitutionControlDescriptorGetByIds() { }

        public InstitutionControlDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InstitutionControlDescriptorPost : Resources.InstitutionControlDescriptor.SampleStudentTranscript.InstitutionControlDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class InstitutionControlDescriptorPut : Resources.InstitutionControlDescriptor.SampleStudentTranscript.InstitutionControlDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class InstitutionControlDescriptorDelete : IHasIdentifier
    {
        public InstitutionControlDescriptorDelete() { }

        public InstitutionControlDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SampleStudentTranscript.InstitutionLevelDescriptors
{

    [ExcludeFromCodeCoverage]
    public class InstitutionLevelDescriptorGetByExample
    {
        public string CodeValue { get; set; }
        public string Description { get; set; }
        public DateTime EffectiveBeginDate { get; set; }
        public DateTime EffectiveEndDate { get; set; }
        public Guid Id { get; set; }
        public int InstitutionLevelDescriptorId { get; set; }
        public string Namespace { get; set; }
        public string ShortDescription { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InstitutionLevelDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public InstitutionLevelDescriptorGetByIds() { }

        public InstitutionLevelDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InstitutionLevelDescriptorPost : Resources.InstitutionLevelDescriptor.SampleStudentTranscript.InstitutionLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class InstitutionLevelDescriptorPut : Resources.InstitutionLevelDescriptor.SampleStudentTranscript.InstitutionLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class InstitutionLevelDescriptorDelete : IHasIdentifier
    {
        public InstitutionLevelDescriptorDelete() { }

        public InstitutionLevelDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SampleStudentTranscript.PostSecondaryOrganizations
{

    [ExcludeFromCodeCoverage]
    public class PostSecondaryOrganizationGetByExample
    {
        public bool AcceptanceIndicator { get; set; }
        public Guid Id { get; set; }
        public string InstitutionControlDescriptor { get; set; }
        public string InstitutionLevelDescriptor { get; set; }
        public string NameOfInstitution { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PostSecondaryOrganizationGetByIds : IHasIdentifiers<Guid>
    {
        public PostSecondaryOrganizationGetByIds() { }

        public PostSecondaryOrganizationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PostSecondaryOrganizationPost : Resources.PostSecondaryOrganization.SampleStudentTranscript.PostSecondaryOrganization
    {
    }

    [ExcludeFromCodeCoverage]
    public class PostSecondaryOrganizationPut : Resources.PostSecondaryOrganization.SampleStudentTranscript.PostSecondaryOrganization
    {
    }

    [ExcludeFromCodeCoverage]
    public class PostSecondaryOrganizationDelete : IHasIdentifier
    {
        public PostSecondaryOrganizationDelete() { }

        public PostSecondaryOrganizationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SampleStudentTranscript.SpecialEducationGraduationStatusDescriptors
{

    [ExcludeFromCodeCoverage]
    public class SpecialEducationGraduationStatusDescriptorGetByExample
    {
        public string CodeValue { get; set; }
        public string Description { get; set; }
        public DateTime EffectiveBeginDate { get; set; }
        public DateTime EffectiveEndDate { get; set; }
        public Guid Id { get; set; }
        public string Namespace { get; set; }
        public string ShortDescription { get; set; }
        public int SpecialEducationGraduationStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SpecialEducationGraduationStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public SpecialEducationGraduationStatusDescriptorGetByIds() { }

        public SpecialEducationGraduationStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SpecialEducationGraduationStatusDescriptorPost : Resources.SpecialEducationGraduationStatusDescriptor.SampleStudentTranscript.SpecialEducationGraduationStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SpecialEducationGraduationStatusDescriptorPut : Resources.SpecialEducationGraduationStatusDescriptor.SampleStudentTranscript.SpecialEducationGraduationStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SpecialEducationGraduationStatusDescriptorDelete : IHasIdentifier
    {
        public SpecialEducationGraduationStatusDescriptorDelete() { }

        public SpecialEducationGraduationStatusDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SampleStudentTranscript.SubmissionCertificationDescriptors
{

    [ExcludeFromCodeCoverage]
    public class SubmissionCertificationDescriptorGetByExample
    {
        public string CodeValue { get; set; }
        public string Description { get; set; }
        public DateTime EffectiveBeginDate { get; set; }
        public DateTime EffectiveEndDate { get; set; }
        public Guid Id { get; set; }
        public string Namespace { get; set; }
        public string ShortDescription { get; set; }
        public int SubmissionCertificationDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SubmissionCertificationDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public SubmissionCertificationDescriptorGetByIds() { }

        public SubmissionCertificationDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SubmissionCertificationDescriptorPost : Resources.SubmissionCertificationDescriptor.SampleStudentTranscript.SubmissionCertificationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SubmissionCertificationDescriptorPut : Resources.SubmissionCertificationDescriptor.SampleStudentTranscript.SubmissionCertificationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SubmissionCertificationDescriptorDelete : IHasIdentifier
    {
        public SubmissionCertificationDescriptorDelete() { }

        public SubmissionCertificationDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

