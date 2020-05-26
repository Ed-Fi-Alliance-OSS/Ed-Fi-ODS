// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Linq;
using EdFi.Ods.Common.Metadata.Schemas;
using TechTalk.SpecFlow;

namespace EdFi.Ods.WebService.Tests.Profiles
{
    public static class ScenarioContextExtensions
    {
        public static string EntityTypeName(this ScenarioContext scenarioContext) => scenarioContext.Get<string>(ScenarioContextKeys.ResourceType);

        public static Resource Resource(this ScenarioContext scenarioContext, string entityTypeName = "")
        {
            var typeName = !string.IsNullOrEmpty(entityTypeName)
                ? entityTypeName
                : scenarioContext.EntityTypeName();

            return scenarioContext.Profile()
                                  .Resource.Single(x => x.name == typeName);
        }

        public static Profile Profile(this ScenarioContext scenarioContext) => scenarioContext.Get<Profile>();

        public static string ProfileName(this ScenarioContext scenarioContext) => scenarioContext.Get<string>(ScenarioContextKeys.ProfileName);

        public static T PersistedEntity<T>(this ScenarioContext scenarioContext) => scenarioContext.Get<T>(ScenarioContextKeys.PersistedEntity);

        public static T OriginalEntity<T>(this ScenarioContext scenarioContext) => scenarioContext.Get<T>(ScenarioContextKeys.OriginalEntity);

        public static string ResourceModelName(this ScenarioContext scenarioContext)
            => scenarioContext.Get<string>(ScenarioContextKeys.ResourceModelName);
    }
}
