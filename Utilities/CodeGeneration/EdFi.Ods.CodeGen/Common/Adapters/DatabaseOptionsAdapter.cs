// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common.Extensions;
using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.Generator.Common.Options;

namespace EdFi.Ods.CodeGen.Common.Adapters;

public class DatabaseOptionsAdapter : IDatabaseOptions
{
    private TemplateContext _templateContext;

    public void SetTemplateContext(TemplateContext templateContext)
    {
        _templateContext = templateContext;
    }
    
    public string DatabaseEngine
    {
        get => _templateContext.TemplateSet.DatabaseEngine.Value.ToMixedCase();
        set => throw new System.NotImplementedException();
    }

    public string Schema
    {
        get => _templateContext.SchemaPhysicalName;
        set => throw new System.NotImplementedException();
    }
}
