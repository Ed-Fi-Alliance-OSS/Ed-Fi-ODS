// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Models.Domain
{
    public enum Cardinality
    {
        /// <summary>
        /// Indicates the association represents a <em>required</em> one-to-one relationship.
        /// </summary>
        OneToOne,
        /// <summary>
        /// Indicates the association represents an <em>optional</em> one-to-one relationship.
        /// </summary>
        OneToZeroOrOne,
        /// <summary>
        /// Indicates the association represents an inheritance relationship.
        /// </summary>
        OneToOneInheritance,
        /// <summary>
        /// Indicates the association represents a relationship with a <em>required</em> entity extension.
        /// </summary>
        OneToOneExtension,
        /// <summary>
        /// Indicates the association represents a relationship with an <em>optional</em> entity extension.
        /// </summary>
        OneToZeroOrOneExtension,
        /// <summary>
        /// Indicates the association represents an <em>optional</em> one-to-many relationship.
        /// </summary>
        OneToZeroOrMore,
        /// <summary>
        /// Indicates the association represents a <em>required</em> one-to-many relationship.
        /// </summary>
        OneToOneOrMore
    }
}
