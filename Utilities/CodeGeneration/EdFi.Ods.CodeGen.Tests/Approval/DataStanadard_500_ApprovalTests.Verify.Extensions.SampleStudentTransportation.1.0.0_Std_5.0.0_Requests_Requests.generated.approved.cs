using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Attributes;

namespace EdFi.Ods.Api.Common.Models.Requests.SampleStudentTransportation.StudentTransportations
{

    [ExcludeFromCodeCoverage]
    public class StudentTransportationGetByExample
    {
        public string AMBusNumber { get; set; }
        public decimal EstimatedMilesFromSchool { get; set; }
        public Guid Id { get; set; }
        public string PMBusNumber { get; set; }
        public int SchoolId { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentTransportationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentTransportationGetByIds() { }

        public StudentTransportationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentTransportationPost : Resources.StudentTransportation.SampleStudentTransportation.StudentTransportation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentTransportationPut : Resources.StudentTransportation.SampleStudentTransportation.StudentTransportation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentTransportationDelete : IHasIdentifier
    {
        public StudentTransportationDelete() { }

        public StudentTransportationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

