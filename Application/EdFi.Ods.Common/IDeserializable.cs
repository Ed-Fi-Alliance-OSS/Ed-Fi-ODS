// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common;

public interface IDeserializable
{
    /// <summary>
    /// Deserializes the current item to a fully initialized object of the specified target type.
    /// </summary>
    /// <typeparam name="TTarget">The resource class type to be deserialized.</typeparam>
    bool TryDeserialize<TTarget>(out TTarget deserialized);
}
