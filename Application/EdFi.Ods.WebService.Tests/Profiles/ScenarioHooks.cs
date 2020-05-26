// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using Castle.Windsor;
using EdFi.TestObjects;
using TechTalk.SpecFlow;

namespace EdFi.Ods.WebService.Tests.Profiles
{
    [Binding]
    public sealed class ScenarioHooks
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            IWindsorContainer container;

            // Reset the TestObjectFactory values between scenarios, when relevant
            if (FeatureContext.Current.TryGetValue(out container))
            {
                var testObjectFactory = container.Resolve<ITestObjectFactory>();
                testObjectFactory.ResetValueBuilders();
            }
        }
    }
}
