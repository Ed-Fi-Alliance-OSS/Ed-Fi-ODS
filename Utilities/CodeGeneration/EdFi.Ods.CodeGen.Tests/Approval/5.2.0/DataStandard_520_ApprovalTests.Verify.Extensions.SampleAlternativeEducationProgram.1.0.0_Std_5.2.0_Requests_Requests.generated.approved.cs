using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Attributes;

namespace EdFi.Ods.Api.Common.Models.Requests.SampleAlternativeEducationProgram.AlternativeEducationEligibilityReasonDescriptors
{

    [ExcludeFromCodeCoverage]
    public class AlternativeEducationEligibilityReasonDescriptorGetByExample
    {
        public int AlternativeEducationEligibilityReasonDescriptorId { get; set; }
        public string CodeValue { get; set; }
        public Guid Id { get; set; }
        public string Namespace { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AlternativeEducationEligibilityReasonDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AlternativeEducationEligibilityReasonDescriptorGetByIds() { }

        public AlternativeEducationEligibilityReasonDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AlternativeEducationEligibilityReasonDescriptorPost : Resources.AlternativeEducationEligibilityReasonDescriptor.SampleAlternativeEducationProgram.AlternativeEducationEligibilityReasonDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AlternativeEducationEligibilityReasonDescriptorPut : Resources.AlternativeEducationEligibilityReasonDescriptor.SampleAlternativeEducationProgram.AlternativeEducationEligibilityReasonDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AlternativeEducationEligibilityReasonDescriptorDelete : IHasIdentifier
    {
        public AlternativeEducationEligibilityReasonDescriptorDelete() { }

        public AlternativeEducationEligibilityReasonDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociations
{

    [ExcludeFromCodeCoverage]
    public class StudentAlternativeEducationProgramAssociationGetByExample
    {
        public string AlternativeEducationEligibilityReasonDescriptor { get; set; }
        public DateTime BeginDate { get; set; }
        public long EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public long ProgramEducationOrganizationId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentAlternativeEducationProgramAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentAlternativeEducationProgramAssociationGetByIds() { }

        public StudentAlternativeEducationProgramAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentAlternativeEducationProgramAssociationPost : Resources.StudentAlternativeEducationProgramAssociation.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentAlternativeEducationProgramAssociationPut : Resources.StudentAlternativeEducationProgramAssociation.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentAlternativeEducationProgramAssociationDelete : IHasIdentifier
    {
        public StudentAlternativeEducationProgramAssociationDelete() { }

        public StudentAlternativeEducationProgramAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

