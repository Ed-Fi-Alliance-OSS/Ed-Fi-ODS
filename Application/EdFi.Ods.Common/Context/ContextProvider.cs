// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Context;

/// <summary>
/// Provides a generic implementation of <see cref="IContextProvider{T}" /> that eliminates boilerplate implementations
/// by automatically providing a key for context storage, and enables strongly-typed context access through dependency injection. 
/// </summary>
/// <typeparam name="T">The <see cref="Type" /> of the object containing the context to be stored.</typeparam>
public class ContextProvider<T> : IContextProvider<T>
{
    private static readonly string _contextKey = typeof(T).FullName;
    
    private readonly IContextStorage _contextStorage;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContextProvider{T}"/> class using the supplied context storage.
    /// </summary>
    /// <param name="contextStorage"></param>
    public ContextProvider(IContextStorage contextStorage)
    {
        _contextStorage = contextStorage;
    }

    /// <inheritdoc cref="IContextProvider{T}.Get" />
    public T Get() => _contextStorage.GetValue<T>(_contextKey);

    /// <inheritdoc cref="IContextProvider{T}.Set" />
    public void Set(T context) => _contextStorage.SetValue(_contextKey, context);
}
