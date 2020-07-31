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
using System.Xml.Linq;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.Engine.XmlLookupPipeline;
using NUnit.Framework;

namespace EdFi.LoadTools.Test
{
    [TestFixture]
    public class XmlLookupToResourceProcessorTests
    {
        private readonly XElement _a1Identity = XElement.Parse("<AIdentity><Id>1</Id></AIdentity>");

        private readonly XElement _a1Lookup = XElement.Parse("<ALookup><Value>A</Value></ALookup>");
        private readonly XElement _a2Identity = XElement.Parse("<AIdentity><Id>2</Id></AIdentity>");
        private readonly XElement _a2Lookup = XElement.Parse("<ALookup><Value>B</Value></ALookup>");
        private readonly XElement _bLookup = XElement.Parse("<BLookup><Value>B</Value></BLookup>");
        private readonly IHashProvider _hashProvider = new HashProvider();

        private readonly Func<IHashProvider, XElement, string> _x2Hs = (h, x) => h.BytesToStr(h.Hash(x.ToString()));

        private IDictionary<string, XElement> HashIdentities
        {
            get
            {
                var result = new Dictionary<string, XElement>
                             {
                                 {
                                     _x2Hs(_hashProvider, _a1Lookup), _a1Identity
                                 },
                                 {
                                     _x2Hs(_hashProvider, _a2Lookup), _a2Identity
                                 }
                             };

                return result;
            }
        }

        private XElement RunProcessorOnInputElement(XElement source)
        {
            var processor = new XmlLookupToResourceProcessor(
                _hashProvider,
                HashIdentities);

            var reader = new XmlTextReader(new StringReader(source.ToString()));
            var sb = new StringBuilder();
            var writer = new XmlTextWriter(new StringWriter(sb));

            processor.CopyXmlLookupsToResources(reader, writer);

            var xmlResult = XElement.Parse(sb.ToString());
            return xmlResult;
        }

        [Test]
        public void Should_add_identity_for_successful_lookup()
        {
            var xmlSource = XElement.Parse("<AReference>" + _a1Lookup + "</AReference>");
            var xmlResult = RunProcessorOnInputElement(xmlSource);
            Console.WriteLine($"xmlSource:\r\n {xmlSource}\r\n\r\nxmlResult:\r\n {xmlResult}");
            Assert.IsNotNull(xmlResult.Element("AIdentity"));
        }

        [Test]
        public void Should_ignore_identity_for_no_lookup()
        {
            var xmlSource = XElement.Parse("<AReference>" + _a1Identity + "</AReference>");
            var xmlResult = RunProcessorOnInputElement(xmlSource);
            Console.WriteLine($"xmlSource:\r\n {xmlSource}\r\n\r\nxmlResult:\r\n {xmlResult}");
            Assert.IsFalse(xmlResult.Nodes().Any(x => x.NodeType == XmlNodeType.Comment));
        }

        [Test]
        public void Should_prefer_provided_identity_information_over_lookup()
        {
            var xmlSource = XElement.Parse("<AReference>" + _a1Identity + _a1Lookup + "</AReference>");
            var xmlResult = RunProcessorOnInputElement(xmlSource);
            Console.WriteLine($"xmlSource:\r\n {xmlSource}\r\n\r\nxmlResult:\r\n {xmlResult}");
            var identities = xmlResult.Descendants("AIdentity").ToArray();
            Assert.IsTrue(identities.All(x => x.PreviousNode == null));
        }

        [Test]
        public void Should_show_failure_comment_for_unsuccessful_lookup()
        {
            var xmlSource = XElement.Parse("<BReference>" + _bLookup + "</BReference>");
            var xmlResult = RunProcessorOnInputElement(xmlSource);
            Console.WriteLine($"xmlSource:\r\n {xmlSource}\r\n\r\nxmlResult:\r\n {xmlResult}");
            Assert.IsNull(xmlResult.Element("BIdentity"));
            Assert.IsTrue(xmlResult.Nodes().Any(x => x.NodeType == XmlNodeType.Comment));
            Assert.IsTrue(xmlResult.ToString().Contains("No BIdentity could be retrieved"));
        }

        [Test]
        public void Should_recurse_identity_lookups()
        {
            var xmlSource = XElement.Parse(
                "<Root><CReference><CIdentity>" +
                "<AReference>" + _a1Lookup + "</AReference>" +
                "<AReference>" + _a2Lookup + "</AReference>" +
                "<AReference>" + _a1Lookup + "</AReference>" +
                "</CIdentity></CReference></Root>");

            var xmlResult = RunProcessorOnInputElement(xmlSource);
            Console.WriteLine($"xmlSource:\r\n {xmlSource}\r\n\r\nxmlResult:\r\n {xmlResult}");
            var identities = xmlResult.Descendants("AIdentity").ToArray();
            Assert.AreEqual(3, identities.Length);
            Assert.IsTrue(identities.All(x => x.PreviousNode.NodeType == XmlNodeType.Comment));
        }
    }
}
