// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.NHibernate.Architecture
{
    /// <summary>
    /// Defines a method for registering Ed-Fi aggregate and entity extensions.
    /// </summary>
    public interface IEntityExtensionRegistrar
    {
        /// <summary>
        /// Registers an Ed-Fi entity extension type to enable the creation of the entity extension objects during entity initialization.
        /// </summary>
        /// <param name="edFiStandardEntityType">The <see cref="Type"/> of the Ed-Fi entity.</param>
        /// <param name="extensionName">The name of the Ed-Fi extension.</param>
        /// <param name="extensionType">The <see cref="Type"/> of the Ed-Fi extension entity.</param>
        /// <param name="isRequired">Indicates whether the presence of the entity extension is required or optional.</param>
        void RegisterEntityExtensionType(Type edFiStandardEntityType, string extensionName, Type extensionType, bool isRequired);

        /// <summary>
        /// Registers an Ed-Fi entity extension type to enable the creation of aggregate extension entries during entity initialization.
        /// </summary>
        /// <param name="edFiStandardEntityType">The type of the Ed-Fi Standard entity.</param>
        /// <param name="aggregateExtensionEntity">The <see cref="Entity" /> representing the Ed-Fi extension entity added to an Ed-Fi standard aggregate.</param>
        void RegisterAggregateExtensionEntity(Type edFiStandardEntityType, Entity aggregateExtensionEntity);
    }
}
