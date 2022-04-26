// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database.NamingConventions;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems
{
    public class DeletedItemsQueryTemplatePreparer : TrackedChangesQueryTemplatePreparerBase, IDeletedItemsQueryTemplatePreparer
    {
        public DeletedItemsQueryTemplatePreparer(
            IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider,
            IDatabaseNamingConvention namingConvention,
            IDeletedItemsQueryBuilderFactory deletedItemsQueryBuilderFactory)
            : base(deletedItemsQueryBuilderFactory, defaultPageSizeLimitProvider, namingConvention) { }

        protected override QueryBuilder FinalizeDataQueryBuilder(
            QueryBuilder queryBuilder,
            IQueryParameters queryParameters,
            Resource resource)
        {
            ApplyPaging(queryBuilder, queryParameters);
            ApplyChangeVersionCriteria(queryBuilder, queryParameters);

            return queryBuilder;
        }
    }
}
