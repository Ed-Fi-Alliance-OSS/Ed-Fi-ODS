using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Attributes;

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.AccreditationStatusDescriptors
{

    [ExcludeFromCodeCoverage]
    public class AccreditationStatusDescriptorGetByExample
    {
        public int AccreditationStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AccreditationStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AccreditationStatusDescriptorGetByIds() { }

        public AccreditationStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AccreditationStatusDescriptorPost : Resources.AccreditationStatusDescriptor.TPDM.AccreditationStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AccreditationStatusDescriptorPut : Resources.AccreditationStatusDescriptor.TPDM.AccreditationStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AccreditationStatusDescriptorDelete : IHasIdentifier
    {
        public AccreditationStatusDescriptorDelete() { }

        public AccreditationStatusDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.AidTypeDescriptors
{

    [ExcludeFromCodeCoverage]
    public class AidTypeDescriptorGetByExample
    {
        public int AidTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AidTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AidTypeDescriptorGetByIds() { }

        public AidTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AidTypeDescriptorPost : Resources.AidTypeDescriptor.TPDM.AidTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AidTypeDescriptorPut : Resources.AidTypeDescriptor.TPDM.AidTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AidTypeDescriptorDelete : IHasIdentifier
    {
        public AidTypeDescriptorDelete() { }

        public AidTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.Candidates
{

    [ExcludeFromCodeCoverage]
    public class CandidateGetByExample
    {
        public string BirthCity { get; set; }
        public string BirthCountryDescriptor { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthInternationalProvince { get; set; }
        public string BirthSexDescriptor { get; set; }
        public string BirthStateAbbreviationDescriptor { get; set; }
        public string CandidateIdentifier { get; set; }
        public DateTime DateEnteredUS { get; set; }
        public string DisplacementStatus { get; set; }
        public bool EconomicDisadvantaged { get; set; }
        public string EnglishLanguageExamDescriptor { get; set; }
        public bool FirstGenerationStudent { get; set; }
        public string FirstName { get; set; }
        public string GenderDescriptor { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public bool HispanicLatinoEthnicity { get; set; }
        public Guid Id { get; set; }
        public string LastSurname { get; set; }
        public string LimitedEnglishProficiencyDescriptor { get; set; }
        public string MaidenName { get; set; }
        public string MiddleName { get; set; }
        public bool MultipleBirthStatus { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public string PersonId { get; set; }
        public string SexDescriptor { get; set; }
        public string SourceSystemDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CandidateGetByIds : IHasIdentifiers<Guid>
    {
        public CandidateGetByIds() { }

        public CandidateGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CandidatePost : Resources.Candidate.TPDM.Candidate
    {
    }

    [ExcludeFromCodeCoverage]
    public class CandidatePut : Resources.Candidate.TPDM.Candidate
    {
    }

    [ExcludeFromCodeCoverage]
    public class CandidateDelete : IHasIdentifier
    {
        public CandidateDelete() { }

        public CandidateDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.CandidateEducatorPreparationProgramAssociations
{

    [ExcludeFromCodeCoverage]
    public class CandidateEducatorPreparationProgramAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public string CandidateIdentifier { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime EndDate { get; set; }
        public string EPPProgramPathwayDescriptor { get; set; }
        public Guid Id { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
        public string ReasonExitedDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CandidateEducatorPreparationProgramAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public CandidateEducatorPreparationProgramAssociationGetByIds() { }

        public CandidateEducatorPreparationProgramAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CandidateEducatorPreparationProgramAssociationPost : Resources.CandidateEducatorPreparationProgramAssociation.TPDM.CandidateEducatorPreparationProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class CandidateEducatorPreparationProgramAssociationPut : Resources.CandidateEducatorPreparationProgramAssociation.TPDM.CandidateEducatorPreparationProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class CandidateEducatorPreparationProgramAssociationDelete : IHasIdentifier
    {
        public CandidateEducatorPreparationProgramAssociationDelete() { }

        public CandidateEducatorPreparationProgramAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.CertificationRouteDescriptors
{

    [ExcludeFromCodeCoverage]
    public class CertificationRouteDescriptorGetByExample
    {
        public int CertificationRouteDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationRouteDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CertificationRouteDescriptorGetByIds() { }

        public CertificationRouteDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationRouteDescriptorPost : Resources.CertificationRouteDescriptor.TPDM.CertificationRouteDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CertificationRouteDescriptorPut : Resources.CertificationRouteDescriptor.TPDM.CertificationRouteDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CertificationRouteDescriptorDelete : IHasIdentifier
    {
        public CertificationRouteDescriptorDelete() { }

        public CertificationRouteDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.CoteachingStyleObservedDescriptors
{

    [ExcludeFromCodeCoverage]
    public class CoteachingStyleObservedDescriptorGetByExample
    {
        public int CoteachingStyleObservedDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CoteachingStyleObservedDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CoteachingStyleObservedDescriptorGetByIds() { }

        public CoteachingStyleObservedDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CoteachingStyleObservedDescriptorPost : Resources.CoteachingStyleObservedDescriptor.TPDM.CoteachingStyleObservedDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CoteachingStyleObservedDescriptorPut : Resources.CoteachingStyleObservedDescriptor.TPDM.CoteachingStyleObservedDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CoteachingStyleObservedDescriptorDelete : IHasIdentifier
    {
        public CoteachingStyleObservedDescriptorDelete() { }

        public CoteachingStyleObservedDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.CredentialStatusDescriptors
{

    [ExcludeFromCodeCoverage]
    public class CredentialStatusDescriptorGetByExample
    {
        public int CredentialStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CredentialStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CredentialStatusDescriptorGetByIds() { }

        public CredentialStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CredentialStatusDescriptorPost : Resources.CredentialStatusDescriptor.TPDM.CredentialStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CredentialStatusDescriptorPut : Resources.CredentialStatusDescriptor.TPDM.CredentialStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CredentialStatusDescriptorDelete : IHasIdentifier
    {
        public CredentialStatusDescriptorDelete() { }

        public CredentialStatusDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EducatorPreparationPrograms
{

    [ExcludeFromCodeCoverage]
    public class EducatorPreparationProgramGetByExample
    {
        public string AccreditationStatusDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public string ProgramId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducatorPreparationProgramGetByIds : IHasIdentifiers<Guid>
    {
        public EducatorPreparationProgramGetByIds() { }

        public EducatorPreparationProgramGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducatorPreparationProgramPost : Resources.EducatorPreparationProgram.TPDM.EducatorPreparationProgram
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducatorPreparationProgramPut : Resources.EducatorPreparationProgram.TPDM.EducatorPreparationProgram
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducatorPreparationProgramDelete : IHasIdentifier
    {
        public EducatorPreparationProgramDelete() { }

        public EducatorPreparationProgramDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EducatorRoleDescriptors
{

    [ExcludeFromCodeCoverage]
    public class EducatorRoleDescriptorGetByExample
    {
        public int EducatorRoleDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducatorRoleDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EducatorRoleDescriptorGetByIds() { }

        public EducatorRoleDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducatorRoleDescriptorPost : Resources.EducatorRoleDescriptor.TPDM.EducatorRoleDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducatorRoleDescriptorPut : Resources.EducatorRoleDescriptor.TPDM.EducatorRoleDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducatorRoleDescriptorDelete : IHasIdentifier
    {
        public EducatorRoleDescriptorDelete() { }

        public EducatorRoleDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EnglishLanguageExamDescriptors
{

    [ExcludeFromCodeCoverage]
    public class EnglishLanguageExamDescriptorGetByExample
    {
        public int EnglishLanguageExamDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EnglishLanguageExamDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EnglishLanguageExamDescriptorGetByIds() { }

        public EnglishLanguageExamDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EnglishLanguageExamDescriptorPost : Resources.EnglishLanguageExamDescriptor.TPDM.EnglishLanguageExamDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EnglishLanguageExamDescriptorPut : Resources.EnglishLanguageExamDescriptor.TPDM.EnglishLanguageExamDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EnglishLanguageExamDescriptorDelete : IHasIdentifier
    {
        public EnglishLanguageExamDescriptorDelete() { }

        public EnglishLanguageExamDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EPPProgramPathwayDescriptors
{

    [ExcludeFromCodeCoverage]
    public class EPPProgramPathwayDescriptorGetByExample
    {
        public int EPPProgramPathwayDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EPPProgramPathwayDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EPPProgramPathwayDescriptorGetByIds() { }

        public EPPProgramPathwayDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EPPProgramPathwayDescriptorPost : Resources.EPPProgramPathwayDescriptor.TPDM.EPPProgramPathwayDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EPPProgramPathwayDescriptorPut : Resources.EPPProgramPathwayDescriptor.TPDM.EPPProgramPathwayDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EPPProgramPathwayDescriptorDelete : IHasIdentifier
    {
        public EPPProgramPathwayDescriptorDelete() { }

        public EPPProgramPathwayDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.Evaluations
{

    [ExcludeFromCodeCoverage]
    public class EvaluationGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public string EvaluationDescription { get; set; }
        public string EvaluationPeriodDescriptor { get; set; }
        public string EvaluationTitle { get; set; }
        public string EvaluationTypeDescriptor { get; set; }
        public Guid Id { get; set; }
        public int InterRaterReliabilityScore { get; set; }
        public decimal MaxRating { get; set; }
        public decimal MinRating { get; set; }
        public string PerformanceEvaluationTitle { get; set; }
        public string PerformanceEvaluationTypeDescriptor { get; set; }
        public short SchoolYear { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationGetByIds : IHasIdentifiers<Guid>
    {
        public EvaluationGetByIds() { }

        public EvaluationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationPost : Resources.Evaluation.TPDM.Evaluation
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationPut : Resources.Evaluation.TPDM.Evaluation
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationDelete : IHasIdentifier
    {
        public EvaluationDelete() { }

        public EvaluationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EvaluationElements
{

    [ExcludeFromCodeCoverage]
    public class EvaluationElementGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public string EvaluationElementTitle { get; set; }
        public string EvaluationObjectiveTitle { get; set; }
        public string EvaluationPeriodDescriptor { get; set; }
        public string EvaluationTitle { get; set; }
        public string EvaluationTypeDescriptor { get; set; }
        public Guid Id { get; set; }
        public decimal MaxRating { get; set; }
        public decimal MinRating { get; set; }
        public string PerformanceEvaluationTitle { get; set; }
        public string PerformanceEvaluationTypeDescriptor { get; set; }
        public short SchoolYear { get; set; }
        public int SortOrder { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementGetByIds : IHasIdentifiers<Guid>
    {
        public EvaluationElementGetByIds() { }

        public EvaluationElementGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementPost : Resources.EvaluationElement.TPDM.EvaluationElement
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementPut : Resources.EvaluationElement.TPDM.EvaluationElement
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementDelete : IHasIdentifier
    {
        public EvaluationElementDelete() { }

        public EvaluationElementDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EvaluationElementRatings
{

    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingGetByExample
    {
        public string AreaOfRefinement { get; set; }
        public string AreaOfReinforcement { get; set; }
        public string Comments { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime EvaluationDate { get; set; }
        public string EvaluationElementRatingLevelDescriptor { get; set; }
        public string EvaluationElementTitle { get; set; }
        public string EvaluationObjectiveTitle { get; set; }
        public string EvaluationPeriodDescriptor { get; set; }
        public string EvaluationTitle { get; set; }
        public string Feedback { get; set; }
        public Guid Id { get; set; }
        public string PerformanceEvaluationTitle { get; set; }
        public string PerformanceEvaluationTypeDescriptor { get; set; }
        public string PersonId { get; set; }
        public short SchoolYear { get; set; }
        public string SourceSystemDescriptor { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingGetByIds : IHasIdentifiers<Guid>
    {
        public EvaluationElementRatingGetByIds() { }

        public EvaluationElementRatingGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingPost : Resources.EvaluationElementRating.TPDM.EvaluationElementRating
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingPut : Resources.EvaluationElementRating.TPDM.EvaluationElementRating
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingDelete : IHasIdentifier
    {
        public EvaluationElementRatingDelete() { }

        public EvaluationElementRatingDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EvaluationElementRatingLevelDescriptors
{

    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingLevelDescriptorGetByExample
    {
        public int EvaluationElementRatingLevelDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingLevelDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EvaluationElementRatingLevelDescriptorGetByIds() { }

        public EvaluationElementRatingLevelDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingLevelDescriptorPost : Resources.EvaluationElementRatingLevelDescriptor.TPDM.EvaluationElementRatingLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingLevelDescriptorPut : Resources.EvaluationElementRatingLevelDescriptor.TPDM.EvaluationElementRatingLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingLevelDescriptorDelete : IHasIdentifier
    {
        public EvaluationElementRatingLevelDescriptorDelete() { }

        public EvaluationElementRatingLevelDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EvaluationObjectives
{

    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public string EvaluationObjectiveDescription { get; set; }
        public string EvaluationObjectiveTitle { get; set; }
        public string EvaluationPeriodDescriptor { get; set; }
        public string EvaluationTitle { get; set; }
        public string EvaluationTypeDescriptor { get; set; }
        public Guid Id { get; set; }
        public decimal MaxRating { get; set; }
        public decimal MinRating { get; set; }
        public string PerformanceEvaluationTitle { get; set; }
        public string PerformanceEvaluationTypeDescriptor { get; set; }
        public short SchoolYear { get; set; }
        public int SortOrder { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveGetByIds : IHasIdentifiers<Guid>
    {
        public EvaluationObjectiveGetByIds() { }

        public EvaluationObjectiveGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationObjectivePost : Resources.EvaluationObjective.TPDM.EvaluationObjective
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationObjectivePut : Resources.EvaluationObjective.TPDM.EvaluationObjective
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveDelete : IHasIdentifier
    {
        public EvaluationObjectiveDelete() { }

        public EvaluationObjectiveDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EvaluationObjectiveRatings
{

    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveRatingGetByExample
    {
        public string Comments { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime EvaluationDate { get; set; }
        public string EvaluationObjectiveTitle { get; set; }
        public string EvaluationPeriodDescriptor { get; set; }
        public string EvaluationTitle { get; set; }
        public Guid Id { get; set; }
        public string ObjectiveRatingLevelDescriptor { get; set; }
        public string PerformanceEvaluationTitle { get; set; }
        public string PerformanceEvaluationTypeDescriptor { get; set; }
        public string PersonId { get; set; }
        public short SchoolYear { get; set; }
        public string SourceSystemDescriptor { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveRatingGetByIds : IHasIdentifiers<Guid>
    {
        public EvaluationObjectiveRatingGetByIds() { }

        public EvaluationObjectiveRatingGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveRatingPost : Resources.EvaluationObjectiveRating.TPDM.EvaluationObjectiveRating
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveRatingPut : Resources.EvaluationObjectiveRating.TPDM.EvaluationObjectiveRating
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveRatingDelete : IHasIdentifier
    {
        public EvaluationObjectiveRatingDelete() { }

        public EvaluationObjectiveRatingDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EvaluationPeriodDescriptors
{

    [ExcludeFromCodeCoverage]
    public class EvaluationPeriodDescriptorGetByExample
    {
        public int EvaluationPeriodDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationPeriodDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EvaluationPeriodDescriptorGetByIds() { }

        public EvaluationPeriodDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationPeriodDescriptorPost : Resources.EvaluationPeriodDescriptor.TPDM.EvaluationPeriodDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationPeriodDescriptorPut : Resources.EvaluationPeriodDescriptor.TPDM.EvaluationPeriodDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationPeriodDescriptorDelete : IHasIdentifier
    {
        public EvaluationPeriodDescriptorDelete() { }

        public EvaluationPeriodDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EvaluationRatings
{

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public DateTime EvaluationDate { get; set; }
        public string EvaluationPeriodDescriptor { get; set; }
        public string EvaluationRatingLevelDescriptor { get; set; }
        public string EvaluationRatingStatusDescriptor { get; set; }
        public string EvaluationTitle { get; set; }
        public Guid Id { get; set; }
        public string LocalCourseCode { get; set; }
        public string PerformanceEvaluationTitle { get; set; }
        public string PerformanceEvaluationTypeDescriptor { get; set; }
        public string PersonId { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string SectionIdentifier { get; set; }
        public string SessionName { get; set; }
        public string SourceSystemDescriptor { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingGetByIds : IHasIdentifiers<Guid>
    {
        public EvaluationRatingGetByIds() { }

        public EvaluationRatingGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingPost : Resources.EvaluationRating.TPDM.EvaluationRating
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingPut : Resources.EvaluationRating.TPDM.EvaluationRating
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingDelete : IHasIdentifier
    {
        public EvaluationRatingDelete() { }

        public EvaluationRatingDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EvaluationRatingLevelDescriptors
{

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingLevelDescriptorGetByExample
    {
        public int EvaluationRatingLevelDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingLevelDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EvaluationRatingLevelDescriptorGetByIds() { }

        public EvaluationRatingLevelDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingLevelDescriptorPost : Resources.EvaluationRatingLevelDescriptor.TPDM.EvaluationRatingLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingLevelDescriptorPut : Resources.EvaluationRatingLevelDescriptor.TPDM.EvaluationRatingLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingLevelDescriptorDelete : IHasIdentifier
    {
        public EvaluationRatingLevelDescriptorDelete() { }

        public EvaluationRatingLevelDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EvaluationRatingStatusDescriptors
{

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingStatusDescriptorGetByExample
    {
        public int EvaluationRatingStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EvaluationRatingStatusDescriptorGetByIds() { }

        public EvaluationRatingStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingStatusDescriptorPost : Resources.EvaluationRatingStatusDescriptor.TPDM.EvaluationRatingStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingStatusDescriptorPut : Resources.EvaluationRatingStatusDescriptor.TPDM.EvaluationRatingStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingStatusDescriptorDelete : IHasIdentifier
    {
        public EvaluationRatingStatusDescriptorDelete() { }

        public EvaluationRatingStatusDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EvaluationTypeDescriptors
{

    [ExcludeFromCodeCoverage]
    public class EvaluationTypeDescriptorGetByExample
    {
        public int EvaluationTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EvaluationTypeDescriptorGetByIds() { }

        public EvaluationTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationTypeDescriptorPost : Resources.EvaluationTypeDescriptor.TPDM.EvaluationTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationTypeDescriptorPut : Resources.EvaluationTypeDescriptor.TPDM.EvaluationTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationTypeDescriptorDelete : IHasIdentifier
    {
        public EvaluationTypeDescriptorDelete() { }

        public EvaluationTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.FinancialAids
{

    [ExcludeFromCodeCoverage]
    public class FinancialAidGetByExample
    {
        public decimal AidAmount { get; set; }
        public string AidConditionDescription { get; set; }
        public string AidTypeDescriptor { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid Id { get; set; }
        public bool PellGrantRecipient { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class FinancialAidGetByIds : IHasIdentifiers<Guid>
    {
        public FinancialAidGetByIds() { }

        public FinancialAidGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class FinancialAidPost : Resources.FinancialAid.TPDM.FinancialAid
    {
    }

    [ExcludeFromCodeCoverage]
    public class FinancialAidPut : Resources.FinancialAid.TPDM.FinancialAid
    {
    }

    [ExcludeFromCodeCoverage]
    public class FinancialAidDelete : IHasIdentifier
    {
        public FinancialAidDelete() { }

        public FinancialAidDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.GenderDescriptors
{

    [ExcludeFromCodeCoverage]
    public class GenderDescriptorGetByExample
    {
        public int GenderDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GenderDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public GenderDescriptorGetByIds() { }

        public GenderDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GenderDescriptorPost : Resources.GenderDescriptor.TPDM.GenderDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class GenderDescriptorPut : Resources.GenderDescriptor.TPDM.GenderDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class GenderDescriptorDelete : IHasIdentifier
    {
        public GenderDescriptorDelete() { }

        public GenderDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.ObjectiveRatingLevelDescriptors
{

    [ExcludeFromCodeCoverage]
    public class ObjectiveRatingLevelDescriptorGetByExample
    {
        public int ObjectiveRatingLevelDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ObjectiveRatingLevelDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ObjectiveRatingLevelDescriptorGetByIds() { }

        public ObjectiveRatingLevelDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ObjectiveRatingLevelDescriptorPost : Resources.ObjectiveRatingLevelDescriptor.TPDM.ObjectiveRatingLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ObjectiveRatingLevelDescriptorPut : Resources.ObjectiveRatingLevelDescriptor.TPDM.ObjectiveRatingLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ObjectiveRatingLevelDescriptorDelete : IHasIdentifier
    {
        public ObjectiveRatingLevelDescriptorDelete() { }

        public ObjectiveRatingLevelDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.PerformanceEvaluations
{

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationGetByExample
    {
        public string AcademicSubjectDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public string EvaluationPeriodDescriptor { get; set; }
        public Guid Id { get; set; }
        public string PerformanceEvaluationDescription { get; set; }
        public string PerformanceEvaluationTitle { get; set; }
        public string PerformanceEvaluationTypeDescriptor { get; set; }
        public short SchoolYear { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationGetByIds : IHasIdentifiers<Guid>
    {
        public PerformanceEvaluationGetByIds() { }

        public PerformanceEvaluationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationPost : Resources.PerformanceEvaluation.TPDM.PerformanceEvaluation
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationPut : Resources.PerformanceEvaluation.TPDM.PerformanceEvaluation
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationDelete : IHasIdentifier
    {
        public PerformanceEvaluationDelete() { }

        public PerformanceEvaluationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.PerformanceEvaluationRatings
{

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingGetByExample
    {
        public DateTime ActualDate { get; set; }
        public int ActualDuration { get; set; }
        public TimeSpan ActualTime { get; set; }
        public bool Announced { get; set; }
        public string Comments { get; set; }
        public string CoteachingStyleObservedDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public string EvaluationPeriodDescriptor { get; set; }
        public Guid Id { get; set; }
        public string PerformanceEvaluationRatingLevelDescriptor { get; set; }
        public string PerformanceEvaluationTitle { get; set; }
        public string PerformanceEvaluationTypeDescriptor { get; set; }
        public string PersonId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public short SchoolYear { get; set; }
        public string SourceSystemDescriptor { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingGetByIds : IHasIdentifiers<Guid>
    {
        public PerformanceEvaluationRatingGetByIds() { }

        public PerformanceEvaluationRatingGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingPost : Resources.PerformanceEvaluationRating.TPDM.PerformanceEvaluationRating
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingPut : Resources.PerformanceEvaluationRating.TPDM.PerformanceEvaluationRating
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingDelete : IHasIdentifier
    {
        public PerformanceEvaluationRatingDelete() { }

        public PerformanceEvaluationRatingDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.PerformanceEvaluationRatingLevelDescriptors
{

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingLevelDescriptorGetByExample
    {
        public int PerformanceEvaluationRatingLevelDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingLevelDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public PerformanceEvaluationRatingLevelDescriptorGetByIds() { }

        public PerformanceEvaluationRatingLevelDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingLevelDescriptorPost : Resources.PerformanceEvaluationRatingLevelDescriptor.TPDM.PerformanceEvaluationRatingLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingLevelDescriptorPut : Resources.PerformanceEvaluationRatingLevelDescriptor.TPDM.PerformanceEvaluationRatingLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingLevelDescriptorDelete : IHasIdentifier
    {
        public PerformanceEvaluationRatingLevelDescriptorDelete() { }

        public PerformanceEvaluationRatingLevelDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.PerformanceEvaluationTypeDescriptors
{

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationTypeDescriptorGetByExample
    {
        public int PerformanceEvaluationTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public PerformanceEvaluationTypeDescriptorGetByIds() { }

        public PerformanceEvaluationTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationTypeDescriptorPost : Resources.PerformanceEvaluationTypeDescriptor.TPDM.PerformanceEvaluationTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationTypeDescriptorPut : Resources.PerformanceEvaluationTypeDescriptor.TPDM.PerformanceEvaluationTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationTypeDescriptorDelete : IHasIdentifier
    {
        public PerformanceEvaluationTypeDescriptorDelete() { }

        public PerformanceEvaluationTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.RubricDimensions
{

    [ExcludeFromCodeCoverage]
    public class RubricDimensionGetByExample
    {
        public string CriterionDescription { get; set; }
        public int DimensionOrder { get; set; }
        public int EducationOrganizationId { get; set; }
        public string EvaluationElementTitle { get; set; }
        public string EvaluationObjectiveTitle { get; set; }
        public string EvaluationPeriodDescriptor { get; set; }
        public string EvaluationTitle { get; set; }
        public Guid Id { get; set; }
        public string PerformanceEvaluationTitle { get; set; }
        public string PerformanceEvaluationTypeDescriptor { get; set; }
        public int RubricRating { get; set; }
        public string RubricRatingLevelDescriptor { get; set; }
        public short SchoolYear { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RubricDimensionGetByIds : IHasIdentifiers<Guid>
    {
        public RubricDimensionGetByIds() { }

        public RubricDimensionGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RubricDimensionPost : Resources.RubricDimension.TPDM.RubricDimension
    {
    }

    [ExcludeFromCodeCoverage]
    public class RubricDimensionPut : Resources.RubricDimension.TPDM.RubricDimension
    {
    }

    [ExcludeFromCodeCoverage]
    public class RubricDimensionDelete : IHasIdentifier
    {
        public RubricDimensionDelete() { }

        public RubricDimensionDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.RubricRatingLevelDescriptors
{

    [ExcludeFromCodeCoverage]
    public class RubricRatingLevelDescriptorGetByExample
    {
        public int RubricRatingLevelDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RubricRatingLevelDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public RubricRatingLevelDescriptorGetByIds() { }

        public RubricRatingLevelDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RubricRatingLevelDescriptorPost : Resources.RubricRatingLevelDescriptor.TPDM.RubricRatingLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class RubricRatingLevelDescriptorPut : Resources.RubricRatingLevelDescriptor.TPDM.RubricRatingLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class RubricRatingLevelDescriptorDelete : IHasIdentifier
    {
        public RubricRatingLevelDescriptorDelete() { }

        public RubricRatingLevelDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.SurveyResponsePersonTargetAssociations
{

    [ExcludeFromCodeCoverage]
    public class SurveyResponsePersonTargetAssociationGetByExample
    {
        public Guid Id { get; set; }
        public string Namespace { get; set; }
        public string PersonId { get; set; }
        public string SourceSystemDescriptor { get; set; }
        public string SurveyIdentifier { get; set; }
        public string SurveyResponseIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyResponsePersonTargetAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public SurveyResponsePersonTargetAssociationGetByIds() { }

        public SurveyResponsePersonTargetAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyResponsePersonTargetAssociationPost : Resources.SurveyResponsePersonTargetAssociation.TPDM.SurveyResponsePersonTargetAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveyResponsePersonTargetAssociationPut : Resources.SurveyResponsePersonTargetAssociation.TPDM.SurveyResponsePersonTargetAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveyResponsePersonTargetAssociationDelete : IHasIdentifier
    {
        public SurveyResponsePersonTargetAssociationDelete() { }

        public SurveyResponsePersonTargetAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.SurveySectionResponsePersonTargetAssociations
{

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponsePersonTargetAssociationGetByExample
    {
        public Guid Id { get; set; }
        public string Namespace { get; set; }
        public string PersonId { get; set; }
        public string SourceSystemDescriptor { get; set; }
        public string SurveyIdentifier { get; set; }
        public string SurveyResponseIdentifier { get; set; }
        public string SurveySectionTitle { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponsePersonTargetAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public SurveySectionResponsePersonTargetAssociationGetByIds() { }

        public SurveySectionResponsePersonTargetAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponsePersonTargetAssociationPost : Resources.SurveySectionResponsePersonTargetAssociation.TPDM.SurveySectionResponsePersonTargetAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponsePersonTargetAssociationPut : Resources.SurveySectionResponsePersonTargetAssociation.TPDM.SurveySectionResponsePersonTargetAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponsePersonTargetAssociationDelete : IHasIdentifier
    {
        public SurveySectionResponsePersonTargetAssociationDelete() { }

        public SurveySectionResponsePersonTargetAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

