// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace EdFi.Ods.Api.NetCore.Configuration
{
    public class MvcOptionsConfigurator : IConfigureOptions<MvcOptions>
    {
        private readonly IEnumerable<IApplicationModelConvention> _applicationModelConventions;
        private readonly IEnumerable<IFilterMetadata> _filters;

        public MvcOptionsConfigurator(IEnumerable<IApplicationModelConvention> applicationModelConventions, IEnumerable<IFilterMetadata> filters)
        {
            _applicationModelConventions = applicationModelConventions;
            _filters = filters;
        }

        public void Configure(MvcOptions options)
        {
            foreach (IApplicationModelConvention applicationModelConvention in _applicationModelConventions)
            {
                options.Conventions.Add(applicationModelConvention);
            }

            foreach (var actionFilterAttribute in _filters)
            {
                options.Filters.Add(actionFilterAttribute);
            }
        }
    }
}
