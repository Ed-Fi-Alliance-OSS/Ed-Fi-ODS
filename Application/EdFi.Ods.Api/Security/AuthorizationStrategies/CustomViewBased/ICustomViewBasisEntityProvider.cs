using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.CustomViewBased;

/// <summary>
/// Defines a method for getting the entity whose identity the authorization strategy is based upon.
/// </summary>
public interface ICustomViewBasisEntityProvider
{
    /// <summary>
    /// Gets the entity whose identity the authorization strategy is based upon.
    /// </summary>
    /// <param name="authorizationStrategyName">The name of the authorization strategy to process using conventions to identify the entity that is the basis for authorization.</param>
    /// <returns>A tuple containing the entity, if identified, and the attempted entity name derived from the supplied authorization strategy name (if available) for logging/troubleshooting purposes.</returns>
    (string attemptedEntityName, Entity entity) GetBasisEntity(string authorizationStrategyName);
}
