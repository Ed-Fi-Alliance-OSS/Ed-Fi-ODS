using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Infrastructure.Pipelines.CreateOrUpdate;
using EdFi.Ods.Api.Infrastructure.Pipelines.Factories;

namespace EdFi.Ods.Api.Pipelines.SampleStudentTranscript
{
    [ExcludeFromCodeCoverage]
    public class InstitutionControlDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.InstitutionControlDescriptor.SampleStudentTranscript.InstitutionControlDescriptor, Entities.NHibernate.InstitutionControlDescriptorAggregate.SampleStudentTranscript.InstitutionControlDescriptor>
    {
        public InstitutionControlDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class InstitutionLevelDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.InstitutionLevelDescriptor.SampleStudentTranscript.InstitutionLevelDescriptor, Entities.NHibernate.InstitutionLevelDescriptorAggregate.SampleStudentTranscript.InstitutionLevelDescriptor>
    {
        public InstitutionLevelDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class PostSecondaryOrganizationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.PostSecondaryOrganization.SampleStudentTranscript.PostSecondaryOrganization, Entities.NHibernate.PostSecondaryOrganizationAggregate.SampleStudentTranscript.PostSecondaryOrganization>
    {
        public PostSecondaryOrganizationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class SpecialEducationGraduationStatusDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.SpecialEducationGraduationStatusDescriptor.SampleStudentTranscript.SpecialEducationGraduationStatusDescriptor, Entities.NHibernate.SpecialEducationGraduationStatusDescriptorAggregate.SampleStudentTranscript.SpecialEducationGraduationStatusDescriptor>
    {
        public SpecialEducationGraduationStatusDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class SubmissionCertificationDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.SubmissionCertificationDescriptor.SampleStudentTranscript.SubmissionCertificationDescriptor, Entities.NHibernate.SubmissionCertificationDescriptorAggregate.SampleStudentTranscript.SubmissionCertificationDescriptor>
    {
        public SubmissionCertificationDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}
