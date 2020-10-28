using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using EdFi.Ods.Common;
using Newtonsoft.Json;

namespace EdFi.Ods.Features.Publishing.Resources
{
    /// <summary>
    /// A class which represents the publishing.Snapshot table of the Snapshot aggregate in the ODS Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Snapshot
    {
        /// <summary>
        /// The unique identifier for the Snapshot resource.
        /// </summary>
        [DataMember(Name="id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }

        /// <summary>
        /// The unique identifier of the snapshot.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="snapshotIdentifier"), NaturalKeyMember]
        public string SnapshotIdentifier { get; set; }

        /// <summary>
        /// The date and time that the snapshot was initiated.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="snapshotDateTime")]
        public DateTime SnapshotDateTime { get; set; }
    }
}
