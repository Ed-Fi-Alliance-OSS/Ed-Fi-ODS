#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Linq;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Common.Security
{
    public class ApplicationSettingHashConfigurationProvider : IHashConfigurationProvider
    {
        private readonly HashConfiguration _hashConfiguration;

        public ApplicationSettingHashConfigurationProvider(IConfigValueProvider appConfigProvider, ISecureHasher[] secureHashers)
        {
            Func<string, string> getValue = appConfigProvider.GetValue;

            Func<string, int> getIntValue = key =>
                                            {
                                                var value = getValue(key);

                                                if (value == null)
                                                {
                                                    throw new Exception($"Configuration for value '{key}' has invalid value.");
                                                }

                                                int intValue;

                                                if (!int.TryParse(value, out intValue))
                                                {
                                                    throw new Exception($"Configuration for value '{key}' has invalid value of '{value}'.");
                                                }

                                                return intValue;
                                            };

            var algorithm = getValue("Password.Algorithm");

            if (!secureHashers.Any(x => x.Algorithm.Equals(algorithm)))
            {
                throw new Exception($"Hashing algorithm ({algorithm}) was not found in a configured secure hasher.");
            }

            _hashConfiguration = new HashConfiguration
                                 {
                                     Algorithm = algorithm, Iterations = getIntValue("Password.Iterations"),
                                     SaltSize = getIntValue("Password.SaltSize")
                                 };
        }

        public HashConfiguration GetHashConfiguration()
        {
            return _hashConfiguration;
        }
    }
}
#endif