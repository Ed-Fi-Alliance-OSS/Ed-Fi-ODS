using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Infrastructure.Pipelines.CreateOrUpdate;
using EdFi.Ods.Api.Infrastructure.Pipelines.Factories;

namespace EdFi.Ods.Api.Pipelines.SampleAlternativeEducationProgram
{
    [ExcludeFromCodeCoverage]
    public class AlternativeEducationEligibilityReasonDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.AlternativeEducationEligibilityReasonDescriptor.SampleAlternativeEducationProgram.AlternativeEducationEligibilityReasonDescriptor, Entities.NHibernate.AlternativeEducationEligibilityReasonDescriptorAggregate.SampleAlternativeEducationProgram.AlternativeEducationEligibilityReasonDescriptor>
    {
        public AlternativeEducationEligibilityReasonDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StudentAlternativeEducationProgramAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.StudentAlternativeEducationProgramAssociation.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociation, Entities.NHibernate.StudentAlternativeEducationProgramAssociationAggregate.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociation>
    {
        public StudentAlternativeEducationProgramAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}
