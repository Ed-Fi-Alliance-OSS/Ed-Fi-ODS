// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Microsoft.Extensions.Configuration;

namespace EdFi.Ods.Common.Configuration
{
    public class DefaultPageSizeLimitProvider : IDefaultPageSizeLimitProvider
    {
        private readonly int _defaultPageSizeLimit;

        public DefaultPageSizeLimitProvider(int defaultPageSizeLimit)
        {
            _defaultPageSizeLimit = defaultPageSizeLimit;
        }

        public int GetDefaultPageSizeLimit() => _defaultPageSizeLimit;
    }
}
