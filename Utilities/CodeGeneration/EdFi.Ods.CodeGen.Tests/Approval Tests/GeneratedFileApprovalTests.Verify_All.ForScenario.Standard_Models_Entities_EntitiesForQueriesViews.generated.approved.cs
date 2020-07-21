using System;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Common.Dtos;

// Views
namespace EdFi.Ods.Entities.NHibernate.QueryModels.Views
{

    /// <summary>
    /// A class which represents the auth.CommunityOrganizationIdToCommunityProviderId table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_CommunityOrganizationIdToCommunityProviderId : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int? CommunityOrganizationId  { get; set; }
        public virtual int CommunityProviderId  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.CommunityOrganizationIdToEducationOrganizationId table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_CommunityOrganizationIdToEducationOrganizationId : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int? CommunityOrganizationId  { get; set; }
        public virtual int EducationOrganizationId  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.CommunityProviderIdToEducationOrganizationId table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_CommunityProviderIdToEducationOrganizationId : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int CommunityProviderId  { get; set; }
        public virtual int EducationOrganizationId  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.CommunityProviderIdToStaffUSI table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_CommunityProviderIdToStaffUSI : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int CommunityProviderId  { get; set; }
        public virtual int StaffUSI  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.EducationOrganizationIdentifiers table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_EducationOrganizationIdentifiers : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int? CommunityOrganizationId  { get; set; }
        public virtual int? CommunityProviderId  { get; set; }
        public virtual int EducationOrganizationId  { get; set; }
        public virtual string EducationOrganizationType  { get; set; }
        public virtual int? EducationServiceCenterId  { get; set; }
        public virtual string FullEducationOrganizationType  { get; set; }
        public virtual int? LocalEducationAgencyId  { get; set; }
        public virtual string NameOfInstitution  { get; set; }
        public virtual int? PostSecondaryInstitutionId  { get; set; }
        public virtual int? SchoolId  { get; set; }
        public virtual int? StateEducationAgencyId  { get; set; }
        public virtual int? TeacherPreparationProviderId  { get; set; }
        public virtual int? UniversityId  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.EducationOrganizationIdToEducationServiceCenterId table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_EducationOrganizationIdToEducationServiceCenterId : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int? EducationOrganizationId  { get; set; }
        public virtual int? EducationServiceCenterId  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.EducationOrganizationIdToLocalEducationAgencyId table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_EducationOrganizationIdToLocalEducationAgencyId : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int EducationOrganizationId  { get; set; }
        public virtual int? LocalEducationAgencyId  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.EducationOrganizationIdToPostSecondaryInstitutionId table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_EducationOrganizationIdToPostSecondaryInstitutionId : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int EducationOrganizationId  { get; set; }
        public virtual int PostSecondaryInstitutionId  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.EducationOrganizationIdToSchoolId table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_EducationOrganizationIdToSchoolId : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int EducationOrganizationId  { get; set; }
        public virtual int SchoolId  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.EducationOrganizationIdToStaffUSI table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_EducationOrganizationIdToStaffUSI : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int? EducationOrganizationId  { get; set; }
        public virtual int StaffUSI  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.EducationOrganizationIdToStateAgencyId table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_EducationOrganizationIdToStateAgencyId : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int? EducationOrganizationId  { get; set; }
        public virtual int? StateEducationAgencyId  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.EducationOrganizationIdToStudentUSI table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_EducationOrganizationIdToStudentUSI : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int? EducationOrganizationId  { get; set; }
        public virtual int StudentUSI  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.EducationOrganizationIdToTeacherPreparationProviderId table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_EducationOrganizationIdToTeacherPreparationProviderId : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int EducationOrganizationId  { get; set; }
        public virtual int TeacherPreparationProviderId  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.EducationOrganizationIdToUniversityId table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_EducationOrganizationIdToUniversityId : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int EducationOrganizationId  { get; set; }
        public virtual int UniversityId  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.EducationOrganizationToStaffUSI_Assignment table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_EducationOrganizationToStaffUSI_Assignment : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual long? Count  { get; set; }
        public virtual int EducationOrganizationId  { get; set; }
        public virtual int StaffUSI  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.EducationOrganizationToStaffUSI_Employment table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_EducationOrganizationToStaffUSI_Employment : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual long? Count  { get; set; }
        public virtual int EducationOrganizationId  { get; set; }
        public virtual int StaffUSI  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.LocalEducationAgency table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_LocalEducationAgency : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int LocalEducationAgencyId  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.LocalEducationAgencyIdToParentUSI table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_LocalEducationAgencyIdToParentUSI : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual long? Count  { get; set; }
        public virtual int? LocalEducationAgencyId  { get; set; }
        public virtual int ParentUSI  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.LocalEducationAgencyIdToSchoolId table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_LocalEducationAgencyIdToSchoolId : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int? LocalEducationAgencyId  { get; set; }
        public virtual int SchoolId  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.LocalEducationAgencyIdToStaffUSI table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_LocalEducationAgencyIdToStaffUSI : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int? LocalEducationAgencyId  { get; set; }
        public virtual int? SchoolId  { get; set; }
        public virtual int StaffUSI  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.LocalEducationAgencyIdToStudentUSI table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_LocalEducationAgencyIdToStudentUSI : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual long? Ignored  { get; set; }
        public virtual int? LocalEducationAgencyId  { get; set; }
        public virtual int StudentUSI  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.LocalEducationAgencyIdToStudentUSIThroughEdOrgAssociation table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_LocalEducationAgencyIdToStudentUSIThroughEdOrgAssociation : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int? LocalEducationAgencyId  { get; set; }
        public virtual int StudentUSI  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.ParentUSIToSchoolId table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_ParentUSIToSchoolId : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual long? Count  { get; set; }
        public virtual int ParentUSI  { get; set; }
        public virtual int SchoolId  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.ParentUSIToStudentUSI table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_ParentUSIToStudentUSI : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual long? Count  { get; set; }
        public virtual int ParentUSI  { get; set; }
        public virtual int StudentUSI  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.PostSecondaryInstitutionIdToStaffUSI table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_PostSecondaryInstitutionIdToStaffUSI : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int PostSecondaryInstitutionId  { get; set; }
        public virtual int StaffUSI  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.School table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_School : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int? LocalEducationAgencyId  { get; set; }
        public virtual int SchoolId  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.SchoolIdToStaffUSI table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_SchoolIdToStaffUSI : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int SchoolId  { get; set; }
        public virtual int StaffUSI  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.SchoolIdToStudentUSI table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_SchoolIdToStudentUSI : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual long? Ignored  { get; set; }
        public virtual int SchoolId  { get; set; }
        public virtual int StudentUSI  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.SchoolIdToStudentUSIThroughEdOrgAssociation table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_SchoolIdToStudentUSIThroughEdOrgAssociation : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int SchoolId  { get; set; }
        public virtual int StudentUSI  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.StaffUSIToTeacherPreparationProviderId table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_StaffUSIToTeacherPreparationProviderId : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int StaffUSI  { get; set; }
        public virtual int TeacherPreparationProviderId  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }

    /// <summary>
    /// A class which represents the auth.StaffUSIToUniversityId table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_StaffUSIToUniversityId : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int StaffUSI  { get; set; }
        public virtual int UniversityId  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        // -------------------------------------------------------------

        // =============================================================
        //              External references for HQL Queries
        // -------------------------------------------------------------
        // -------------------------------------------------------------
    }
}
