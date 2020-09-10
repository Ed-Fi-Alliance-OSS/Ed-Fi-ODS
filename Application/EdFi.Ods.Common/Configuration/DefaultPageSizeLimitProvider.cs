// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETSTANDARD
using Microsoft.Extensions.Configuration;

namespace EdFi.Ods.Common.Configuration
{
    public class DefaultPageSizeLimitProvider : IDefaultPageSizeLimitProvider
    {
        private readonly IConfiguration _configuration;
       
        public DefaultPageSizeLimitProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
       
        public int GetDefaultPageSizeLimit() => int.TryParse(_configuration.GetSection("defaultPageSizeLimit").Value, out int defaultPageSizeLimit)
        ? defaultPageSizeLimit
        : 500;
    }
}
#endif
