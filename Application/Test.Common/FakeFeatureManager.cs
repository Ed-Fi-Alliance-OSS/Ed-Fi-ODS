// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.Ods.Common.Constants;
using Microsoft.FeatureManagement;

namespace Test.Common;

/// <summary>
/// Implements a fake feature manager that initially treats every feature as enabled, but provides a method for
/// changing the state of individual features. 
/// </summary>
public class FakeFeatureManager : IFeatureManager
{
    private readonly bool _featureStateDisposition = true;

    private readonly Dictionary<string, bool> _featureStateByName = new(StringComparer.OrdinalIgnoreCase);

    public IAsyncEnumerable<string> GetFeatureNamesAsync() => throw new System.NotImplementedException();

    /// <summary>
    /// Initializes a new instance of the <see cref="FakeFeatureManager"/> class with every feature enabled by default.
    /// </summary>
    public FakeFeatureManager() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="FakeFeatureManager"/> class using the provided feature enabled/disabled disposition.
    /// </summary>
    /// <param name="featureStateDisposition">The initial enabled/disabled state of the features.</param>
    /// <param name="exceptions">Features whose states represent exceptions to the provided disposition.</param>
    public FakeFeatureManager(bool featureStateDisposition, params ApiFeature[] exceptions)
    {
        _featureStateDisposition = featureStateDisposition;

        foreach (var feature in exceptions)
        {
            SetState(feature.GetConfigKeyName(), !featureStateDisposition);
        }
    }

    public Task<bool> IsEnabledAsync(string feature) => Task.FromResult(GetState(feature));

    public Task<bool> IsEnabledAsync<TContext>(string feature, TContext context) => Task.FromResult(GetState(feature));

    private bool GetState(string featureName)
    {
        return _featureStateByName.GetValueOrDefault(featureName, _featureStateDisposition);
    }

    public void SetState(ApiFeature feature, bool enabled)
    {
        SetState(feature.GetConfigKeyName(), enabled);
    }
    
    public void SetState(string featureName, bool enabled)
    {
        _featureStateByName[featureName] = enabled;
    }
}
