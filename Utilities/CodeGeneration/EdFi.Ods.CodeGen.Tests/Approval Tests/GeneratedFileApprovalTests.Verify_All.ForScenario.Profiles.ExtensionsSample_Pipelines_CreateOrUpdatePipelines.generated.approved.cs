using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Pipelines;
using EdFi.Ods.Pipelines.Factories;

namespace EdFi.Ods.Api.Pipelines.Staff_Entity_Extension_IncludeOnly
{
    [ExcludeFromCodeCoverage]
    public class StaffCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.Staff.EdFi.Staff_Entity_Extension_IncludeOnly_Writable.Staff, Entities.NHibernate.StaffAggregate.EdFi.Staff>
    {
        public StaffCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Staff_Entity_Extension_ExcludeOnly
{
    [ExcludeFromCodeCoverage]
    public class StaffCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.Staff.EdFi.Staff_Entity_Extension_ExcludeOnly_Writable.Staff, Entities.NHibernate.StaffAggregate.EdFi.Staff>
    {
        public StaffCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Staff_Include_All
{
    [ExcludeFromCodeCoverage]
    public class StaffCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.Staff.EdFi.Staff_Include_All_Writable.Staff, Entities.NHibernate.StaffAggregate.EdFi.Staff>
    {
        public StaffCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Staff_and_Prospect_MixedInclude
{
    [ExcludeFromCodeCoverage]
    public class StaffCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.Staff.EdFi.Staff_and_Prospect_MixedInclude_Writable.Staff, Entities.NHibernate.StaffAggregate.EdFi.Staff>
    {
        public StaffCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.Applicant.GrandBend.Staff_and_Prospect_MixedInclude_Writable.Applicant, Entities.NHibernate.ApplicantAggregate.GrandBend.Applicant>
    {
        public ApplicantCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Applicant_MixedInclude
{
    [ExcludeFromCodeCoverage]
    public class ApplicantCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.Applicant.GrandBend.Applicant_MixedInclude_Writable.Applicant, Entities.NHibernate.ApplicantAggregate.GrandBend.Applicant>
    {
        public ApplicantCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Staff_and_Prospect_MixedExclude
{
    [ExcludeFromCodeCoverage]
    public class StaffCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.Staff.EdFi.Staff_and_Prospect_MixedExclude_Writable.Staff, Entities.NHibernate.StaffAggregate.EdFi.Staff>
    {
        public StaffCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.Applicant.GrandBend.Staff_and_Prospect_MixedExclude_Writable.Applicant, Entities.NHibernate.ApplicantAggregate.GrandBend.Applicant>
    {
        public ApplicantCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Staff_and_Prospect_MixedExclude2
{
    [ExcludeFromCodeCoverage]
    public class StaffCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.Staff.EdFi.Staff_and_Prospect_MixedExclude2_Writable.Staff, Entities.NHibernate.StaffAggregate.EdFi.Staff>
    {
        public StaffCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.Applicant.GrandBend.Staff_and_Prospect_MixedExclude2_Writable.Applicant, Entities.NHibernate.ApplicantAggregate.GrandBend.Applicant>
    {
        public ApplicantCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Applicant_MixedInclude2
{
    [ExcludeFromCodeCoverage]
    public class ApplicantCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.Applicant.GrandBend.Applicant_MixedInclude2_Writable.Applicant, Entities.NHibernate.ApplicantAggregate.GrandBend.Applicant>
    {
        public ApplicantCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Applicant_MixedInclude1
{
    [ExcludeFromCodeCoverage]
    public class ApplicantCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.Applicant.GrandBend.Applicant_MixedInclude1_Writable.Applicant, Entities.NHibernate.ApplicantAggregate.GrandBend.Applicant>
    {
        public ApplicantCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Student_Include_All
{
    [ExcludeFromCodeCoverage]
    public class StudentCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.Student.EdFi.Student_Include_All_Writable.Student, Entities.NHibernate.StudentAggregate.EdFi.Student>
    {
        public StudentCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}
