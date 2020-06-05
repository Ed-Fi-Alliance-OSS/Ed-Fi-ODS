// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using FluentValidation.Results;

namespace EdFi.Ods.Common.Metadata
{
    public class CompositeMetadataValidator
    {
        private const string ValidationSchemaResourceName = @"EdFi.Ods.Common.Metadata.Schemas.Ed-Fi-ODS-API-Composites.xsd";

        private XmlSchemaSet GetValidationSchemaSet()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();

            using (var streamReader = new StreamReader(currentAssembly.GetManifestResourceStream(ValidationSchemaResourceName)))
            {
                var schemaSet = new XmlSchemaSet();

                schemaSet.Add("", XmlReader.Create(new StringReader(streamReader.ReadToEnd())));

                return schemaSet;
            }
        }

        public ValidationResult Validate(XDocument compositeDefinition)
        {
            ValidationResult validationResult = null;

            compositeDefinition.Validate(
                GetValidationSchemaSet(),
                (sender, args) =>
                {
                    validationResult =
                        new ValidationResult(
                            new[]
                            {
                                new ValidationFailure(
                                    string.Empty,
                                    $"The composite definition '{compositeDefinition.Annotation<string>()}' assembly failed schema validation:{Environment.NewLine}{args.Message}")
                            });
                });

            return validationResult ?? new ValidationResult();
        }
    }
}
