// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System;

namespace EdFi.Ods.SwaggerUI
{
    public class StartupFactory
    {
        private readonly string _startupClassName;
        private const string MissingStartupClassMessage =
            "Could not find a startup class named '{0}' that derives from SwaggerStartupBase.";
        public StartupFactory(string startupClassName)
        {
            _startupClassName = startupClassName;
        }

        public SwaggerStartupBase CreateStartup(WebHostBuilderContext webHostBuilderContext) 
        {
            var startupType = FindStartupClassType(_startupClassName);
            var startup = (SwaggerStartupBase)Activator.CreateInstance(startupType, webHostBuilderContext.Configuration);
            return startup;
        }
        
        private Type FindStartupClassType(string startupClassName)
        {
            var startupType = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => assembly.GetName().Name?.StartsWith("EdFi.") ?? false)
                .SelectMany(assembly => assembly.GetTypes())
                .FirstOrDefault(t => t.Name == startupClassName && typeof(SwaggerStartupBase).IsAssignableFrom(t));

            if (startupType == null)
            {
                throw new TypeLoadException(string.Format(MissingStartupClassMessage, startupClassName));
            }

            return startupType;
        }
    }
}
