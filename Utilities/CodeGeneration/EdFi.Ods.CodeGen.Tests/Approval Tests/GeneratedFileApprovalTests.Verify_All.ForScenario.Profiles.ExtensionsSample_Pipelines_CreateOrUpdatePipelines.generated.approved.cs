using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.CreateOrUpdate;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Factories;

namespace EdFi.Ods.Api.Pipelines.Staff_Entity_Extension_IncludeOnly
{
    [ExcludeFromCodeCoverage]
    public class StaffCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.Staff.EdFi.Staff_Entity_Extension_IncludeOnly_Writable.Staff, Entities.NHibernate.StaffAggregate.EdFi.Staff>
    {
        public StaffCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Staff_Entity_Extension_ExcludeOnly
{
    [ExcludeFromCodeCoverage]
    public class StaffCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.Staff.EdFi.Staff_Entity_Extension_ExcludeOnly_Writable.Staff, Entities.NHibernate.StaffAggregate.EdFi.Staff>
    {
        public StaffCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Staff_Include_All
{
    [ExcludeFromCodeCoverage]
    public class StaffCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.Staff.EdFi.Staff_Include_All_Writable.Staff, Entities.NHibernate.StaffAggregate.EdFi.Staff>
    {
        public StaffCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Staff_and_Prospect_MixedInclude
{
    [ExcludeFromCodeCoverage]
    public class StaffCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.Staff.EdFi.Staff_and_Prospect_MixedInclude_Writable.Staff, Entities.NHibernate.StaffAggregate.EdFi.Staff>
    {
        public StaffCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class BusRouteCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.BusRoute.Sample.Staff_and_Prospect_MixedInclude_Writable.BusRoute, Entities.NHibernate.BusRouteAggregate.Sample.BusRoute>
    {
        public BusRouteCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.BusRoute_MixedInclude
{
    [ExcludeFromCodeCoverage]
    public class BusRouteCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.BusRoute.Sample.BusRoute_MixedInclude_Writable.BusRoute, Entities.NHibernate.BusRouteAggregate.Sample.BusRoute>
    {
        public BusRouteCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Staff_and_Prospect_MixedExclude
{
    [ExcludeFromCodeCoverage]
    public class StaffCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.Staff.EdFi.Staff_and_Prospect_MixedExclude_Writable.Staff, Entities.NHibernate.StaffAggregate.EdFi.Staff>
    {
        public StaffCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class BusRouteCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.BusRoute.Sample.Staff_and_Prospect_MixedExclude_Writable.BusRoute, Entities.NHibernate.BusRouteAggregate.Sample.BusRoute>
    {
        public BusRouteCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Staff_and_Prospect_MixedExclude2
{
    [ExcludeFromCodeCoverage]
    public class StaffCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.Staff.EdFi.Staff_and_Prospect_MixedExclude2_Writable.Staff, Entities.NHibernate.StaffAggregate.EdFi.Staff>
    {
        public StaffCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class BusRouteCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.BusRoute.Sample.Staff_and_Prospect_MixedExclude2_Writable.BusRoute, Entities.NHibernate.BusRouteAggregate.Sample.BusRoute>
    {
        public BusRouteCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.BusRoute_MixedInclude2
{
    [ExcludeFromCodeCoverage]
    public class BusRouteCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.BusRoute.Sample.BusRoute_MixedInclude2_Writable.BusRoute, Entities.NHibernate.BusRouteAggregate.Sample.BusRoute>
    {
        public BusRouteCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.BusRoute_MixedInclude1
{
    [ExcludeFromCodeCoverage]
    public class BusRouteCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.BusRoute.Sample.BusRoute_MixedInclude1_Writable.BusRoute, Entities.NHibernate.BusRouteAggregate.Sample.BusRoute>
    {
        public BusRouteCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Student_Include_All
{
    [ExcludeFromCodeCoverage]
    public class StudentCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.Student.EdFi.Student_Include_All_Writable.Student, Entities.NHibernate.StudentAggregate.EdFi.Student>
    {
        public StudentCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}
