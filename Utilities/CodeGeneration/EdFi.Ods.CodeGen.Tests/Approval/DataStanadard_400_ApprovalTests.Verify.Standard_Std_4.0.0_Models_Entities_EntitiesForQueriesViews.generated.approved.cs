using System;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Models.Domain;

// Views
namespace EdFi.Ods.Entities.NHibernate.QueryModels.Views
{

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
        public virtual int? OrganizationDepartmentId  { get; set; }
        public virtual int? PostSecondaryInstitutionId  { get; set; }
        public virtual int? SchoolId  { get; set; }
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
    /// A class which represents the auth.EducationOrganizationIdToParentUSI table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_EducationOrganizationIdToParentUSI : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int ParentUSI  { get; set; }
        public virtual int SourceEducationOrganizationId  { get; set; }
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
        public virtual int SourceEducationOrganizationId  { get; set; }
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
        public virtual int SourceEducationOrganizationId  { get; set; }
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
    /// A class which represents the auth.EducationOrganizationIdToStudentUSIThroughResponsibility table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_EducationOrganizationIdToStudentUSIThroughResponsibility : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int SourceEducationOrganizationId  { get; set; }
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
    /// A class which represents the auth.EducationOrganizationIdToEducationOrganizationId table of the (unspecified) aggregate in the ODS database.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class auth_EducationOrganizationIdToEducationOrganizationId : AggregateRootWithCompositeKey
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int SourceEducationOrganizationId  { get; set; }
        public virtual int TargetEducationOrganizationId  { get; set; }
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
