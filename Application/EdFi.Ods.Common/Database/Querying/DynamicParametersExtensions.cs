// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using Dapper;

namespace EdFi.Ods.Common.Database.Querying;

public static class DynamicParametersExtensions
{
    // Build a compiled expression delegate to access the private 'parameters' field
    private static readonly Func<DynamicParameters, IDictionary> _getParametersDelegate = CreateGetParametersDelegate();

    /// <summary>
    /// Merges the parameter values from the source <see cref="DynamicParameters" /> into the target <see cref="DynamicParameters" />,
    /// skipping over parameters that have the same name and value.
    /// </summary>
    /// <param name="target">The DynamicParameters instance that is the merge target.</param>
    /// <param name="source">The DynamicParameters instance whose values are to be merged into the target instance.</param>
    public static void MergeParameters(this DynamicParameters target, DynamicParameters source)
    {
        // Use the compiled delegate to get the 'parameters' dictionary
        var targetParameters = _getParametersDelegate(target);
        var sourceParameters = _getParametersDelegate(source);

        // Merge source parameters into target parameters
        foreach (string key in sourceParameters.Keys)
        {
            if (!targetParameters.Contains(key))
            {
                targetParameters.Add(key, sourceParameters[key]);
            }
            else
            {
                if (!targetParameters[key].Equals(sourceParameters[key]))
                {
                    throw new Exception($"Target parameters already contains a key of '{key}' with a different value.");
                }
            }
        }
    }

    private static Func<DynamicParameters, IDictionary> CreateGetParametersDelegate()
    {
        // Get the FieldInfo for the private 'parameters' field
        var fieldInfo = typeof(DynamicParameters).GetField("parameters", BindingFlags.NonPublic | BindingFlags.Instance);

        if (fieldInfo == null)
        {
            throw new Exception("Could not find the 'parameters' field in DynamicParameters.");
        }

        // Create a parameter expression for the DynamicParameters instance
        var instance = Expression.Parameter(typeof(DynamicParameters), "instance");

        // Create an expression to access the field
        var fieldAccess = Expression.Field(instance, fieldInfo);

        // Convert the field access to a delegate returning IDictionary
        var lambda = Expression.Lambda<Func<DynamicParameters, IDictionary>>(fieldAccess, instance);

        // Compile the expression into a delegate
        return lambda.Compile();
    }
}
