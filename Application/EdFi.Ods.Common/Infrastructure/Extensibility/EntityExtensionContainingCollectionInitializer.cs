// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.Ods.Common.Infrastructure.Extensibility;

/// <summary>
/// Implements the default collection initializer based on <see cref="List{Object}"/>.
/// </summary>
public class EntityExtensionContainingCollectionInitializer : IEntityExtensionContainingCollectionInitializer
{
    public object CreateContainingCollection() => new List<object>();

    public object CreateContainingCollection(Type extensionObjectType, object parentEntity)
    {
        var extensionObject = (IChildEntity) Activator.CreateInstance(extensionObjectType);
        extensionObject.SetParent(parentEntity);

        return new List<object> { extensionObject };
    }
}
