// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.Engine.ResourcePipeline;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Repository.Hierarchy;
using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace EdFi.LoadTools.Test
{
    public class XmlReferenceCacheTests
    {
        private const string Id1 = "1";
        private const string ElementA = "A";

        private static IEnumerable<XmlModelMetadata> CreateEmptyMetadata()
        {
            return Enumerable.Empty<XmlModelMetadata>();
        }

        private static XElement CreateElement(string elementType, string id)
        {
            return new XElement(
                elementType,
                new XAttribute("id", id)
            );
        }

        [TestFixture]
        public class When_id_but_no_references
        {
            private XmlReferenceCache _cache;

            [SetUp]
            public void Setup()
            {
                _cache = new XmlReferenceCache(CreateEmptyMetadata());
                _cache.PreloadReferenceSource(Id1, CreateElement(ElementA, Id1));
            }

            [Test]
            public void Should_not_have_reference_element()
            {
                Assert.IsTrue(_cache.Exists(Id1));
                Assert.IsNull(_cache.VisitReference(Id1));
            }
        }

        [TestFixture]
        public class When_id_with_reference_second
        {
            private XmlReferenceCache _cache;

            [SetUp]
            public void Setup()
            {
                _cache = new XmlReferenceCache(CreateEmptyMetadata());
                _cache.PreloadReferenceSource(Id1, CreateElement(ElementA, Id1));
                _cache.LoadReference(Id1);
            }

            [Test]
            public void Should_not_have_reference_element()
            {
                Assert.IsTrue(_cache.Exists(Id1));
                Assert.AreEqual(_cache.RemainingReferenceCount(Id1), 1);
                Assert.IsNull(_cache.VisitReference(Id1));
            }
        }

        [TestFixture]
        public class When_id_with_reference_first
        {
            private XmlReferenceCache _cache;

            [SetUp]
            public void Setup()
            {
                _cache = new XmlReferenceCache(CreateEmptyMetadata());
                _cache.LoadReference(Id1);
                _cache.PreloadReferenceSource(Id1, CreateElement(ElementA, Id1));
            }

            [Test]
            public void Should_have_reference_element()
            {
                Assert.IsTrue(_cache.Exists(Id1));
                Assert.AreEqual(_cache.RemainingReferenceCount(Id1), 1);
                Assert.IsNotNull(_cache.VisitReference(Id1));
            }
        }

        [TestFixture]
        public class When_loading_reference_for_non_preloaded_reference
        {
            private XmlReferenceCache _cache;

            [SetUp]
            public void Setup()
            {
                _cache = new XmlReferenceCache(CreateEmptyMetadata());
                var element = CreateElement(ElementA, Id1);
                _cache.PreloadReferenceSource(Id1, element);
                _cache.LoadReference(Id1);
                _cache.LoadReferenceSource(Id1, element);
            }

            [Test]
            public void Should_have_reference_element()
            {
                Assert.IsTrue(_cache.Exists(Id1));
                Assert.AreEqual(_cache.RemainingReferenceCount(Id1), 1);
                Assert.IsNotNull(_cache.VisitReference(Id1));
                Assert.AreEqual(_cache.RemainingReferenceCount(Id1), 0);
                Assert.IsNull(_cache.VisitReference(Id1));
            }
        }

        [TestFixture]
        public class When_loading_reference_for_preloaded_reference
        {
            private XmlReferenceCache _cache;

            [SetUp]
            public void Setup()
            {
                _cache = new XmlReferenceCache(CreateEmptyMetadata());
                var element = CreateElement(ElementA, Id1);
                _cache.LoadReference(Id1);
                _cache.PreloadReferenceSource(Id1, element);
                _cache.LoadReferenceSource(Id1, element);
            }

            [Test]
            public void Should_have_reference_element()
            {
                Assert.IsTrue(_cache.Exists(Id1));
                Assert.AreEqual(_cache.RemainingReferenceCount(Id1), 1);
                Assert.IsNotNull(_cache.VisitReference(Id1));
                Assert.AreEqual(_cache.RemainingReferenceCount(Id1), 0);
                Assert.IsNull(_cache.VisitReference(Id1));
            }
        }

        [TestFixture]
        public class When_resolving_references : IAppender
        {
            private TestCacheProvider _cacheProvider;
            private List<LoggingEvent> _logs;
            private XmlModelMetadata _metadata;
            private ApiLoaderWorkItem _resourceWorkItem;
            private ResolveReferenceStep _step;

            void IAppender.DoAppend(LoggingEvent loggingEvent)
            {
                _logs.Add(loggingEvent);
            }

            void IAppender.Close() { }

            string IAppender.Name { get; set; }

            [SetUp]
            public void Setup()
            {
                ((Hierarchy) LogManager.GetRepository()).Root.AddAppender(this);
                _logs = new List<LoggingEvent>();

                _cacheProvider = new TestCacheProvider(new XmlReferenceCache(CreateEmptyMetadata()));

                _metadata = new XmlModelMetadata
                            {
                                Model = "A", Property = "B", Type = "string"
                            };

                var element = XElement.Parse("<A><ResourceReference ref='1'/></A>");

                _step = new ResolveReferenceStep(
                    _cacheProvider, new[]
                                    {
                                        _metadata
                                    });

                _resourceWorkItem = new ApiLoaderWorkItem("filename", 1, element, 1);
            }

            [TearDown]
            public void Teardown()
            {
                ((Hierarchy) LogManager.GetRepository()).Root.RemoveAppender(this);
            }

            [Test]
            public void Should_not_throw_exception_on_unresolved_references()
            {
                _step.Process(_resourceWorkItem);
                var log = _logs.SingleOrDefault(x => x.Level.Name == "ERROR" && x.LoggerName == _step.GetType().Name);
                Assert.IsNotNull(log);
                Assert.IsTrue(log.RenderedMessage.Contains("'1'"));
            }

            private class TestCacheProvider : IXmlReferenceCacheProvider
            {
                private readonly XmlReferenceCache _cache;

                public TestCacheProvider(XmlReferenceCache cache)
                {
                    _cache = cache;
                }

                public IXmlReferenceCache GetXmlReferenceCache(string fileName)
                {
                    return _cache;
                }
            }
        }
    }
}
