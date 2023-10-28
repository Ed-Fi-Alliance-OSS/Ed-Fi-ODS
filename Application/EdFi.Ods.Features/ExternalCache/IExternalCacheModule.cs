﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;

namespace EdFi.Ods.Features.ExternalCache
{
    public interface IExternalCacheModule
    {
        void RegisterProvider(ContainerBuilder builder);
        void RegisterDistributedCache(ContainerBuilder builder);
        string ExternalCacheProvider { get; }
        bool IsProviderSelected();
        void OverrideApiClientDetailsCache(ContainerBuilder builder);
        void OverrideDescriptorsCache(ContainerBuilder builder);
        void OverridePersonUniqueIdToUsiCache(ContainerBuilder builder);
    }
}
