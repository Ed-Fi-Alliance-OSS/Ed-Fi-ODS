using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.CreateOrUpdate;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Factories;

namespace EdFi.Ods.Api.Pipelines.Test_Profile_Resource_ExcludeOnly
{
    [ExcludeFromCodeCoverage]
    public class SchoolCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.School.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School, Entities.NHibernate.SchoolAggregate.EdFi.School>
    {
        public SchoolCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Test_Profile_Resource_IncludeOnly
{
    [ExcludeFromCodeCoverage]
    public class SchoolCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.School.EdFi.Test_Profile_Resource_IncludeOnly_Writable.School, Entities.NHibernate.SchoolAggregate.EdFi.School>
    {
        public SchoolCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Test_Profile_Resource_ReadOnly
{
}

namespace EdFi.Ods.Api.Pipelines.Test_Profile_Resource_WriteOnly
{
    [ExcludeFromCodeCoverage]
    public class SchoolCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.School.EdFi.Test_Profile_Resource_WriteOnly_Writable.School, Entities.NHibernate.SchoolAggregate.EdFi.School>
    {
        public SchoolCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}
