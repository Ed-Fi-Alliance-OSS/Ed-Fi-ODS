// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using Castle.Core.Logging;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Utils.Extensions;

namespace EdFi.Ods.CodeGen.Providers.Impl
{
    public class MustacheTemplateProvider : IMustacheTemplateProvider
    {
        public ILogger Logger { get; set; } = NullLogger.Instance;

        public IDictionary<string, string> GetMustacheTemplates()
        {
            var templatesByTemplateName = new Dictionary<string, string>();

            var assembly = GetType().Assembly;
            var embeddedResourceNames = assembly.GetManifestResourceNames();
            string subFolder = $"{assembly.GetName().Name}.Mustache.";

            foreach (string embeddedResourceName in embeddedResourceNames)
            {
                Logger.Debug($"");
                // get only the mustache templates
                if (!embeddedResourceName.StartsWithIgnoreCase(subFolder))
                {
                    continue;
                }

                Logger.Debug($"Loading template {embeddedResourceName}");
                
                string template = assembly.ReadResource(embeddedResourceName);

                if (string.IsNullOrEmpty(template))
                {
                    Logger.Error($"Unable to load the template for {embeddedResourceName}.");
                    throw new ArgumentException($"Unable to load the template for {embeddedResourceName}.");
                }

                // get the name of the template for the key
                // eg EdFi.CodeGen.Mustache.AggregateLoaders.mustache -> AggregateLoaders
                string templateName = embeddedResourceName.Replace(subFolder, string.Empty).Replace(".mustache", string.Empty);

                Logger.Debug($"Adding {templateName} into the cache.");
                templatesByTemplateName.Add(templateName, template);
            }

            return templatesByTemplateName;
        }
    }
}
