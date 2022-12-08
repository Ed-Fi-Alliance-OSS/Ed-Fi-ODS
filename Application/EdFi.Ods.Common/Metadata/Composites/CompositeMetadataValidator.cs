// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.XPath;
using EdFi.Ods.Common.Extensions;
using FluentValidation.Results;

namespace EdFi.Ods.Common.Metadata.Composites
{
    public class CompositeMetadataValidator
    {
        private const string ValidationSchemaResourceName = @"EdFi.Ods.Common.Metadata.Schemas.Ed-Fi-ODS-API-Composites.xsd";

        private XmlSchemaSet GetValidationSchemaSet()
        {
            var currentAssembly = typeof(CompositeMetadataValidator).Assembly;

            using (var streamReader = new StreamReader(currentAssembly.GetManifestResourceStream(ValidationSchemaResourceName)))
            {
                var schemaSet = new XmlSchemaSet();

                schemaSet.Add("", XmlReader.Create(new StringReader(streamReader.ReadToEnd())));

                return schemaSet;
            }
        }

        public ValidationResult Validate(XDocument compositeDefinition)
        {
            var errorLabel = new Lazy<string> ( () =>
            {
                string orgCode = compositeDefinition.XPathSelectElement("/CompositeMetadata").AttributeValue("organizationCode");

                string[] categories = compositeDefinition.XPathSelectElements("//Category")
                    .Select(x => x.AttributeValue("displayName"))
                    .ToArray();

                return string.Join("/", categories)
                    + (string.IsNullOrEmpty(orgCode)
                        ? string.Empty
                        : $" ({orgCode})");
            });  
            
            var validationFailures = new List<ValidationFailure>();

            compositeDefinition.Validate(
                GetValidationSchemaSet(),
                (sender, args) =>
                {
                    validationFailures.Add(new ValidationFailure(string.Empty, $"{errorLabel.Value}: {args.Message}"));
                });

            return new ValidationResult(validationFailures);
        }
    }
}
