// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Features.OpenApiMetadata.Dtos
{
    public class SwaggerDocumentContext
    {
        public SwaggerDocumentContext(IResourceModel resourceModel)
        {
            ResourceModel = resourceModel;
            IsIncludedExtension = x => true;
            RenderType = RenderType.AllWithStronglyTypedExtensions;
        }

        public IResourceModel ResourceModel { get; }

        public SwaggerProfileContext ProfileContext { get; set; }

        public SwaggerCompositeContext CompositeContext { get; set; }

        public bool IsProfileContext => ProfileContext != null;

        public bool IsCompositeContext => CompositeContext != null;

        /// <summary>
        /// Indicates whether generic extensions should be rendered
        /// Overrides the IsIncludedExtension behavior
        /// </summary>
        public RenderType RenderType { get; set; }

        public Func<ResourceClassBase, bool> IsIncludedExtension { get; set; }
    }

    /// <summary>
    /// Describes the rendering modes of the SwaggerDocumentFactory
    /// </summary>
    public enum RenderType
    {
        /// <summary>
        /// Default rendering mode that includes all resources, with strongly-typed extensions (for a tightly-coupled client-side SDK).
        /// </summary>
        AllWithStronglyTypedExtensions, /// <summary>
        /// Uses generalized extension collections (for a loosely-coupled client-side SDK).
        /// </summary>
        GeneralizedExtensions, /// <summary>
        /// Includes extension resources only and any model definitions for "entity extension" classes.
        /// </summary>
        ExtensionArtifactsOnly
    }
}
