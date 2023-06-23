// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Common.Specifications;

/// <summary>
/// Defines methods for obtaining the entity names of the known person types, and identifying whether various input
/// arguments are referring to a person type or person identifier.
/// </summary>
public interface IPersonEntitySpecification
{
    /// <summary>
    /// Indicates whether the specified <see cref="Type"/> represents a type of person.
    /// </summary>
    /// <param name="type">The <see cref="Type"/> to be evaluated.</param>
    /// <returns><b>true</b> if the entity type represents a type of person; otherwise <b>false</b>.</returns>
    bool IsPersonEntity(Type type);

    /// <summary>
    /// Indicates whether the specified type name represents a type of person.
    /// </summary>
    /// <param name="typeName">The <see cref="Type.Name"/> value to be evaluated.</param>
    /// <returns><b>true</b> if the entity represents a type of person; otherwise <b>false</b>.</returns>
    bool IsPersonEntity(string typeName);

    /// <summary>
    /// Indicates whether the specified property name is an identifier for a person.
    /// </summary>
    /// <param name="propertyName">The name of the property to be evaluated.</param>
    /// <returns><b>true</b> if the property is an identifier for a type of person; otherwise <b>false</b>.</returns>
    bool IsPersonIdentifier(string propertyName);

    /// <summary>
    /// Indicates whether the specified property name is an identifier for the specified person type.
    /// </summary>
    /// <param name="propertyName">The name of the property to be evaluated.</param>
    /// <param name="personType">A specific type of person.</param>
    /// <returns><b>true</b> if the property is an identifier for the specified type of person; otherwise <b>false</b>.</returns>
    bool IsPersonIdentifier(string propertyName, string personType);
    
    /// <summary>
    /// Gets the type of person for a supplied UniqueId property name.
    /// </summary>
    /// <param name="propertyName">The name of the property to be evaluated.</param>
    /// <returns>The type of person associated with the property name if matched; otherwise null.</returns>
    string GetUniqueIdPersonType(string propertyName);

    /// <summary>
    /// Attempt to determine the type of person for a supplied UniqueId property name.
    /// </summary>
    /// <param name="propertyName">The name of the UniqueId property to be evaluated.</param>
    /// <param name="personType">The type of person identified, based on the property name.</param>
    /// <returns><b>true</b> if the person type could be determined; otherwise <b>false</b>.</returns>
    bool TryGetUniqueIdPersonType(string propertyName, out string personType);

    /// <summary>
    /// Gets the type of person for a supplied USI property name.
    /// </summary>
    /// <param name="propertyName">The name of the property to be evaluated.</param>
    /// <returns>The type of person associated with the property name if matched; otherwise null.</returns>
    string GetUSIPersonType(string propertyName);

    /// <summary>
    /// Attempt to determine the type of person for a supplied USI property name.
    /// </summary>
    /// <param name="propertyName">The name of the USI property to be evaluated.</param>
    /// <param name="personType">The type of person identified, based on the property name.</param>
    /// <returns><b>true</b> if the person type could be determined; otherwise <b>false</b>.</returns>
    bool TryGetUSIPersonType(string propertyName, out string personType);

    /// <summary>
    /// Attempt to determine the type of person and an associated role name for a supplied USI property name.
    /// </summary>
    /// <param name="propertyName">The name of the USI property to be evaluated.</param>
    /// <param name="personType">The type of person identified, based on the property name.</param>
    /// <param name="roleName">The role name applied to the property name.</param>
    /// <returns><b>true</b> if the person type could be determined; otherwise <b>false</b>.</returns>
    bool TryGetUSIPersonTypeAndRoleName(string propertyName, out string personType, out string roleName);

    /// <summary>
    /// Indicates whether the supplied resource class and resource property individually match the conventions necessary for
    /// the property to be a UniqueId property, and the resource class to be associated with a person entity.
    /// </summary>
    /// <param name="resourceClass">The resource class to be evaluated.</param>
    /// <param name="property">The resource property to be evaluated.</param>
    /// <returns><b>true</b> if both input parameter match their respective conventions; otherwise <b>false</b>.</returns>
    bool IsDefiningUniqueId(ResourceClassBase resourceClass, ResourceProperty property);
}
