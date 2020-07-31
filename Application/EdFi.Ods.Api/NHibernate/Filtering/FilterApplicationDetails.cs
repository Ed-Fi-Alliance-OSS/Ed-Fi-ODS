// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using EdFi.Ods.Api.NHibernate.Architecture;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Engine;
using NHibernate.SqlCommand;
using NHibernate.Type;

namespace EdFi.Ods.Api.NHibernate.Filtering
{
    /// <summary>
    /// Provides details for how to apply a filter, including an NHibernate FilterDefinition and a predicate function for identifying which entity mappings are to be impacted.
    /// </summary>
    public class FilterApplicationDetails
    {
        private static readonly Regex ParameterRegex = new Regex(@"\:(?<Parameter>\w+)", RegexOptions.Compiled);

        /// <summary>
        /// Creates a new filter definition, creating parameter definitions automatically using built-in conventions
        /// based on information parsed from the supplied condition. 
        /// </summary>
        /// <param name="filterName">The name of the filter.</param>
        /// <param name="friendlyDefaultConditionFormat">The default condition (as SQL) for the filter with named format specifiers marking where distinct aliases are required (e.g. "(Column1 LIKE :Parm1 OR Column2 IN (SELECT {newAlias1}.Column2 FROM Table1 {newAlias1})").</param>
        /// <param name="friendlyHqlConditionFormat">The default condition (as HQL) for the filter with named format specifiers marking where distinct aliases are required, with {currentAlias} being the alias for the current entity in the context of the HQL query (e.g. "({currentAlias}.Property1 LIKE :Parm1 OR {currentAlias}.Property2 IN (SELECT {newAlias1}.Property2 FROM EntityOneQ {newAlias1})").</param>
        /// <param name="criteriaApplicator">A function to apply the filter to the query using NHibernate's <see cref="ICriteria"/> API.</param>
        /// <param name="shouldApply">A predicate function using a mapped entity's <see cref="Type"/> and properties used to determine whether the filter should be applied to a particular entity.</param>
        /// <remarks>This constructor makes some base level assumptions to simplify the declaration of the filters, but 
        /// it could lead to incorrect results.  For parameters with names equal to "Id" or with names ending with "Id",
        /// it assumes the use of SQL Server Table-Valued Parameters typed as GUID or 32-bit integers, respectively. 
        /// For parameters with names ending with "UniqueId" or "Date", it will use the <see cref="NHibernateUtil.String" /> 
        /// and <see cref="NHibernateUtil.DateTime" /> types respectively.  All other parameters will be created as 
        /// <see cref="NHibernateUtil.String" />.  If these conventions don't work for a particular filter definition, 
        /// use the other constructor overload.
        /// </remarks>
        public FilterApplicationDetails(
            string filterName,
            string friendlyDefaultConditionFormat,
            string friendlyHqlConditionFormat,
            Action<ICriteria, Junction, IDictionary<string, object>, JoinType> criteriaApplicator,
            Func<Type, PropertyInfo[], bool> shouldApply)
        {
            ShouldApply = shouldApply;
            CriteriaApplicator = criteriaApplicator;

            string defaultCondition = ProcessFormatStringForAliases(friendlyDefaultConditionFormat);

            var parameterNames = ParseDistinctParameterNames(friendlyDefaultConditionFormat);

            var parameters = parameterNames.ToDictionary(
                n => n,
                n =>
                {
                    // Handle entity Ids as a Table-Valued Parameter containing Guids
                    if (n == "Id")
                    {
                        return (IType) new SqlServerStructured<Guid>();
                    }

                    // Handle UniqueIds as strings
                    if (n.EndsWith("UniqueId"))
                    {
                        return (IType) NHibernateUtil.String;
                    }

                    // Handle properties with "Id" suffixes as a Table-Valued Parameter containing integers
                    if (n.EndsWith("Id"))
                    {
                        return (IType) new SqlServerStructured<int>();
                    }

                    // Handle dates
                    if (n.EndsWith("Date"))
                    {
                        return (IType) NHibernateUtil.DateTime;
                    }

                    // Treat everything else a string
                    return (IType) NHibernateUtil.String;
                },
                StringComparer.InvariantCultureIgnoreCase);

            FilterDefinition = new FilterDefinition(filterName, defaultCondition, parameters, false);
            HqlConditionFormatString = ProcessFormatStringForAliases(friendlyHqlConditionFormat);
        }

        /// <summary>
        /// Creates a new filter definition, using the supplied parameter definitions.
        /// </summary>
        /// <param name="filterName">The name of the filter.</param>
        /// <param name="friendlyDefaultConditionFormat">The default condition for the filter with numbered format specifiers marking where distinct aliases are required (e.g. "(Column1 LIKE :Parm1 OR Column2 IN (SELECT {0}.Column2 FROM Table1 {0})").</param>
        /// <param name="friendlyHqlConditionFormat">The default condition (as HQL) for the filter with numbered format specifiers marking where distinct aliases are required, with {0} being the current alias (e.g. "({0}.Property1 LIKE :Parm1 OR {0}.Property2 IN (SELECT {1}.Property2 FROM EntityOneQ {1})").</param>
        /// <param name="parameters">The named parameters and their data types (e.g. NHibernateUtil.String).</param>
        /// <param name="shouldApply">A predicate function using a mapped entity's <see cref="Type"/> and properties used to determine whether the filter should be applied to a particular entity.</param>
        public FilterApplicationDetails(
            string filterName,
            string friendlyDefaultConditionFormat,
            string friendlyHqlConditionFormat,
            IDictionary<string, IType> parameters,
            Func<Type, PropertyInfo[], bool> shouldApply)
        {
            ShouldApply = shouldApply;

            string defaultCondition = ProcessFormatStringForAliases(friendlyDefaultConditionFormat);

            FilterDefinition = new FilterDefinition(filterName, defaultCondition, parameters, false);
            HqlConditionFormatString = ProcessFormatStringForAliases(friendlyHqlConditionFormat);
        }

        /// <summary>
        /// Gets the NHibernate FilterDefinition to be added to the configuration.
        /// </summary>
        public FilterDefinition FilterDefinition { get; }

        /// <summary>
        /// Gets a format string containing the filter condition expressed as HQL rather than SQL, and with all new aliases assigned and the 'currentAlias' marker as the '{0}' format specifier.
        /// </summary>
        public string HqlConditionFormatString { get; }

        /// <summary>
        /// Gets the function for applying the filter using NHibernate's <see cref="ICriteria"/> API.
        /// </summary>
        public Action<ICriteria, Junction, IDictionary<string, object>, JoinType> CriteriaApplicator { get; }

        /// <summary>
        /// Gets the predicate functional for determining whether the filter should be applied to a particular entity.
        /// </summary>
        public Func<Type, PropertyInfo[], bool> ShouldApply { get; }

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

        private static IEnumerable<string> ParseDistinctParameterNames(string defaultCondition)
        {
            var matches = ParameterRegex.Matches(defaultCondition);

            var parameterNames = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);

            foreach (Match match in matches)
            {
                parameterNames.Add(
                    match.Groups["Parameter"]
                         .Value);
            }

            return parameterNames;
        }

        public override string ToString()
        {
            return string.Format(
                "Filter: {0} (Parameters: {1})",
                FilterDefinition.FilterName,
                string.Join(", ", FilterDefinition.ParameterNames));
        }
    }
}
