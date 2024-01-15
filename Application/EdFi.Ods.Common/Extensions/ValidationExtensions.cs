// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Validation;

namespace EdFi.Ods.Common.Extensions;

public static class ValidationExtensions
{
    /// <summary>
    /// Prepends the path from the "path builder" in the validation context's items to validation context's MemberName
    /// property to produce the full path in the object graph to the member. 
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns>The full path to the member.</returns>
    public static string MemberNamePath(this ValidationContext validationContext)
    {
        var pathBuilder = ValidationHelpers.GetPathBuilder(validationContext);

        if (pathBuilder.Length == 0)
        {
            return validationContext.MemberName;
        }
        
        return $"{pathBuilder}.{validationContext.MemberName}";
    }

    /// <summary>
    /// Creates a new dictionary of items from the one provided for the parent's <see cref="ValidationContext" /> with the
    /// collection's associated resource class model applied. 
    /// </summary>
    /// <param name="items">The items from the parent context, containing the parent's resource class.</param>
    /// <param name="collectionPropertyName">The name of the collection property for obtaining the associated resource class.</param>
    /// <returns>The new items to be used for a new <see cref="ValidationContext" />.</returns>
    public static IDictionary<object, object> ForCollection(
        this IDictionary<object, object> items,
        string collectionPropertyName)
    {
        if (items.TryGetValue(ValidationContextKeys.ResourceClass, out var resourceClassAsObject))
        {
            if (resourceClassAsObject is ResourceClassBase resourceClass)
            {
                if (resourceClass.CollectionByName.TryGetValue(collectionPropertyName, out var collection))
                {
                    // Create a new dictionary for each validation context
                    return new Dictionary<object, object>(items
                        .Where(kvp => (kvp.Key as string) != ValidationContextKeys.ResourceClass)
                        .Prepend(new KeyValuePair<object, object>(ValidationContextKeys.ResourceClass, collection.ItemType)));

                    // Alternative approach: reuse same Items for every validation, but then reset to containing resource class after each collection/embedded object validation tree completes
                    // items[ValidationContextKeys.ResourceClass] = collection.ItemType;
                }
            }
        }

        return items;
    }

    /// <summary>
    /// Creates a new dictionary of items from the one provided for the parent's <see cref="ValidationContext" /> with the
    /// embedded object's associated resource class model applied. 
    /// </summary>
    /// <param name="items">The items from the parent context, containing the parent's resource class.</param>
    /// <param name="embeddedObjectPropertyName">The name of the embedded object property for obtaining the associated resource class.</param>
    /// <returns>The new items to be used for a new <see cref="ValidationContext" />.</returns>
    public static IDictionary<object, object> ForEmbeddedObject(
        this IDictionary<object, object> items,
        string embeddedObjectPropertyName)
    {
        if (items.TryGetValue(ValidationContextKeys.ResourceClass, out var resourceClassAsObject))
        {
            if (resourceClassAsObject is ResourceClassBase resourceClass)
            {
                if (resourceClass.EmbeddedObjectByName.TryGetValue(embeddedObjectPropertyName, out var embeddedObject))
                {
                    // Create a new dictionary for each validation context
                    return new Dictionary<object, object>(items
                        .Where(kvp => (kvp.Key as string) != ValidationContextKeys.ResourceClass)
                        .Prepend(new KeyValuePair<object, object>(ValidationContextKeys.ResourceClass, embeddedObject.ObjectType)));

                    // Alternative approach: reuse same Items for every validation, but then reset to containing resource class after each collection/embedded object validation tree completes
                    // items[ValidationContextKeys.ResourceClass] = embeddedObject.ObjectType;
                }
            }
        }

        return items;
    }

    /// <summary>
    /// Creates a new dictionary of items from the one provided for the parent's <see cref="ValidationContext" /> with the
    /// extension's associated resource class model applied. 
    /// </summary>
    /// <param name="items">The items from the parent context, containing the parent's resource class.</param>
    /// <param name="extensionPropertyName">The name of the extension for obtaining the extension's associated resource class.</param>
    /// <returns>The new items to be used for a new <see cref="ValidationContext" />.</returns>
    public static IDictionary<object, object> ForExtension(
        this IDictionary<object, object> items,
        string extensionPropertyName)
    {
        if (items.TryGetValue(ValidationContextKeys.ResourceClass, out var resourceClassAsObject))
        {
            if (resourceClassAsObject is ResourceClassBase resourceClass)
            {
                if (resourceClass.ExtensionByName.TryGetValue(extensionPropertyName, out var extension))
                {
                    // Create a new dictionary for each validation context
                    return new Dictionary<object, object>(items
                        .Where(kvp => (kvp.Key as string) != ValidationContextKeys.ResourceClass)
                        .Prepend(new KeyValuePair<object, object>(ValidationContextKeys.ResourceClass, extension.ObjectType)));

                    // Alternative approach: reuse same Items for every validation, but then reset to containing resource class after each collection/embedded object validation tree completes
                    // items[ValidationContextKeys.ResourceClass] = extension.ObjectType;
                }
            }
        }

        return items;
    }
}
