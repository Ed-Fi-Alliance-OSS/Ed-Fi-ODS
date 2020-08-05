// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common
{
    /// <summary>
    /// Defines a property indicating the source of the resource/entity identifier.
    /// </summary>
    public interface IHasIdentifierSource
    {
        /// <summary>
        /// Gets or sets the source of the identifier.
        /// </summary>
        IdentifierSource IdSource { get; set; }
    }

    /// <summary>
    /// Contains values identifying the source for a resource/entity identifier value.
    /// </summary>
    public enum IdentifierSource
    {
        /// <summary>
        /// Indicates that the identifier was supplied by the client.
        /// </summary>
        ClientSupplied,
        /// <summary>
        /// Indicates that the identifier was supplied by the server.
        /// </summary>
        SystemSupplied,
    }
}