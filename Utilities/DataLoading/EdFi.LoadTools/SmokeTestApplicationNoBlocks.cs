// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.LoadTools.SmokeTest;
using log4net;

namespace EdFi.LoadTools
{
    public class SmokeTestApplicationNoBlocks : ISmokeTestApplication
    {
        private readonly IEnumerable<ITestGenerator> _testGenerators;

        public SmokeTestApplicationNoBlocks(IEnumerable<ITestGenerator> testGenerators)
        {
            _testGenerators = testGenerators;
        }

        protected ILog Log => LogManager.GetLogger(GetType().Name);

        public async Task<int> Run()
        {
            var hasFail = false;

            foreach (var testGenerator in _testGenerators)
            {
                var tests = testGenerator.GenerateTests();

                foreach (var test in tests)
                {
                    var result = false;

                    try
                    {
                        result = await test.PerformTest().ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex);
                    }

                    if (!result)
                    {
                        hasFail = true;
                    }
                }
            }

            return hasFail
                ? 1
                : 0;
        }
    }
}
