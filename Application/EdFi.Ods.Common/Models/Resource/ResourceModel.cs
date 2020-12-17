// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Utils.Extensions;

namespace EdFi.Ods.Common.Models.Resource
{
    public interface IResourceModel
    {
        /// <summary>
        /// Gets a provider capable of mapping schema names between logical, physical, proper case name and URI segment representations.
        /// </summary>
        ISchemaNameMapProvider SchemaNameMapProvider { get; }

        /// <summary>
        /// Gets the Resource using the specified FullName.
        /// </summary>
        /// <param name="resourceFullName">The name of the resource to be retrieved.</param>
        /// <returns>The matching resource.</returns>
        Resource GetResourceByFullName(FullName resourceFullName);

        /// <summary>
        /// Get a read-only list of all the resources available in the model.
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<Resource> GetAllResources();

        /// <summary>
        /// Gets the Resource using the schema and collection name representation as used on the API.
        /// </summary>
        /// <param name="schemaUriSegment">The URI representation of the schema of the resource.</param>
        /// <param name="resourceCollectionName">The pluralized collection name of the resource.</param>
        /// <returns>The matching resource.</returns>
        Resource GetResourceByApiCollectionName(string schemaUriSegment, string resourceCollectionName);
    }

    /// <summary>
    /// Defines a method for enabling the assignment of an alternate resource model to satisfy resource requests on the current call.
    /// </summary>
    public interface IHasContextualResourceSelector
    {
        /// <summary>
        /// Sets the <see cref="IResourceSelector"/> implementation to use to satisfy requests for resources on the current call context.
        /// </summary>
        /// <param name="contextualResourceSelector">The <see cref="IResourceSelector"/> to be used to satisfy requests for resources from the model on the current call context.</param>
        /// <returns>The underlying <see cref="IResourceSelector"/>, enabling the caller to make direct calls to the underlying source as necessary.</returns>
        IResourceSelector SetContextualResourceSelector(IResourceSelector contextualResourceSelector);
    }

    public class ResourceModel : IResourceModel, IHasContextualResourceSelector
    {
        private const string ResourceSelectorKey = "ResourceModel.ResourcesSelector";
        private readonly DomainModel _domainModel;
        private readonly IDictionary<FullName, Resource> _resourceByName;

        public ResourceModel(DomainModel domainModel)
        {
            _domainModel = domainModel;
            _resourceByName = new Dictionary<FullName, Resource>();

            // Add all aggregate roots to the resource model
            domainModel
                .Entities
                .Where(a => a.IsAggregateRoot)
                .ForEach(AddResource);
            
            DefaultResourceSelector = new ResourceSelector(_resourceByName);
        }

        internal IResourceSelector DefaultResourceSelector { get; }

        private IResourceSelector ResourceSelector
        {
            get
            {
                return
                    (IResourceSelector) CallContext.GetData(ResourceSelectorKey)
                    ?? DefaultResourceSelector;
            }
        }

        /// <summary>
        /// Sets a resource selector for the current CallContext.
        /// </summary>
        /// <param name="resourceSelector">The resource selector to be used in the current CallContext.</param>
        IResourceSelector IHasContextualResourceSelector.SetContextualResourceSelector(IResourceSelector resourceSelector)
        {
            CallContext.SetData(ResourceSelectorKey, resourceSelector);

            return DefaultResourceSelector;
        }

        public Resource GetResourceByFullName(FullName fullName)
        {
            return ResourceSelector.GetByName(fullName);
        }

        public Resource GetResourceByApiCollectionName(string schemaUriSegment, string resourceCollectionName)
        {
            return ResourceSelector.GetByApiCollectionName(schemaUriSegment, resourceCollectionName);
        }

        public IReadOnlyList<Resource> GetAllResources()
        {
            return ResourceSelector.GetAll();
        }

        /// <summary>
        /// Gets a provider capable of mapping schema names between logical, physical, proper case name and URI segment representations.
        /// </summary>
        public ISchemaNameMapProvider SchemaNameMapProvider => _domainModel.SchemaNameMapProvider;

        private void AddResource(Entity entity)
        {
            var resource = new Resource(this, entity);
            _resourceByName.Add(entity.FullName, resource);
        }
    }
}
