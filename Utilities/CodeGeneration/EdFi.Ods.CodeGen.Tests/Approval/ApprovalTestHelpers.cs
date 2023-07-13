// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.CodeGen.Conventions;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.CodeGen.Providers.Impl;

namespace EdFi.Ods.CodeGen.Tests.Approval;

public static class ApprovalTestHelpers
{
    private static readonly ICodeRepositoryProvider _codeRepositoryProvider = new DeveloperCodeRepositoryProvider();
    
    private static readonly Lazy<string> _odsRepository = new(() => _codeRepositoryProvider.GetCodeRepositoryByName(CodeRepositoryConventions.Ods));

    private static readonly Lazy<string> _repositoryRoot = new(() => _codeRepositoryProvider.GetCodeRepositoryByName(CodeRepositoryConventions.Root));

    private static readonly Lazy<string> _extensionRepository = new(() => _codeRepositoryProvider.GetCodeRepositoryByName(CodeRepositoryConventions.ExtensionsRepositoryName));

    public static string OdsRepository => _odsRepository.Value;
    public static string RepositoryRoot => _repositoryRoot.Value;
    public static string ExtensionRepository => _extensionRepository.Value;
}
