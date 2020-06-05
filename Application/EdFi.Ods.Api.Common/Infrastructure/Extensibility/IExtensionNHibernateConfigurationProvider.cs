// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Api.Common.Dtos;
using NHibernate.Cfg.MappingSchema;

namespace EdFi.Ods.Api.Common.Infrastructure.Extensibility
{
    public interface IExtensionNHibernateConfigurationProvider
    {
        OrmMappingFileData OrmMappingFileData { get; }

        /// <summary>
        /// Extensions that are new properties added to a "core" entity.
        /// </summary>
        IDictionary<string, HbmBag> EntityExtensionHbmBagByEntityName { get; }

        /// <summary>
        /// Extensions that are new entities added to an existing aggregate.
        /// </summary>
        IDictionary<string, HbmBag[]> AggregateExtensionHbmBagsByEntityName { get; }

        /// <summary>
        /// Extensions that are derived from a class without a discriminator (e.g. a descriptor).
        /// </summary>
        IDictionary<string, HbmJoinedSubclass[]> NonDiscriminatorBasedHbmJoinedSubclassesByEntityName { get; }

        /// <summary>
        /// Extensions that are derived from either a class using a discriminator.
        /// </summary>
        IDictionary<string, HbmSubclass[]> DiscriminatorBasedHbmSubclassesByEntityName { get; }
    }
}
