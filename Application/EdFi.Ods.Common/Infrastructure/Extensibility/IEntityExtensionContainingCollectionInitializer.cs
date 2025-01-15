// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Infrastructure.Extensibility;

/// <summary>
/// Defines methods for creating the collection that holds the entity extension object which is appropriate for NHibernate
/// persistence operation under the current configuration.
/// </summary>
public interface IEntityExtensionContainingCollectionInitializer
{
    /// <summary>
    /// Creates an empty, uninitialized collection appropriate for NHibernate persistence operations. 
    /// </summary>
    /// <returns>An empty, uninitialized collection.</returns>
    object CreateContainingCollection();
        
    /// <summary>
    /// Creates a collection appropriate for NHibernate persistence operations initialized with the supplied entity extension object. 
    /// </summary>
    /// <param name="extensionObject"></param>
    /// <returns></returns>
    object CreateContainingCollection(object extensionObject);
}
