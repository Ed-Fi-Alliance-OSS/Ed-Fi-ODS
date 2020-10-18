// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.CodeGen.Providers.Impl
{
    public class IncludePluginsProvider : IIncludePluginsProvider
    {
        private readonly bool _includePlugins;

        public IncludePluginsProvider(bool includePlugins)
        {
            _includePlugins = includePlugins;
        }

        public bool IncludePlugins()
        {
           return _includePlugins;
        }
    }
}
