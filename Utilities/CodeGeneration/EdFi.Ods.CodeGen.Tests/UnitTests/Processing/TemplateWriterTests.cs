// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Threading;
using EdFi.Ods.CodeGen.Models.Application;
using EdFi.Ods.CodeGen.Models.Configuration;
using EdFi.Ods.CodeGen.Processing;
using EdFi.Ods.CodeGen.Processing.Impl;
using EdFi.Ods.CodeGen.Providers;
using FakeItEasy;
using NUnit.Framework;

namespace EdFi.Ods.CodeGen.Tests.UnitTests.Processing
{
    [TestFixture]
    public class TemplateWriterTests
    {
        public class When_getting_the_assemblies_from_the_assembly_json_file : TestFixtureBase
        {
            private IMustacheTemplateProvider _mustacheTemplateProvider;
            private TemplateWriterData _templateWriterData;
            private ITemplateWriter _templateWriter;
            private readonly string templateName = "template";

            protected override void Arrange()
            {
                var expectedTemplateString = @"using EdFi.Ods.Xml.XmlMetadata;";

                var templatesByTemplateName = new Dictionary<string, string>
                {
                    {templateName, expectedTemplateString},
                    {"template2", "template2 string"}
                };

                _templateWriterData = new TemplateWriterData
                {
                    Model = new
                    {
                        NamespaceName = "testNamespace",
                        ClassName = "testClass",
                        InterfaceName = "testInterfaceName"
                    },
                    TemplateSet = new TemplateSet {Name = templateName}
                };

                _mustacheTemplateProvider = Stub<IMustacheTemplateProvider>();

                A.CallTo(() => _mustacheTemplateProvider.GetMustacheTemplates())
                    .Returns(templatesByTemplateName);

                _templateWriter = new TemplateWriter(_mustacheTemplateProvider);
            }

            protected override void Act()
            {
                // simulate writing the data twice
                _templateWriter.WriteAsync(_templateWriterData, CancellationToken.None)
                    .RunSynchronously();

                _templateWriter.WriteAsync(_templateWriterData, CancellationToken.None)
                    .RunSynchronously();
            }

            public override void RunOnceAfterAll() { }

            [Test]
            public void Should_call_GetMustacheTemplates_once()
                => A.CallTo(() => _mustacheTemplateProvider.GetMustacheTemplates())
                    .MustHaveHappenedOnceExactly();
        }
    }
}
