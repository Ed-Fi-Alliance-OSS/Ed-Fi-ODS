// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.Ods.CodeGen.Providers.Impl
{
    public class ExtensionLocationPluginsProvider : IExtensionLocationPluginsProvider
    {
        private readonly IEnumerable<string> _extensionPaths;

        public ExtensionLocationPluginsProvider(IEnumerable<string> extensionPaths)
        {
            _extensionPaths = extensionPaths ?? Array.Empty<string>();
        }

        public IEnumerable<string> GetExtensionLocationPlugins()
        {
            return _extensionPaths;
        }
    }
}
