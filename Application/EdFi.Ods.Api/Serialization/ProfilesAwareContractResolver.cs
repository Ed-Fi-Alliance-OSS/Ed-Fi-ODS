// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Profiles;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Utils.Profiles;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Serialization;

namespace EdFi.Ods.Api.Serialization;

public class ProfilesAwareContractResolver : DefaultContractResolver
{
    private static readonly string[] _extensionsInArray = { "Extensions" };
    private static readonly string[] _metadataProperties =
    {
        "ETag",
        "LastModifiedDate"
    };
    private static readonly List<MemberInfo> _emptyMemberList = new();

    private readonly ConcurrentDictionary<MappingContractKey, JsonContract> _contractByKey = new();
    private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;

    private readonly ConcurrentDictionary<Type, FullName> _fullNameByType = new();
    private readonly IContextProvider<ProfileContentTypeContext> _profileContentTypeContextProvider;

    private readonly IProfileResourceModelProvider _profileResourceModelProvider;
    private readonly string _resourcesNamespacePrefix = $"{Namespaces.Resources.BaseNamespace}.";
    private readonly ISchemaNameMapProvider _schemaNameMapProvider;
    private static readonly char[] _decimalAsCharArray = { '.' };

    public ProfilesAwareContractResolver(
        IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider,
        IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
        IProfileResourceModelProvider profileResourceModelProvider,
        ISchemaNameMapProvider schemaNameMapProvider)
    {
        _dataManagementResourceContextProvider = dataManagementResourceContextProvider
            ?? throw new ArgumentNullException(nameof(dataManagementResourceContextProvider));

        _profileResourceModelProvider = profileResourceModelProvider
            ?? throw new ArgumentNullException(nameof(profileResourceModelProvider));

        _schemaNameMapProvider = schemaNameMapProvider ?? throw new ArgumentNullException(nameof(schemaNameMapProvider));

        _profileContentTypeContextProvider = profileContentTypeContextProvider
            ?? throw new ArgumentNullException(nameof(profileContentTypeContextProvider));
    }

    public override JsonContract ResolveContract(Type type)
    {
        // Use default behavior for everything but resource classes
        if (type.FullName?.StartsWith(_resourcesNamespacePrefix) != true)
        {
            return base.ResolveContract(type);
        }

        var profileContentTypeContext = _profileContentTypeContextProvider.Get();

        // Use default behavior if there is no Profile request
        if (profileContentTypeContext == null || profileContentTypeContext.ContentTypeUsage == ContentTypeUsage.Writable)
        {
            return base.ResolveContract(type);
        }

        var resourceClassFullName = GetFullNameFromResourceTypeNamespace(type);

        var mappingContractKey = new MappingContractKey(
            resourceClassFullName,
            profileContentTypeContext.ProfileName,
            _dataManagementResourceContextProvider.Get().Resource.FullName,
            profileContentTypeContext.ContentTypeUsage);

        var contract = _contractByKey.GetOrAdd(mappingContractKey, 
            static (k, x) => x.Item2.CreateContract(x.type), 
            (type, this));

        return contract;
    }

    private FullName GetFullNameFromResourceTypeNamespace(Type type)
    {
        return _fullNameByType.GetOrAdd(
            type,
            static (t, @this) =>
            {
                // Ensure the type provided is from the expected namespace
                if (!(t.FullName?.StartsWith(@this._resourcesNamespacePrefix) ?? false))
                {
                    throw new InvalidOperationException(
                        $"The type '{t.FullName}' does not start with the expected resource namespace of '{@this._resourcesNamespacePrefix}'.");
                }
                
                // Create a string segment for the pertinent part of the full name
                var resourceTypeNamespace = new StringSegment(
                    t.FullName,
                    @this._resourcesNamespacePrefix.Length,
                    t.FullName.Length - @this._resourcesNamespacePrefix.Length);

                var namePartsTokenizer = resourceTypeNamespace.Split(_decimalAsCharArray);

                var (schema, name) = GetSchemaAndResourceNameFromTokenizedString(namePartsTokenizer);

                string physicalSchemaName = @this._schemaNameMapProvider.GetSchemaMapByProperCaseName(schema).PhysicalName;

                return new FullName(physicalSchemaName, name);
                
                (string, string) GetSchemaAndResourceNameFromTokenizedString(StringTokenizer tokenizer)
                {
                    using var enumerator = tokenizer.GetEnumerator();

                    enumerator.MoveNext();
                    enumerator.MoveNext();

                    string schema = enumerator.Current.Value;
                    enumerator.MoveNext();

                    if (enumerator.Current.Value == "Extensions")
                    {
                        enumerator.MoveNext();
                        schema = enumerator.Current.Value;
                        enumerator.MoveNext();
                    }

                    string name = enumerator.Current.Value;

                    return (schema, name);
                }
            }, 
            this);
    }

    protected override List<MemberInfo> GetSerializableMembers(Type objectType)
    {
        string typeFullName = objectType.FullName;

        // Use default serialization behavior if this is not a resource class
        if (typeFullName?.StartsWith(_resourcesNamespacePrefix) != true)
        {
            return base.GetSerializableMembers(objectType);
        }

        // Get the profile request context
        var profileContentTypeContext = _profileContentTypeContextProvider.Get();

        // If this is not Profile-constrained, or we're deserializing, use default behavior
        if (profileContentTypeContext == null || profileContentTypeContext.ContentTypeUsage == ContentTypeUsage.Writable)
        {
            return base.GetSerializableMembers(objectType);
        }

        var resourceClassFullName = GetFullNameFromResourceTypeNamespace(objectType);

        var profileResourceModel = _profileResourceModelProvider.GetProfileResourceModel(profileContentTypeContext.ProfileName);

        var profileResource =
            profileResourceModel.GetResourceByName(_dataManagementResourceContextProvider.Get().Resource.FullName);

        if (profileResource == null)
        {
            throw new Exception(
                $"Resource '{profileContentTypeContext.ResourceName}' not found in API Profile '{profileContentTypeContext.ProfileName}'.");
        }

        var profileResourceClass =
            profileResource.AllContainedItemTypesOrSelf.SingleOrDefault(x => x.FullName == resourceClassFullName);

        if (profileResourceClass == null)
        {
            // If it's a reference class, just serialize it using default serialization behavior
            if (resourceClassFullName.Name.EndsWith("Reference"))
            {
                return base.GetSerializableMembers(objectType);
            }

            return _emptyMemberList;
        }

        var supportedMemberNames = profileResourceClass.PropertyByName.Keys
            .Concat(profileResourceClass.CollectionByName.Keys)
            .Concat(profileResourceClass.ReferenceByName.Keys)
            .Concat(profileResourceClass.EmbeddedObjectByName.Keys)
            .Concat(_metadataProperties);

        if (profileResourceClass.Extensions.Any())
        {
            supportedMemberNames = supportedMemberNames.Concat(_extensionsInArray);
        }

        // Get the total list of available members to serialize
        var serializableMembers = base.GetSerializableMembers(objectType);

        var profileConstrainedMembers = serializableMembers
            .Where(mi => supportedMemberNames?.Contains(mi.Name) != false)
            .ToList();

        return profileConstrainedMembers;
    }
}
