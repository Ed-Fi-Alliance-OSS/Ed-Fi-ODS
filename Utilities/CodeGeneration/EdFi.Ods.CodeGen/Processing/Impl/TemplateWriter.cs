// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.CodeGen.Models.Application;
using EdFi.Ods.CodeGen.Providers;
using log4net;
using Stubble.Core;
using Stubble.Core.Builders;
using Stubble.Core.Settings;

namespace EdFi.Ods.CodeGen.Processing.Impl
{
    public class TemplateWriter : ITemplateWriter
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(TemplateProcessor));
        private readonly RenderSettings _renderSettings;
        private readonly Lazy<StubbleVisitorRenderer> _stubbleRender;
        private readonly Lazy<IDictionary<string, string>> _templatesByTemplateName;

        public TemplateWriter(IMustacheTemplateProvider mustacheTemplateProvider)
        {
            if (mustacheTemplateProvider == null)
            {
                throw new ArgumentNullException(nameof(mustacheTemplateProvider));
            }

            _templatesByTemplateName = new Lazy<IDictionary<string, string>>(mustacheTemplateProvider.GetMustacheTemplates);

            _stubbleRender = new Lazy<StubbleVisitorRenderer>(
                () => new StubbleBuilder()
                    .Configure(
                        settings =>
                        {
                            settings.SetMaxRecursionDepth(512);
                            settings.SetIgnoreCaseOnKeyLookup(true);
                        }
                    )
                    .Build());

            _renderSettings = new RenderSettings {SkipHtmlEncoding = true};
        }

        public async Task WriteAsync(TemplateWriterData codeGenTemplateWriterData, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (!_templatesByTemplateName.Value.TryGetValue(codeGenTemplateWriterData.TemplateSet.Name, out string template))
            {
                throw new Exception($"Template '{codeGenTemplateWriterData.TemplateSet.Name}' not found. Possible templates are: {Environment.NewLine}{string.Join(Environment.NewLine, _templatesByTemplateName.Value.Keys)}");
            }

            _logger.Debug($"Rendering {codeGenTemplateWriterData.TemplateSet.Name}.");

            string destinationFolder = Path.GetDirectoryName(codeGenTemplateWriterData.OutputPath);

            if (!Directory.Exists(destinationFolder))
            {
                _logger.Debug($"Creating destination folder {destinationFolder}.");
                Directory.CreateDirectory(destinationFolder);
            }

            string renderedTemplate = await _stubbleRender
                .Value
                .RenderAsync(template, codeGenTemplateWriterData.Model, _templatesByTemplateName.Value, _renderSettings)
                .ConfigureAwait(false);

            await using var streamWriter = new StreamWriter(codeGenTemplateWriterData.OutputPath);

            _logger.Debug($"Writing {codeGenTemplateWriterData.OutputPath}.");

            await streamWriter.WriteAsync(renderedTemplate)
                .ConfigureAwait(false);
        }
    }
}
