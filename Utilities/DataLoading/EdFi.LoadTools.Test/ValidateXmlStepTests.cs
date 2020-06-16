// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Linq;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.Engine.InterchangePipeline;
using log4net.Config;
using NUnit.Framework;
[assembly: XmlConfigurator(Watch = true)]
namespace EdFi.LoadTools.Test
{
   [TestFixture]
    public class ValidateXmlStepTests : IXsdConfiguration
    {
        private TestAppender _testAppender;

        string IXsdConfiguration.Folder => string.Empty;

        bool IXsdConfiguration.DoNotValidateXml => true;

        [SetUp]
        public void Setup()
        {            
            _testAppender = new TestAppender();
            _testAppender.AttachToRoot();        
        }

        [TearDown]
        public void Teardown()
        {
            _testAppender.DetachFromRoot();
        }

        [Test]
        public void Should_skip_processing_when_DoNotValidateXml_is_set()
        {
            var step = new ValidateXmlStep(null, this);
            step.Process(null, null);

            var log = _testAppender.Logs.SingleOrDefault(x => x.Level.Name == "WARN" && x.LoggerName == nameof(ValidateXmlStep).ToString());
            Assert.IsNotNull(log);
            Assert.IsTrue(log.RenderedMessage.Contains("XML validation step skipped"));
        }
    }
}
