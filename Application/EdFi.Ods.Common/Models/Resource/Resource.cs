// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Models.Resource
{
    // Resource (top-level) only
    public class Resource : ResourceClassBase
    {
        private readonly Lazy<IReadOnlyDictionary<string, LinkedCollection>> _linkedCollectionByName;
        private readonly Lazy<IReadOnlyList<LinkedCollection>> _linkedCollections;

        internal Resource(IResourceModel resourceModel, Entity entity)
            : base(resourceModel, entity)
        {
            _linkedCollections = LazyInitializeLinkedCollections(entity);
            _linkedCollectionByName = LazyInitializeLinkedCollectionByName();
        }

        internal Resource(IResourceModel resourceModel, Entity entity, FilterContext filterContext)
            : base(resourceModel, entity, filterContext)
        {
            _linkedCollections = LazyInitializeLinkedCollections(entity);
            _linkedCollectionByName = LazyInitializeLinkedCollectionByName();
        }

        internal Resource(Resource[] resources)
            : base(
                resources.Cast<ResourceClassBase>()
                         .ToArray())
        {
            var entity = resources.Select(r => r.Entity)
                                  .Distinct(ModelComparers.Entity)
                                  .Single();

            _linkedCollections = LazyInitializeLinkedCollections(entity);
            _linkedCollectionByName = LazyInitializeLinkedCollectionByName();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Resource" /> class using the specified name that is defined in a 
        /// Composite definition rather than requiring it to be derived from an <see cref="Entity" /> in the domain model.
        /// </summary>
        /// <param name="name">The name to be given to the resource.</param>
        /// <remarks>This constructor was introduced for use in building the root resource of a Composite resource providing the
        /// ability to change the name used on the API.</remarks>
        public Resource(string name)
            : base(name)
        {
            _linkedCollections = new Lazy<IReadOnlyList<LinkedCollection>>(() => new List<LinkedCollection>());

            _linkedCollectionByName = new Lazy<IReadOnlyDictionary<string, LinkedCollection>>(
                () =>
                    new Dictionary<string, LinkedCollection>());
        }

        public bool IsEdFiCore { get; set; }

        /// <summary>
        /// Gets the root <see cref="Resource" /> class for the current resource.
        /// </summary>
        public override Resource ResourceRoot => this;

        /// <summary>
        /// Indicates whether the resource class is part of an extension to an Ed-Fi standard resource (i.e. a "resource extension" as opposed to being part of a new "extension resource").
        /// </summary>
        public override bool IsResourceExtension => false;

        /// <summary>
        /// Indicates whether the resource class is the "Extension" class artifact for a resource extension, containing all the 
        /// extension <see cref="ResourceProperty" />, <see cref="Reference" />, <see cref="Collection" />, and <see cref="EmbeddedObject" /> instances.
        /// </summary>
        public override bool IsResourceExtensionClass => false;

        // External one-to-many
        public IReadOnlyList<LinkedCollection> LinkedCollections => _linkedCollections.Value;

        public IReadOnlyDictionary<string, LinkedCollection> LinkedResourceCollectionByName => _linkedCollectionByName.Value;

        /// <summary>
        /// Returns all the child item types contained within resource.
        /// </summary>
        public IReadOnlyList<ResourceChildItem> AllContainedItemTypes => ContainedItemTypes;

        /// <summary>
        /// Returns the resource and all the child item types contained within resource.
        /// </summary>
        public IReadOnlyList<ResourceClassBase> AllContainedItemTypesOrSelf => new ResourceClassBase[]
                                                                               {
                                                                                   this
                                                                               }.Concat(ContainedItemTypes)
                                                                                .ToArray();

        /// <summary>
        /// Returns all the references contained within the resource.
        /// </summary>
        public IReadOnlyList<Reference> AllContainedReferences => ContainedReferences;

        private Lazy<IReadOnlyDictionary<string, LinkedCollection>> LazyInitializeLinkedCollectionByName()
        {
            return new Lazy<IReadOnlyDictionary<string, LinkedCollection>>(
                () =>
                    LinkedCollections.ToDictionary(x => x.Name, x => x, StringComparer.InvariantCultureIgnoreCase));
        }

        private Lazy<IReadOnlyList<LinkedCollection>> LazyInitializeLinkedCollections(Entity entity)
        {
            return new Lazy<IReadOnlyList<LinkedCollection>>(
                () =>
                    entity
                       .NonNavigableChildren
                       .Where(a => a.OtherEntity.IsAggregateRoot)
                       .Select(a => new LinkedCollection(this, a))
                       .ToList());
        }

        protected override IEnumerable<ResourceMemberBase> LazyInitializeAllMembers()
        {
            return base.LazyInitializeAllMembers()
                       .Concat(LinkedCollections);
        }

        public override string JsonPath
        {
            get => "$";
        }
    }
}
