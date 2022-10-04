// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdFi.Common;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Profiles;
using EdFi.Ods.Common.Security.Claims;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Serialization;

namespace EdFi.Ods.Api.Serialization;

// SPIKE NOTE: We may want to provide an extension point while initializing the JSON serializer for the API so that the Profiles
// feature can set to this contract resolver (renamed to ProfilesContractResolver) as part of the feature only (otherwise the
// default behavior would be to use the CamelCasePropertyNamesContractResolver).

public class ProfilesAwareContractResolver : DefaultContractResolver
{
    // SPIKE NOTE: This namespace should probably be defined in a conventions class, if not already
    private const string EdFiOdsApiModelsResourcesNamespacePrefix = "EdFi.Ods.Api.Common.Models.Resources.";

    private readonly ConcurrentDictionary<MappingContractKey, JsonContract> _contractByKey = new();
    private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;

    private readonly ConcurrentDictionary<Type, FullName> _fullNameByType = new();
    private readonly IContextProvider<ProfileContentTypeContext> _profileContentTypeContextProvider;

    private readonly IProfileResourceModelProvider _profileResourceModelProvider;

    public ProfilesAwareContractResolver(
        IContextProvider<ProfileContentTypeContext> profileRequestContextProvider,
        IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
        IProfileResourceModelProvider profileResourceModelProvider)
    {
        _dataManagementResourceContextProvider = dataManagementResourceContextProvider;

        _profileResourceModelProvider = Preconditions.ThrowIfNull(
            profileResourceModelProvider,
            nameof(profileResourceModelProvider));

        _profileContentTypeContextProvider = Preconditions.ThrowIfNull(
            profileRequestContextProvider,
            nameof(profileRequestContextProvider));
    }

    public override JsonContract ResolveContract(Type type)
    {
        // Use default behavior for everything but resource classes
        if (type.FullName?.StartsWith(EdFiOdsApiModelsResourcesNamespacePrefix) != true)
        {
            return base.ResolveContract(type);
        }

        var profileContentTypeContext = _profileContentTypeContextProvider.Get();

        // Use default behavior if there is no Profile request
        if (profileContentTypeContext == null)
        {
            return base.ResolveContract(type);
        }

        var resourceClassFullName = GetFullNameFromResourceTypeNamespace(type);

        // SPIKE NOTE: Review this check somewhere on top-level resource classes -- but isn't probably valid here (e.g. on child types)
        // // Ensure that the resource name of the profile request context matches the type being serialized
        // if (!profileRequestContext.ResourceName.EqualsIgnoreCase(resourceClassFullName.Name))
        // {
        //     throw new BadRequestException(
        //         "The resource specified in the profile-based content type did not match the resource targeted by the request.");
        // }

        var mappingContractKey = new MappingContractKey(
            resourceClassFullName,
            profileContentTypeContext.ProfileName,
            _dataManagementResourceContextProvider.Get().Resource.FullName,
            profileContentTypeContext.ContentTypeUsage);

        var contract = _contractByKey.GetOrAdd(mappingContractKey, k => CreateContract(type));

        return contract;
    }

    private FullName GetFullNameFromResourceTypeNamespace(Type type)
    {
        return _fullNameByType.GetOrAdd(
            type,
            t =>
            {
                // Create a string segment for the pertinent part of the full name
                var resourceTypeNamespace = new StringSegment(
                    type.FullName,
                    EdFiOdsApiModelsResourcesNamespacePrefix.Length,
                    type.FullName.Length - EdFiOdsApiModelsResourcesNamespacePrefix.Length);

                var namePartsTokenizer = resourceTypeNamespace.Split(new[] { '.' });

                // SPIKE NOTE: Do we need to convert the schema name from ProperCaseName to the PhysicalName. Will they ever be different, other than in casing?
                var (schema, name) = GetSchemaAndResourceNameFromTokenizedString(namePartsTokenizer);

                return new FullName(schema, name);
            });

        (string, string) GetSchemaAndResourceNameFromTokenizedString(StringTokenizer tokenizer)
        {
            using var enumerator = tokenizer.GetEnumerator();

            enumerator.MoveNext();

            enumerator.MoveNext();
            string schema = enumerator.Current.Value;

            enumerator.MoveNext();
            string name = enumerator.Current.Value;

            return (schema, name);
        }
    }

    protected override List<MemberInfo> GetSerializableMembers(Type objectType)
    {
        // Get the total list of available members to serialize
        var serializableMembers = base.GetSerializableMembers(objectType);

        string typeFullName = objectType.FullName;

        // Use default serialization behavior if this is not a resource class
        if (typeFullName?.StartsWith(EdFiOdsApiModelsResourcesNamespacePrefix) != true)
        {
            return serializableMembers;
        }

        // Get the profile request context
        var profileRequestContext = _profileContentTypeContextProvider.Get();

        // If this is not Profile-constrained, use default behavior
        if (profileRequestContext == null)
        {
            return serializableMembers;
        }

        var resourceClassFullName = GetFullNameFromResourceTypeNamespace(objectType);

        var profileResourceModel = _profileResourceModelProvider.GetProfileResourceModel(profileRequestContext.ProfileName);

        var profileResource =
            profileResourceModel.GetResourceByName(_dataManagementResourceContextProvider.Get().Resource.FullName);

        if (profileResource == null)
        {
            throw new Exception(
                $"Resource '{profileRequestContext.ResourceName}' not found in API Profile '{profileRequestContext.ProfileName}'");
        }

        var profileResourceClass =
            profileResource.AllContainedItemTypesOrSelf.SingleOrDefault(x => x.FullName == resourceClassFullName);

        var supportedMemberNames = profileResourceClass?.PropertyByName.Keys.Concat(profileResourceClass.CollectionByName.Keys)
            .Concat(profileResourceClass.ReferenceByName.Keys)
            .ToArray();

        var profileConstrainedMembers = serializableMembers
            .Where(mi => supportedMemberNames?.Contains(mi.Name) != false)
            .ToList();

        return profileConstrainedMembers;
    }
}
