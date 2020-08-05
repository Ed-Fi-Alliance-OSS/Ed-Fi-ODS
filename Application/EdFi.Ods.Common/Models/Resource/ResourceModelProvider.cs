// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Models.Resource
{
    /// <summary>
    /// Gets the Resource model representation for the API.
    /// </summary>
    public class ResourceModelProvider : IResourceModelProvider
    {
        private readonly Lazy<ResourceModel> _resourceModel;

        public ResourceModelProvider(IDomainModelProvider domainModelProvider)
        {
            var domainModel = new Lazy<DomainModel>(domainModelProvider.GetDomainModel);
            _resourceModel = new Lazy<ResourceModel>(() => new ResourceModel(domainModel.Value));
        }

        public ResourceModel GetResourceModel()
        {
            return _resourceModel.Value;
        }
    }
}
