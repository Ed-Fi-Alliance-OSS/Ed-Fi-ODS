// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Common.Repositories;

public class DeserializationContextProvider : IDeserializationContextProvider
{
    private readonly IContextStorage _contextStorage;
    private const string ContextKey = "IsDeserializing";
    
    // Create boxed boolean values to limit heap usage through reuse
    private static readonly object _deserializing = true;
    private static readonly object _notDeserializing = false;

    public DeserializationContextProvider(IContextStorage contextStorage)
    {
        _contextStorage = contextStorage;
    }

    public void SetState(bool isDeserializing)
    {
        _contextStorage.SetValue(
            ContextKey,
            isDeserializing
                ? _deserializing
                : _notDeserializing);
    }

    public bool IsDeserializing() => _contextStorage.GetValue<bool>(ContextKey);
}
