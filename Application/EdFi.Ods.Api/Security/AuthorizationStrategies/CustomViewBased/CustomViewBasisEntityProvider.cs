using System.Collections.Concurrent;
using System.Linq;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.CustomViewBased;

public class CustomViewBasisEntityProvider : ICustomViewBasisEntityProvider
{
    private readonly IDomainModelProvider _domainModelProvider;
    private readonly ConcurrentDictionary<string, (string attemptedEntityName, Entity basisEntity)> _basisEntityByStrategyName = new();

    public CustomViewBasisEntityProvider(IDomainModelProvider domainModelProvider)
    {
        _domainModelProvider = domainModelProvider;
    }

    /// <inheritdoc cref="ICustomViewBasisEntityProvider.GetBasisEntity" />
    public (string attemptedEntityName, Entity entity) GetBasisEntity(string authorizationStrategyName)
    {
        int withPos = authorizationStrategyName.IndexOf("With");

        // Custom view-based authorization strategy relies on strict convention-based naming: {BasisEntity}With...
        if (withPos < 0)
        {
            return (null, null);
        }

        return _basisEntityByStrategyName.GetOrAdd(authorizationStrategyName,
            (n) =>
            {
                string entityName = authorizationStrategyName.Substring(0, withPos);

                // Search first for the entity name in the Ed-Fi Standard
                var entityFullName = new FullName(EdFiConventions.PhysicalSchemaName, entityName);

                if (_domainModelProvider.GetDomainModel().EntityByFullName.TryGetValue(entityFullName, out Entity edfiEntity))
                {
                    return (entityName, edfiEntity);
                }

                // Search extension schemas
                foreach (Schema schema in _domainModelProvider.GetDomainModel()
                             .Schemas.Where(s => s.PhysicalName != EdFiConventions.PhysicalSchemaName))
                {
                    entityFullName = new FullName(schema.PhysicalName, entityName);

                    if (_domainModelProvider.GetDomainModel().EntityByFullName.TryGetValue(entityFullName, out Entity extensionEntity))
                    {
                        return (entityName, extensionEntity);
                    }
                }

                return (entityName, null);
            });
    }
}
