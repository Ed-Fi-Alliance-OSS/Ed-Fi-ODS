// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.LoadTools.SmokeTest;

namespace EdFi.SmokeTest.Console.Application
{
    public class TestFactory<TKey, TValue> : List<Func<TKey, TValue>>, ITestFactory<TKey, TValue>
        where TValue : ITest { }
}
