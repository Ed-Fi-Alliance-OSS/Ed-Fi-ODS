// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Inflection;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using log4net;

namespace EdFi.Ods.Features.Composites
{
    public class CompositeResourceModelBuilder : ICompositeItemBuilder<CompositeResourceModelBuilderContext, Resource>
    {
        private const string Collection = "Collection";
        private const string LinkedCollection = "LinkedCollection";
        private const string ReferencedResource = "ReferencedResource";
        private const string EmbeddedObject = "EmbeddedObject";

        private static ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Applies the composite resource's root resource to the build result using the supplied builder context.
        /// </summary>
        /// <param name="processorContext"></param>
        /// <param name="builderContext">The builder context.</param>
        public void ApplyRootResource(CompositeDefinitionProcessorContext processorContext, CompositeResourceModelBuilderContext builderContext)
        {
            string compositeName = processorContext.CurrentElement.Ancestors("Composite")
                                                   .First()
                                                   .AttributeValue("name");

            string resourceName = CompositeTermInflector.MakeSingular(compositeName);
            builderContext.RootResource = new Resource(resourceName); //resource.Entity.Name);
            builderContext.CurrentResource = builderContext.RootResource;
        }

        /// <summary>
        /// Applies the composite resource's child resource to the build result using the supplied builder context.
        /// </summary>
        /// <param name="builderContext">The builder context.</param>
        /// <param name="processorContext">The composite definition processor context.</param>
        public void ApplyChildResource(
            CompositeResourceModelBuilderContext builderContext,
            CompositeDefinitionProcessorContext processorContext)
        {
            // Nothing to apply (we only need to actually build the model)
        }

        /// <summary>
        /// Apply the provided property projections onto the build result with the provided builder and composite
        /// definition processor contexts.
        /// </summary>
        /// <param name="propertyProjections">A list of property projections to be applied to the build result.</param>
        /// <param name="builderContext">The builder context.</param>
        /// <param name="processorContext">The composite definition processor context.</param>
        public void ProjectProperties(
            IReadOnlyList<CompositePropertyProjection> propertyProjections,
            CompositeResourceModelBuilderContext builderContext,
            CompositeDefinitionProcessorContext processorContext)
        {
            // Local reused functional predicate
            var isIdProperty = new Func<CompositePropertyProjection, bool>(
                p =>
                    p.ResourceProperty.PropertyName.EqualsIgnoreCase("Id"));

            // Ensure Id property appears first
            var orderedPropertyProjections =
                propertyProjections.Where(isIdProperty)
                                   .Concat(propertyProjections.Where(p => !isIdProperty(p)));

            if (processorContext.ShouldIncludeResourceSubtype())
            {
                Logger.Debug($"Adding the resource type the property collection");

                AddItem(
                    builderContext.CurrentResource.Properties,
                    new ResourceProperty(
                        builderContext.CurrentResource,
                        processorContext.CurrentResourceClass.Name.ToCamelCase() + "Type",
                        new PropertyType(DbType.AnsiString, 128, 0, 0, true),
                        new PropertyCharacteristics(
                            false,
                            false,
                            false,
                            true, // All projected properties are "local" properties on the new object
                            false,
                            null),
                        null));
            }

            foreach (var property in orderedPropertyProjections)
            {
                Logger.Debug($"Projecting property {property.ResourceProperty.PropertyName}.");
                var entityProperty = property.ResourceProperty.EntityProperty;

                if (!builderContext.CurrentResource.IsAbstract()
                    || builderContext.CurrentResource.IsAbstract()
                    && entityProperty.IsIdentifying
                    && processorContext.ShouldIncludeResourceSubtype())
                {
                    Logger.Debug($"Adding property {property.ResourceProperty.PropertyName} to the builder context.");

                    AddItem(
                        builderContext.CurrentResource.Properties,
                        new ResourceProperty(
                            builderContext.CurrentResource,
                            property.DisplayName ?? property.ResourceProperty.PropertyName,
                            property.ResourceProperty.PropertyType,
                            new PropertyCharacteristics(
                                entityProperty.IsLookup,
                                entityProperty.IsDirectLookup,
                                entityProperty.IsIdentifying,
                                true, // All projected properties are "local" properties on the new object
                                entityProperty.IsServerAssigned,
                                entityProperty.LookupEntity == null
                                    ? null as FullName?
                                    : entityProperty.LookupEntity.FullName),
                            property.ResourceProperty.Description));
                }
                else
                {
                    Logger.Debug($"Stripping property {property.ResourceProperty.PropertyName} from the builder context.");
                }
            }


        }

