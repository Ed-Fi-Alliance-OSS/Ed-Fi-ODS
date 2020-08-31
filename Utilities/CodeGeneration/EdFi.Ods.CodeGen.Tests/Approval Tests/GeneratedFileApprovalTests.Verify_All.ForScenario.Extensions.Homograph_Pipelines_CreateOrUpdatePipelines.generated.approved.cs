using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Infrastructure.Pipelines.CreateOrUpdate;
using EdFi.Ods.Api.Infrastructure.Pipelines.Factories;

namespace EdFi.Ods.Api.Pipelines.Homograph
{
    [ExcludeFromCodeCoverage]
    public class NameCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.Name.Homograph.Name, Entities.NHibernate.NameAggregate.Homograph.Name>
    {
        public NameCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ParentCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.Parent.Homograph.Parent, Entities.NHibernate.ParentAggregate.Homograph.Parent>
    {
        public ParentCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.School.Homograph.School, Entities.NHibernate.SchoolAggregate.Homograph.School>
    {
        public SchoolCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolYearTypeCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.SchoolYearType.Homograph.SchoolYearType, Entities.NHibernate.SchoolYearTypeAggregate.Homograph.SchoolYearType>
    {
        public SchoolYearTypeCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.Staff.Homograph.Staff, Entities.NHibernate.StaffAggregate.Homograph.Staff>
    {
        public StaffCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StudentCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.Student.Homograph.Student, Entities.NHibernate.StudentAggregate.Homograph.Student>
    {
        public StudentCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.StudentSchoolAssociation.Homograph.StudentSchoolAssociation, Entities.NHibernate.StudentSchoolAssociationAggregate.Homograph.StudentSchoolAssociation>
    {
        public StudentSchoolAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}
