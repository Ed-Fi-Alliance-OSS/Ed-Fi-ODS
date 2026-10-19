// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Repositories;
using MessagePack;

namespace EdFi.Ods.Features.SerializedData.Repositories;

/// <summary>
/// Registers the unresolved reference data of entities with the current <see cref="ReferenceDataLookupContext" /> so that
/// the resource identifiers used in resource reference links can be resolved before the aggregate is serialized.
/// </summary>
/// <remarks>
/// When an existing aggregate is updated, the reference data registered while mapping the submitted aggregate is
/// discarded and tracking is deferred to the synchronization onto the persisted aggregate. That synchronization does
/// not register the reference data of child items it adds (they are the submitted instances themselves), and when the
/// persisted aggregate was hydrated by NHibernate (because its serialized data was missing or stale), the serialized
/// reference data of its existing items is never resolved either. Tracking the persisted aggregate immediately before
/// resolution ensures the serialized aggregate contains the resource identifiers needed for resource reference links.
/// </remarks>
public class ReferenceDataTracker : IReferenceDataTracker
{
    private static readonly ConcurrentDictionary<Type, TrackedMembers> _trackedMembersByType = new();

    private readonly IContextProvider<ReferenceDataLookupContext> _referenceDataLookupContextProvider;

    public ReferenceDataTracker(IContextProvider<ReferenceDataLookupContext> referenceDataLookupContextProvider)
    {
        _referenceDataLookupContextProvider = referenceDataLookupContextProvider;
    }

    /// <inheritdoc cref="IReferenceDataTracker.TrackUnresolvedReferenceData" />
    public void TrackUnresolvedReferenceData(object entity)
    {
        var referenceDataLookupContext = _referenceDataLookupContextProvider.Get();

        if (referenceDataLookupContext is null)
        {
            return;
        }

        Track(entity, referenceDataLookupContext, new HashSet<object>(ReferenceEqualityComparer.Instance));
    }

    private static void Track(object item, ReferenceDataLookupContext referenceDataLookupContext, HashSet<object> visited)
    {
        if (item is null || !visited.Add(item))
        {
            return;
        }

        switch (item)
        {
            case IDictionary dictionary:
                foreach (var value in dictionary.Values)
                {
                    Track(value, referenceDataLookupContext, visited);
                }

                return;

            case IEnumerable enumerable and not string:
                foreach (var element in enumerable)
                {
                    Track(element, referenceDataLookupContext, visited);
                }

                return;
        }

        var trackedMembers = _trackedMembersByType.GetOrAdd(item.GetType(), GetTrackedMembers);

        foreach (var property in trackedMembers.ReferenceDataProperties)
        {
            if (property.GetValue(item) is IEntityReferenceData referenceData
                && (referenceData.Id is null || referenceData.Id == Guid.Empty)
                && IsFullyDefined(referenceData))
            {
                referenceDataLookupContext.Add(referenceData);
            }
        }

        foreach (var property in trackedMembers.DescendantProperties)
        {
            Track(property.GetValue(item), referenceDataLookupContext, visited);
        }
    }

    private static bool IsFullyDefined(IEntityReferenceData referenceData)
    {
        // Reference data hydrated before its parent was assigned initializes its contextual key values on first access of the
        // key values, so access them before checking whether the reference is fully defined
        referenceData.GetPrimaryKeyValues();

        return referenceData.IsFullyDefined();
    }

    private static TrackedMembers GetTrackedMembers(Type type)
    {
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.CanRead && p.GetIndexParameters().Length == 0)
            // Only consider members that are serialized with the aggregate (NHibernate-mapped reference data, which may be a
            // lazy-loading proxy, is excluded from serialization and already carries its resource identifier)
            .Where(p => !p.IsDefined(typeof(IgnoreMemberAttribute), inherit: true))
            // Ignore references to the parent entity (part of the child's domain signature) so only descendants are visited
            .Where(p => !p.IsDefined(typeof(DomainSignatureAttribute), inherit: true))
            .ToArray();

        return new TrackedMembers(
            properties.Where(p => typeof(IEntityReferenceData).IsAssignableFrom(p.PropertyType)).ToArray(),
            properties.Where(p => IsDescendantProperty(p.PropertyType)).ToArray());

        static bool IsDescendantProperty(Type propertyType)
        {
            if (typeof(IChildEntity).IsAssignableFrom(propertyType) || typeof(IDictionary).IsAssignableFrom(propertyType))
            {
                return true;
            }

            // Collections of child entities (ignoring strings and collections of primitives such as byte arrays)
            var elementType = propertyType.IsArray
                ? propertyType.GetElementType()
                : propertyType.GetInterfaces()
                    .Append(propertyType)
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                    .Select(i => i.GetGenericArguments()[0])
                    .FirstOrDefault();

            return elementType is not null
                && elementType != typeof(string)
                && !elementType.IsPrimitive
                && !elementType.IsValueType;
        }
    }

    private sealed record TrackedMembers(PropertyInfo[] ReferenceDataProperties, PropertyInfo[] DescendantProperties);
}
