using System.Threading;
using System.Threading.Tasks;

namespace EdFi.Ods.Common.Security.Authorization;

/// <summary>
/// Defines a method for authorizing a single entity.
/// </summary>
public interface IEntityAuthorizer
{
    /// <summary>
    /// Authorizes the specified entity for the action and throws an exception if authorization fails.
    /// </summary>
    /// <param name="entity">The entity to be authorized.</param>
    /// <param name="actionUri">The action being performed on the entity.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AuthorizeEntityAsync(object entity, string actionUri, CancellationToken cancellationToken);
}
