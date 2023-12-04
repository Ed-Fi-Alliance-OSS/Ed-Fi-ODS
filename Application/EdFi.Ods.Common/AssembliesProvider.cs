// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Reflection;
using EdFi.Common.Extensions;
using log4net;

namespace EdFi.Ods.Common
{
    public class AssembliesProvider : IAssembliesProvider
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(AssembliesProvider));

        public Assembly[] GetAssemblies() => AppDomain.CurrentDomain.GetAssemblies();

        public Assembly Get(string assemblyName)
            => GetAssemblies().FirstOrDefault(x => x.GetName().Name.EqualsIgnoreCase(assemblyName));
    }
}
