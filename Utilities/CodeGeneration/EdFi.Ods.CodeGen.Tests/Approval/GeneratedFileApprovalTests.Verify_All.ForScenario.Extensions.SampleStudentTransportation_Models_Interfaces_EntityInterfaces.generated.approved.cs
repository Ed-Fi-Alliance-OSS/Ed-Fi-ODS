using System;
using System.Collections.Generic;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common;

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
}
