// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using Castle.Windsor;
using EdFi.Ods.Common.Configuration;
using TechTalk.SpecFlow;

namespace EdFi.Ods.WebService.Tests.Composites
{
    [Binding]
    public static class ScenarioHooks
    {
        [BeforeScenario("NonDefaultDescriptorNamespace")]
        public static void BeforeScenario()
        {
            var container = FeatureContext.Current.Get<IWindsorContainer>();
            var nvc = (NameValueCollectionConfigValueProvider) container.Resolve<IConfigValueProvider>();
            nvc.Values["DescriptorNamespacePrefix"] = "http://testspace.com";
        }

        [AfterScenario("NonDefaultDescriptorNamespace")]
        public static void AfterScenario()
        {
            var container = FeatureContext.Current.Get<IWindsorContainer>();
            var nvc = (NameValueCollectionConfigValueProvider) container.Resolve<IConfigValueProvider>();
            nvc.Values.Remove("DescriptorNamespacePrefix");
        }
    }
}
