// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

namespace EdFi.Ods.Common.Infrastructure.Filtering
{
    /// <summary>
    /// Provides details for how to apply a filter, including an NHibernate FilterDefinition and a predicate function for identifying which entity mappings are to be impacted.
    /// </summary>
    public class AuthorizationFilterDefinition
    {
        // private static readonly Regex ParameterRegex = new Regex(@"\:(?<Parameter>\w+)", RegexOptions.Compiled);

        /// <summary>
        /// Creates a new filter definition, creating parameter definitions automatically using built-in conventions
        /// based on information parsed from the supplied condition.
        /// </summary>
        /// <param name="filterName">The name of the filter.</param>
        /// <param name="friendlyDefaultConditionFormat">The default condition (as SQL) for the filter with named format specifiers marking where distinct aliases are required (e.g. "(Column1 LIKE :Parm1 OR Column2 IN (SELECT {newAlias1}.Column2 FROM Table1 {newAlias1})").</param>
        /// <param name="friendlyHqlConditionFormat">The default condition (as HQL) for the filter with named format specifiers marking where distinct aliases are required, with {currentAlias} being the alias for the current entity in the context of the HQL query (e.g. "({currentAlias}.Property1 LIKE :Parm1 OR {currentAlias}.Property2 IN (SELECT {newAlias1}.Property2 FROM EntityOneQ {newAlias1})").</param>
        /// <param name="criteriaApplicator">A function to apply the filter to the query using NHibernate's <see cref="NHibernate.ICriteria"/> API.</param>
        /// <param name="authorizeInstance">A function that authorizes the instance contained in the authorization context data, or indicates that authorization cannot be performed without a trip to the database.</param>
        /// <param name="shouldApply">A predicate function using a mapped entity's <see cref="System.Type"/> and properties used to determine whether the filter should be applied to a particular entity.</param>
        /// <remarks>This constructor makes some base level assumptions to simplify the declaration of the filters, but
        /// it could lead to incorrect results.  For parameters with names equal to "Id" or with names ending with "Id",
        /// it assumes the use of SQL Server Table-Valued Parameters typed as GUID or 32-bit integers, respectively.
        /// For parameters with names ending with "UniqueId" or "Date", it will use the <see cref="NHibernate.NHibernateUtil.String" />
        /// and <see cref="NHibernate.NHibernateUtil.DateTime" /> types respectively.  All other parameters will be created as
        /// <see cref="NHibernate.NHibernateUtil.String" />.  If these conventions don't work for a particular filter definition,
        /// use the other constructor overload.
        /// </remarks>
        public AuthorizationFilterDefinition(
            string filterName,
            string friendlyDefaultConditionFormat, // TODO: GKM - Eliminate if truly unused
            string friendlyHqlConditionFormat,
            Action<ICriteria, Junction, IDictionary<string, object>, JoinType> criteriaApplicator,
            Func<EdFiAuthorizationContext, AuthorizationFilterContext, InstanceAuthorizationResult> authorizeInstance,
            Func<Type, PropertyInfo[], bool> shouldApply)
        {
            FilterName = filterName;
            HqlConditionFormatString = ProcessFormatStringForAliases(friendlyHqlConditionFormat);
            CriteriaApplicator = criteriaApplicator;
            AuthorizeInstance = authorizeInstance;
            ShouldApply = shouldApply;
        }

        public string FilterName { get; set; }

        // /// <summary>
        // /// Gets the NHibernate FilterDefinition to be added to the configuration.
        // /// </summary>
        // public FilterDefinition FilterDefinition { get; protected set; }

        /// <summary>
        /// Gets a format string containing the filter condition expressed as HQL rather than SQL, and with all new aliases assigned and the 'currentAlias' marker as the '{0}' format specifier.
        /// </summary>
        public string HqlConditionFormatString { get; protected set; }

        /// <summary>
        /// Gets the function for applying the filter using NHibernate's <see cref="NHibernate.ICriteria"/> API.
        /// </summary>
        public Action<ICriteria, Junction, IDictionary<string, object>, JoinType> CriteriaApplicator { get; protected set; }

        public Func<EdFiAuthorizationContext, AuthorizationFilterContext, InstanceAuthorizationResult> AuthorizeInstance { get; }

        /// <summary>
        /// Gets the predicate functional for determining whether the filter should be applied to a particular entity.
        /// </summary>
        public Func<Type, PropertyInfo[], bool> ShouldApply { get; protected set; }

        private static string ProcessFormatStringForAliases(string format)
        {
            Func<int, string> getFriendlyAliasKey = n => "{newAlias" + n + "}";
            var aliasGenerator = new AliasGenerator("fltr_", useSharedState: true);

            var parameterValues = new List<object>();

            if (format.Contains("{currentAlias}"))
            {
                // Leave the current alias parameter intact in the string after preparation as the {0} marker.
                format = format.Replace("{currentAlias}", "{0}");
                parameterValues.Add("{0}");
            }

            int newAliasNumber = 1;

            // Get the initial key to look for
            string friendlyAliasKey = getFriendlyAliasKey(newAliasNumber);

            while (format.Contains(friendlyAliasKey))
            {
                // Replace friendly alias marker with 0-based numeric format specifier
                format = format.Replace(getFriendlyAliasKey(newAliasNumber), "{" + parameterValues.Count + "}");

                // Add the corresponding value to the parameters
                parameterValues.Add(aliasGenerator.GetNextAlias());

                // Create the key for the next possible friendly parameter marker
                friendlyAliasKey = getFriendlyAliasKey(++newAliasNumber);
            }

            string defaultCondition = string.Format(format, parameterValues.ToArray());

            return defaultCondition;
        }

        public override string ToString()
        {
            return $"Filter: {FilterName}";
        }
    }
}
