// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Linq;
using EdFi.Common;
using EdFi.Common.Extensions;
using EdFi.Common.Inflection;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Profiles;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Utils.Profiles;

namespace EdFi.Ods.Common.Models;

public class MappingContractProvider : IMappingContractProvider
{
    private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
    private readonly IContextProvider<ProfileContentTypeContext> _profileContentTypeContextProvider;
    private readonly IProfileResourceModelProvider _profileResourceModelProvider;
    private readonly ISchemaNameMapProvider _schemaNameMapProvider;

    private readonly ConcurrentDictionary<MappingContractKey, IMappingContract>
        _mappingContractByKey = new();

    public MappingContractProvider(
        IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider,
        IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
        IProfileResourceModelProvider profileResourceModelProvider,
        ISchemaNameMapProvider schemaNameMapProvider)
    {
        _dataManagementResourceContextProvider = dataManagementResourceContextProvider
            ?? throw new ArgumentNullException(nameof(dataManagementResourceContextProvider));

        _profileContentTypeContextProvider = profileContentTypeContextProvider
            ?? throw new ArgumentNullException(nameof(profileContentTypeContextProvider));

        _profileResourceModelProvider = profileResourceModelProvider
            ?? throw new ArgumentNullException(nameof(profileResourceModelProvider));

        _schemaNameMapProvider = schemaNameMapProvider ?? throw new ArgumentNullException(nameof(schemaNameMapProvider));
    }

    public IMappingContract GetMappingContract(FullName resourceClassFullName)
    {
        // Is there a Profile in context?
        var profileContentTypeContext = _profileContentTypeContextProvider.Get();

        if (profileContentTypeContext == null)
        {
            return null;
        }

        var dataManagementResourceContext = _dataManagementResourceContextProvider.Get();

        // Need to verify that the resource in the profile content type matches the current request resource
        if (!dataManagementResourceContext.Resource.Name.EqualsIgnoreCase(profileContentTypeContext.ResourceName))
        {
            throw new BadRequestException(
                "The resource in the profile-based content type does not match the resource targeted by the request.");
        }
        
        var mappingContractKey = new MappingContractKey(
            resourceClassFullName,
            profileContentTypeContext.ProfileName,
            dataManagementResourceContext.Resource.FullName,
            profileContentTypeContext.ContentTypeUsage);

        return GetOrCreateMappingContract(mappingContractKey);
    }

