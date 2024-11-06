// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Models.Queries;

namespace EdFi.Ods.Common.Providers.Queries;

public static class QueryBuilderExtensions
{
    private const string ChangeVersion = "ChangeVersion";

    public static void ApplyChangeVersionCriteria(this QueryBuilder queryBuilder, IQueryParameters queryParameters)
    {
        if (queryParameters == null)
        {
            return;
        }

        if (queryParameters.MinChangeVersion.HasValue)
        {
            queryBuilder.Where(ChangeVersion, ">=", queryParameters.MinChangeVersion.Value);
        }

        if (queryParameters.MaxChangeVersion.HasValue)
        {
            queryBuilder.Where(ChangeVersion, "<=", queryParameters.MaxChangeVersion.Value);
        }
    }

    public static void ApplyQueryParameterCriteria(this QueryBuilder queryBuilder, IQueryParameters queryParameters)
    {
        if (queryParameters == null)
        {
            return;
        }

        foreach (IQueryCriteriaBase criteria in queryParameters.QueryCriteria)
        {
            if (criteria is TextCriteria textCriteria)
            {
                MatchMode mode;

                switch (textCriteria.MatchMode)
                {
                    case TextMatchMode.Anywhere:
                        mode = MatchMode.Anywhere;

                        break;

                    case TextMatchMode.Start:
                        mode = MatchMode.Start;

                        break;

                    case TextMatchMode.End:
                        mode = MatchMode.End;

                        break;

                    //case TextMatchMode.Exact:
                    default:
                        mode = MatchMode.Exact;

                        break;
                }

                queryBuilder.WhereLike(textCriteria.PropertyName, textCriteria.Value, mode);
            }
        }
    }
}
