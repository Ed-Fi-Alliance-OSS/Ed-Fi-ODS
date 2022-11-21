// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Threading;
using EdFi.Ods.CodeGen.Generators;
using EdFi.Ods.CodeGen.Models;
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
    public class TemplateProcessorTests
    {
        public class When_processing_an_assembly_for_code_generation : TestFixtureBase
        {
            private ITemplateWriter _templateWriter;
            private ICodeRepositoryProvider _codeRepositoryProvider;
            private ITemplateSetProvider _templateSetProvider;
            private ITemplateContextProvider _templateContextProvider;
            private IGeneratorProvider _generatorProvider;
            private IGenerator _generator;
            private TemplateProcessor _templateProcessor;
            private AssemblyData _assemblyData;
            private TemplateSet _templateSet;
            private TemplateContext _templateContext;

            protected override void Arrange()
            {
                _assemblyData = new AssemblyData
                {
                    AssemblyName = "testAssembly",
                    Path = "testFolder",
                    TemplateSet = "standard"
                };

                _templateSet = new TemplateSet
                {
                                   Name = "Entities.mustache", Driver = "Entities",
                                   OutputPath = "Models/Entities/Entities.generated.cs"
                };

                var templates = new List<TemplateSet> {_templateSet};

                var model = new object();

                _templateContext = new TemplateContext();

                _templateWriter = Stub<ITemplateWriter>();
                _codeRepositoryProvider = Stub<ICodeRepositoryProvider>();
                _templateSetProvider = Stub<ITemplateSetProvider>();
                _templateContextProvider = Stub<ITemplateContextProvider>();
                _generator = Stub<IGenerator>();
                _generatorProvider = Stub<IGeneratorProvider>();

                A.CallTo(() => _codeRepositoryProvider.GetResolvedCodeRepositoryByName(A<string>._, A<string>._))
                    .Returns("testRepo/testFolder");

                A.CallTo(() => _templateSetProvider.GetTemplatesByName(A<string>._))
                    .Returns(templates);

                A.CallTo(() => _templateContextProvider.Create(A<AssemblyData>._))
                    .Returns(_templateContext);

                A.CallTo(() => _generator.Generate(A<TemplateContext>._))
                    .Returns(model);

                A.CallTo(() => _generatorProvider.GetGeneratorByDriverName(A<string>._))
                    .Returns(_generator);

                _templateProcessor = new TemplateProcessor(
                    _generatorProvider,
                    _templateWriter,
                    _templateSetProvider,
                    _templateContextProvider);
            }

            protected override void Act()
                => _templateProcessor.ProcessAsync(_assemblyData, CancellationToken.None)
                    .RunSynchronously();

            public override void RunOnceAfterAll() { }

            [Test]
            public void Should_call_create_template_model_with_template_context_once()
                => A.CallTo(() => _generator.Generate(_templateContext))
                    .MustHaveHappenedOnceExactly();

            [Test]
            public void Should_call_templateContext_create_once()
                => A.CallTo(() => _templateContextProvider.Create(_assemblyData))
                    .MustHaveHappenedOnceExactly();

            [Test]
            public void Should_call_templateModelProvider_get_template_model_once()
                => A.CallTo(() => _generatorProvider.GetGeneratorByDriverName(_templateSet.Driver))
                    .MustHaveHappenedOnceExactly();

            [Test]
            public void Should_call_templateWriter_WriteAsync_once()
                => A.CallTo(() => _templateWriter.WriteAsync(A<TemplateWriterData>.That.IsNotNull(), CancellationToken.None))
                    .MustHaveHappenedOnceExactly();
        }
    }
}
