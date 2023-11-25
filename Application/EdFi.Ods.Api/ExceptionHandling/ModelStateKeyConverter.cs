// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using Autofac.Extras.DynamicProxy;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Api.ExceptionHandling;

[Intercept("cache-model-state-key")]
// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public class ModelStateKeyConverter
{
    public virtual string GetJsonPath(Resource resource, string key)
    {
        string jsonPath = string.Join('.', GetJsonPathParts(resource, key));
        
        if (key.StartsWith('$'))
        {
            return jsonPath;
        }
        
        return string.Concat("$.", jsonPath);
    }

    private static IEnumerable<string> GetJsonPathParts(Resource resource, string key)
    {
        ResourceClassBase currentResourceClass = resource;
        var pathParts = key.Split('.');

        bool isExtension = false;
        
        foreach (ReadOnlySpan<char> pathPart in pathParts)
        {
            // Look for indexer
            int indexerStart = pathPart.IndexOf('[');

            if (isExtension)
            {
                isExtension = false;
                var pathPartAsString = pathPart.ToString();
                yield return pathPartAsString;
                
                currentResourceClass = currentResourceClass.ExtensionByName[pathPartAsString].ObjectType;
            }
            else if (indexerStart >= 0)
            {
                int indexerEnd = pathPart.IndexOf(']');

                var indexSpan = pathPart.Slice(indexerStart, indexerEnd - indexerStart + 1);
                var nameSpan = pathPart.Slice(0, indexerStart);

                if (currentResourceClass.MemberByName.TryGetValue(nameSpan.ToString(), out var member))
                {
                    // Combine JSON property name with indexer
                    yield return string.Concat(member.JsonPropertyName, indexSpan.ToString());

                    currentResourceClass = (member as Collection).ItemType;
                }
                else
                {
                    // Return the path part provided (should not happen)
                    yield return pathPart.ToString();
                }
            }
            else if (pathPart.Equals("Extensions", StringComparison.Ordinal))
            {
                yield return "_ext";
                isExtension = true;
            }
            else if (currentResourceClass.MemberByName.TryGetValue(pathPart.ToString(), out var member))
            {
                yield return member.JsonPropertyName;

                switch (member)
                {
                    case EmbeddedObject embeddedObject:
                        currentResourceClass = embeddedObject.ObjectType;

                        break;

                    case Reference reference:
                        currentResourceClass = reference.ReferencedResource;

                        break;

                    case Extension extension:
                        currentResourceClass = extension.ObjectType;

                        break;
                }
            }
            else
            {
                // Return the text provided (should not happen)
                yield return pathPart.ToString();
            }
        }
    }
}
