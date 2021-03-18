// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using log4net;

namespace EdFi.LoadTools.Engine.Factories
{
    public class XsdStreamsRetriever
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(XsdStreamsRetriever));

        private readonly IXsdConfiguration _configuration;
        private readonly Regex _regex = new Regex(Constants.XsdRegex);

        public XsdStreamsRetriever(IXsdConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Stream> GetStreams()
        {
            var xsdFolderPath = Path.GetFullPath(_configuration.Folder);
            var files = Directory.GetFiles(xsdFolderPath, "*.xsd").ToList();

            if (files.Count == 0)
            {
                throw new FileNotFoundException($"No xsd files found at '{xsdFolderPath}'");
            }

            _log.Debug($"Get all xsd files at '{xsdFolderPath}'");

            // Find core interchanges that will be replaced with the extension interchange
            var coreInterchangesToRemove =
                files.Select(f => _regex.Match(f))
                     .Where(match => match != null && match.Success)
                     .Select(match => $@"Interchange-{match.Groups["InterchangeType"].Value}.xsd");

            files = files.Where(f => coreInterchangesToRemove.All(ci => Path.GetFileName(f) != ci)).ToList();
            return files.Select(x => new FileStream(x, FileMode.Open, FileAccess.Read));
        }
    }
}
