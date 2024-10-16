// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Api.Infrastructure.Pipelines;
using EdFi.Ods.Common.Repositories;

namespace EdFi.Ods.Common.Infrastructure.Pipelines.GetMany
{
    public class GetManyContext<TResourceModel, TEntityModel>
        : IHasPersistentModel<TEntityModel>, IHasPersistentModels<TEntityModel>,
            IHasResource<TResourceModel> 
        where TResourceModel : IHasETag
        where TEntityModel : class, IMappable
    {
        public GetManyContext(
            TResourceModel resourceSpecification,
            IQueryParameters queryParameters,
            IDictionary<string, string> additionalParameters)
        {
            Resource = resourceSpecification;
            QueryParameters = queryParameters;
            AdditionalParameters = additionalParameters;
        }

        /// <summary>
        ///     Gets or sets additional query parameters to apply to the search/filter.
        /// </summary>
        public IQueryParameters QueryParameters { get; set; }

        /// <summary>
        /// Gets or sets additional parameters supplied by the API client that are not recognized as common parameters or members of the resource.
        /// </summary>
        public IDictionary<string, string> AdditionalParameters { get; set; }

        /// <summary>
        ///     Gets or sets the persistent model to be used as a specification for the query.
        /// </summary>
        public TEntityModel PersistentModel { get; set; }

        /// <summary>
        ///     Gets or sets the list of persistent models retrieved from storage.
        /// </summary>
        public IList<ResultItem<TEntityModel>> PersistentModels { get; set; }

        /// <summary>
        ///     Gets or sets the resource model to be used as a specification for the query.
        /// </summary>
        public TResourceModel Resource { get; set; }
    }
}
