namespace EdFi.Ods.Extensions.Publishing.Feature.SnapshotContext
{
    /// <summary>
    /// Provides contextual information related to the snapshot to be used to service the current API request.
    /// </summary>
    public class SnapshotContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SnapshotContext" /> class using the supplied snapshot identifier.
        /// </summary>
        /// <param name="snapshotIdentifier"></param>
        public SnapshotContext(string snapshotIdentifier)
        {
            SnapshotIdentifier = snapshotIdentifier;
        }

        /// <summary>
        /// Gets the snapshot identifier to be used to identify the read-only ODS database to be used
        /// to service the current API request. 
        /// </summary>
        public string SnapshotIdentifier { get; }
    }
}
