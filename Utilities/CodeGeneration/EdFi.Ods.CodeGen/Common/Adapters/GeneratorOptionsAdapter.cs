// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Generator.Common.Options;

namespace EdFi.Ods.CodeGen.Common.Adapters;

public class GeneratorOptionsAdapter : IGeneratorOptions
{
    private readonly Dictionary<string, string> _propertyByName = new();
    
    public IDictionary<string, string> PropertyByName
    {
        get => _propertyByName;
    }
    
    #region Properties unused by CodeGeneration utility
    public string OutputPath
    {
        get => throw new System.NotImplementedException();
        set => throw new System.NotImplementedException();
    }

    public IEnumerable<string> Properties
    {
        get => throw new System.NotImplementedException();
        set => throw new System.NotImplementedException();
    }

    public IEnumerable<string> Plugins
    {
        get => throw new System.NotImplementedException();
        set => throw new System.NotImplementedException();
    }

    public string TemplatePath
    {
        get => throw new System.NotImplementedException();
        set => throw new System.NotImplementedException();
    }

    public string LogLevel
    {
        get => throw new System.NotImplementedException();
        set => throw new System.NotImplementedException();
    }
    #endregion
}
