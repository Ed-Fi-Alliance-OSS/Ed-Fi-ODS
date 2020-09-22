// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Common.Inflection;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Models.Resource
{
    public abstract class ResourceClassBase
    {
        private readonly Lazy<IReadOnlyList<Collection>> _collections;

        private readonly Lazy<IReadOnlyList<ResourceChildItem>> _containedItemTypes;

        private readonly Lazy<IReadOnlyList<Reference>> _containedReferences;

        private readonly Lazy<IReadOnlyList<EmbeddedObject>> _embeddedObjects;

        // New members to support resource extensions
        private readonly Lazy<IReadOnlyList<Extension>> _extensions;

        private readonly Lazy<IReadOnlyList<ResourceProperty>> _properties;

        private readonly Lazy<IReadOnlyList<Reference>> _references;

        private Lazy<IReadOnlyList<ResourceMemberBase>> _allMembers;

        private Lazy<IReadOnlyList<ResourceProperty>> _allProperties;
        private Lazy<IReadOnlyList<ResourceProperty>> _allIdentifyingProperties;

        private Lazy<IReadOnlyDictionary<string, ResourceProperty>> _allPropertyByName;
        private Lazy<IReadOnlyDictionary<string, Collection>> _collectionByName;
        private Lazy<IReadOnlyDictionary<string, EmbeddedObject>> _embeddedObjectByName;
        private Lazy<IReadOnlyDictionary<string, Extension>> _extensionByName;

        private Lazy<IReadOnlyDictionary<string, ResourceMemberBase>> _memberByName;

        private Lazy<IReadOnlyList<string>> _memberNamesInvolvedInJsonCollisions;

        private string _pluralName;

        private Lazy<IReadOnlyDictionary<string, ResourceProperty>> _propertyByName;
        private Lazy<IReadOnlyDictionary<string, Reference>> _referenceByName;

        protected internal ResourceClassBase(IResourceModel resourceModel, Entity entity)
            : this(resourceModel, entity, null) { }

        protected internal ResourceClassBase(IResourceModel resourceModel, Entity entity, FilterContext filterContext)
            : this(
                resourceModel,
                entity,
                filterContext,

                // Include all collections and embedded objects (but don't include extensions [from another schema] here)
                () => GetCollectionAssociations(entity),
                () => GetEmbeddedObjectAssociations(entity)) { }

        protected internal ResourceClassBase(
            IResourceModel resourceModel,
            Entity entity,
            FilterContext filterContext,
            Func<IEnumerable<AssociationView>> collectionAssociations,
            Func<IEnumerable<AssociationView>> embbededObjectAssociations)
        {
            Entity = entity;
            FullName = new FullName(entity.Schema, entity.Name);
            Description = entity.Description;
            IsDerived = entity.IsDerived;
            IsDeprecated = entity.IsDeprecated;
            DeprecationReasons = entity.DeprecationReasons;

            FilterContext = filterContext ?? FilterContext.NullFilterContext;

            // Initialize lists
            _properties = LazyInitializeProperties(Entity);
            _embeddedObjects = LazyInitializeEmbeddedObjects(embbededObjectAssociations);
            _collections = LazyInitializeCollections(collectionAssociations);
            _references = LazyInitializeReferences(Entity);
            _containedItemTypes = LazyInitializeContainedTypes();
            _containedReferences = LazyInitializeContainedReferences();
            _extensions = LazyInitializeExtensions(Entity);

            LazyInitializeDerivedCollections();

            ResourceModel = resourceModel;
        }

        /// <summary>
        /// Creates a combined resource by distinctly merging multiple supplied resources.
        /// </summary>
        protected ResourceClassBase(ResourceClassBase[] resources)
        {
            ValidateCompositeResourceArguments(resources);

            Entity = resources.Select(r => r.Entity)
                              .First();

            FullName = new FullName(Entity.Schema, Entity.Name);
            Description = Entity.Description;
            IsDerived = Entity.IsDerived;

            FilterContext = FilterContext.NullFilterContext;

            _properties = new Lazy<IReadOnlyList<ResourceProperty>>(
                () =>
                    resources.SelectMany(r => r.Properties)
                             .Distinct(ModelComparers.ResourceProperty)
                             .ToList());

            _embeddedObjects = new Lazy<IReadOnlyList<EmbeddedObject>>(
                () =>
                    resources.SelectMany(r => r.EmbeddedObjects)
                             .Distinct(ModelComparers.EmbeddedObject)
                             .ToList());

            _extensions = LazyInitializeExtensions(Entity);

            _collections = new Lazy<IReadOnlyList<Collection>>(
                () =>
                    resources
                       .SelectMany(r => r.Collections)
                       .GroupBy(c => c.PropertyName, c => c)
                       .Select(g => new Collection(g.ToArray()))
                       .ToList());

            _references = new Lazy<IReadOnlyList<Reference>>(
                () =>
                    resources.SelectMany(r => r.References)
                             .Distinct(ModelComparers.Reference)
                             .ToList());

            LazyInitializeDerivedCollections();

            // Resource model assignment must happen after all lazy initialization
            ResourceModel = resources.Select(r => r.ResourceModel)
                                     .Distinct()
                                     .Single();
        }

        protected internal ResourceClassBase(string name)
        {
            FullName = new FullName(null, name);

            FilterContext = FilterContext.NullFilterContext;

            _properties = new Lazy<IReadOnlyList<ResourceProperty>>(() => new List<ResourceProperty>());
            _embeddedObjects = new Lazy<IReadOnlyList<EmbeddedObject>>(() => new List<EmbeddedObject>());
            _collections = new Lazy<IReadOnlyList<Collection>>(() => new List<Collection>());
            _references = new Lazy<IReadOnlyList<Reference>>(() => new List<Reference>());

            _containedItemTypes = LazyInitializeContainedTypes();
            _containedReferences = LazyInitializeContainedReferences();
            _extensions = new Lazy<IReadOnlyList<Extension>>(() => new List<Extension>());

            LazyInitializeDerivedCollections();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceClassBase" /> class as an implicit extension class,
        /// using the specified functions for providing the associations for collections and embedded objects.
        /// </summary>
        /// <param name="resourceModel"></param>
        /// <param name="fullName"></param>
        /// <param name="collectionAssociations"></param>
        /// <param name="embeddedObjectAssociations"></param>
        /// <param name="filterContext"></param>
        protected internal ResourceClassBase(
            IResourceModel resourceModel,
            FullName fullName,
            Func<IEnumerable<AssociationView>> collectionAssociations,
            Func<IEnumerable<AssociationView>> embeddedObjectAssociations,
            FilterContext filterContext)
        {
            if (resourceModel == null)
            {
                throw new ArgumentNullException(nameof(resourceModel));
            }

            ResourceModel = resourceModel;

            FullName = fullName;

            FilterContext = filterContext ?? FilterContext.NullFilterContext;

            _properties = new Lazy<IReadOnlyList<ResourceProperty>>(() => new List<ResourceProperty>());
            _embeddedObjects = LazyInitializeEmbeddedObjects(embeddedObjectAssociations);
            _collections = LazyInitializeCollections(collectionAssociations);
            _references = new Lazy<IReadOnlyList<Reference>>(() => new List<Reference>());

            _containedItemTypes = LazyInitializeContainedTypes();
            _containedReferences = LazyInitializeContainedReferences();
            _extensions = new Lazy<IReadOnlyList<Extension>>(() => new List<Extension>());

            LazyInitializeDerivedCollections();
        }

        public string Description { get; }

        /// <summary>
        /// Indicates whether the underlying entity for this resource is a derived instance of an abstract entity.
        /// </summary>
        public bool IsDerived { get; }

        /// <summary>
        /// Indicates whether the resource represents an Ed-Fi Standard artifact, based on the resource's assigned schema, if present.
        /// </summary>
        public bool IsEdFiStandardResource => EdFiConventions.IsEdFiPhysicalSchemaName(FullName.Schema);

        public IResourceModel ResourceModel { get; }

        // Class type name
        public string Name => FullName.Name;

        /// <summary>
        /// Gets the proper-case name of the associated schema, if applicable.
        /// </summary>
        public string SchemaProperCaseName => ResourceModel?.SchemaNameMapProvider?.GetSchemaMapByPhysicalName(FullName.Schema)
                                                            .ProperCaseName;

        /// <summary>
        /// The name of the resource represented as a <see cref="Domain.FullName" />, where the <see cref="Domain.FullName.Schema" /> property will return a <b>null</b>
        /// value if no schema is relevant in the current usage context.
        /// </summary>
        public FullName FullName { get; }

        public string PluralName
        {
            get
            {
                if (_pluralName == null)
                {
                    if (Entity == null)
                    {
                        _pluralName = CompositeTermInflector.MakePlural(Name);
                    }
                    else
                    {
                        _pluralName = Entity.PluralName;
                    }
                }

                return _pluralName;
            }
            private set { _pluralName = value; }
        }

        public Entity Entity { get; }

        /// <summary>
        /// Gets all the identifying properties defined on, or introduced by references to this resource class (with identifying properties listed before non-identifying properties).
        /// </summary>
        public virtual IReadOnlyList<ResourceProperty> AllIdentifyingProperties => _allIdentifyingProperties.Value;

        /// <summary>
        /// Gets the identifying properties of the resource that are introduced in the local context, including those in references, as necessary.
        /// </summary>
        public IReadOnlyList<ResourceProperty> IdentifyingProperties => AllProperties
                                                                       .Where(p => p.IsIdentifying && p.EntityProperty?.IsFromParent != true)
                                                                       .ToList();

        /// <summary>
        /// Gets all the properties of the resource that are not identifying, including those in references, as necessary.
        /// </summary>
        public IReadOnlyList<ResourceProperty> NonIdentifyingProperties => AllProperties
                                                                          .Where(p => !p.IsIdentifying && p.EntityProperty?.IsFromParent != true)
                                                                          .ToList();

        /// <summary>
        /// Gets all the properties defined on, or introduced by references to this resource class (with identifying properties listed before non-identifying properties).
        /// </summary>
        public virtual IReadOnlyList<ResourceProperty> AllProperties => _allProperties.Value;

        /// <summary>
        /// Gets a dictionary containing all the properties (even those in references), accessible by property name.
        /// </summary>
        public IReadOnlyDictionary<string, ResourceProperty> AllPropertyByName => _allPropertyByName.Value;

        /// <summary>
        /// Gets only the properties that are on the resource class including identifying properties, but excluding properties that are present in references.
        /// </summary>
        public virtual IReadOnlyList<ResourceProperty> Properties => _properties.Value;

        /// <summary>
        /// Gets a dictionary containing just the properties that are on the resource class itself (excluding those in references).
        /// </summary>
        /// <see cref="AllPropertyByName"/>
        public IReadOnlyDictionary<string, ResourceProperty> PropertyByName => _propertyByName.Value;

        // Embedded one-to-many
        public virtual IReadOnlyList<Collection> Collections => _collections.Value;

        public IReadOnlyDictionary<string, Collection> CollectionByName => _collectionByName.Value;

        // Embedded one-to-one
        public virtual IReadOnlyList<EmbeddedObject> EmbeddedObjects => _embeddedObjects.Value;

        public IReadOnlyDictionary<string, EmbeddedObject> EmbeddedObjectByName => _embeddedObjectByName.Value;

        /// <summary>
        /// New property exposing extensions
        /// </summary>
        public virtual IReadOnlyList<Extension> Extensions => _extensions.Value;

        /// <summary>
        /// New property exposing extensions by Name
        /// </summary>
        public IReadOnlyDictionary<string, Extension> ExtensionByName => _extensionByName.Value;

        // External many-to-one references
        public virtual IReadOnlyList<Reference> References => _references.Value;

        public IReadOnlyDictionary<string, Reference> ReferenceByName => _referenceByName.Value;

        public virtual IReadOnlyList<ResourceMemberBase> AllMembers => _allMembers.Value;

        public IReadOnlyDictionary<string, ResourceMemberBase> MemberByName => _memberByName.Value;

        internal IReadOnlyList<string> MemberNamesInvolvedInJsonCollisions => _memberNamesInvolvedInJsonCollisions.Value;

        protected IReadOnlyList<ResourceChildItem> ContainedItemTypes => _containedItemTypes.Value;

        protected IReadOnlyList<Reference> ContainedReferences => _containedReferences.Value;

        /// <summary>
        /// Gets the <see cref="FilterContext" /> that is to be applied to all members and extensions of the resource, also providing access to the unfiltered version of the resource class.
        /// </summary>
        public FilterContext FilterContext { get; }

        /// <summary>
        /// Indicates whether the resource class is part of an extension to an Ed-Fi standard resource (i.e. a "resource extension" as opposed to being part of a new "extension resource").
        /// </summary>
        public abstract bool IsResourceExtension { get; }

        /// <summary>
        /// Indicates whether the resource class is the "Extension" class artifact for a resource extension, containing all the
        /// extension <see cref="ResourceProperty" />, <see cref="Reference" />, <see cref="Collection" />, and <see cref="EmbeddedObject" /> instances.
        /// </summary>
        public abstract bool IsResourceExtensionClass { get; }

        /// <summary>
        /// Gets the root <see cref="Resource" /> class for the current resource.
        /// </summary>
        public abstract Resource ResourceRoot { get; }

        private static IEnumerable<AssociationView> GetEmbeddedObjectAssociations(Entity entity)
        {
            return entity.NavigableOneToOnes
                         .Concat(entity.InheritedNavigableOneToOnes)
                         .Where(x => x.ThisEntity.Schema == x.OtherEntity.Schema);
        }

        private static IEnumerable<AssociationView> GetCollectionAssociations(Entity entity)
        {
            return entity.NavigableChildren
                         .Concat(entity.InheritedNavigableChildren)
                         .Where(x => x.ThisEntity.Schema == x.OtherEntity.Schema);
        }

        private Lazy<IReadOnlyList<Reference>> LazyInitializeReferences(Entity entity)
        {
            return new Lazy<IReadOnlyList<Reference>>(
                () =>
                    entity.NonNavigableParents
                          .Concat(
                               entity.BaseEntity != null
                                   ? entity.BaseEntity.NonNavigableParents
                                   : new AssociationView[0])
                          .Where(a => !a.OtherEntity.IsLookupEntity()) // Don't generate references associations to Types/Descriptors
                          .Select(
                               a => new Reference(
                                   this,
                                   a)) // ResourceModel.ResourceByName[a.OtherEntity.Name])) // TODO: Role names applied to property name here?
                          .Where(r => FilterContext.MemberFilter.ShouldInclude(r.PropertyName) || r.Association.IsIdentifying)
                          .ToList());
        }

        private Lazy<IReadOnlyList<Collection>> LazyInitializeCollections(Func<IEnumerable<AssociationView>> collectionAssociations)
        {
            return new Lazy<IReadOnlyList<Collection>>(
                () =>
                    collectionAssociations()
                       .Where(a => FilterContext.MemberFilter.ShouldInclude(a.Name))
                       .Select(a => new Collection(this, a, FilterContext.GetChildContext(a.Name)))
                       .ToList());
        }

        private Lazy<IReadOnlyList<EmbeddedObject>> LazyInitializeEmbeddedObjects(Func<IEnumerable<AssociationView>> embeddedObjectAssociations)
        {
            return new Lazy<IReadOnlyList<EmbeddedObject>>(
                () =>
                    embeddedObjectAssociations()
                       .Where(a => FilterContext.MemberFilter.ShouldInclude(a.Name))
                       .Select(a => new EmbeddedObject(this, a, FilterContext.GetChildContext(a.Name)))
                       .ToList());
        }

        // Added support for lazily initializing the extension members, similar to EmbeddedObjects
        private Lazy<IReadOnlyList<Extension>> LazyInitializeExtensions(Entity entity)
        {
            var schemaNameMapProvider = entity.DomainModel.SchemaNameMapProvider;

            return new Lazy<IReadOnlyList<Extension>>(
                () =>
                {
                    if (!entity.IsEdFiStandardEntity)
                    {
                        return new List<Extension>();
                    }

                    // Get collections where the Navigable child is from a different schema
                    var extensionCollections = entity.NavigableChildren.Concat(entity.InheritedNavigableChildren)
                                                     .Where(c => !c.OtherEntity.Schema.Equals(entity.Schema))
                                                     .Where(
                                                          c => FilterContext.MemberFilter.ShouldIncludeExtension(
                                                              GetExtensionClassSchemaProperCaseName(c)))
                                                     .ToList();

                    // Get collections where the Navigable one-to-one is from a different schema
                    var extensionOneToOnes = entity.NavigableOneToOnes.Concat(entity.InheritedNavigableOneToOnes)
                                                   .Where(c => !c.OtherEntity.Schema.Equals(entity.Schema))
                                                   .Where(
                                                        c => FilterContext.MemberFilter.ShouldIncludeExtension(
                                                            GetExtensionClassSchemaProperCaseName(c)))
                                                   .ToList();

                    // Build the Resource's Extensions
                    var extensions = entity.Extensions
                                           .Select(
                                                x => new
                                                     {
                                                         Entity = x, Association = x.EdFiStandardEntityAssociation.Inverse,
                                                         SchemaProperCaseName = x.EdFiStandardEntityAssociation.Inverse.Name, SchemaPhysicalName =
                                                             schemaNameMapProvider
                                                                .GetSchemaMapByProperCaseName(x.EdFiStandardEntityAssociation.Inverse.Name)
                                                                .PhysicalName
                                                     })
                                           .Where(ext => FilterContext.MemberFilter.ShouldIncludeExtension(ext.SchemaProperCaseName))
                                           .Select(
                                                ext => new Extension(
                                                    this,
                                                    ext.Association,
                                                    FilterContext.GetExtensionContext(ext.SchemaProperCaseName),
                                                    collectionAssociations:
                                                    () => extensionCollections.Where(a => a.OtherEntity.Schema == ext.SchemaPhysicalName),
                                                    embeddedObjectAssociations:
                                                    () => extensionOneToOnes.Where(a => a.OtherEntity.Schema == ext.SchemaPhysicalName)
                                                ))
                                           .ToList();

                    // Identify need to implicitly create extension classes (if no extension properties are defined, but collections and embedded objects exist)
                    var implicitExtensionsFromCollections = extensionCollections
                                                           .Select(GetExtensionClassSchemaProperCaseName)
                                                           .Distinct()

                                                            // Where the new schema isn't already in the explicit extensions class
                                                           .Where(
                                                                properCaseName => !extensions.Any(
                                                                    x => x.PropertyName.EqualsIgnoreCase(properCaseName)))
                                                           .Select(
                                                                properCaseName => new
                                                                                  {
                                                                                      SchemaProperCaseName = properCaseName, SchemaPhysicalName =
                                                                                          schemaNameMapProvider
                                                                                             .GetSchemaMapByProperCaseName(properCaseName)
                                                                                             .PhysicalName
                                                                                  })

                                                            // Create an implicit extension class
                                                           .Select(
                                                                x =>
                                                                {
                                                                    Extension extension = null;
                                                                    
                                                                    extension = new Extension(
                                                                        this,
                                                                        () => new ResourceChildItem(
                                                                            extension,
                                                                            ResourceModel,
                                                                            new FullName(
                                                                                x.SchemaPhysicalName,
                                                                                $"{entity.Name}Extension"),
                                                                            this,
                                                                            () => extensionCollections.Where(
                                                                                a => a.OtherEntity.Schema
                                                                                    == x.SchemaPhysicalName),
                                                                            () => extensionOneToOnes.Where(
                                                                                a => a.OtherEntity.Schema
                                                                                    == x.SchemaPhysicalName),
                                                                            FilterContext.GetExtensionContext(
                                                                                x.SchemaProperCaseName)),
                                                                        x.SchemaProperCaseName);

                                                                    return extension;
                                                                });

                    extensions.AddRange(implicitExtensionsFromCollections);

                    var implicitExtensionsFromEmbeddedObjects = extensionOneToOnes

                                                                // Where the new schema isn't already in the explicit extensions class
                                                               .Select(GetExtensionClassSchemaProperCaseName)
                                                               .Distinct()
                                                               .Where(
                                                                    properCaseName => !extensions.Any(
                                                                        x => x.PropertyName.EqualsIgnoreCase(properCaseName)))
                                                               .Select(
                                                                    properCaseName => new
                                                                                      {
                                                                                          SchemaProperCaseName = properCaseName, SchemaPhysicalName =
                                                                                              schemaNameMapProvider
                                                                                                 .GetSchemaMapByProperCaseName(properCaseName)
                                                                                                 .PhysicalName
                                                                                      })
                                                               .Select(
                                                                    x =>
                                                                    {
                                                                        Extension extension = null;
                                                                        
                                                                        extension = new Extension(
                                                                            this,
                                                                            () => new ResourceChildItem(
                                                                                extension,
                                                                                ResourceModel,
                                                                                new FullName(
                                                                                    x.SchemaPhysicalName,
                                                                                    $"{entity.Name}Extension"),
                                                                                this,
                                                                                () => extensionCollections.Where(
                                                                                    a => a.OtherEntity.Schema
                                                                                        == x.SchemaPhysicalName),
                                                                                () => extensionOneToOnes.Where(
                                                                                    a => a.OtherEntity.Schema
                                                                                        == x.SchemaPhysicalName),
                                                                                FilterContext.GetExtensionContext(
                                                                                    x.SchemaProperCaseName)),
                                                                            x.SchemaProperCaseName);

                                                                        return extension;
                                                                    });

                    extensions.AddRange(implicitExtensionsFromEmbeddedObjects);

                    return extensions;
                });
        }

        private static string GetExtensionClassSchemaProperCaseName(AssociationView c)
        {
            return c.OtherEntity.DomainModel.SchemaNameMapProvider.GetSchemaMapByPhysicalName(c.OtherEntity.Schema)
                    .ProperCaseName;
        }

        private Lazy<IReadOnlyList<ResourceProperty>> LazyInitializeProperties(Entity entity)
        {
            return new Lazy<IReadOnlyList<ResourceProperty>>(
                () =>
                {
                    var result =

                        // Add inherited identifying properties
                        (entity.BaseEntity != null
                            ? entity.BaseAssociation.ThisProperties
                            : new EntityProperty[0])
                        // Add inherited non-identifying properties
                       .Concat(
                            entity.BaseEntity != null
                                ? entity.BaseEntity.NonIdentifyingProperties
                                : new EntityProperty[0])
                       .Concat(
                            entity.Properties
                                  .Where(p => p.IsLocallyDefined || p.IsDirectLookup))
                       .Select(p => new ResourceProperty(this, p))
                       .Where(p => ResourceSpecification.IsAllowableResourceProperty(p.PropertyName))
                       .Where(rp => FilterContext.MemberFilter.ShouldInclude(rp.PropertyName))
                       .ToList();

                    return result;
                });
        }

        private void LazyInitializeDerivedCollections()
        {
            _allProperties = new Lazy<IReadOnlyList<ResourceProperty>>(
                () =>

                    // Add locally defined identifying properties first
                    Properties.Where(p => p.IsIdentifying)

                               // Add reference properties, identifying references first, followed by required, and then optional
                              .Concat(
                                   References
                                      .OrderByDescending(
                                           r => (r.Association.IsIdentifying ? 100: 0)
                                                + (r.IsRequired ? 10 : 0))
                                      .SelectMany(r => r.Properties))

                               // Add non-identifying properties
                              .Concat(Properties.Where(p => !p.IsIdentifying))
                              .Distinct(ModelComparers.ResourcePropertyNameOnly)
                              .ToList());

            _allPropertyByName = new Lazy<IReadOnlyDictionary<string, ResourceProperty>>(
                () =>
                    AllProperties.ToDictionary(x => x.PropertyName, x => x, StringComparer.InvariantCultureIgnoreCase));

            _allIdentifyingProperties = new Lazy<IReadOnlyList<ResourceProperty>>(() => _allProperties.Value.Where(p => p.IsIdentifying).ToArray());
            
            _propertyByName = new Lazy<IReadOnlyDictionary<string, ResourceProperty>>(
                () =>
                    Properties
                       .ToDictionary(x => x.PropertyName, x => x, StringComparer.InvariantCultureIgnoreCase));

            _embeddedObjectByName = new Lazy<IReadOnlyDictionary<string, EmbeddedObject>>(
                () =>
                    EmbeddedObjects.ToDictionary(
                        x => x.PropertyName,
                        x => x,
                        StringComparer.InvariantCultureIgnoreCase));

            // Added lazy initialization of dictionary
            _extensionByName = new Lazy<IReadOnlyDictionary<string, Extension>>(
                () =>
                    Extensions.ToDictionary(
                        x => x.PropertyName,
                        x => x,
                        StringComparer.InvariantCultureIgnoreCase));

            _collectionByName = new Lazy<IReadOnlyDictionary<string, Collection>>(
                () =>
                    Collections.ToDictionary(x => x.PropertyName, x => x, StringComparer.InvariantCultureIgnoreCase));

            _referenceByName = new Lazy<IReadOnlyDictionary<string, Reference>>(
                () =>
                    References.ToDictionary(x => x.PropertyName, x => x, StringComparer.InvariantCultureIgnoreCase));

            _allMembers = new Lazy<IReadOnlyList<ResourceMemberBase>>(
                () => LazyInitializeAllMembers()
                   .ToList());

            _memberByName = new Lazy<IReadOnlyDictionary<string, ResourceMemberBase>>(
                () => AllMembers.ToDictionary(x => x.PropertyName, x => x, StringComparer.InvariantCultureIgnoreCase));

            _memberNamesInvolvedInJsonCollisions = new Lazy<IReadOnlyList<string>>(
                () =>
                {
                    var allProposedNames =
                        AllMembers.Select(
                                       p =>
                                           Tuple.Create(
                                               p.PropertyName,
                                               JsonNamingConvention.ProposeJsonPropertyName(p.ParentFullName.Name, p.PropertyName)))
                                  .ToList();

                    var proposedJsonNames = new HashSet<string>();
                    var rejectedJsonNames = new HashSet<string>();

                    foreach (var nameAndProposedName in allProposedNames)
                    {
                        if (!proposedJsonNames.Add(nameAndProposedName.Item2))
                        {
                            rejectedJsonNames.Add(nameAndProposedName.Item2);
                        }
                    }

                    return allProposedNames
                          .Where(t => rejectedJsonNames.Contains(t.Item2))
                          .Select(t => t.Item1)
                          .ToList();
                }
            );
        }

        protected virtual IEnumerable<ResourceMemberBase> LazyInitializeAllMembers()
        {
            return Properties
                  .Concat<ResourceMemberBase>(Collections)
                  .Concat(References)
                  .Concat(EmbeddedObjects);
        }

        private Lazy<IReadOnlyList<ResourceChildItem>> LazyInitializeContainedTypes()
        {
            return new Lazy<IReadOnlyList<ResourceChildItem>>(
                () =>

                    // Collections
                    Collections
                       .Where(c => FilterContext.MemberFilter.ShouldInclude(c.PropertyName))
                       .Select(c => c.ItemType)
                       .Concat(Collections.SelectMany(c => c.ItemType.ContainedItemTypes))

                        // EmbeddedObjects
                       .Concat(
                            EmbeddedObjects
                               .Where(o => FilterContext.MemberFilter.ShouldInclude(o.PropertyName))
                               .Select(o => o.ObjectType))
                       .Concat(EmbeddedObjects.SelectMany(o => o.ObjectType.ContainedItemTypes))

                        // Extensions
                       .Concat(
                            Extensions
                               .Where(x => FilterContext.MemberFilter.ShouldIncludeExtension(x.PropertyName))
                               .Select(x => x.ObjectType))
                       .Concat(Extensions.SelectMany(x => x.ObjectType.ContainedItemTypes))
                       .ToList()
            );
        }

        private Lazy<IReadOnlyList<Reference>> LazyInitializeContainedReferences()
        {
            return new Lazy<IReadOnlyList<Reference>>(
                () =>
                    References
                       .Concat(Collections.SelectMany(c => c.ItemType.ContainedReferences))
                       .Concat(EmbeddedObjects.SelectMany(o => o.ObjectType.ContainedReferences))
                       .Concat(Extensions.SelectMany(o => o.ObjectType.ContainedReferences))
                       .Distinct(ModelComparers.ReferenceTypeNameOnly)
                       .ToList()
            );
        }

        private static void ValidateCompositeResourceArguments(ResourceClassBase[] resources)
        {
            if (!resources.Any())
            {
                throw new ArgumentException(
                    "At least 1 resource must be supplied in order to create a composite resource.");
            }

            // Ensure that all resources refer to a common Entity
            var distinctEntities = resources.Select(r => r.Entity)
                                            .Distinct(ModelComparers.Entity)
                                            .ToList();

            if (distinctEntities.Count() != 1)
            {
                throw new InvalidOperationException(
                    string.Format(
                        "All resources supplied for a composite resource must be derived from the same Entity.  Entities found: '{0}'",
                        string.Join("', '", distinctEntities.Select(e => e.Name))));
            }
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString() => Name;

        public bool IsDeprecated { get; set; }

        public string[] DeprecationReasons { get; set; }
        
        public abstract string JsonPath { get; }
    }
}
