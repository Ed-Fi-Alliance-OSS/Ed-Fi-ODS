// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Features.OpenApiMetadata.Dtos
{
    public class SwaggerResource : ISwaggerResourceContext
    {
        private string _name;

        private IEnumerable<ResourceProperty> _properties;

        public SwaggerResource(Resource resource)
        {
            Resource = resource;
            Description = resource.Description.EnhanceResourceDescription(resource.IsDeprecated, resource.DeprecationReasons);
        }

        protected SwaggerResource(SwaggerResource swaggerResource)
            : this(swaggerResource.Resource)
        {
            Name = swaggerResource.Name;
            RequestProperties = swaggerResource.RequestProperties;
            ContextualResource = swaggerResource.ContextualResource;
            Readable = swaggerResource.Readable;
            Writable = swaggerResource.Writable;
            IsProfileResource = swaggerResource.IsProfileResource;
            CompositeResourceContext = swaggerResource.CompositeResourceContext;
        }

        public string Name
        {
            get { return _name ?? Resource.Name; }
            set { _name = value; }
        }

        // Used only in the swagger document factory context.
        // TODO: JSM - Need to re-evaluate after the revised phase 3 changes come in for the resource model.
        public string NameWithoutContext => Name.ReplaceSuffix($"_{OperationNamingContext}", string.Empty);

        public IEnumerable<ResourceProperty> RequestProperties
        {
            get { return _properties ?? Resource.AllRequestProperties(); }
            set { _properties = value; }
        }

        public string Description { get; }

        public Resource Resource { get; }

        public bool Readable { get; set; }

        public bool Writable { get; set; }

        public bool IsCompositeResource => CompositeResourceContext != null;

        public bool IsProfileResource { get; set; }

        public CompositeResourceContext CompositeResourceContext { get; set; }

        public string OperationNamingContext => Readable == Writable || !IsProfileResource
            ? string.Empty
            : (Readable
                ? "Readable"
                : "Writable");

        public Resource ContextualResource { get; set; }
    }
}
