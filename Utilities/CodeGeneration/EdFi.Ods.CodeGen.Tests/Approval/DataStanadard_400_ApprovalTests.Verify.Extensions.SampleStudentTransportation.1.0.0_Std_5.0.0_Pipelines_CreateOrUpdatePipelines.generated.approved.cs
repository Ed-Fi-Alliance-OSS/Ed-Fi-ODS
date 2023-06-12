using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Infrastructure.Pipelines.CreateOrUpdate;
using EdFi.Ods.Api.Infrastructure.Pipelines.Factories;

namespace EdFi.Ods.Api.Pipelines.SampleStudentTransportation
{
    [ExcludeFromCodeCoverage]
    public class StudentTransportationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.StudentTransportation.SampleStudentTransportation.StudentTransportation, Entities.NHibernate.StudentTransportationAggregate.SampleStudentTransportation.StudentTransportation>
    {
        public StudentTransportationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}
