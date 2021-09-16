// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Common.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters
{
    public static class ICriteriaExtensions
    {
        /// <summary>
        /// Applies a join-based filter to the criteria for the specified authorization view.
        /// </summary>
        /// <param name="criteria">The criteria to which filters should be applied.</param>
        /// <param name="whereJunction">The <see cref="ICriterion" /> container for adding WHERE clause criterion.</param>
        /// <param name="parameters">The named parameters to be used to satisfy additional filtering requirements.</param>
        /// <param name="viewName">The name of the view to be filtered.</param>
        /// <param name="joinPropertyName">The name of the property to be joined between the entity being queried and the authorization view.</param>
        /// <param name="filterPropertyName">The name of the property to be used for applying filter values.</param>
        /// <param name="joinType">The <see cref="JoinType" /> to be used.</param>
        /// <param name="authViewAlias">The name of the property to be used for auth View Alias name.</param>
        public static void ApplyJoinFilter(
            this ICriteria criteria,
            Junction whereJunction,
            IDictionary<string, object> parameters,
            string viewName,
            string joinPropertyName,
            string filterPropertyName,
            JoinType joinType,
            string authViewAlias = null)
        {
            string entityName = $"{viewName.GetAuthorizationTableClassName()}".GetFullNameForTable();

            if (viewName.ContainsIgnoreCase("EducationOrganizationIdToEducationOrganizationId"))
            {
                authViewAlias = $"authTable{viewName}";
                entityName = $"{viewName.GetAuthorizationViewClassName()}".GetFullNameForView();
            }
            else if (!string.IsNullOrWhiteSpace(authViewAlias))
            {
                authViewAlias = $"authView{authViewAlias}";
            }
            else
            {
                authViewAlias = $"authView{viewName}";
            }

            // Apply authorization join using ICriteria
            criteria.CreateEntityAlias(
                authViewAlias,
                Restrictions.EqProperty($"aggregateRoot.{joinPropertyName}", $"{authViewAlias}.{joinPropertyName}"),
                joinType, entityName);

            object value;

            // Defensive check to ensure required parameter is present
            if (!parameters.TryGetValue(filterPropertyName, out value))
            {
                throw new Exception($"Unable to find parameter for filtering '{filterPropertyName}' on view '{viewName}'.");
            }

            var arrayOfValues = value as object[];

            if (arrayOfValues != null)
            {
                if (joinType == JoinType.InnerJoin)
                {
                    whereJunction.Add(Restrictions.In($"{authViewAlias}.{filterPropertyName}", arrayOfValues));
                }
                else
                {
                    var and = new AndExpression(
                        Restrictions.In($"{authViewAlias}.{filterPropertyName}", arrayOfValues),
                        Restrictions.IsNotNull($"{authViewAlias}.{joinPropertyName}"));

                    whereJunction.Add(and);
                }
            }
            else
            {
                if (joinType == JoinType.InnerJoin)
                {
                    whereJunction.Add(Restrictions.Eq($"{authViewAlias}.{filterPropertyName}", value));
                }
                else
                {
                    var and = new AndExpression(
                        Restrictions.Eq($"{authViewAlias}.{filterPropertyName}", value),
                        Restrictions.IsNotNull($"{authViewAlias}.{joinPropertyName}"));

                    whereJunction.Add(and);
                }
            }
        }

        private static string GetFullNameForView(this string viewName)
        {
            return Namespaces.Entities.NHibernate.QueryModels.GetViewNamespace(viewName);
        }

        private static string GetFullNameForTable(this string tableName)
        {
            return Namespaces.Entities.NHibernate.QueryModels.GetTableNamespace(tableName);
        }
    }
}
