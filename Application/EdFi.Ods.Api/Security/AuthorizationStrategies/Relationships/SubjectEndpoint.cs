// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;

/// <summary>
/// Represent the name, value and (optionally) authorization path modifier for the endpoint of the subject of authorization.
/// </summary>
public class SubjectEndpoint
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SubjectEndpoint"/> class using a name/value tuple.
    /// </summary>
    /// <param name="tuple">A tuple consisting of the name and value for the subject of authorization.</param>
    public SubjectEndpoint((string name, object value) tuple)
    {
        Name = tuple.name;
        Value = tuple.value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SubjectEndpoint"/> class using a name/value tuple and an authorization path modifier for the subject of authorization.
    /// </summary>
    /// <param name="tuple"></param>
    /// <param name="authorizationPathModifier"></param>
    public SubjectEndpoint((string name, object value) tuple, string authorizationPathModifier)
    {
        Name = tuple.name;
        Value = tuple.value;
        AuthorizationPathModifier = authorizationPathModifier;
    }

    /// <summary>
    /// Gets the name of the endpoint.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the value of the endpoint (for instance-based authorizations).
    /// </summary>
    public object Value { get; }

    /// <summary>
    /// Gets the authorization path modifier for authorization.
    /// </summary>
    /// <remarks>This value is used to change which authorization database view is utilized for authorization.</remarks>
    public string AuthorizationPathModifier { get; }
}
