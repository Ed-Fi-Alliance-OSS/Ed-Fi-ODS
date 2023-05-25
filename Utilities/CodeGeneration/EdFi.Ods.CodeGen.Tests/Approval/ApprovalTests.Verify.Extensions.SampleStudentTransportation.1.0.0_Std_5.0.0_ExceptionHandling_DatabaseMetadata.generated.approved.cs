using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Api.Providers;

namespace EdFi.Ods.Api.Common.ExceptionHandling.SampleStudentTransportation
{
    [ExcludeFromCodeCoverage]
    public class DatabaseMetadataProvider : IDatabaseMetadataProvider
    {
        public IndexDetails GetIndexDetails(string indexName)
        {
            IndexDetails indexDetails = null;

            IndexDetailsByName.TryGetValue(indexName, out indexDetails);

            return indexDetails;
        }

        private static readonly Dictionary<string, IndexDetails> IndexDetailsByName = new Dictionary<string, IndexDetails>(StringComparer.InvariantCultureIgnoreCase) {
            { "FK_StudentTransportation_School", new IndexDetails { IndexName = "FK_StudentTransportation_School", TableName = "StudentTransportation", ColumnNames = new List<string> { "SchoolId" } } },
            { "FK_StudentTransportation_Student", new IndexDetails { IndexName = "FK_StudentTransportation_Student", TableName = "StudentTransportation", ColumnNames = new List<string> { "StudentUSI" } } },
            { "StudentTransportation_PK", new IndexDetails { IndexName = "StudentTransportation_PK", TableName = "StudentTransportation", ColumnNames = new List<string> { "AMBusNumber", "PMBusNumber", "SchoolId", "StudentUSI" } } },
            { "UX_StudentTransportation_Id", new IndexDetails { IndexName = "UX_StudentTransportation_Id", TableName = "StudentTransportation", ColumnNames = new List<string> { "Id" } } },
        };
    }
}
