using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Pipelines;
using EdFi.Ods.Pipelines.Factories;

namespace EdFi.Ods.Api.Pipelines.GrandBend
{
    [ExcludeFromCodeCoverage]
    public class ApplicantCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.Applicant.GrandBend.Applicant, Entities.NHibernate.ApplicantAggregate.GrandBend.Applicant>
    {
        public ApplicantCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}
