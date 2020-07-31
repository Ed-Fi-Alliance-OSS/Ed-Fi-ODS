// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using EdFi.Ods.CodeGen.Providers.Impl;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Metadata.Schemas;

namespace EdFi.Ods.CodeGen.Metadata
{
    public static class MetadataHelper
    {
        private static readonly MetadataFolderProvider _metadataFolderProvider;

        /// <summary>
        ///  NOTE: This is legacy code and it needs to be refactored
        /// </summary>
        static MetadataHelper()
        {
            var codeRepository = new DeveloperCodeRepositoryProvider();
            _metadataFolderProvider = new MetadataFolderProvider(codeRepository);
        }

        public static XDocument GetProfilesXDocument(string profilesMetadataPath)
        {
            // By convention, this should only look for a file called "Profiles.xml"
            string xml = GetMetadataRawXml(profilesMetadataPath, "Profiles.xml");

            if (xml == null)
            {
                return new XDocument();
            }

            return XDocument.Parse(xml);
        }

        public static Profiles GetProfiles(XDocument profilesXDocument) => GetProfilesCore(profilesXDocument.ToString());

        private static Profiles GetProfilesCore(string profilesXml)
        {
            if (profilesXml == null)
            {
                return new Profiles {Profile = new Profile[0]};
            }

            ValidateProfileXml(profilesXml);
            var sr = new StringReader(profilesXml);
            var serializer = new XmlSerializer(typeof(Profiles));
            var profiles = (Profiles) serializer.Deserialize(sr);

            return profiles;
        }

        public static void ValidateProfileXml(string profileXml)
        {
            ValidateRawXml(profileXml, "profiles", @"Metadata.Schemas.Ed-Fi-ODS-API-Profiles.xsd");
        }

        private static string GetMetadataRawXml(string metadataPath, string fileName)
        {
            string metadataFilePath = Path.Combine(metadataPath, fileName);

            if (!File.Exists(metadataFilePath))
            {
                return null;
            }

            string xml = File.ReadAllText(metadataFilePath);
            return xml;
        }

        private static void ValidateRawXml(string rawXml, string metadataType, string resourceName)
        {
            var xmlReaderSettings = new XmlReaderSettings {ValidationType = ValidationType.Schema};

            xmlReaderSettings.ValidationEventHandler += (sender, e) =>
            {
                throw new XmlSchemaValidationException(
                    $"The {metadataType} specified are not valid. {e.Message} on line number {e.Exception.LineNumber} line position {e.Exception.LinePosition}");
            };

            XmlReader metadataXsd;

            // the embedded resource for profies is located in the common assembly
            var currentAssembly = Assembly.GetAssembly(typeof(IChildEntity));

            Stream stream = currentAssembly.GetManifestResourceStream($"{currentAssembly.GetName().Name}.{resourceName}");

            metadataXsd = new XmlTextReader(stream);

            xmlReaderSettings.Schemas.Add("", metadataXsd);
            var metadataXml = new XmlTextReader(new StringReader(rawXml));

            stream.Dispose();

            var xmlReader = XmlReader.Create(metadataXml, xmlReaderSettings);

            while (xmlReader.Read()) { }
        }
    }
}
