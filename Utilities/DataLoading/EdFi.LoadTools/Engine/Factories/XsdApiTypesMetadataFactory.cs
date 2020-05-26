// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Xml.Schema;

namespace EdFi.LoadTools.Engine.Factories
{
    /// <summary>
    ///     Return XSD metadata that is filtered to match types that should exist in API metadata
    /// </summary>
    public class XsdApiTypesMetadataFactory : XsdMetadataFactory
    {
        public XsdApiTypesMetadataFactory(XmlSchemaSet schemaSet)
            : base(schemaSet) { }

        /// <summary>
        ///     Don't return Lookup Types or Prior Descriptors because the API doesn't have these concepts
        /// </summary>
        protected override bool ShouldFilterOut(string model, XmlSchemaElement ele)
        {
            return (ele.ElementSchemaType.Name?.EndsWith("LookupType") ?? false) ||
                   (model?.EndsWith("LookupType") ?? false) ||
                   (model?.EndsWith("Descriptor") ?? false) && ele.Name == "PriorDescriptor";
        }
    }
}
