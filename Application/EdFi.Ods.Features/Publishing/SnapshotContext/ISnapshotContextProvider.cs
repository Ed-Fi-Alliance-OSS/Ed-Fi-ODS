namespace EdFi.Ods.Extensions.Publishing.Feature.SnapshotContext
{
    /// <summary>
    /// Defines methods for getting and setting <see cref="SnapshotContext" /> for the current API request.
    /// </summary>
    public interface ISnapshotContextProvider
    {
        /// <summary>
        /// Gets the <see cref="SnapshotContext" /> for the current API request.
        /// </summary>
        /// <returns>The current context.</returns>
        SnapshotContext GetSnapshotContext();

        /// <summary>
        /// Sets the <see cref="SnapshotContext" /> for the current API request.
        /// </summary>
        /// <param name="snapshotContext">The snapshot context to be set.</param>
        void SetSnapshotContext(SnapshotContext snapshotContext);
    }
}