    private IMappingContract GetOrCreateMappingContract(MappingContractKey mappingContractKey)
    {
        // With no profile, no specific mapping contract is needed (synchronize and map everything)
        if (string.IsNullOrEmpty(mappingContractKey.ProfileName))
        {
            return null;
        }

        var mappingContract = _mappingContractByKey.GetOrAdd(
            mappingContractKey,
            static (key, @this) =>
            {
                // Get the profile-constrained resource model
                var profileResourceModel = @this._profileResourceModelProvider.GetProfileResourceModel(key.ProfileName);

                // If we couldn't find it, throw an error
                if (profileResourceModel == null)
                {
                    throw new BadRequestException($"Unable to find resource model for API Profile '{key.ProfileName}'.");
                }

                // If we can't find the resource in the profile, throw an error
                if (!profileResourceModel.ResourceByName.TryGetValue(key.ProfileResourceName, out var contentTypes))
                {
                    throw new BadRequestException(
                        $"The '{key.ProfileResourceName.Name}' resource is not accessible through the '{key.ProfileName}' profile specified by the content type.");
                }

                // Use the appropriate variant of the resource (readable or writable)
                var profileResource = key.ContentTypeUsage == ContentTypeUsage.Readable
                    ? contentTypes.Readable
                    : contentTypes.Writable;

                if (profileResource == null)
                {
                    throw new ProfileContentTypeUsageException(
                        $"Resource class '{key.ResourceClassName}' is not {key.ContentTypeUsage.ToString().ToLower()} using API profile '{key.ProfileName}'.",
                        key.ProfileName, key.ContentTypeUsage);
                }

                var profileResourceClass =
                    profileResource.AllContainedItemTypesOrSelf.SingleOrDefault(
                        t => t.FullName == key.ResourceClassName);

                if (profileResourceClass == null)
                {
                    // If we couldn't find the class as a member, look for the special case of it being the base class we're looking for
                    if (profileResource.IsDerived && profileResource.Entity.BaseEntity.FullName == key.ResourceClassName)
                    {
                        profileResourceClass = profileResource;
                    }
                    else
                    {
                        throw new Exception(
                            $"Unable to find resource class '{key.ResourceClassName}' in the {key.ContentTypeUsage} resource '{key.ProfileResourceName}' defined in Profile '{key.ProfileName}'.");
                    }
                }

                // Need to convert the physical schema name (which is what it should be) to ProperCaseName
                string properCaseSchemaName = @this._schemaNameMapProvider
                    .GetSchemaMapByPhysicalName(key.ResourceClassName.Schema)
                    .ProperCaseName;
                
                string mappingContractTypeName =
                    $"{Namespaces.Entities.Common.BaseNamespace}.{properCaseSchemaName}.{key.ResourceClassName.Name}MappingContract";

                string assemblyName = key.ResourceClassName.Schema.EqualsIgnoreCase(EdFiConventions.PhysicalSchemaName)
                    ? Namespaces.Standard.BaseNamespace
                    : $"{Namespaces.Extensions.BaseNamespace}.{properCaseSchemaName}";

                // Find the mapping contract type for the specific class
                var mappingContractType = Type.GetType(
                    $"{mappingContractTypeName}, {assemblyName}",
                    throwOnError: true,
                    ignoreCase: true);

                // Use reflection to get the constructor of the mapping contract
                var constructorInfo = mappingContractType.GetConstructors().Single();

                var arguments = constructorInfo.GetParameters()
                    .Select(
                        parameterInfo =>
                        {
                            if (parameterInfo.Name == "supportedExtensions")
                            {
                                return profileResourceClass.Extensions.Select(x => x.PropertyName).ToArray();
                            }

                            if (parameterInfo.Name?.StartsWith("is") != true)
                            {
                                throw new Exception(
                                    $"Constructor argument '{parameterInfo.Name}' of '{mappingContractType.FullName}' did not conform to expected naming convention of isXxxxSupported or isXxxxIncluded.");
                            }

                            if (parameterInfo.Name.EndsWith("Supported"))
                            {
                                string memberName = parameterInfo.Name.Substring(
                                    2,
                                    parameterInfo.Name.Length - "Supported".Length - 2);

                                return profileResourceClass.FilterContext.MemberFilter.ShouldInclude(memberName);
                            }

                            if (parameterInfo.Name.EndsWith("Included"))
                            {
                                string memberName = parameterInfo.Name.Substring(
                                    2,
                                    parameterInfo.Name.Length - "Included".Length - 2);

                                string collectionName = CompositeTermInflector.MakePlural(memberName);

                                if (profileResourceClass.CollectionByName.TryGetValue(collectionName, out var collection))
                                {
                                    Type itemType = parameterInfo.ParameterType.GenericTypeArguments[0];

                                    return ResourceItemPredicateBuilder.Build(itemType, collection.ValueFilters);
                                }

                                // No predicate necessary because the collection itself is not included by this profile
                                return null;
                            }

                            throw new Exception(
                                $"Constructor argument '{parameterInfo.Name}' of '{mappingContractType.FullName}' did not conform to expected naming convention of isXxxxSupported or isXxxxIncluded.");
                        })
                    .ToArray();

                // Create the synchronization context
                return (IMappingContract)constructorInfo.Invoke(arguments);
            }, 
            this);

        return mappingContract;
    }
}

public class MappingContractKey : IEquatable<MappingContractKey>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MappingContractKey" /> class for a non-profile constrained synchronization context.
    /// </summary>
    /// <param name="resourceClassName">The <see cref="FullName" /> of the resource class.</param>
    public MappingContractKey(FullName resourceClassName)
    {
        ResourceClassName = resourceClassName;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MappingContractKey" /> class for a profile-specific synchronization context.
    /// </summary>
    /// <param name="resourceClassName">The name of the resource class (resource root or child item within the resource).</param>
    /// <param name="profileName">The name of the profile.</param>
    /// <param name="profileResourceName">The <see cref="FullName" /> of the resource in context (e.g. the School or LocalEducationAgency for a resource class of EducationOrganizationAddress).</param>
    /// <param name="contentTypeUsage">The usage of the profile (readable or writable).</param>
    public MappingContractKey(
        FullName resourceClassName,
        string profileName,
        FullName profileResourceName,
        ContentTypeUsage contentTypeUsage)
    {
        ResourceClassName = resourceClassName;

        ProfileName = Preconditions.ThrowIfNull(profileName, nameof(profileName));

        ProfileResourceName = profileResourceName;

        if (contentTypeUsage == default(ContentTypeUsage))
        {
            throw new ArgumentException("Content type usage was not specified.");
        }

        ContentTypeUsage = contentTypeUsage;
    }

    public FullName ResourceClassName { get; }

    public string ProfileName { get; }

    public FullName ProfileResourceName { get; }

    public ContentTypeUsage ContentTypeUsage { get; }

    public bool Equals(MappingContractKey other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return ResourceClassName.Equals(other.ResourceClassName)
            && string.Equals(ProfileName, other.ProfileName)
            && ProfileResourceName.Equals(other.ProfileResourceName)
            && ContentTypeUsage == other.ContentTypeUsage;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        return Equals((MappingContractKey)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = ResourceClassName.GetHashCode();

            hashCode = (hashCode * 397)
                ^ (ProfileName != null
                    ? ProfileName.GetHashCode()
                    : 0);

            hashCode = (hashCode * 397) ^ ProfileResourceName.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)ContentTypeUsage;

            return hashCode;
        }
    }
}
