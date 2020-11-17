using System;
using EdFi.Ods.Common;
using Newtonsoft.Json;

namespace EdFi.Ods.Features.Publishing.Resources
{
    /// <summary>
    /// A class which represents the publishing.Snapshot table of the Snapshot aggregate in the ODS Database.
    /// </summary>
    public class Snapshot
    {
        /// <summary>
        /// The unique identifier for the Snapshot resource.
        /// </summary>
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }

        /// <summary>
        /// The unique identifier of the snapshot.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        public string SnapshotIdentifier { get; set; }

        /// <summary>
        /// The date and time that the snapshot was initiated.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        public DateTime SnapshotDateTime { get; set; }
    }
}
