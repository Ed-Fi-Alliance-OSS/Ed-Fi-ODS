// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.Ods.Common.Repositories;

/// <summary>
/// Implements a contextual object for tracking the "ReferenceData" entities that need to have the key values
/// resolved to the associated entity's Id and Discriminator values for generating resource reference links.
/// </summary>
public class ReferenceDataLookupContext
{
    private readonly Lazy<ISet<IEntityReferenceData>> _values = new(
        () => new HashSet<IEntityReferenceData>(ReferenceEqualityComparer.Instance));

    private bool _isSuppressed;
    
    public ISet<IEntityReferenceData> Items
    {
        get => _values.IsValueCreated
            ? _values.Value
            : throw new Exception("No Items have been added. Use Any method prior to accessing Items to ensure data is present.");
    }

    /// <summary>
    /// Adds an entry to the context containing the reference data instance containing the key value for which the
    /// Id and Discriminator are be retrieved.
    /// </summary>
    public bool Add(IEntityReferenceData referenceData)
    {
        if (_isSuppressed)
        {
            return false;
        }

        return _values.Value.Add(referenceData);
    }

    /// <summary>
    /// Suppresses all further reference data resolution tracking for the current request.
    /// </summary>
    /// <remarks>
    /// This method is called when an NHibernate=hydrated reference data object is assigned to any entity model to prevent
    /// unnecessary resolution performed based on the information gathered by this class.
    /// </remarks>
    public void Suppress()
    {
        _isSuppressed = true;
        Clear();
    }

    /// <summary>
    /// Restores reference data that was pending resolution before tracking was suppressed, without resuming tracking.
    /// </summary>
    /// <remarks>
    /// This method is used when some aggregates of a request were deserialized (registering their unresolved reference
    /// data) before others were hydrated by NHibernate (which suppresses tracking and clears the context).
    /// </remarks>
    /// <param name="pendingItems">The reference data items that were pending resolution before suppression.</param>
    public void Restore(IEnumerable<IEntityReferenceData> pendingItems)
    {
        foreach (var item in pendingItems)
        {
            _values.Value.Add(item);
        }
    }

    /// <summary>
    /// Clears all reference data that has been added for resolution and resumes tracking (if it had been suppressed).
    /// </summary>
    /// <remarks>
    /// This method is used once an existing aggregate has been retrieved for an update, deferring reference data
    /// tracking to the subsequent synchronization of the submitted aggregate onto the persisted one.
    /// </remarks>
    public void Reset()
    {
        Clear();
        _isSuppressed = false;
    }

    /// <summary>
    /// Indicates whether any lookups have been added to the context. 
    /// </summary>
    /// <returns><b>true</b> if there are any identifier values to be resolved; otherwise <b>false</b>.</returns>
    public bool Any()
    {
        return _values.IsValueCreated && _values.Value.Count > 0;
    }

    /// <summary>
    /// Indicates whether the activity for reference data resolution has been suppressed for the duration of this request.
    /// </summary>
    /// <returns><b>true</b> if it has been suppressed; otherwise <b>false</b>.</returns>
    public bool IsSuppressed()
    {
        return _isSuppressed;
    }

    /// <summary>
    /// Clears any reference data classes that have been added for resolution.
    /// </summary>
    public void Clear()
    {
        if (_values.IsValueCreated)
        {
            _values.Value.Clear();
        }
    }
}
