using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Models.Validation;
using EdFi.Ods.Common.Profiles;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Features.Profiles;

/// <summary>
/// Implements a decorator over <see cref="ICreateEntity{TEntity}"/> that determines if a Profile has been applied that
/// makes it impossible to create the resource's entities and if so, throws a <see cref="DataPolicyException"/>.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class ProfileBasedCreateEntityDecorator<TEntity> : ICreateEntity<TEntity>
    where TEntity : IHasIdentifier, IDateVersionedEntity
{
    private readonly ICreateEntity<TEntity> _createEntity;
    private readonly IContextProvider<ProfileContentTypeContext> _profileContentTypeContextProvider;
    private readonly IProfileResourceModelProvider _profileResourceModelProvider;
    private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
    private readonly IProfileValidationReporter _profileValidationReporter;

    public ProfileBasedCreateEntityDecorator(
        ICreateEntity<TEntity> createEntity,
        IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider,
        IProfileResourceModelProvider profileResourceModelProvider,
        IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
        IProfileValidationReporter profileValidationReporter)
    {
        _createEntity = createEntity;
        _profileContentTypeContextProvider = profileContentTypeContextProvider;
        _profileResourceModelProvider = profileResourceModelProvider;
        _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
        _profileValidationReporter = profileValidationReporter;
    }

    /// <summary>
    /// Ensures the entity can be created before passing it through to the target of the call.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="enforceOptimisticLock"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="DataPolicyException">Occurs when an active Profile prevents the resource's entities from being created.</exception>
    public Task CreateAsync(TEntity entity, bool enforceOptimisticLock, CancellationToken cancellationToken)
    {
        EnsureCreatable();

        return _createEntity.CreateAsync(entity, enforceOptimisticLock, cancellationToken);
    }

    private void EnsureCreatable()
    {
        var profileContentTypeContext = _profileContentTypeContextProvider.Get();

        if (profileContentTypeContext == null)
        {
            return;
        }

        var resource = _dataManagementResourceContextProvider.Get().Resource;

        if (_profileResourceModelProvider.GetProfileResourceModel(profileContentTypeContext.ProfileName)
            .ResourceByName.TryGetValue(resource.FullName, out ProfileResourceContentTypes contentTypes))
        {
            if (!contentTypes.CanCreateResourceClass(resource.FullName))
            {
                throw new DataPolicyException("scenario30.");
            }
        }
    }
}