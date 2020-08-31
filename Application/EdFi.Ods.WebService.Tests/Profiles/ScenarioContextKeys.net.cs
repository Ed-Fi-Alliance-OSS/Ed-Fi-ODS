// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
namespace EdFi.Ods.WebService.Tests.Profiles
{
    public class ScenarioContextKeys
    {
        public const string Data = "data";
        public const string ProfileName = "profileName";
        public const string AssignedProfiles = "assignedProfiles";
        public const string ResourceModelName = "resourceModelName";
        public const string ResourceCollectionName = "resourceCollectionName";
        public const string PersistedEntity = "persistedEntity";
        public const string OriginalEntity = "originalEntity";
        public const string ResourceForUpdate = "entityResourceForUpdate";
        public const string ContextualPrimaryKeyPropertyCount = "contextualPrimaryKeyPropertyCount";
        public const string ExcludedPropertyCount = "excludedPropertyCount";
        public const string IncludedPropertyCount = "includedPropertyCount";
        public const string ResourceType = "resourceType";
    }
}
#endif