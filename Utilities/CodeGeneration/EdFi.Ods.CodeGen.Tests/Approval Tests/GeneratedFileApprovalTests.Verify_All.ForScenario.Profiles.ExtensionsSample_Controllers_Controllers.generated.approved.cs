using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Entities.Common.EdFi;
using EdFi.Ods.Pipelines.Factories;
using EdFi.Ods.Api.Services.CustomActionResults;
using EdFi.Ods.Api.Services.Queries;
using EdFi.Ods.Api.Services.Requests;

namespace EdFi.Ods.Api.Services.Controllers.GrandBend.Applicants.Applicant_MixedInclude
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ApplicantsController : EdFiControllerBase<
        Models.Resources.Applicant.GrandBend.Applicant_MixedInclude_Readable.Applicant,
        Models.Resources.Applicant.GrandBend.Applicant_MixedInclude_Writable.Applicant,
        Entities.Common.GrandBend.IApplicant,
        Entities.NHibernate.ApplicantAggregate.GrandBend.Applicant,
        Api.Models.Requests.GrandBend.Applicants.Applicant_MixedInclude.ApplicantPut,
        Api.Models.Requests.GrandBend.Applicants.Applicant_MixedInclude.ApplicantPost,
        Api.Models.Requests.GrandBend.Applicants.Applicant_MixedInclude.ApplicantDelete,
        Api.Models.Requests.GrandBend.Applicants.Applicant_MixedInclude.ApplicantGetByExample>
    {
        public ApplicantsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.GrandBend.Applicants.Applicant_MixedInclude.ApplicantGetByExample request, Entities.Common.GrandBend.IApplicant specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ApplicantIdentifier = request.ApplicantIdentifier;
            specification.BirthDate = request.BirthDate;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HighestCompletedLevelOfEducationDescriptor = request.HighestCompletedLevelOfEducationDescriptor;
            specification.HighlyQualifiedAcademicSubjectDescriptor = request.HighlyQualifiedAcademicSubjectDescriptor;
            specification.HighlyQualifiedTeacher = request.HighlyQualifiedTeacher;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.LoginId = request.LoginId;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.SexDescriptor = request.SexDescriptor;
            specification.YearsOfPriorProfessionalExperience = request.YearsOfPriorProfessionalExperience;
            specification.YearsOfPriorTeachingExperience = request.YearsOfPriorTeachingExperience;
                    }

        protected override string GetResourceCollectionName()
        {
            return "applicants";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.applicant.applicant-mixedinclude.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GrandBend.Applicants.Applicant_MixedInclude1
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ApplicantsController : EdFiControllerBase<
        Models.Resources.Applicant.GrandBend.Applicant_MixedInclude1_Readable.Applicant,
        Models.Resources.Applicant.GrandBend.Applicant_MixedInclude1_Writable.Applicant,
        Entities.Common.GrandBend.IApplicant,
        Entities.NHibernate.ApplicantAggregate.GrandBend.Applicant,
        Api.Models.Requests.GrandBend.Applicants.Applicant_MixedInclude1.ApplicantPut,
        Api.Models.Requests.GrandBend.Applicants.Applicant_MixedInclude1.ApplicantPost,
        Api.Models.Requests.GrandBend.Applicants.Applicant_MixedInclude1.ApplicantDelete,
        Api.Models.Requests.GrandBend.Applicants.Applicant_MixedInclude1.ApplicantGetByExample>
    {
        public ApplicantsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.GrandBend.Applicants.Applicant_MixedInclude1.ApplicantGetByExample request, Entities.Common.GrandBend.IApplicant specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ApplicantIdentifier = request.ApplicantIdentifier;
            specification.BirthDate = request.BirthDate;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HighestCompletedLevelOfEducationDescriptor = request.HighestCompletedLevelOfEducationDescriptor;
            specification.HighlyQualifiedAcademicSubjectDescriptor = request.HighlyQualifiedAcademicSubjectDescriptor;
            specification.HighlyQualifiedTeacher = request.HighlyQualifiedTeacher;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.LoginId = request.LoginId;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.SexDescriptor = request.SexDescriptor;
            specification.YearsOfPriorProfessionalExperience = request.YearsOfPriorProfessionalExperience;
            specification.YearsOfPriorTeachingExperience = request.YearsOfPriorTeachingExperience;
                    }

        protected override string GetResourceCollectionName()
        {
            return "applicants";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.applicant.applicant-mixedinclude1.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GrandBend.Applicants.Applicant_MixedInclude2
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ApplicantsController : EdFiControllerBase<
        Models.Resources.Applicant.GrandBend.Applicant_MixedInclude2_Readable.Applicant,
        Models.Resources.Applicant.GrandBend.Applicant_MixedInclude2_Writable.Applicant,
        Entities.Common.GrandBend.IApplicant,
        Entities.NHibernate.ApplicantAggregate.GrandBend.Applicant,
        Api.Models.Requests.GrandBend.Applicants.Applicant_MixedInclude2.ApplicantPut,
        Api.Models.Requests.GrandBend.Applicants.Applicant_MixedInclude2.ApplicantPost,
        Api.Models.Requests.GrandBend.Applicants.Applicant_MixedInclude2.ApplicantDelete,
        Api.Models.Requests.GrandBend.Applicants.Applicant_MixedInclude2.ApplicantGetByExample>
    {
        public ApplicantsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.GrandBend.Applicants.Applicant_MixedInclude2.ApplicantGetByExample request, Entities.Common.GrandBend.IApplicant specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ApplicantIdentifier = request.ApplicantIdentifier;
            specification.BirthDate = request.BirthDate;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HighestCompletedLevelOfEducationDescriptor = request.HighestCompletedLevelOfEducationDescriptor;
            specification.HighlyQualifiedAcademicSubjectDescriptor = request.HighlyQualifiedAcademicSubjectDescriptor;
            specification.HighlyQualifiedTeacher = request.HighlyQualifiedTeacher;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.LoginId = request.LoginId;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.SexDescriptor = request.SexDescriptor;
            specification.YearsOfPriorProfessionalExperience = request.YearsOfPriorProfessionalExperience;
            specification.YearsOfPriorTeachingExperience = request.YearsOfPriorTeachingExperience;
                    }

        protected override string GetResourceCollectionName()
        {
            return "applicants";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.applicant.applicant-mixedinclude2.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GrandBend.Applicants.Staff_and_Prospect_MixedExclude
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ApplicantsController : EdFiControllerBase<
        Models.Resources.Applicant.GrandBend.Staff_and_Prospect_MixedExclude_Readable.Applicant,
        Models.Resources.Applicant.GrandBend.Staff_and_Prospect_MixedExclude_Writable.Applicant,
        Entities.Common.GrandBend.IApplicant,
        Entities.NHibernate.ApplicantAggregate.GrandBend.Applicant,
        Api.Models.Requests.GrandBend.Applicants.Staff_and_Prospect_MixedExclude.ApplicantPut,
        Api.Models.Requests.GrandBend.Applicants.Staff_and_Prospect_MixedExclude.ApplicantPost,
        Api.Models.Requests.GrandBend.Applicants.Staff_and_Prospect_MixedExclude.ApplicantDelete,
        Api.Models.Requests.GrandBend.Applicants.Staff_and_Prospect_MixedExclude.ApplicantGetByExample>
    {
        public ApplicantsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.GrandBend.Applicants.Staff_and_Prospect_MixedExclude.ApplicantGetByExample request, Entities.Common.GrandBend.IApplicant specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ApplicantIdentifier = request.ApplicantIdentifier;
            specification.BirthDate = request.BirthDate;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HighestCompletedLevelOfEducationDescriptor = request.HighestCompletedLevelOfEducationDescriptor;
            specification.HighlyQualifiedAcademicSubjectDescriptor = request.HighlyQualifiedAcademicSubjectDescriptor;
            specification.HighlyQualifiedTeacher = request.HighlyQualifiedTeacher;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.LoginId = request.LoginId;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.SexDescriptor = request.SexDescriptor;
            specification.YearsOfPriorProfessionalExperience = request.YearsOfPriorProfessionalExperience;
            specification.YearsOfPriorTeachingExperience = request.YearsOfPriorTeachingExperience;
                    }

        protected override string GetResourceCollectionName()
        {
            return "applicants";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.applicant.staff-and-prospect-mixedexclude.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Staffs.EdFi.Staff_and_Prospect_MixedExclude
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffsController : EdFiControllerBase<
        Models.Resources.Staff.EdFi.Staff_and_Prospect_MixedExclude_Readable.Staff,
        Models.Resources.Staff.EdFi.Staff_and_Prospect_MixedExclude_Writable.Staff,
        Entities.Common.EdFi.IStaff,
        Entities.NHibernate.StaffAggregate.EdFi.Staff,
        Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedExclude.StaffPut,
        Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedExclude.StaffPost,
        Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedExclude.StaffDelete,
        Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedExclude.StaffGetByExample>
    {
        public StaffsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedExclude.StaffGetByExample request, IStaff specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BirthDate = request.BirthDate;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HighestCompletedLevelOfEducationDescriptor = request.HighestCompletedLevelOfEducationDescriptor;
            specification.HighlyQualifiedTeacher = request.HighlyQualifiedTeacher;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.LoginId = request.LoginId;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.OldEthnicityDescriptor = request.OldEthnicityDescriptor;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PersonId = request.PersonId;
            specification.SexDescriptor = request.SexDescriptor;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.YearsOfPriorProfessionalExperience = request.YearsOfPriorProfessionalExperience;
            specification.YearsOfPriorTeachingExperience = request.YearsOfPriorTeachingExperience;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffs";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.staff.staff-and-prospect-mixedexclude.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GrandBend.Applicants.Staff_and_Prospect_MixedExclude2
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ApplicantsController : EdFiControllerBase<
        Models.Resources.Applicant.GrandBend.Staff_and_Prospect_MixedExclude2_Readable.Applicant,
        Models.Resources.Applicant.GrandBend.Staff_and_Prospect_MixedExclude2_Writable.Applicant,
        Entities.Common.GrandBend.IApplicant,
        Entities.NHibernate.ApplicantAggregate.GrandBend.Applicant,
        Api.Models.Requests.GrandBend.Applicants.Staff_and_Prospect_MixedExclude2.ApplicantPut,
        Api.Models.Requests.GrandBend.Applicants.Staff_and_Prospect_MixedExclude2.ApplicantPost,
        Api.Models.Requests.GrandBend.Applicants.Staff_and_Prospect_MixedExclude2.ApplicantDelete,
        Api.Models.Requests.GrandBend.Applicants.Staff_and_Prospect_MixedExclude2.ApplicantGetByExample>
    {
        public ApplicantsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.GrandBend.Applicants.Staff_and_Prospect_MixedExclude2.ApplicantGetByExample request, Entities.Common.GrandBend.IApplicant specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ApplicantIdentifier = request.ApplicantIdentifier;
            specification.BirthDate = request.BirthDate;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HighestCompletedLevelOfEducationDescriptor = request.HighestCompletedLevelOfEducationDescriptor;
            specification.HighlyQualifiedAcademicSubjectDescriptor = request.HighlyQualifiedAcademicSubjectDescriptor;
            specification.HighlyQualifiedTeacher = request.HighlyQualifiedTeacher;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.LoginId = request.LoginId;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.SexDescriptor = request.SexDescriptor;
            specification.YearsOfPriorProfessionalExperience = request.YearsOfPriorProfessionalExperience;
            specification.YearsOfPriorTeachingExperience = request.YearsOfPriorTeachingExperience;
                    }

        protected override string GetResourceCollectionName()
        {
            return "applicants";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.applicant.staff-and-prospect-mixedexclude2.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Staffs.EdFi.Staff_and_Prospect_MixedExclude2
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffsController : EdFiControllerBase<
        Models.Resources.Staff.EdFi.Staff_and_Prospect_MixedExclude2_Readable.Staff,
        Models.Resources.Staff.EdFi.Staff_and_Prospect_MixedExclude2_Writable.Staff,
        Entities.Common.EdFi.IStaff,
        Entities.NHibernate.StaffAggregate.EdFi.Staff,
        Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedExclude2.StaffPut,
        Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedExclude2.StaffPost,
        Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedExclude2.StaffDelete,
        Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedExclude2.StaffGetByExample>
    {
        public StaffsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedExclude2.StaffGetByExample request, IStaff specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BirthDate = request.BirthDate;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HighestCompletedLevelOfEducationDescriptor = request.HighestCompletedLevelOfEducationDescriptor;
            specification.HighlyQualifiedTeacher = request.HighlyQualifiedTeacher;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.LoginId = request.LoginId;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.OldEthnicityDescriptor = request.OldEthnicityDescriptor;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PersonId = request.PersonId;
            specification.SexDescriptor = request.SexDescriptor;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.YearsOfPriorProfessionalExperience = request.YearsOfPriorProfessionalExperience;
            specification.YearsOfPriorTeachingExperience = request.YearsOfPriorTeachingExperience;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffs";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.staff.staff-and-prospect-mixedexclude2.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GrandBend.Applicants.Staff_and_Prospect_MixedInclude
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ApplicantsController : EdFiControllerBase<
        Models.Resources.Applicant.GrandBend.Staff_and_Prospect_MixedInclude_Readable.Applicant,
        Models.Resources.Applicant.GrandBend.Staff_and_Prospect_MixedInclude_Writable.Applicant,
        Entities.Common.GrandBend.IApplicant,
        Entities.NHibernate.ApplicantAggregate.GrandBend.Applicant,
        Api.Models.Requests.GrandBend.Applicants.Staff_and_Prospect_MixedInclude.ApplicantPut,
        Api.Models.Requests.GrandBend.Applicants.Staff_and_Prospect_MixedInclude.ApplicantPost,
        Api.Models.Requests.GrandBend.Applicants.Staff_and_Prospect_MixedInclude.ApplicantDelete,
        Api.Models.Requests.GrandBend.Applicants.Staff_and_Prospect_MixedInclude.ApplicantGetByExample>
    {
        public ApplicantsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.GrandBend.Applicants.Staff_and_Prospect_MixedInclude.ApplicantGetByExample request, Entities.Common.GrandBend.IApplicant specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ApplicantIdentifier = request.ApplicantIdentifier;
            specification.BirthDate = request.BirthDate;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HighestCompletedLevelOfEducationDescriptor = request.HighestCompletedLevelOfEducationDescriptor;
            specification.HighlyQualifiedAcademicSubjectDescriptor = request.HighlyQualifiedAcademicSubjectDescriptor;
            specification.HighlyQualifiedTeacher = request.HighlyQualifiedTeacher;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.LoginId = request.LoginId;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.SexDescriptor = request.SexDescriptor;
            specification.YearsOfPriorProfessionalExperience = request.YearsOfPriorProfessionalExperience;
            specification.YearsOfPriorTeachingExperience = request.YearsOfPriorTeachingExperience;
                    }

        protected override string GetResourceCollectionName()
        {
            return "applicants";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.applicant.staff-and-prospect-mixedinclude.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Staffs.EdFi.Staff_and_Prospect_MixedInclude
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffsController : EdFiControllerBase<
        Models.Resources.Staff.EdFi.Staff_and_Prospect_MixedInclude_Readable.Staff,
        Models.Resources.Staff.EdFi.Staff_and_Prospect_MixedInclude_Writable.Staff,
        Entities.Common.EdFi.IStaff,
        Entities.NHibernate.StaffAggregate.EdFi.Staff,
        Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedInclude.StaffPut,
        Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedInclude.StaffPost,
        Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedInclude.StaffDelete,
        Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedInclude.StaffGetByExample>
    {
        public StaffsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedInclude.StaffGetByExample request, IStaff specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BirthDate = request.BirthDate;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HighestCompletedLevelOfEducationDescriptor = request.HighestCompletedLevelOfEducationDescriptor;
            specification.HighlyQualifiedTeacher = request.HighlyQualifiedTeacher;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.LoginId = request.LoginId;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.OldEthnicityDescriptor = request.OldEthnicityDescriptor;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PersonId = request.PersonId;
            specification.SexDescriptor = request.SexDescriptor;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.YearsOfPriorProfessionalExperience = request.YearsOfPriorProfessionalExperience;
            specification.YearsOfPriorTeachingExperience = request.YearsOfPriorTeachingExperience;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffs";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.staff.staff-and-prospect-mixedinclude.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Staffs.EdFi.Staff_Entity_Extension_ExcludeOnly
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffsController : EdFiControllerBase<
        Models.Resources.Staff.EdFi.Staff_Entity_Extension_ExcludeOnly_Readable.Staff,
        Models.Resources.Staff.EdFi.Staff_Entity_Extension_ExcludeOnly_Writable.Staff,
        Entities.Common.EdFi.IStaff,
        Entities.NHibernate.StaffAggregate.EdFi.Staff,
        Api.Models.Requests.Staffs.EdFi.Staff_Entity_Extension_ExcludeOnly.StaffPut,
        Api.Models.Requests.Staffs.EdFi.Staff_Entity_Extension_ExcludeOnly.StaffPost,
        Api.Models.Requests.Staffs.EdFi.Staff_Entity_Extension_ExcludeOnly.StaffDelete,
        Api.Models.Requests.Staffs.EdFi.Staff_Entity_Extension_ExcludeOnly.StaffGetByExample>
    {
        public StaffsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Staffs.EdFi.Staff_Entity_Extension_ExcludeOnly.StaffGetByExample request, IStaff specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BirthDate = request.BirthDate;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HighestCompletedLevelOfEducationDescriptor = request.HighestCompletedLevelOfEducationDescriptor;
            specification.HighlyQualifiedTeacher = request.HighlyQualifiedTeacher;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.LoginId = request.LoginId;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.OldEthnicityDescriptor = request.OldEthnicityDescriptor;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PersonId = request.PersonId;
            specification.SexDescriptor = request.SexDescriptor;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.YearsOfPriorProfessionalExperience = request.YearsOfPriorProfessionalExperience;
            specification.YearsOfPriorTeachingExperience = request.YearsOfPriorTeachingExperience;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffs";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.staff.staff-entity-extension-excludeonly.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Staffs.EdFi.Staff_Entity_Extension_IncludeOnly
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffsController : EdFiControllerBase<
        Models.Resources.Staff.EdFi.Staff_Entity_Extension_IncludeOnly_Readable.Staff,
        Models.Resources.Staff.EdFi.Staff_Entity_Extension_IncludeOnly_Writable.Staff,
        Entities.Common.EdFi.IStaff,
        Entities.NHibernate.StaffAggregate.EdFi.Staff,
        Api.Models.Requests.Staffs.EdFi.Staff_Entity_Extension_IncludeOnly.StaffPut,
        Api.Models.Requests.Staffs.EdFi.Staff_Entity_Extension_IncludeOnly.StaffPost,
        Api.Models.Requests.Staffs.EdFi.Staff_Entity_Extension_IncludeOnly.StaffDelete,
        Api.Models.Requests.Staffs.EdFi.Staff_Entity_Extension_IncludeOnly.StaffGetByExample>
    {
        public StaffsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Staffs.EdFi.Staff_Entity_Extension_IncludeOnly.StaffGetByExample request, IStaff specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BirthDate = request.BirthDate;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HighestCompletedLevelOfEducationDescriptor = request.HighestCompletedLevelOfEducationDescriptor;
            specification.HighlyQualifiedTeacher = request.HighlyQualifiedTeacher;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.LoginId = request.LoginId;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.OldEthnicityDescriptor = request.OldEthnicityDescriptor;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PersonId = request.PersonId;
            specification.SexDescriptor = request.SexDescriptor;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.YearsOfPriorProfessionalExperience = request.YearsOfPriorProfessionalExperience;
            specification.YearsOfPriorTeachingExperience = request.YearsOfPriorTeachingExperience;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffs";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.staff.staff-entity-extension-includeonly.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Staffs.EdFi.Staff_Include_All
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffsController : EdFiControllerBase<
        Models.Resources.Staff.EdFi.Staff_Include_All_Readable.Staff,
        Models.Resources.Staff.EdFi.Staff_Include_All_Writable.Staff,
        Entities.Common.EdFi.IStaff,
        Entities.NHibernate.StaffAggregate.EdFi.Staff,
        Api.Models.Requests.Staffs.EdFi.Staff_Include_All.StaffPut,
        Api.Models.Requests.Staffs.EdFi.Staff_Include_All.StaffPost,
        Api.Models.Requests.Staffs.EdFi.Staff_Include_All.StaffDelete,
        Api.Models.Requests.Staffs.EdFi.Staff_Include_All.StaffGetByExample>
    {
        public StaffsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Staffs.EdFi.Staff_Include_All.StaffGetByExample request, IStaff specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BirthDate = request.BirthDate;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HighestCompletedLevelOfEducationDescriptor = request.HighestCompletedLevelOfEducationDescriptor;
            specification.HighlyQualifiedTeacher = request.HighlyQualifiedTeacher;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.LoginId = request.LoginId;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.OldEthnicityDescriptor = request.OldEthnicityDescriptor;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PersonId = request.PersonId;
            specification.SexDescriptor = request.SexDescriptor;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.YearsOfPriorProfessionalExperience = request.YearsOfPriorProfessionalExperience;
            specification.YearsOfPriorTeachingExperience = request.YearsOfPriorTeachingExperience;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffs";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.staff.staff-include-all.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Students.EdFi.Student_Include_All
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentsController : EdFiControllerBase<
        Models.Resources.Student.EdFi.Student_Include_All_Readable.Student,
        Models.Resources.Student.EdFi.Student_Include_All_Writable.Student,
        Entities.Common.EdFi.IStudent,
        Entities.NHibernate.StudentAggregate.EdFi.Student,
        Api.Models.Requests.Students.EdFi.Student_Include_All.StudentPut,
        Api.Models.Requests.Students.EdFi.Student_Include_All.StudentPost,
        Api.Models.Requests.Students.EdFi.Student_Include_All.StudentDelete,
        Api.Models.Requests.Students.EdFi.Student_Include_All.StudentGetByExample>
    {
        public StudentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Students.EdFi.Student_Include_All.StudentGetByExample request, IStudent specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BirthCity = request.BirthCity;
            specification.BirthCountryDescriptor = request.BirthCountryDescriptor;
            specification.BirthDate = request.BirthDate;
            specification.BirthInternationalProvince = request.BirthInternationalProvince;
            specification.BirthSexDescriptor = request.BirthSexDescriptor;
            specification.BirthStateAbbreviationDescriptor = request.BirthStateAbbreviationDescriptor;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.DateEnteredUS = request.DateEnteredUS;
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.MultipleBirthStatus = request.MultipleBirthStatus;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PersonId = request.PersonId;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "students";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.student.student-include-all.readable+json";
        }
    }
}
