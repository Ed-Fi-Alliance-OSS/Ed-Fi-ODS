// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Autofac;
using EdFi.Ods.CodeGen.Models.Application;
using EdFi.Ods.CodeGen.Models.Configuration;
using EdFi.Ods.CodeGen.Processing;
using EdFi.Ods.CodeGen.Tests.IntegrationTests._Helpers;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.CodeGen.Tests.IntegrationTests.Processing
{
    [TestFixture]
    public class TemplateWriterTests
    {
        public class When_passing_non_existing_mustache_template
        {
            private readonly string namespaceName = "testNamespace";
            private readonly string templateName = "nonExistingTemplate";
            private IContainer _container;
            private TemplateWriterData _templateWriterData;

            [Test]
            public void Should_throw_error()
            {
                _container = ContainerHelper.CreateContainer(new Options());

                // Arrange
                _templateWriterData = new TemplateWriterData
                {
                    Model = new
                    {
                        NamespaceName = namespaceName,
                        ClassName = "testClass",
                        InterfaceName = "testInterfaceName"
                    },
                    TemplateSet = new TemplateSet {Name = templateName},
                    OutputPath = $"{Environment.CurrentDirectory}/Output.cs"
                };

                // Act
                var exception = Assert.ThrowsAsync<KeyNotFoundException>(
                    async () => await _container.Resolve<ITemplateWriter>()
                        .WriteAsync(_templateWriterData, CancellationToken.None));

                // Assert
                exception.Message.ShouldMatch($"The given key '{templateName}' was not present in the dictionary.");
            }

            [TearDown]
            public void TearDown() => _container?.Dispose();
        }
    }
}
