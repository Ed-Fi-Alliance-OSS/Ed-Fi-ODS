using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Infrastructure.Pipelines.CreateOrUpdate;
using EdFi.Ods.Api.Infrastructure.Pipelines.Factories;

namespace EdFi.Ods.Api.Pipelines.Test_Profile_Resource_IncludeOnly
{
    [ExcludeFromCodeCoverage]
    public class SchoolCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.School.EdFi.Test_Profile_Resource_IncludeOnly_Writable.School, Entities.NHibernate.SchoolAggregate.EdFi.School>
    {
        public SchoolCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Test_Profile_Resource_ExcludeOnly
{
    [ExcludeFromCodeCoverage]
    public class SchoolCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.School.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School, Entities.NHibernate.SchoolAggregate.EdFi.School>
    {
        public SchoolCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Test_Profile_Resource_References_IncludeOnly
{
    [ExcludeFromCodeCoverage]
    public class SchoolCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.School.EdFi.Test_Profile_Resource_References_IncludeOnly_Writable.School, Entities.NHibernate.SchoolAggregate.EdFi.School>
    {
        public SchoolCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Test_Profile_Resource_References_ExcludeOnly
{
    [ExcludeFromCodeCoverage]
    public class SchoolCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.School.EdFi.Test_Profile_Resource_References_ExcludeOnly_Writable.School, Entities.NHibernate.SchoolAggregate.EdFi.School>
    {
        public SchoolCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Test_Profile_Resource_IncludeAll
{
    [ExcludeFromCodeCoverage]
    public class SchoolCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.School.EdFi.Test_Profile_Resource_IncludeAll_Writable.School, Entities.NHibernate.SchoolAggregate.EdFi.School>
    {
        public SchoolCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Test_Profile_StaffOnly_Resource_IncludeAll
{
    [ExcludeFromCodeCoverage]
    public class StaffCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.Staff.EdFi.Test_Profile_StaffOnly_Resource_IncludeAll_Writable.Staff, Entities.NHibernate.StaffAggregate.EdFi.Staff>
    {
        public StaffCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Test_Profile_StudentOnly_Resource_IncludeAll
{
    [ExcludeFromCodeCoverage]
    public class StudentCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.Student.EdFi.Test_Profile_StudentOnly_Resource_IncludeAll_Writable.Student, Entities.NHibernate.StudentAggregate.EdFi.Student>
    {
        public StudentCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Test_Profile_StudentOnly2_Resource_IncludeAll
{
    [ExcludeFromCodeCoverage]
    public class StudentCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.Student.EdFi.Test_Profile_StudentOnly2_Resource_IncludeAll_Writable.Student, Entities.NHibernate.StudentAggregate.EdFi.Student>
    {
        public StudentCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
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

namespace EdFi.Ods.Api.Pipelines.Test_Profile_Resource_Child_Collection_IncludeAll
{
    [ExcludeFromCodeCoverage]
    public class SchoolCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.School.EdFi.Test_Profile_Resource_Child_Collection_IncludeAll_Writable.School, Entities.NHibernate.SchoolAggregate.EdFi.School>
    {
        public SchoolCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Test_Profile_Resource_BaseClass_Child_Collection_IncludeOnly
{
    [ExcludeFromCodeCoverage]
    public class SchoolCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.School.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_IncludeOnly_Writable.School, Entities.NHibernate.SchoolAggregate.EdFi.School>
    {
        public SchoolCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Test_Profile_Resource_BaseClass_Child_Collection_ExcludeOnly
{
    [ExcludeFromCodeCoverage]
    public class SchoolCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.School.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_ExcludeOnly_Writable.School, Entities.NHibernate.SchoolAggregate.EdFi.School>
    {
        public SchoolCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Test_Profile_Resource_BaseClass_Child_Collection_ExcludeOnly_2
{
}

namespace EdFi.Ods.Api.Pipelines.Test_Profile_Resource_Child_Collection_Filtered_To_IncludeOnly_Specific_Descriptors
{
    [ExcludeFromCodeCoverage]
    public class SchoolCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.School.EdFi.Test_Profile_Resource_Child_Collection_Filtered_To_IncludeOnly_Specific_Descriptors_Writable.School, Entities.NHibernate.SchoolAggregate.EdFi.School>
    {
        public SchoolCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Test_Profile_Resource_Child_Collection_Filtered_To_ExcludeOnly_Specific_Descriptors
{
    [ExcludeFromCodeCoverage]
    public class SchoolCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.School.EdFi.Test_Profile_Resource_Child_Collection_Filtered_To_ExcludeOnly_Specific_Descriptors_Writable.School, Entities.NHibernate.SchoolAggregate.EdFi.School>
    {
        public SchoolCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_IncludeOnly_Specific_Types_and_Descriptors
{
    [ExcludeFromCodeCoverage]
    public class StudentAssessmentCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.StudentAssessment.EdFi.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_IncludeOnly_Specific_Types_and_Descriptors_Writable.StudentAssessment, Entities.NHibernate.StudentAssessmentAggregate.EdFi.StudentAssessment>
    {
        public StudentAssessmentCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_ExcludeOnly_Specific_Types_and_Descriptors
{
    [ExcludeFromCodeCoverage]
    public class StudentAssessmentCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.StudentAssessment.EdFi.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_ExcludeOnly_Specific_Types_and_Descriptors_Writable.StudentAssessment, Entities.NHibernate.StudentAssessmentAggregate.EdFi.StudentAssessment>
    {
        public StudentAssessmentCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Test_Profile_Student_and_School_Include_All
{
    [ExcludeFromCodeCoverage]
    public class SchoolCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.School.EdFi.Test_Profile_Student_and_School_Include_All_Writable.School, Entities.NHibernate.SchoolAggregate.EdFi.School>
    {
        public SchoolCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StudentCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.Student.EdFi.Test_Profile_Student_and_School_Include_All_Writable.Student, Entities.NHibernate.StudentAggregate.EdFi.Student>
    {
        public StudentCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly
{
    [ExcludeFromCodeCoverage]
    public class LocalEducationAgencyCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.LocalEducationAgency.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly_Writable.LocalEducationAgency, Entities.NHibernate.LocalEducationAgencyAggregate.EdFi.LocalEducationAgency>
    {
        public LocalEducationAgencyCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.School.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly_Writable.School, Entities.NHibernate.SchoolAggregate.EdFi.School>
    {
        public SchoolCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly
{
    [ExcludeFromCodeCoverage]
    public class LocalEducationAgencyCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.LocalEducationAgency.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly_Writable.LocalEducationAgency, Entities.NHibernate.LocalEducationAgencyAggregate.EdFi.LocalEducationAgency>
    {
        public LocalEducationAgencyCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.School.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly_Writable.School, Entities.NHibernate.SchoolAggregate.EdFi.School>
    {
        public SchoolCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Student_Readable_Restricted
{
}

namespace EdFi.Ods.Api.Pipelines.Assessment_Readable_Includes_Embedded_Object
{
}

namespace EdFi.Ods.Api.Pipelines.Assessment_Readable_Excludes_Embedded_Object
{
}

namespace EdFi.Ods.Api.Pipelines.Assessment_Writable_Includes_Embedded_Object
{
    [ExcludeFromCodeCoverage]
    public class AssessmentCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.Assessment.EdFi.Assessment_Writable_Includes_Embedded_Object_Writable.Assessment, Entities.NHibernate.AssessmentAggregate.EdFi.Assessment>
    {
        public AssessmentCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Assessment_Writable_Excludes_Embedded_Object
{
    [ExcludeFromCodeCoverage]
    public class AssessmentCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.Assessment.EdFi.Assessment_Writable_Excludes_Embedded_Object_Writable.Assessment, Entities.NHibernate.AssessmentAggregate.EdFi.Assessment>
    {
        public AssessmentCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.Test_Profile_For_Composites_With_Multiple_Resources
{
}

namespace EdFi.Ods.Api.Pipelines.Test_StudentEducationOrganizationAssociation_Exclude_All_Addrs_Except_Physical
{
}

namespace EdFi.Ods.Api.Pipelines.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeOnly
{
    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.StudentSpecialEducationProgramAssociation.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeOnly_Writable.StudentSpecialEducationProgramAssociation, Entities.NHibernate.StudentSpecialEducationProgramAssociationAggregate.EdFi.StudentSpecialEducationProgramAssociation>
    {
        public StudentSpecialEducationProgramAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.StudentSpecialEducationProgramAssociation_Derived_Association_ExcludeOnly
{
    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.StudentSpecialEducationProgramAssociation.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_ExcludeOnly_Writable.StudentSpecialEducationProgramAssociation, Entities.NHibernate.StudentSpecialEducationProgramAssociationAggregate.EdFi.StudentSpecialEducationProgramAssociation>
    {
        public StudentSpecialEducationProgramAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeAll
{
    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.StudentSpecialEducationProgramAssociation.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeAll_Writable.StudentSpecialEducationProgramAssociation, Entities.NHibernate.StudentSpecialEducationProgramAssociationAggregate.EdFi.StudentSpecialEducationProgramAssociation>
    {
        public StudentSpecialEducationProgramAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}

namespace EdFi.Ods.Api.Pipelines.MinimalStudentSchoolAssociation_IncludeOnly
{
}

namespace EdFi.Ods.Api.Pipelines.MinimalStudentSchoolAssociation_ExcludeOnly
{
}

namespace EdFi.Ods.Api.Pipelines.Test_Profile_Some_References_With_Unified_Keys_Included
{
}

namespace EdFi.Ods.Api.Pipelines.Profile_Validation_Regression_References
{
}
