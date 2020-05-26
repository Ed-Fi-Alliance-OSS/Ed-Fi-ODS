// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.IO;
using System.Xml;
using System.Xml.Schema;
using log4net;

namespace EdFi.LoadTools.Engine.InterchangePipeline
{
    public class ValidateXmlStep : IInterchangePipelineStep
    {
        private static readonly ILog Log = LogManager.GetLogger(nameof(ValidateXmlStep));
        private readonly IXsdConfiguration _configuration;
        private readonly XmlSchemaSet _schemaSet;

        public ValidateXmlStep(XmlSchemaSet schemaSet, IXsdConfiguration configuration)
        {
            _schemaSet = schemaSet;
            _configuration = configuration;
        }

        public bool Process(string sourceFileName, Stream stream)
        {
            if (_configuration.DoNotValidateXml)
            {
                Log.Warn("XML validation step skipped");
                return true;
            }

            var result = true;

            var settings = new XmlReaderSettings
                           {
                               ValidationType = ValidationType.Schema, Schemas = _schemaSet, Async = true
                           };

            settings.ValidationEventHandler += (s, e) =>
                                               {
                                                   result = false;
                                                   Log.Error(e.Message);
                                               };

            using (var reader = XmlReader.Create(stream, settings))
            {
                while (reader.Read()) { }
            }

            Log.Info("Validated");
            return result;
        }
    }
}
