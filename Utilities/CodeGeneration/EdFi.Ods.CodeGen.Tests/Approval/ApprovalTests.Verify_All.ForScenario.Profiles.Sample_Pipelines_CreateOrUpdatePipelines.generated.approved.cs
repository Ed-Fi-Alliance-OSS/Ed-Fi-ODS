using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Infrastructure.Pipelines.CreateOrUpdate;
using EdFi.Ods.Api.Infrastructure.Pipelines.Factories;

namespace EdFi.Ods.Api.Pipelines.Sample_Profile_Resource_ExcludeOnly
{
    [ExcludeFromCodeCoverage]
    public class SchoolCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.School.EdFi.Sample_Profile_Resource_ExcludeOnly_Writable.School, Entities.NHibernate.SchoolAggregate.EdFi.School>
    {
        public SchoolCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Sample_Profile_Resource_IncludeOnly
{
    [ExcludeFromCodeCoverage]
    public class SchoolCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.School.EdFi.Sample_Profile_Resource_IncludeOnly_Writable.School, Entities.NHibernate.SchoolAggregate.EdFi.School>
    {
        public SchoolCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Sample_Profile_Resource_ReadOnly
{
}

namespace EdFi.Ods.Api.Pipelines.Sample_Profile_Resource_WriteOnly
{
    [ExcludeFromCodeCoverage]
    public class SchoolCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.School.EdFi.Sample_Profile_Resource_WriteOnly_Writable.School, Entities.NHibernate.SchoolAggregate.EdFi.School>
    {
        public SchoolCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}
