// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using log4net.Config;
using NUnit.Framework;

namespace EdFi.LoadTools.Test
{
   [TestFixture]
    public class LogConfiguration
    {
        [SetUp]
        public static void ConfigureLogging(TestContext context)
        {
            BasicConfigurator.Configure();
        }
    }
}
