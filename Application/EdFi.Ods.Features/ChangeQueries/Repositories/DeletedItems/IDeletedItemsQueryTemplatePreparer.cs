namespace EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems
{
    /// <summary>
    /// Provides a marker interface for use in injecting the correct implementation of
    /// <see cref="ITrackedChangesQueryTemplatePreparer"/> into artifacts related to processing
    /// deleted item requests.
    /// </summary>
    public interface IDeletedItemsQueryTemplatePreparer : ITrackedChangesQueryTemplatePreparer { }
}