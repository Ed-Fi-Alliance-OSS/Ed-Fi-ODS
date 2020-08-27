// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace EdFi.LoadTools.Engine.Factories
{
    public class XmlIoFactory : IXmlPairsFactory
    {
        private readonly string _destinationPath;
        private readonly List<string> _files;

        public XmlIoFactory(IDataConfiguration configuration)
        {
            _destinationPath = Path.Combine(configuration.Folder, "Output");
            _files = new List<string>(Directory.GetFiles(configuration.Folder, "*.xml"));

            var dirInfo = Directory.CreateDirectory(_destinationPath);

            foreach (var fileInfo in dirInfo.EnumerateFiles())
            {
                if (_files.Any(
                    f =>
                        string.Compare(Path.GetFileName(f), fileInfo.Name, StringComparison.CurrentCultureIgnoreCase) == 0))
                {
                    fileInfo.Delete();
                }
            }
        }

        public IEnumerable<XmlReader> GetSources()
        {
            var result = _files.Select(f => new XmlTextReader(f));
            return result;
        }

        public IEnumerable<XmlIoPair> GetIoPairs()
        {
            var result = _files.Select(
                f => new XmlIoPair
                     {
                         Source = new XmlTextReader(f),

                         // ReSharper disable once AssignNullToNotNullAttribute
                         Destination = new XmlTextWriter(Path.Combine(_destinationPath, Path.GetFileName(f)), Encoding.UTF8)
                     });

            return result;
        }
    }
}
