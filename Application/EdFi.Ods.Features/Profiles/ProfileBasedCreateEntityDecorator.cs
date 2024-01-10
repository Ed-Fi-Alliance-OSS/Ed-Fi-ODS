using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Models.Validation;
using EdFi.Ods.Common.Profiles;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Features.Profiles;

public class ProfileBasedCreateEntityDecorator<TEntity> : ICreateEntity<TEntity>
    where TEntity : IHasIdentifier, IDateVersionedEntity
{
    private readonly ICreateEntity<TEntity> _createEntity;
    private readonly IContextProvider<ProfileContentTypeContext> _profileContentTypeContextProvider;
    private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
    private readonly IProfileValidationReporter _profileValidationReporter;

    public ProfileBasedCreateEntityDecorator(
        ICreateEntity<TEntity> createEntity,
        IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider,
        IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
        IProfileValidationReporter profileValidationReporter)
    {
        _createEntity = createEntity;
        _profileContentTypeContextProvider = profileContentTypeContextProvider;
        _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
        _profileValidationReporter = profileValidationReporter;
    }

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

        if (!_profileValidationReporter.IsSuitableForCreation(profileContentTypeContext.ProfileName, resource.FullName))
        {
            throw new BadRequestException("The resource cannot be created because a data policy has been applied to the request that prevents it.", 
                new [] { $"The Profile definition for '{profileContentTypeContext.ProfileName}' excludes (or does not include) one or more required data elements needed to create the resource." });
        }
    }
}