// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Common.Descriptors;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Infrastructure.Repositories;

public class DescriptorSurrogateKeyResolver : ISurrogateKeyResolver
{
    private readonly IDescriptorResolver _descriptorResolver;

    public DescriptorSurrogateKeyResolver(IDescriptorResolver descriptorResolver)
    {
        _descriptorResolver = descriptorResolver;
    }

    public Task<bool> TryResolveKeyAsync(Entity entity, object instance)
    {
        if (instance is IEdFiDescriptor descriptor)
        {
            // If already resolved, quit resolution process now
            if (descriptor.DescriptorId != default)
            {
                return Task.FromResult(true);
            }

            var uri = $"{descriptor.Namespace}#{descriptor.CodeValue}";

            int resolvedDescriptorId = _descriptorResolver.GetDescriptorId(entity.Name, uri);

            if (resolvedDescriptorId == 0)
            {
                // This should never happen
                throw new Exception($"The '{entity.Name}' value of '{uri}' could not be resolved to an existing descriptor.");
            }

            descriptor.DescriptorId = resolvedDescriptorId;
                
            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }
}
