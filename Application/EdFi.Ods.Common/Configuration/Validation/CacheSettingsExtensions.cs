// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Configuration.Validation;

public static class CacheSettingsExtensions
{
    public static bool IsExternalCacheIsInUse(this CacheSettings settings)
    {
        return settings.Descriptors.UseExternalCache
            || settings.PersonUniqueIdToUsi.UseExternalCache
            || settings.ApiClientDetails.UseExternalCache;
    }
}
