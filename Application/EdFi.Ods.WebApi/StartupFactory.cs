// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.Api.Startup;
using Microsoft.AspNetCore.Hosting;
using System;
using EdFi.Common.Extensions;

namespace EdFi.Ods.WebApi
{
    public class StartupFactory(string startupClassName)
    {
        private readonly string _startupClassName = startupClassName;
        private const string MissingStartupClassMessage =
            "Could not find a startup class named '{0}' that derives from OdsStartupBase.";

        public OdsStartupBase Create(WebHostBuilderContext webHostBuilderContext)
        {
            var startupType = FindStartupClassType(_startupClassName);
            var startup = (OdsStartupBase)Activator.CreateInstance(
                startupType,
                webHostBuilderContext.HostingEnvironment,
                webHostBuilderContext.Configuration);
            return startup;
        }

        private Type FindStartupClassType(string startupClassName)
        {
            var startupType = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => assembly.GetName().Name?.StartsWith("EdFi.") ?? false)
                .SelectMany(assembly => assembly.GetTypes())
                .FirstOrDefault(t => t.Name.EqualsIgnoreCase(startupClassName) && typeof(OdsStartupBase).IsAssignableFrom(t));

            if (startupType == null)
            {
                throw new TypeLoadException(string.Format(MissingStartupClassMessage, startupClassName));
            }
            return startupType;
        }
    }
}
