using System;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Models.Domain;

// TupleView
namespace EdFi.Ods.Entities.NHibernate.QueryModels.Tables
{

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
