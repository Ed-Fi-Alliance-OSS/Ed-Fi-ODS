// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using log4net;

namespace EdFi.LoadTools.Engine.Factories
{
    public class ResourceFileStreamFactory : IResourceStreamFactory
    {
        private static readonly ILog Log = LogManager.GetLogger(nameof(ResourceFileStreamFactory));
        private readonly IDataConfiguration _configuration;
        private readonly string[] _xmlFiles;
        private readonly Regex _interchangeNameRegex = new Regex(Constants.InterchangeNameRegex, RegexOptions.Compiled);
        private readonly Dictionary<string, List<string>> _interchangeToInterchangeFilesDictionary = new Dictionary<string, List<string>>();

        public ResourceFileStreamFactory(IDataConfiguration configuration)
        {
            _configuration = configuration;
            _xmlFiles = Directory.GetFiles(_configuration.Folder, "*.xml", SearchOption.AllDirectories);
        }

        public Dictionary<string, List<string>> GetInterchangeToInterchangeFilesMap()
        {
            string GetInterchangeType(string fileName)
            {
                var settings = new XmlReaderSettings { CloseInput = true };

                using (var reader = XmlReader.Create(fileName, settings))
                {
                    if (reader.MoveToContent() == XmlNodeType.Element)
                    {
                        var match = _interchangeNameRegex.Match(reader.Name);
                        
                        if (match.Success)
                        {
                            return match.Groups["InterchangeType"].Value;
                        }
                    }
                }

                return null;
            }

            foreach (var file in _xmlFiles)
            {
                var interchangeType = GetInterchangeType(file);

                if (!string.IsNullOrEmpty(interchangeType))
                {
                    if (_interchangeToInterchangeFilesDictionary.TryGetValue(interchangeType, out List<string> files))
                    {
                        files.Add(file);
                    }
                    else
                    {
                        _interchangeToInterchangeFilesDictionary[interchangeType] = new List<string> {file};
                    }
                }
            }

            return _interchangeToInterchangeFilesDictionary;
        }

        public Stream GetStream(string interchangeFileName)
        {
            return new FileStream(interchangeFileName, FileMode.Open, FileAccess.Read);
        }
    }
}
