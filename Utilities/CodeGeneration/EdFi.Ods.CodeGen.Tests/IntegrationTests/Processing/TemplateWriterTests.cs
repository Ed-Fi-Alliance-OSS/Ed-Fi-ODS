// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Castle.Windsor;
using EdFi.Ods.CodeGen.Models.Application;
using EdFi.Ods.CodeGen.Models.Configuration;
using EdFi.Ods.CodeGen.Processing;
using EdFi.Ods.CodeGen._Installers;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.CodeGen.Tests.IntegrationTests.Processing
{
    [TestFixture]
    public class TemplateWriterTests
    {
        public class When_writing_the_file_with_generated_code_using_passed_mustache_template : TestFixtureBase
        {
            private TemplateWriterData _templateWriterData;
            private WindsorContainer _container;
            private readonly string templateName = "Entities";
            private readonly string namespaceName = "testNamespace";

            protected override void Arrange()
            {
                _container = new WindsorContainer();
                _container.Install(new AppConfigInstaller(), new ProvidersInstaller(), new ProcessingInstaller());

                _templateWriterData = new TemplateWriterData
                                      {
                                          Model = new
                                                  {
                                                      SchemaProperCaseName = namespaceName, ClassName = "testClass", InterfaceName = "testInterfaceName"
                                                  },
                                          TemplateSet = new TemplateSet
                                                        {
                                                            Name = templateName
                                                        },
                                          OutputPath = $"{Environment.CurrentDirectory}\\Output.cs"
                                      };
            }

            protected override void Act() => _container.Resolve<ITemplateWriter>().WriteAsync(_templateWriterData, CancellationToken.None);

            public override void RunOnceAfterAll()
            {
                if (File.Exists(_templateWriterData.OutputPath))
                {
                    File.Delete(_templateWriterData.OutputPath);
                }

                base.RunOnceAfterAll();
            }

            [Test]
            public void Should_file_Created() => File.Exists(_templateWriterData.OutputPath).ShouldBeTrue();

            [Test]
            public void Should_file_has_content() => new FileInfo(_templateWriterData.OutputPath).Length.ShouldBeGreaterThan(0);

            [Test]
            public void Should_file_has_expected_content() => File.ReadAllText(_templateWriterData.OutputPath).Contains(namespaceName).ShouldBeTrue();
        }

        public class When_passing_non_existing_mustache_template
        {
            private readonly string namespaceName = "testNamespace";
            private readonly string templateName = "nonExistingTemplate";
            private WindsorContainer _container;
            private TemplateWriterData _templateWriterData;

            [Test]
            public void Should_throw_error()
            {
                // Arrange
                _container = new WindsorContainer();
                _container.Install(new AppConfigInstaller(), new ProvidersInstaller(), new ProcessingInstaller());

                _templateWriterData = new TemplateWriterData
                                      {
                                          Model = new
                                                  {
                                                      NamespaceName = namespaceName, ClassName = "testClass", InterfaceName = "testInterfaceName"
                                                  },
                                          TemplateSet = new TemplateSet
                                                        {
                                                            Name = templateName
                                                        },
                                          OutputPath = $"{Environment.CurrentDirectory}\\Output.cs"
                                      };

                // Act
                var exception = Assert.ThrowsAsync<KeyNotFoundException>(
                    async () => await _container.Resolve<ITemplateWriter>().WriteAsync(_templateWriterData, CancellationToken.None));

                // Assert
                exception.Message.ShouldMatch($"The given key '{templateName}' was not present in the dictionary.");
            }
        }
    }
}
