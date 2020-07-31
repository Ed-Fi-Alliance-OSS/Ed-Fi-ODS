// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.Engine.XmlLookupPipeline;
using NUnit.Framework;

namespace EdFi.LoadTools.Test
{
    [TestFixture]
    public class LookupPipelineTests
    {
        public IEnumerable<ILookupPipelineStep> Pipeline(IDictionary<string, XElement> hashIdentities)
        {
            var hashProvider = new HashProvider();
            hashIdentities = hashIdentities ?? new ConcurrentDictionary<string, XElement>();

            return new ILookupPipelineStep[]
                   {
                       new IdentifyResourceTypeStep(), new ComputeHashStep(hashProvider), new AvoidDuplicateLookupsStep(hashIdentities),

                       //new MapXmlLookupToGetByExampleJsonStep(),
                       //new PerformGetByExampleStep(),
                       //new MapResourceToIdentityStep(),
                       new StoreIdentityForWritingStep(hashIdentities)
                   };
        }

        [Test]
        public void Should_not_perform_lookup_multiple_times_for_the_same_value()
        {
            var xml = XElement.Parse(
                "<Container>" +
                "<AReference><ALookup><Value>A</Value></ALookup></AReference>" +
                "<BReference><BLookup>" +
                "<AReference><ALookup><Value>A</Value></ALookup></AReference>" +
                "</BLookup></BReference>" +
                "</Container>");

            var xwip = new XmlToWorkItemsProcessor();
            var items = xwip.GetLookupWorkItems(new XmlTextReader(new StringReader(xml.ToString()))).ToList();
            var hashIdentities = new Dictionary<string, XElement>();

            foreach (var xmlLookupWorkItem in items)
            {
                foreach (var lookupPipelineStep in Pipeline(hashIdentities))
                {
                    lookupPipelineStep.Process(xmlLookupWorkItem);
                }
            }

            foreach (var wi in items)
            {
                Console.WriteLine(wi.HashString);
                Console.WriteLine(wi.LookupXElement);
                Console.WriteLine(wi.IdentityXElement);
            }

            Assert.AreEqual(3, items.Count);
            Assert.AreEqual(2, hashIdentities.Count);
        }
    }
}
