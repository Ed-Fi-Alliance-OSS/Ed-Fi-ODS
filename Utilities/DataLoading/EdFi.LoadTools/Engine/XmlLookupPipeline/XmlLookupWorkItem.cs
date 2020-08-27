// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Xml.Linq;

namespace EdFi.LoadTools.Engine.XmlLookupPipeline
{
    public class XmlLookupWorkItem
    {
        public XmlLookupWorkItem(XElement xelement)
        {
            LookupXElement = xelement;
        }

        public string JsonModelName { get; set; }

        public string JsonResourceName { get; set; }

        public string ResourceName { get; set; }

        public string HashString { get; set; }

        public string IdentityName { get; set; }

        public string LookupName { get; set; }

        public XElement LookupXElement { get; }

        public XElement GetByExampleXElement { get; set; }

        public XElement ResourceXElement { get; set; }

        public XElement IdentityXElement { get; set; }
    }
}
