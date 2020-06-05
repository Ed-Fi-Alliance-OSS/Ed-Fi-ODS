// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.Ods.Api.Common.Infrastructure.Extensibility
{
    /// <summary>
    /// Defines a method for registering Ed-Fi aggregate and entity extensions.
    /// </summary>
    public interface IEntityExtensionRegistrar
    {
        IDictionary<Type, Dictionary<string, EntityExtension>> EntityExtensionsByEntityType { get; }

        IDictionary<Type, IList<string>> AggregateExtensionEntityNamesByType { get; }
    }
}
