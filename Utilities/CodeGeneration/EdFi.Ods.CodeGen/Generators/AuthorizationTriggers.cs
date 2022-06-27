// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Generator.Common.Database.TemplateModelProviders;

namespace EdFi.Ods.CodeGen.Generators;

public class AuthorizationTriggers : GeneratorBase
{
    private readonly DatabaseTemplateModelProvider _templateModelProvider;

    public AuthorizationTriggers(DatabaseTemplateModelProvider templateModelProvider)
    {
        _templateModelProvider = templateModelProvider;
    }
    protected override object Build()
    {
        return _templateModelProvider.GetTemplateModel(new Dictionary<string, string>());
    }
}
