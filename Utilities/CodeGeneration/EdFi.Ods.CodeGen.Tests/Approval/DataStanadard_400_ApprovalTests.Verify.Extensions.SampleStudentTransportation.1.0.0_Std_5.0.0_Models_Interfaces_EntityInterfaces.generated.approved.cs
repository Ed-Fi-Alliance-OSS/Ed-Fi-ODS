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
        [NaturalKeyMember]
        string AMBusNumber { get; set; }
        [NaturalKeyMember]
        string PMBusNumber { get; set; }
        [NaturalKeyMember]
        int SchoolId { get; set; }
        [NaturalKeyMember]
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
            bool isEstimatedMilesFromSchoolSupported
            )
        {
            IsEstimatedMilesFromSchoolSupported = isEstimatedMilesFromSchoolSupported;
        }

        public bool IsEstimatedMilesFromSchoolSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "EstimatedMilesFromSchool":
                    return IsEstimatedMilesFromSchoolSupported;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }
}
