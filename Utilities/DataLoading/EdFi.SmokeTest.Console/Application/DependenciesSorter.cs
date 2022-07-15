// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.SmokeTest;

namespace EdFi.SmokeTest.Console.Application
{
    public class DependenciesSorter : Dictionary<Type, Func<IEnumerable<Dependency>, IEnumerable<Dependency>>>, IDependenciesSorter
    { }
}