        /// <summary>
        /// Builds the artifact for the root resource of the composite definition.
        /// </summary>
        /// <param name="builderContext">The builder context.</param>
        /// <param name="processorContext">The composite definition processor context.</param>
        /// <param name="resource">The resource that is built.</param>
        /// <returns>The build result.</returns>
        public bool TryBuildForRootResource(
            CompositeResourceModelBuilderContext builderContext,
            CompositeDefinitionProcessorContext processorContext,
            out Resource resource)
        {
            resource = builderContext.RootResource;
            return true;
        }

        /// <summary>
        /// Builds the artifact for the root resource of the composite definition.
        /// </summary>
        /// <param name="parentResult">The parent build result, for compositional behavior (if applicable).</param>
        /// <param name="builderContext">The builder context.</param>
        /// <param name="processorContext">The composite definition processor context.</param>
        /// <returns>The build result.</returns>
        public Resource BuildForChildResource(
            Resource parentResult,
            CompositeResourceModelBuilderContext builderContext,
            CompositeDefinitionProcessorContext processorContext)
        {
            string currentElementName = processorContext.CurrentElement.Name.LocalName;

            switch (currentElementName)
            {
                case Collection:
                    AddItem(builderContext.ParentResource.Collections,
                        new Collection(
                            builderContext.ParentResource,
                            builderContext.CurrentResource as ResourceChildItem,
                            processorContext.JoinAssociation,
                            processorContext.MemberDisplayName));

                    break;

                case LinkedCollection:

                    AddItem(builderContext.ParentResource.Collections,
                        new Collection(
                            builderContext.ParentResource,
                            builderContext.CurrentResource as ResourceChildItem,
                            processorContext.JoinAssociation,
                            processorContext.MemberDisplayName));

                    break;

                case ReferencedResource:

                    AddItem(builderContext.ParentResource.EmbeddedObjects,
                        new EmbeddedObject(
                            builderContext.ParentResource,
                            builderContext.CurrentResource as ResourceChildItem,
                            processorContext.MemberDisplayName));

                    break;

                case EmbeddedObject:

                    AddItem(builderContext.ParentResource.EmbeddedObjects,
                        new EmbeddedObject(
                            builderContext.ParentResource,
                            builderContext.CurrentResource as ResourceChildItem,
                            processorContext.MemberDisplayName));

                    break;

                default:

                    throw new NotSupportedException($"Child element type '{currentElementName}' is not yet supported.");
            }

            // Nothing to compose (results are built in-place using the builder context)
            return null;
        }

        /// <summary>
        /// Builds a new context from the current builder context for use in processing a flattened reference.
        /// </summary>
        /// <param name="builderContext">The builder context.</param>
        /// <returns>The new builder context for use in processing a flattened reference.</returns>
        public CompositeResourceModelBuilderContext CreateFlattenedMemberContext(
            CompositeResourceModelBuilderContext builderContext)
        {
            // Nothing to do
            return builderContext;
        }

        /// <summary>
        /// Applies the provided flattened resource reference to the build result using the supplied builder context.
        /// </summary>
        /// <param name="member">The flattened ReferencedResource or EmbeddedObject to be applied to the build result.</param>
        /// <param name="builderContext">The builder context.</param>
        public void ApplyFlattenedMember(ResourceMemberBase member, CompositeResourceModelBuilderContext builderContext)
        {
            // Nothing to do
        }

        /// <summary>
        /// Applies the provided local identifying properties to the build result using the supplied builder context.
        /// </summary>
        /// <param name="locallyDefinedIdentifyingProperties">The list of local identifying properties to be applied to the build result.</param>
        /// <param name="builderContext">The builder context.</param>
        /// <param name="processorContext">The composite definition processor context.</param>
        public void ApplyLocalIdentifyingProperties(
            IReadOnlyList<EntityProperty> locallyDefinedIdentifyingProperties,
            CompositeResourceModelBuilderContext builderContext,
            CompositeDefinitionProcessorContext processorContext)
        {
            // Nothing to do
        }

