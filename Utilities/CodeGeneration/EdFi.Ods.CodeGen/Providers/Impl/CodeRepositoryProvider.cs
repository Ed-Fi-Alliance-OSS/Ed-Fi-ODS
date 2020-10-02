// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using EdFi.Common.Extensions;
using EdFi.Ods.CodeGen.Helpers;
using EdFi.Ods.Common.Extensions;
using log4net;

namespace EdFi.Ods.CodeGen.Providers.Impl
{
    public class CodeRepositoryProvider : ICodeRepositoryProvider
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(CodeRepositoryProvider));
        private readonly Lazy<CodeRepositoryHelper> _codeRepositoryHelper;

        public CodeRepositoryProvider(string codeRepositoryPath)
        {
            if (codeRepositoryPath == null)
            {
                throw new ArgumentNullException(nameof(codeRepositoryPath));
            }

            if (codeRepositoryPath.Equals(string.Empty))
            {
                throw new ArgumentException("code repository path cannot be empty", nameof(codeRepositoryPath));
            }

            _codeRepositoryHelper = new Lazy<CodeRepositoryHelper>(() => new CodeRepositoryHelper(codeRepositoryPath));
        }

        public string GetCodeRepositoryByName(string key) => _codeRepositoryHelper.Value[key];

        public string GetResolvedCodeRepositoryByName(string key, string folderName)
        {
            _logger.Debug($"Resolving path location for key {key}.");

            if (key.EqualsIgnoreCase("root"))
            {
                return _codeRepositoryHelper.Value[key];
            }

            return Path.Combine(_codeRepositoryHelper.Value["root"], _codeRepositoryHelper.Value[key], folderName);
        }
    }
}
