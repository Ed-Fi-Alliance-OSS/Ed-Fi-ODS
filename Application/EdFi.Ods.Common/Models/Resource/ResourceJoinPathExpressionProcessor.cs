// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common.Models.Resource
{
    public interface IResourceJoinPathExpressionProcessor
    {
        void ProcessPath(
            Resource startingResource,
            string pathName,
            string pathExpression,
            Action<ResourceProperty, string> processPropertyCallback = null,
            Action<Reference, string> processReferenceCallback = null,
            Action<Collection, string> processCollectionCallback = null,
            Action<LinkedCollection, string> processLinkedCollectionCallback = null,
            Action<EmbeddedObject, string> processEmbeddedObjectCallback = null);
    }

    public class ResourceJoinPathExpressionProcessor : IResourceJoinPathExpressionProcessor
    {
        public void ProcessPath(
            Resource startingResource,
            string pathName,
            string pathExpression,
            Action<ResourceProperty, string> processPropertyCallback = null,
            Action<Reference, string> processReferenceCallback = null,
            Action<Collection, string> processCollectionCallback = null,
            Action<LinkedCollection, string> processLinkedCollectionCallback = null,
            Action<EmbeddedObject, string> processEmbeddedObjectCallback = null)
        {
            var resourceModel = startingResource.ResourceModel;

            string[] pathParts = pathExpression.Split(
                new[]
                {
                    "->", "."
                },
                StringSplitOptions.None);

            ResourceClassBase currentFilterModel = startingResource;

            foreach (string part in pathParts)
            {
                ResourceMemberBase member;

                // TODO: Embedded convention - reference properties end with "Reference" suffix
                if (!currentFilterModel.MemberByName.TryGetValue(part, out member)
                    && !currentFilterModel.MemberByName.TryGetValue(part.EnsureSuffixApplied("Reference"), out member))
                {
                    throw new Exception(
                        string.Format(
                            "Unable to find member '{0}' on resource class '{1}' for path '{2}' using path expression '{3}'.",
                            part,
                            currentFilterModel.Name,
                            string.IsNullOrEmpty(pathName)
                                ? "(unspecifed)"
                                : pathName,
                            pathExpression));
                }

                var property = member as ResourceProperty;

                if (property != null)
                {
                    if (processPropertyCallback != null)
                    {
                        processPropertyCallback(property, part);
                    }

                    break;
                }

                var reference = member as Reference;

                if (reference != null)
                {
                    // TODO: Embedded convention - reference properties end with "Reference" suffix
                    if (processReferenceCallback != null)
                    {
                        processReferenceCallback(reference, part.EnsureSuffixApplied("Reference"));
                    }

                    currentFilterModel = resourceModel.GetResourceByFullName(reference.ReferencedResource.Entity.FullName);
                    continue;
                }

                var linkedCollection = member as LinkedCollection;

                if (linkedCollection != null)
                {
                    if (processLinkedCollectionCallback != null)
                    {
                        processLinkedCollectionCallback(linkedCollection, part);
                    }

                    currentFilterModel = resourceModel.GetResourceByFullName(linkedCollection.Association.OtherEntity.FullName);
                    continue;
                }

                var collection = member as Collection;

                if (collection != null)
                {
                    if (processCollectionCallback != null)
                    {
                        processCollectionCallback(collection, part);
                    }

                    currentFilterModel = collection.ItemType;
                    continue;
                }

                var embeddedObject = member as EmbeddedObject;

                if (embeddedObject != null)
                {
                    if (processEmbeddedObjectCallback != null)
                    {
                        processEmbeddedObjectCallback(embeddedObject, part);
                    }

                    currentFilterModel = embeddedObject.ObjectType;
                    continue;
                }

                throw new NotSupportedException(
                    string.Format(
                        "Filter join implementation does not support resource model type '{0}'.",
                        member.GetType()
                              .FullName));
            }
        }
    }
}
