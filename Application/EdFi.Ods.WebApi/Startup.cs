// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Startup;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace EdFi.Ods.WebApi
{
    public class Startup : OdsStartupBase
    {
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
            : base(env, configuration) { }
    }
}
