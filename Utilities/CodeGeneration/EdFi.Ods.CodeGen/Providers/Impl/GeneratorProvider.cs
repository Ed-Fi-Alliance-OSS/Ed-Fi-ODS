// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.CodeGen.Generators;
using EdFi.Ods.Common;
using log4net;

namespace EdFi.Ods.CodeGen.Providers.Impl
{
    public class GeneratorProvider : IGeneratorProvider
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(GeneratorProvider));
        private readonly Lazy<IDictionary<string, IGenerator>> _templateModelByName;

        public GeneratorProvider(IEnumerable<IGenerator> generators)
        {
            Preconditions.ThrowIfNull(generators, nameof(generators));

            _templateModelByName = new Lazy<IDictionary<string, IGenerator>>(
                () =>
                {
                    _logger.Debug("Creating lookup dictionary for templates models.");

                    return generators.ToDictionary(
                        k => k.GetType()
                            .Name,
                        v => v,
                        StringComparer.InvariantCultureIgnoreCase);
                });
        }

        public IGenerator GetGeneratorByDriverName(string driverName)
        {
            Preconditions.ThrowIfNull(driverName, nameof(driverName));
            Preconditions.ThrowIfWhitespace(driverName, nameof(driverName));

            _logger.Debug($"Resolving IGenerator for {driverName}");

            if (_templateModelByName.Value.TryGetValue(driverName, out IGenerator generator))
            {
                return generator;
            }

            _logger.Warn($"Unable to find a generator for {driverName}.");
            return null;
        }
    }
}
