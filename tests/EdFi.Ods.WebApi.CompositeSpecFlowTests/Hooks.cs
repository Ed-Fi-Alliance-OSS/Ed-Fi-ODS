// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Threading;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;
using TechTalk.SpecFlow;

namespace EdFi.Ods.WebApi.CompositeSpecFlowTests
{
    [Binding]
    public class Hooks
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Hooks));

        [BeforeFeature]
        public static void BeforeApiFeature(FeatureContext featureContext)
        {
            featureContext.Set(CompositesSpecFlowTestFixture.Instance.ServiceProvider);
            featureContext.Set(new CancellationToken());

            Hierarchy hierarchy = LogManager.GetRepository(typeof(CompositesSpecFlowTestFixture).Assembly) as Hierarchy;

            MemoryAppender memoryAppender = hierarchy.GetAppenders()
                .SingleOrDefault(a => a.Name == "MemoryAppender") as MemoryAppender;

            featureContext.Set(memoryAppender);
        }
    }
}
