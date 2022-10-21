// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using EdFi.Ods.CodeGen.Models.Configuration;
using log4net;
using Newtonsoft.Json;

namespace EdFi.Ods.CodeGen.Providers.Impl
{
    public class TemplateSetProvider : ITemplateSetProvider
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(TemplateSetProvider));
        private readonly Lazy<ConcurrentDictionary<string, IReadOnlyList<TemplateSet>>> _templatesByTemplateSet;

        public TemplateSetProvider()
        {
            _templatesByTemplateSet =
                new Lazy<ConcurrentDictionary<string, IReadOnlyList<TemplateSet>>>(LazyInitializeTemplateSetData);
        }

        public IReadOnlyList<TemplateSet> GetTemplatesByName(string templateSetName)
        {
            if (_templatesByTemplateSet.Value.TryGetValue(templateSetName, out IReadOnlyList<TemplateSet> results))
            {
                return results;
            }

            throw new ArgumentOutOfRangeException(
                nameof(templateSetName),
                $"Unable to find templates for templateSetName '{templateSetName}'.");
        }

        private ConcurrentDictionary<string, IReadOnlyList<TemplateSet>> LazyInitializeTemplateSetData()
        {
            _logger.Debug("Importing embedded template sets.json file");

            var assembly = GetType()
                .Assembly;

            string filename = $"{assembly.GetName().Name}.TemplateSets.json";

            using (var stream = GetType()
                .Assembly.GetManifestResourceStream(filename))
            {
                if (stream == null)
                {
                    throw new ArgumentException($"Unable to find file:{filename}.");
                }

                string result;

                using (StreamReader sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }

                return JsonConvert.DeserializeObject<ConcurrentDictionary<string, IReadOnlyList<TemplateSet>>>(result);
            }
        }
    }
}
