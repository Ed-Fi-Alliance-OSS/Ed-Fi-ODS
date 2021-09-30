namespace EdFi.Ods.Features.ChangeQueries.Repositories.KeyChanges
{
    /// <summary>
    /// Provides a marker interface for use in injecting the correct implementation of
    /// <see cref="ITrackedChangesQueryFactory"/> into artifacts related to processing
    /// key change requests.
    /// </summary>
    public interface IKeyChangesQueryFactory : ITrackedChangesQueryFactory { }
}