        /// <summary>
        /// Captures context from the current builder context to be used as the baseline for processing children
        /// while allowing additional changes to be made to the current context.
        /// </summary>
        /// <seealso cref="ICompositeItemBuilder{TBuilderContext,TBuildResult}.CreateParentingContext"/>
        /// <param name="builderContext">The current build context.</param>
        /// <remarks>Implementations should use this as a means for preserving part of the current
        /// context for future use by storing the snapshot context within the current context.</remarks>
        public void SnapshotParentingContext(CompositeResourceModelBuilderContext builderContext)
        {
            // Nothing to do
        }

        /// <summary>
        /// Creates a new builder context by applying previously snapshot parental context.
        /// </summary>
        /// <param name="builderContext">The current builder context.</param>
        /// <returns>The new builder context to be used for child processing.</returns>
        public CompositeResourceModelBuilderContext CreateParentingContext(
            CompositeResourceModelBuilderContext builderContext)
        {
            // Nothing to do
            return builderContext;
        }

        /// <summary>
        /// Creates a new builder context to be used for processing a child element.
        /// </summary>
        /// <param name="parentingBuilderContext">The parent context to be used to derive the new child context.</param>
        /// <param name="childProcessorContext"></param>
        /// <returns>The new builder context.</returns>
        public CompositeResourceModelBuilderContext CreateChildContext(
            CompositeResourceModelBuilderContext parentingBuilderContext,
            CompositeDefinitionProcessorContext childProcessorContext)
        {
            return new CompositeResourceModelBuilderContext
                   {
                       RootResource = parentingBuilderContext.RootResource, ParentResource = parentingBuilderContext.CurrentResource,
                       CurrentResource = new ResourceChildItem(
                           childProcessorContext.CurrentResourceClass.Name,
                           parentingBuilderContext.CurrentResource)
                   };
        }

        /// <summary>
        /// Creates a new builder context to be used for processing a flattened reference.
        /// </summary>
        /// <param name="parentingBuilderContext">The parent builder context.</param>
        /// <returns>The new builder context.</returns>
        public CompositeResourceModelBuilderContext CreateFlattenedReferenceChildContext(
            CompositeResourceModelBuilderContext parentingBuilderContext)
        {
            // Nothing to do
            return parentingBuilderContext;
        }

        /// <summary>
        /// Applies processing related to the usage/entry to another top-level resource (e.g. applying authorization concerns).
        /// </summary>
        /// <param name="processorContext">The composite definition processor context.</param>
        /// <param name="builderContext">The current builder context.</param>
        /// <returns><b>true</b> if the resource can be processed; otherwise <b>false</b>.</returns>
        public bool TryIncludeResource(CompositeDefinitionProcessorContext processorContext, CompositeResourceModelBuilderContext builderContext)
        {
            // No reason not to include the resource in this usage scenario
            return true;
        }

        /// <summary>
        /// Applies properties necessary to support self-referencing association behavior.
        /// </summary>
        /// <param name="selfReferencingAssociations">The relevant self-referencing associations.</param>
        /// <param name="builderContext">The current builder context.</param>
        /// <param name="processorContext">The composite definition processor context.</param>
        /// <remarks>The associations supplied may not be from the current resource class.  In cases where the self-referencing
        /// behavior is obtained through a referenced resource, the associations will be from the referenced resource.</remarks>
        public void ApplySelfReferencingProperties(
            IReadOnlyList<AssociationView> selfReferencingAssociations,
            CompositeResourceModelBuilderContext builderContext,
            CompositeDefinitionProcessorContext processorContext)
        {
            // Nothing to do
        }

        private static void AddItem<T>(IReadOnlyList<T> readOnlyList, T item)
        {
            var underlyingList = readOnlyList as List<T>;

            if (underlyingList == null)
            {
                throw new InvalidOperationException("Underlying list instance is not of type List<T>.");
            }

            underlyingList.Add(item);
        }
    }
}
