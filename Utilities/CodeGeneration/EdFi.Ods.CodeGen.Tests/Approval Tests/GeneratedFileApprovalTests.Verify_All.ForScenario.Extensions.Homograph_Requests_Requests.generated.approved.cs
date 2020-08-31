using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Attributes;

namespace EdFi.Ods.Api.Common.Models.Requests.Homograph.Names
{

    [ExcludeFromCodeCoverage]
    public class NameGetByExample
    {
        public string FirstName { get; set; }
        public Guid Id { get; set; }
        public string LastSurname { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class NameGetByIds : IHasIdentifiers<Guid>
    {
        public NameGetByIds() { }

        public NameGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class NamePost : Resources.Name.Homograph.Name
    {
    }

    [ExcludeFromCodeCoverage]
    public class NamePut : Resources.Name.Homograph.Name
    {
    }

    [ExcludeFromCodeCoverage]
    public class NameDelete : IHasIdentifier
    {
        public NameDelete() { }

        public NameDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Homograph.Parents
{

    [ExcludeFromCodeCoverage]
    public class ParentGetByExample
    {
        public Guid Id { get; set; }
        public string ParentFirstName { get; set; }
        public string ParentLastSurname { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ParentGetByIds : IHasIdentifiers<Guid>
    {
        public ParentGetByIds() { }

        public ParentGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ParentPost : Resources.Parent.Homograph.Parent
    {
    }

    [ExcludeFromCodeCoverage]
    public class ParentPut : Resources.Parent.Homograph.Parent
    {
    }

    [ExcludeFromCodeCoverage]
    public class ParentDelete : IHasIdentifier
    {
        public ParentDelete() { }

        public ParentDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Homograph.Schools
{

    [ExcludeFromCodeCoverage]
    public class SchoolGetByExample
    {
        public Guid Id { get; set; }
        public string SchoolName { get; set; }
        public string SchoolYear { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolGetByIds : IHasIdentifiers<Guid>
    {
        public SchoolGetByIds() { }

        public SchoolGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolPost : Resources.School.Homograph.School
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolPut : Resources.School.Homograph.School
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolDelete : IHasIdentifier
    {
        public SchoolDelete() { }

        public SchoolDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Homograph.SchoolYearTypes
{

    [ExcludeFromCodeCoverage]
    public class SchoolYearTypeGetByExample
    {
        public Guid Id { get; set; }
        public string SchoolYear { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolYearTypeGetByIds : IHasIdentifiers<Guid>
    {
        public SchoolYearTypeGetByIds() { }

        public SchoolYearTypeGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolYearTypePost : Resources.SchoolYearType.Homograph.SchoolYearType
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolYearTypePut : Resources.SchoolYearType.Homograph.SchoolYearType
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolYearTypeDelete : IHasIdentifier
    {
        public SchoolYearTypeDelete() { }

        public SchoolYearTypeDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Homograph.Staffs
{

    [ExcludeFromCodeCoverage]
    public class StaffGetByExample
    {
        public Guid Id { get; set; }
        public string StaffFirstName { get; set; }
        public string StaffLastSurname { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffGetByIds : IHasIdentifiers<Guid>
    {
        public StaffGetByIds() { }

        public StaffGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffPost : Resources.Staff.Homograph.Staff
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffPut : Resources.Staff.Homograph.Staff
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffDelete : IHasIdentifier
    {
        public StaffDelete() { }

        public StaffDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Homograph.Students
{

    [ExcludeFromCodeCoverage]
    public class StudentGetByExample
    {
        public Guid Id { get; set; }
        public string SchoolYear { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastSurname { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentGetByIds : IHasIdentifiers<Guid>
    {
        public StudentGetByIds() { }

        public StudentGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentPost : Resources.Student.Homograph.Student
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentPut : Resources.Student.Homograph.Student
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentDelete : IHasIdentifier
    {
        public StudentDelete() { }

        public StudentDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Homograph.StudentSchoolAssociations
{

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationGetByExample
    {
        public Guid Id { get; set; }
        public string SchoolName { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastSurname { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentSchoolAssociationGetByIds() { }

        public StudentSchoolAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationPost : Resources.StudentSchoolAssociation.Homograph.StudentSchoolAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationPut : Resources.StudentSchoolAssociation.Homograph.StudentSchoolAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationDelete : IHasIdentifier
    {
        public StudentSchoolAssociationDelete() { }

        public StudentSchoolAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

