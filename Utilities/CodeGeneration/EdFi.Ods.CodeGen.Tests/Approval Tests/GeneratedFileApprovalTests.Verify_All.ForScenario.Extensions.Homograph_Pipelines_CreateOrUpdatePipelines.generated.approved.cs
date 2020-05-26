using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Pipelines;
using EdFi.Ods.Pipelines.Factories;

namespace EdFi.Ods.Api.Pipelines.Homograph
{
    [ExcludeFromCodeCoverage]
    public class NameCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.Name.Homograph.Name, Entities.NHibernate.NameAggregate.Homograph.Name>
    {
        public NameCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ParentCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.Parent.Homograph.Parent, Entities.NHibernate.ParentAggregate.Homograph.Parent>
    {
        public ParentCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.School.Homograph.School, Entities.NHibernate.SchoolAggregate.Homograph.School>
    {
        public SchoolCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolYearTypeCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.SchoolYearType.Homograph.SchoolYearType, Entities.NHibernate.SchoolYearTypeAggregate.Homograph.SchoolYearType>
    {
        public SchoolYearTypeCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.Staff.Homograph.Staff, Entities.NHibernate.StaffAggregate.Homograph.Staff>
    {
        public StaffCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StudentCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.Student.Homograph.Student, Entities.NHibernate.StudentAggregate.Homograph.Student>
    {
        public StudentCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StudentSchoolAssociation.Homograph.StudentSchoolAssociation, Entities.NHibernate.StudentSchoolAssociationAggregate.Homograph.StudentSchoolAssociation>
    {
        public StudentSchoolAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}
