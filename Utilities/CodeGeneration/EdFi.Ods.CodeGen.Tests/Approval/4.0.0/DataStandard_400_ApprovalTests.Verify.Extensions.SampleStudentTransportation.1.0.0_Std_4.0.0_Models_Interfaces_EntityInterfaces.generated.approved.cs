using System;
using System.Linq;
using System.Collections.Generic;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;

#pragma warning disable 108,114

namespace EdFi.Ods.Entities.Common.SampleStudentTransportation
{

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentTransportation model.
    /// </summary>
    public interface IStudentTransportation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        
        string AMBusNumber { get; set; }
        
        string PMBusNumber { get; set; }
        
        int SchoolId { get; set; }
        
        string StudentUniqueId { get; set; }

        // Non-PK properties
        decimal EstimatedMilesFromSchool { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SchoolResourceId { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentTransportationMappingContract : IMappingContract
    {
        public StudentTransportationMappingContract(
            bool isEstimatedMilesFromSchoolSupported,
            bool isSchoolReferenceSupported,
            bool isStudentReferenceSupported
            )
        {
            IsEstimatedMilesFromSchoolSupported = isEstimatedMilesFromSchoolSupported;
            IsSchoolReferenceSupported = isSchoolReferenceSupported;
            IsStudentReferenceSupported = isStudentReferenceSupported;
        }

        public bool IsEstimatedMilesFromSchoolSupported { get; }
        public bool IsSchoolReferenceSupported { get; }
        public bool IsStudentReferenceSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "EstimatedMilesFromSchool":
                    return IsEstimatedMilesFromSchoolSupported;
                case "SchoolReference":
                    return IsSchoolReferenceSupported;
                case "StudentReference":
                    return IsStudentReferenceSupported;
                case "AMBusNumber":
                    // Identifying properties are always supported
                    return true;
                case "PMBusNumber":
                    // Identifying properties are always supported
                    return true;
                case "SchoolId":
                    // Identifying properties are always supported
                    return true;
                case "StudentUniqueId":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }
}
