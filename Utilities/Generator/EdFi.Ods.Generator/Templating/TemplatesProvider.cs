// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Utils.Extensions;
using log4net;

namespace EdFi.Ods.Generator.Templating
{
    public class TemplatesProvider : ITemplatesProvider
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(TemplatesProvider));

        public IDictionary<string, string> GetTemplates(Assembly assembly)
        {
            var templateContentByTemplateName = new Dictionary<string, string>();

            string templatesBasePath = $"{assembly.GetName().Name}.Templates.";

            var templateResourceNames = assembly.GetManifestResourceNames()
                .Where(rn => rn.StartsWithIgnoreCase(templatesBasePath)
                    && rn.EndsWithIgnoreCase(".mustache"))
                .ToList();

            foreach (string templateResourceName in templateResourceNames)
            {
                _logger.Debug($"Loading template '{templateResourceName}'...");

                string templateContent = assembly.ReadResource(templateResourceName);

                if (string.IsNullOrEmpty(templateContent))
                {
                    _logger.Error($"Unable to load the template for '{templateResourceName}'.");
                    throw new ArgumentException($"Unable to load the template for '{templateResourceName}'.");
                }

                // get the name of the template for the key
                // eg EdFi.CodeGen.Mustache.AggregateLoaders.mustache -> AggregateLoaders
                string templateName = templateResourceName
                    .Replace(templatesBasePath, string.Empty)
                    .Replace(".mustache", string.Empty);

                _logger.Debug($"Caching template '{templateName}'...");
                
                templateContentByTemplateName.Add(templateName, templateContent);
            }

            return templateContentByTemplateName;
        }
    }
}
