// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.CodeGen.Models.Application;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.Common;
using log4net;

namespace EdFi.Ods.CodeGen.Processing.Impl
{
    public class TemplateProcessor : ITemplateProcessor
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(TemplateProcessor));
        private readonly IGeneratorProvider _generatorProvider;
        private readonly ITemplateContextProvider _templateContextProvider;
        private readonly ITemplateSetProvider _templateSetProvider;
        private readonly ITemplateWriter _templateWriter;

        public TemplateProcessor(
            IGeneratorProvider generatorProvider,
            ITemplateWriter templateWriter,
            ITemplateSetProvider templateSetProvider,
            ITemplateContextProvider templateContextProvider)
        {
            _templateWriter = Preconditions.ThrowIfNull(templateWriter, nameof(templateWriter));
            _templateSetProvider = Preconditions.ThrowIfNull(templateSetProvider, nameof(templateSetProvider));
            _templateContextProvider = Preconditions.ThrowIfNull(templateContextProvider, nameof(templateContextProvider));
            _generatorProvider = Preconditions.ThrowIfNull(generatorProvider, nameof(generatorProvider));
        }

        public async Task ProcessAsync(AssemblyData assemblyData, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            _logger.Info($"Processing started for assembly: {assemblyData.AssemblyName} in folder: {assemblyData.Path}");

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var templateContext = _templateContextProvider.Create(assemblyData);

            foreach (var templateSet in _templateSetProvider.GetTemplatesByName(assemblyData.TemplateSet))
            {
                templateContext.With(templateSet);

                _logger.Debug($"Generating code for template {templateSet.Name}");

                var generator = _generatorProvider.GetGeneratorByDriverName(templateSet.Driver);

                if (generator != null)
                {
                    var templateStopwatch = new Stopwatch();
                    templateStopwatch.Start();

                    var model = generator.Generate(templateContext);

                    _logger.Debug($"Generating template data for template {templateSet.Name}");

                    string outputPath = Path.Combine(assemblyData.Path, templateSet.OutputPath);

                    var codeGenWriterData = new TemplateWriterData
                    {
                        TemplateSet = templateSet,
                        Model = model,
                        OutputPath = outputPath
                    };

                    _logger.Debug($"Writing template data for path {outputPath}");

                    await _templateWriter.WriteAsync(codeGenWriterData, cancellationToken)
                        .ConfigureAwait(false);

                    templateStopwatch.Stop();

                    _logger.Debug(
                        $"Code generation for template {templateSet.Name} completed in {templateStopwatch.Elapsed.ToString()}.");
                }
                else
                {
                    _logger.Debug($"TemplateSet model not found for {templateSet.Name}, skipping.");
                }
            }

            stopWatch.Stop();

            _logger.Info($"Processing complete for assembly: {assemblyData.AssemblyName} in {stopWatch.Elapsed.ToString()}.");
        }
    }
}
