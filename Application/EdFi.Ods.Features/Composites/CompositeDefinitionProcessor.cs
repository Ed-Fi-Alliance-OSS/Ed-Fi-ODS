// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using log4net;

namespace EdFi.Ods.Features.Composites
{
    public class CompositeDefinitionProcessor<TBuilderContext, TBuildResult> : ICompositeDefinitionProcessor<TBuilderContext, TBuildResult>
        where TBuildResult : class
    {
        private readonly ICompositeItemBuilder<TBuilderContext, TBuildResult> _compositeBuilder;

        private readonly ILog _logger = LogManager.GetLogger(typeof(CompositeDefinitionProcessor<TBuilderContext, TBuildResult>));

        private bool _performValidation;

        private List<string> _validationErrors;

        public CompositeDefinitionProcessor(ICompositeItemBuilder<TBuilderContext, TBuildResult> compositeBuilder)
        {
            _compositeBuilder = compositeBuilder;
        }

        public TBuildResult Process(
            XElement compositeDefinition,
            IResourceModel resourceModel,
            TBuilderContext builderContext)
        {
            var currentElt = compositeDefinition.Element(CompositeDefinitionHelper.BaseResource);

            if (currentElt == null)
            {
                throw new Exception("Unable to find the main 'Resource' element of the composite definition.");
            }

            var resourceLogicalName = currentElt.AttributeValue(CompositeDefinitionHelper.LogicalSchema) ?? EdFiConventions.LogicalName;

            var resourcePhysicalName = resourceModel.SchemaNameMapProvider
                                                    .GetSchemaMapByLogicalName(resourceLogicalName)
                                                    .PhysicalName;

            // Composites does not support extensions
            var currentModel =
                resourceModel.GetResourceByFullName(
                    new FullName(resourcePhysicalName, currentElt.AttributeValue(CompositeDefinitionHelper.Name)));

            var processorContext = new CompositeDefinitionProcessorContext(
                compositeDefinition,
                resourceModel,
                currentElt,
                currentModel,
                null,
                null,
                null,
                0,
                null);

            return ProcessDefinition(default(TBuildResult), builderContext, processorContext);
        }

        public void UseCompositeValidation()
        {
            _validationErrors = new List<string>();
            _performValidation = true;
        }

        private TBuildResult ProcessDefinition(
            TBuildResult parentResult,
            TBuilderContext builderContext,
            CompositeDefinitionProcessorContext processorContext)
        {
            // Apply authorization for aggregate roots here
            if (processorContext.CurrentResourceClass.Entity.IsAggregateRoot)
            {
                // Provide opportunity to perform processing related to navigating into another resource (i.e. authorization)
                if (!_compositeBuilder.TryIncludeResource(processorContext, builderContext))
                {
                    return default(TBuildResult);
                }
            }

            bool isMainQuery = processorContext.IsBaseResource();

            if (isMainQuery)
            {
                _compositeBuilder.ApplyRootResource(processorContext, builderContext);
            }
            else
            {
                _compositeBuilder.ApplyChildResource(builderContext, processorContext);
            }

            var nonIncomingIdentifyingProperties = processorContext.NonIncomingIdentifyingProperties();

            ApplyLocalIdentifyingProperties(builderContext, processorContext, nonIncomingIdentifyingProperties);

            ApplySelfReferencingAssociations(builderContext, processorContext);

            ApplyReferenceHierarchy(builderContext, processorContext);

            // Capture current applicable builder state so it can be modified further at this level without changes affecting children
            _compositeBuilder.SnapshotParentingContext(builderContext);

            // Select projected properties
            var propertyProjections = GetPropertyProjections(processorContext, processorContext.PropertyElements());

            // Project the properties into the artifact under construction
            _compositeBuilder.ProjectProperties(propertyProjections, builderContext, processorContext);

            // Process flattened References
            ProcessFlattenedMemberProperties(processorContext, builderContext);

            TBuildResult thisBuildResult;

            if (isMainQuery)
            {
                // Short circuit the rest of the processing if the root result is null
                if (!_compositeBuilder.TryBuildForRootResource(builderContext, processorContext, out thisBuildResult))
                {
                    return default(TBuildResult);
                }
            }
            else
            {
                thisBuildResult = _compositeBuilder.BuildForChildResource(
                    parentResult,
                    builderContext,
                    processorContext);
            }

            var childBuilderContext = _compositeBuilder.CreateParentingContext(builderContext);

            ProcessChildren(thisBuildResult, processorContext, childBuilderContext);

            if (_performValidation && _validationErrors.Any())
            {
                throw new Exception(string.Join(Environment.NewLine, _validationErrors.ToArray()));
            }

            return thisBuildResult;
        }

        private void ApplyReferenceHierarchy(TBuilderContext builderContext, CompositeDefinitionProcessorContext processorContext)
        {
            if (processorContext.ShouldUseReferenceHierarchy())
            {
                string referenceName = processorContext.AttributeValue(CompositeDefinitionHelper.HierarchicalReferenceName);

                var referencedResourceClass = processorContext.CurrentResourceClass.ReferenceByName[referenceName]
                                                              .ReferencedResource;

                _compositeBuilder.ApplySelfReferencingProperties(
                    referencedResourceClass.Entity.SelfReferencingAssociations,
                    builderContext,
                    processorContext);
            }
        }

        private void ApplySelfReferencingAssociations(TBuilderContext builderContext, CompositeDefinitionProcessorContext processorContext)
        {
            if (processorContext.CurrentResourceClass.Entity.HasSelfReferencingAssociations
                && processorContext.ShouldUseHierarchy())
            {
                _compositeBuilder.ApplySelfReferencingProperties(
                    processorContext.CurrentResourceClass.Entity.SelfReferencingAssociations,
                    builderContext,
                    processorContext);
            }
        }

        private void ApplyLocalIdentifyingProperties(TBuilderContext builderContext, CompositeDefinitionProcessorContext processorContext,
                                                     List<EntityProperty> nonIncomingIdentifyingProperties)
        {
            // Apply local identifying properties to the artifact under construction
            _compositeBuilder.ApplyLocalIdentifyingProperties(
                nonIncomingIdentifyingProperties,
                builderContext,
                processorContext);
        }

        private List<CompositePropertyProjection> GetPropertyProjections(
            CompositeDefinitionProcessorContext processorContext,
            IEnumerable<XElement> propertyElements)
        {
            var selectedElements = CompositeDefinitionHelper.CreateSelectedElements(propertyElements);

            // only allow identifying properties for pass through resources.
            var validPropertiesByName = CompositeDefinitionHelper.ValidPropertiesByName(
                processorContext, processorContext.CurrentResourceClass.AllPropertyByName);

            var validProperties = CompositeDefinitionHelper.GetValidProperties(selectedElements, validPropertiesByName);

            ValidateSelectedElements(
                selectedElements, validProperties,
                processorContext.CurrentElement.AttributeValue(CompositeDefinitionHelper.Name),
                processorContext.ShouldIncludeResourceSubtype());

            return validProperties.Select(
                                       pn =>
                                           new CompositePropertyProjection(
                                               processorContext.CurrentResourceClass.AllPropertyByName[pn.Name],
                                               pn.DisplayName))
                                  .ToList();
        }

        private void ValidateSelectedElements(List<PropertyNameWithDisplayName> selectedElements,
                                              List<PropertyNameWithDisplayName> validProperties,
                                              string elementName,
                                              bool shouldIncludeResourceSubtype)
        {
            if (_performValidation)
            {
                var invalidElements = selectedElements.Except(validProperties)
                                                      .ToList();

                if (invalidElements.Any())
                {
                    invalidElements.ForEach(
                        p =>
                        {
                            string message = shouldIncludeResourceSubtype
                                ? $"TTarget resource '{elementName}' cannot be authorized. Non-identifying resource member {p.Name} cannot be included."
                                : $"Invalid property '{p.Name}' was found on element '{elementName}'.";

                            _validationErrors.Add(message);
                        });
                }
            }
        }

        private List<CompositePropertyProjection> GetPropertyProjectionsForNonAggregateRoot(
            CompositeDefinitionProcessorContext processorContext,
            EmbeddedObject currentMember,
            IEnumerable<XElement> propertyElements,
            string containingElementName)
        {
            var selectedElements = CompositeDefinitionHelper.CreateSelectedElements(propertyElements);
            var validPropertiesByName = CompositeDefinitionHelper.ValidPropertiesByName(processorContext, currentMember.ObjectType.PropertyByName);
            var validProperties = CompositeDefinitionHelper.GetValidProperties(selectedElements, validPropertiesByName);

            ValidateSelectedElements(selectedElements, validProperties, containingElementName, processorContext.ShouldIncludeResourceSubtype());

            return validProperties
                  .Select(pn => new CompositePropertyProjection(currentMember.ObjectType.AllPropertyByName[pn.Name], pn.DisplayName))
                  .ToList();
        }

        private void ProcessChildren(TBuildResult parentResult,
                                     CompositeDefinitionProcessorContext processorContext,
                                     TBuilderContext parentingBuilderContext)
        {
            var resourceModel = processorContext.ResourceModel;
            XElement currentElt = processorContext.CurrentElement;
            ResourceClassBase currentResourceClass = processorContext.CurrentResourceClass;

            // Iterate through children (Collection, EmbeddedObject, Resource or Reference)
            var otherChildren = currentElt.Elements(CompositeDefinitionHelper.Collection)
                                          .Concat(currentElt.Elements(CompositeDefinitionHelper.EmbeddedObject))
                                          .Concat(currentElt.Elements(CompositeDefinitionHelper.LinkedCollection))
                                          .Concat(currentElt.Elements(CompositeDefinitionHelper.ReferencedResource));

            int childIndex = 0;

            foreach (var childElt in otherChildren)
            {
                var childProcessorContext = CreateChildProcessorContext(
                    parentResult, processorContext, parentingBuilderContext, childElt, currentResourceClass, resourceModel, childIndex);

                if (childProcessorContext == null)
                {
                    continue;
                }

                var childBuilderContext = _compositeBuilder.CreateChildContext(parentingBuilderContext, childProcessorContext);

                childIndex++;

                ProcessDefinition(parentResult, childBuilderContext, childProcessorContext);
            }
        }

        private CompositeDefinitionProcessorContext CreateChildProcessorContext(TBuildResult parentResult,
                                                                                CompositeDefinitionProcessorContext processorContext,
                                                                                TBuilderContext parentingBuilderContext,
                                                                                XElement childElement,
                                                                                ResourceClassBase currentResourceClass,
                                                                                IResourceModel resourceModel, int childIndex)
        {
            ResourceClassBase childModel;
            AssociationView association;
            ResourceMemberBase resourceMember;

            string childMemberName = childElement.AttributeValue(CompositeDefinitionHelper.Name);
            string childMemberDisplayName = childElement.AttributeValue(CompositeDefinitionHelper.DisplayName);
            string currentElementName = processorContext.CurrentElement.AttributeValue(CompositeDefinitionHelper.Name);

            string resourceMemberName = string.Empty;
            string childEntityMemberName = string.Empty;

            switch (childElement.Name.LocalName)
            {
                case CompositeDefinitionHelper.Collection:

                    if (!currentResourceClass.CollectionByName.TryGetValue(childMemberName, out Collection collection))
                    {
                        ApplyValidationMessage("collection", childMemberName, currentElementName);
                        return null;
                    }

                    _logger.Debug($"Current element '{currentElementName}' is a collection named '{childMemberName}'.");

                    childModel = collection.ItemType;
                    childEntityMemberName = childMemberName;
                    association = collection.Association;
                    resourceMember = collection;
                    resourceMemberName = collection.PropertyName;

                    break;

                case CompositeDefinitionHelper.LinkedCollection:

                    var resource = currentResourceClass as Resource;

                    if (resource == null)
                    {
                        _logger.Debug($"Current resource class '{currentResourceClass.Name} is not an aggregate root.");
                        return null;
                    }

                    if (!resource.LinkedResourceCollectionByName.TryGetValue(childMemberName, out LinkedCollection linkedCollection))
                    {
                        ApplyValidationMessage("linked collection", childMemberName, currentElementName);
                        return null;
                    }

                    _logger.Debug(
                        $"Current element '{currentElementName} is a linked collection named '{childMemberName}' for resource '{currentResourceClass.Name}'.");

                    childModel = linkedCollection.Resource;
                    childEntityMemberName = childMemberName;
                    association = linkedCollection.Association;
                    resourceMember = linkedCollection;
                    resourceMemberName = linkedCollection.PropertyName;

                    break;

                case CompositeDefinitionHelper.EmbeddedObject:

                    if (!currentResourceClass.EmbeddedObjectByName.TryGetValue(childMemberName, out EmbeddedObject embeddedObject))
                    {
                        ApplyValidationMessage("embedded object", childMemberName, currentElementName);

                        return null;
                    }

                    _logger.Debug($"Current element '{currentElementName}' is an embedded object named '{childMemberName}'.");

                    childModel = embeddedObject.ObjectType;
                    childEntityMemberName = embeddedObject.Association.Name;
                    association = embeddedObject.Association;
                    resourceMember = embeddedObject;
                    resourceMemberName = embeddedObject.PropertyName;

                    if (CompositeDefinitionHelper.ShouldFlatten(childElement))
                    {
                        _logger.Debug($"Flattening embedded object {childModel.Name}");

                        _compositeBuilder.ApplyFlattenedMember(embeddedObject, parentingBuilderContext);

                        var childBuilderContextForObject = _compositeBuilder.CreateFlattenedReferenceChildContext(parentingBuilderContext);

                        var childProcessorContextForObject = new CompositeDefinitionProcessorContext(
                            processorContext.CompositeDefinitionElement,
                            resourceModel,
                            childElement,
                            childModel,
                            association,
                            childEntityMemberName,
                            resourceMemberName,
                            childIndex,
                            resourceMember);

                        ProcessChildren(parentResult, childProcessorContextForObject, childBuilderContextForObject);

                        return null;
                    }

                    break;

                case CompositeDefinitionHelper.ReferencedResource:

                    if (!currentResourceClass.ReferenceByName.TryGetValue(childMemberName, out Reference reference))
                    {
                        ApplyValidationMessage("referenced resource", childMemberName, currentElementName);

                        return null;
                    }

                    _logger.Debug($"Current element '{currentElementName}' is an referenced resourced named '{childMemberName}'.");

                    childModel = reference.ReferencedResource;
                    childEntityMemberName = reference.Association.Name;
                    association = reference.Association;
                    resourceMember = reference;
                    resourceMemberName = reference.PropertyName;

                    // If reference is flattened, process recursively without adding another query at this level.
                    if (CompositeDefinitionHelper.ShouldFlatten(childElement))
                    {
                        _logger.Debug($"Flattening referenced resource {childModel.Name}");

                        _compositeBuilder.ApplyFlattenedMember(reference, parentingBuilderContext);

                        var childBuilderContextForReference = _compositeBuilder.CreateFlattenedReferenceChildContext(parentingBuilderContext);

                        var childProcessorContextForReference = new CompositeDefinitionProcessorContext(
                            processorContext.CompositeDefinitionElement,
                            resourceModel,
                            childElement,
                            childModel,
                            association,
                            childEntityMemberName,
                            resourceMemberName,
                            childIndex,
                            resourceMember);

                        if (childModel.Entity.IsAggregateRoot)
                        {
                            // Provide opportunity to perform processing related to navigating into another resource (i.e. authorization)
                            if (!_compositeBuilder.TryIncludeResource(childProcessorContextForReference, childBuilderContextForReference))
                            {
                                return null;
                            }
                        }

                        ProcessChildren(parentResult, childProcessorContextForReference, childBuilderContextForReference);

                        return null;
                    }

                    break;

                default:

                    throw new NotSupportedException($"Element '{childElement.Name.LocalName}' is not supported.");
            }

            return new CompositeDefinitionProcessorContext(
                processorContext.CompositeDefinitionElement,
                resourceModel,
                childElement,
                childModel,
                association,
                childEntityMemberName,
                childMemberDisplayName ?? resourceMemberName,
                childIndex,
                resourceMember);
        }

        private void ApplyValidationMessage(string resourceType, string childMemberName, string currentEltName)
        {
            if (_performValidation)
            {
                _validationErrors.Add($"Invalid {resourceType} '{childMemberName}' was found in element '{currentEltName}'");
            }
        }

        private void ProcessFlattenedMemberProperties(
            CompositeDefinitionProcessorContext processorContext,
            TBuilderContext builderContext)
        {
            string currentContainingElementName = processorContext.CurrentElement.AttributeValue(CompositeDefinitionHelper.Name);

            var flattenedMemberElements = processorContext.CurrentElement
                                                          .Elements(CompositeDefinitionHelper.ReferencedResource)
                                                          .Where(CompositeDefinitionHelper.ShouldFlatten)
                                                          .ToList();

            flattenedMemberElements.AddRange(
                processorContext.CurrentElement
                                .Elements(CompositeDefinitionHelper.EmbeddedObject)
                                .Where(CompositeDefinitionHelper.ShouldFlatten));

            foreach (var flattenedMemberElt in flattenedMemberElements)
            {
                string flattenedMemberName = flattenedMemberElt.AttributeValue(CompositeDefinitionHelper.Name);

                ResourceMemberBase resourceToUse = null;
                Resource flattenedResource = null;

                bool memberIsReference = flattenedMemberElt.Name.LocalName == CompositeDefinitionHelper.ReferencedResource;
                bool memberIsEmbeddedObject = flattenedMemberElt.Name.LocalName == CompositeDefinitionHelper.EmbeddedObject;

                if (memberIsReference)
                {
                    if (!processorContext.CurrentResourceClass.ReferenceByName.TryGetValue(
                        flattenedMemberName, out Reference resourceToUseAsReference))
                    {
                        ApplyValidationMessage("resource reference", flattenedMemberName, currentContainingElementName);
                        continue;
                    }

                    resourceToUse = resourceToUseAsReference;

                    flattenedResource =
                        processorContext.CurrentResourceClass.ResourceModel.GetResourceByFullName(
                            resourceToUseAsReference.ReferencedResource.Entity.FullName);
                }
                else if (memberIsEmbeddedObject)
                {
                    if (!processorContext.CurrentResourceClass.EmbeddedObjectByName.TryGetValue(
                        flattenedMemberName, out EmbeddedObject resourceAsEmbeddedObject))
                    {
                        ApplyValidationMessage("embedded object", flattenedMemberName, currentContainingElementName);
                        continue;
                    }

                    resourceToUse = resourceAsEmbeddedObject;

                    flattenedResource =
                        processorContext.CurrentResourceClass.ResourceModel.GetResourceByFullName(resourceAsEmbeddedObject.Parent.Entity.FullName);
                }
                else
                {
                    // Defensive programming, but also throw a helpful message in the event it does ever happen
                    throw new NotSupportedException($"Flattened elements of type '{flattenedMemberElt.Name.LocalName}' are not yet supported.");
                }

                var flattenedBuilderContext = _compositeBuilder.CreateFlattenedMemberContext(builderContext);

                var flattenedProcessingContext = new CompositeDefinitionProcessorContext(
                    processorContext.CompositeDefinitionElement,
                    processorContext.ResourceModel,
                    flattenedMemberElt,
                    flattenedResource,
                    null,
                    null,
                    null,
                    0,
                    resourceToUse);

                var shouldContinueWithValidation = resourceToUse == null && _performValidation;

                if (flattenedResource.Entity.IsAggregateRoot)
                {
                    // Provide opportunity to perform processing related to navigating into another resource (i.e. authorization)
                    if (!_compositeBuilder.TryIncludeResource(flattenedProcessingContext, flattenedBuilderContext))
                    {
                        continue;
                    }
                }

                if (shouldContinueWithValidation)
                {
                    continue;
                }

                _compositeBuilder.ApplyFlattenedMember(resourceToUse, flattenedBuilderContext);

                // TODO: Consider refining what is passed into Resource model classes rather than XElements
                var propertyElements = flattenedMemberElt
                                      .Elements(CompositeDefinitionHelper.Property)
                                      .ToList();

                List<CompositePropertyProjection> flattenedPropertyProjections = new List<CompositePropertyProjection>();

                if (memberIsReference)
                {
                    flattenedPropertyProjections = GetPropertyProjections(
                        flattenedProcessingContext,
                        propertyElements);
                }
                else if (memberIsEmbeddedObject)
                {
                    flattenedPropertyProjections = GetPropertyProjectionsForNonAggregateRoot(
                        processorContext,
                        (EmbeddedObject) resourceToUse,
                        propertyElements,
                        currentContainingElementName);
                }

                _compositeBuilder.ProjectProperties(flattenedPropertyProjections, flattenedBuilderContext, flattenedProcessingContext);

                // Recursively process flattened resource properties
                ProcessFlattenedMemberProperties(
                    flattenedProcessingContext,
                    flattenedBuilderContext);
            }
        }
    }
}
