// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.CodeGen.Processing;
using EdFi.Ods.CodeGen.Providers;
using log4net;

namespace EdFi.Ods.CodeGen
{
    public class ApplicationRunner : IApplicationRunner
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(ApplicationRunner));
        private readonly IEnumerable<IAssemblyDataProvider> _assemblyDataProviders;
        private readonly ITemplateProcessor _templateProcessor;

        public ApplicationRunner(ITemplateProcessor templateProcessor, IEnumerable<IAssemblyDataProvider> assemblyDataProviders)
        {
            _templateProcessor = templateProcessor ?? throw new ArgumentNullException(nameof(templateProcessor));
            _assemblyDataProviders = assemblyDataProviders ?? throw new ArgumentNullException(nameof(assemblyDataProviders));
        }

        public async Task RunAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken == null)
            {
                throw new ArgumentNullException(nameof(cancellationToken));
            }

            _logger.Debug("Processing beginning.");

            foreach (var assemblyData in _assemblyDataProviders.SelectMany(x => x.Get()))
            {
                await _templateProcessor.ProcessAsync(assemblyData, cancellationToken)
                    .ConfigureAwait(false);
            }

            _logger.Debug($"Processing complete.");
        }
    }
}
