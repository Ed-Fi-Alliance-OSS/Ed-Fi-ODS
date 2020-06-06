// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Features.Composites
{
    public interface ICompositeItemBuilder<TBuilderContext, TBuildResult>
    {
        /// <summary>
        /// Applies the composite resource's root resource to the build result using the supplied builder context.
        /// </summary>
        /// <param name="processorContext"></param>
        /// <param name="builderContext">The builder context.</param>
        void ApplyRootResource(CompositeDefinitionProcessorContext processorContext, TBuilderContext builderContext);

        /// <summary>
        /// Applies the composite resource's child resource to the build result using the supplied builder context.
        /// </summary>
        /// <param name="builderContext">The builder context.</param>
        /// <param name="processorContext">The composite definition processor context.</param>
        void ApplyChildResource(
            TBuilderContext builderContext,
            CompositeDefinitionProcessorContext processorContext);

        /// <summary>
        /// Apply the provided property projections onto the build result with the provided builder and composite
        /// definition processor contexts.
        /// </summary>
        /// <param name="propertyProjections">A list of property projections to be applied to the build result.</param>
        /// <param name="builderContext">The builder context.</param>
        /// <param name="processorContext">The composite definition processor context.</param>
        void ProjectProperties(
            IReadOnlyList<CompositePropertyProjection> propertyProjections,
            TBuilderContext builderContext,
            CompositeDefinitionProcessorContext processorContext);

        /// <summary>
        /// Builds the artifact for the root resource of the composite definition.
        /// </summary>
        /// <param name="builderContext">The builder context.</param>
        /// <param name="processorContext">The composite definition processor context.</param>
        /// <param name="buildResult">The build result.</param>
        /// <returns><b>true</b> if the result could be built; otherwise <b>false</b>.</returns>
        bool TryBuildForRootResource(
            TBuilderContext builderContext,
            CompositeDefinitionProcessorContext processorContext,
            out TBuildResult buildResult);

        /// <summary>
        /// Builds the artifact for the root resource of the composite definition.
        /// </summary>
        /// <param name="parentResult">The parent build result, for compositional behavior (if applicable).</param>
        /// <param name="builderContext">The builder context.</param>
        /// <param name="processorContext">The composite definition processor context.</param>
        /// <returns>The build result.</returns>
        TBuildResult BuildForChildResource(
            TBuildResult parentResult,
            TBuilderContext builderContext,
            CompositeDefinitionProcessorContext processorContext);

        /// <summary>
        /// Builds a new context from the curent builder context for use in processing a flattened reference.
        /// </summary>
        /// <param name="builderContext">The builder context.</param>
        /// <returns>The new builder context for use in processing a flattened reference.</returns>
        TBuilderContext CreateFlattenedMemberContext(TBuilderContext builderContext);

        /// <summary>
        /// Applies the provided flattened resource reference to the build result using the suplied builder context.
        /// </summary>
        /// <param name="member">The flattened ReferencedResource or EmbeddedObject to be applied to the build result.</param>
        /// <param name="builderContext">The builder context.</param>
        void ApplyFlattenedMember(ResourceMemberBase member, TBuilderContext builderContext);

        /// <summary>
        /// Applies the provided local identifying properties to the build result using the suplied builder context.
        /// </summary>
        /// <param name="locallyDefinedIdentifyingProperties">The list of local identifying properties to be applied to the build result.</param>
        /// <param name="builderContext">The builder context.</param>
        /// <param name="processorContext">The composite definition processor context.</param>
        void ApplyLocalIdentifyingProperties(
            IReadOnlyList<EntityProperty> locallyDefinedIdentifyingProperties,
            TBuilderContext builderContext,
            CompositeDefinitionProcessorContext processorContext);

        /// <summary>
        /// Captures context from the current builder context to be used as the baseline for processing children
        /// while allowing additional changes to be made to the current context.
        /// </summary>
        /// <seealso cref="CreateParentingContext"/>
        /// <param name="builderContext">The current build context.</param>
        /// <remarks>Implementations should use this as a means for preserving part of the current
        /// context for future use by storing the snapshotted context within the current context.</remarks>
        void SnapshotParentingContext(TBuilderContext builderContext);

        /// <summary>
        /// Creates a new builder context by applying previously snapshotted parental context.
        /// </summary>
        /// <param name="builderContext">The current builder context.</param>
        /// <returns>The new builder context to be used for child processing.</returns>
        TBuilderContext CreateParentingContext(TBuilderContext builderContext);

        /// <summary>
        /// Creates a new builder context to be used for processing a child element.
        /// </summary>
        /// <param name="parentingBuilderContext">The parent context to be used to derive the new child context.</param>
        /// <param name="childProcessorContext"></param>
        /// <returns>The new builder context.</returns>
        TBuilderContext CreateChildContext(TBuilderContext parentingBuilderContext, CompositeDefinitionProcessorContext childProcessorContext);

        /// <summary>
        /// Creates a new builder context to be used for processing a flattened reference.
        /// </summary>
        /// <param name="parentingBuilderContext">The parent builder context.</param>
        /// <returns>The new builder context.</returns>
        TBuilderContext CreateFlattenedReferenceChildContext(TBuilderContext parentingBuilderContext);

        /// <summary>
        /// Applies processing related to the usage/entry to another top-level resource (e.g. applying authorization concerns).
        /// </summary>
        /// <param name="processorContext">The composite definition processor context.</param>
        /// <param name="builderContext">The current builder context.</param>
        /// <returns><b>true</b> if the resource can be processed; otherwise <b>false</b>.</returns>
        bool TryIncludeResource(CompositeDefinitionProcessorContext processorContext, TBuilderContext builderContext);

        /// <summary>
        /// Applies properties necessary to support self-referencing association behavior.
        /// </summary>
        /// <param name="selfReferencingAssociations">The relevant self-referencing associations.</param>
        /// <param name="builderContext">The current builder context.</param>
        /// <param name="processorContext">The composite definition processor context.</param>
        /// <remarks>The associations supplied may not be from the current resource class.  In cases where the self-referencing
        /// behavior is obtained through a referenced resource, the associations will be from the referenced resource.</remarks>
        void ApplySelfReferencingProperties(
            IReadOnlyList<AssociationView> selfReferencingAssociations,
            TBuilderContext builderContext,
            CompositeDefinitionProcessorContext processorContext);
    }

    public class CompositePropertyProjection
    {
        public CompositePropertyProjection(ResourceProperty resourceProperty, string displayName)
        {
            ResourceProperty = resourceProperty;
            DisplayName = displayName;
        }

        public ResourceProperty ResourceProperty { get; }

        public string DisplayName { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return ResourceProperty.PropertyName + ":" + (DisplayName ?? "(null)");
        }
    }
}
