// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.CodeGen.Providers.Impl
{
    public class IncludeExtensionsProvider : IIncludeExtensionsProvider
    {
        private readonly bool _includeExtensions;

        public IncludeExtensionsProvider(bool includeExtensions)
        {
            _includeExtensions = includeExtensions;
        }

        public bool IncludeExtensions()
        {
           return _includeExtensions;
        }
    }
}
