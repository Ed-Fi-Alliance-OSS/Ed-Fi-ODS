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
using EdFi.Ods.Entities.Common.GrandBend;
using EdFi.Ods.Pipelines.Factories;
using EdFi.Ods.Api.Services.CustomActionResults;
using EdFi.Ods.Api.Services.Queries;
using EdFi.Ods.Api.Services.Requests;

namespace EdFi.Ods.Api.Services.Controllers.GrandBend.Applicants
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ApplicantsController : EdFiControllerBase<
        Models.Resources.Applicant.GrandBend.Applicant,
        Models.Resources.Applicant.GrandBend.Applicant,
        Entities.Common.GrandBend.IApplicant,
        Entities.NHibernate.ApplicantAggregate.GrandBend.Applicant,
        Api.Models.Requests.GrandBend.Applicants.ApplicantPut,
        Api.Models.Requests.GrandBend.Applicants.ApplicantPost,
        Api.Models.Requests.GrandBend.Applicants.ApplicantDelete,
        Api.Models.Requests.GrandBend.Applicants.ApplicantGetByExample>
    {
        public ApplicantsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.GrandBend.Applicants.ApplicantGetByExample request, Entities.Common.GrandBend.IApplicant specification)
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
    }
}
