// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.CodeGen.Common.Adapters;
using EdFi.Ods.Generator.Common.Database.TemplateModelProviders;
using EdFi.Ods.Generator.Common.Options;

namespace EdFi.Ods.CodeGen.Generators;

public class AuthorizationTriggers : GeneratorBase
{
    private readonly DatabaseOptionsAdapter _databaseOptionsAdapter;
    private readonly Func<DatabaseTemplateModelProvider> _templateModelProviderFactory;

    public AuthorizationTriggers(
        DatabaseOptionsAdapter databaseOptionsAdapter,
        Func<DatabaseTemplateModelProvider> templateModelProviderFactory)
    {
        _databaseOptionsAdapter = databaseOptionsAdapter;
        _templateModelProviderFactory = templateModelProviderFactory;
    }
    
    protected override object Build()
    {
        _databaseOptionsAdapter.SetTemplateContext(TemplateContext);
        return _templateModelProviderFactory().GetTemplateModel(new Dictionary<string, string>());
    }
}
