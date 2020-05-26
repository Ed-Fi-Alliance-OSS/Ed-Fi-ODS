﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.Engine.InterchangePipeline;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EdFi.LoadTools.Test
{
    [TestClass]
    public class ResourceReferencePreloadStepTest
    {
        private TestXmlReferenceCache _cache;
        private FindReferencesStep _findStep;
        private PreloadReferencesStep _loadStep;

        private Stream GetStream()
        {
            const string crlf = "\r\n";

            const string xml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" + crlf +
                               "<Test>" + crlf +
                               "<A id='1' other='junk'>foobar</A>" + crlf +
                               "<B id='2'><F ref='1'/></B>" + crlf +
                               "<C ref='2'></C>" + crlf +
                               "<D id='3'>foobar<E ref='4'/></D>" + crlf +
                               "<G id='4'><H><I ref='5'/></H></G>" + crlf +
                               "</Test>";

            return new MemoryStream(Encoding.UTF8.GetBytes(xml));
        }

        [TestInitialize]
        public void Initialize()
        {
            _cache = new TestXmlReferenceCache();
            _findStep = new FindReferencesStep(_cache);
            _findStep.Process("sourceFileName", GetStream());
            _loadStep = new PreloadReferencesStep(_cache);
            _loadStep.Process("sourceFileName", GetStream());
        }

        [TestMethod]
        public void Should_find_all_ids()
        {
            Assert.AreEqual(4, _cache.PreloadReferenceSourceIds.Count);
        }

        [TestMethod]
        public void Should_find_all_references()
        {
            Assert.AreEqual(4, _cache.LoadReferenceIds.Count);
        }

        private class TestXmlReferenceCache : IXmlReferenceCache, IXmlReferenceCacheProvider
        {
            public readonly List<string> LoadReferenceIds = new List<string>();
            public readonly List<string> PreloadReferenceSourceIds = new List<string>();

            public void PreloadReferenceSource(string id, XElement sourceElement)
            {
                PreloadReferenceSourceIds.Add(id);
            }

            public void LoadReferenceSource(string id, XElement sourceElement)
            {
                throw new NotImplementedException();
            }

            public void LoadReference(string id)
            {
                LoadReferenceIds.Add(id);
            }

            public XElement VisitReference(string id)
            {
                throw new NotImplementedException();
            }

            public bool Exists(string id)
            {
                throw new NotImplementedException();
            }

            public int RemainingReferenceCount(string id)
            {
                throw new NotImplementedException();
            }

            public int NumberOfLoadedReferences { get; } = 0;

            public int NumberOfReferences { get; } = 0;

            public IXmlReferenceCache GetXmlReferenceCache(string fileName)
            {
                return this;
            }
        }
    }
}
