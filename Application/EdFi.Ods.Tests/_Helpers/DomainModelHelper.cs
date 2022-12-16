// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using Newtonsoft.Json;

namespace EdFi.Ods.Tests._Helpers;

public static class DomainModelHelper
{
    public static DomainModel LoadDomainModel(this object obj, string modelName)
    {
        string modelFileName = Path.ChangeExtension(modelName, "json");

        Type type = obj.GetType();
        
        var stream = type.Assembly.GetManifestResourceStream(type, $"TestModels.{modelFileName}");
        
        using var sr = new StreamReader(stream);
        string model = sr.ReadToEnd();

        var domainModelDefinitions = JsonConvert.DeserializeObject<DomainModelDefinitions>(model);

        var domainModel = new DomainModelBuilder(new []{ domainModelDefinitions }).Build();

        return domainModel;
    }

    public static IDomainModelProvider GetDomainModelProvider(this object obj, string modelName)
    {
        return new DomainModelProvider(LoadDomainModel(obj, modelName));
    }

    public static IResourceModelProvider GetResourceModelProvider(this object obj, string modelName)
    {
        return new ResourceModelProvider(GetDomainModelProvider(obj, modelName));
    }
    
    private class DomainModelProvider : IDomainModelProvider
    {
        private readonly DomainModel _domainModel;

        public DomainModelProvider(DomainModel domainModel)
        {
            _domainModel = domainModel;
        }
        
        public DomainModel GetDomainModel() => _domainModel;
    }
}
