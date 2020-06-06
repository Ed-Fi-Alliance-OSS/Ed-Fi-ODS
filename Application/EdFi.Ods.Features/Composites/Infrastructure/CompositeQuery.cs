// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Features.Composites.Infrastructure
{
    public class CompositeQuery
    {
        private readonly Lazy<string[]> _dataFields;
        private readonly Lazy<IEnumeratorWithCompletion> _futureQueryEnumerator;
        private readonly Lazy<string[]> _keyFields;
        private readonly CompositeQuery _parentCompositeQuery;
        private readonly Lazy<IDictionary<string, string>> _recursiveChildKeyMap;
        private readonly Lazy<IDictionary<string, List<Hashtable>>> _dataByParentKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeQuery"/> class for a 
        /// root composite query.
        /// </summary>
        /// <param name="displayName">The name to be used for the collection of data represented by the composite query.</param>
        /// <param name="orderedFieldNames">The names of the fields in selection order.</param>
        /// <param name="futureQuery">The results of the query, exposed by NHibernate as a collection of <see cref="System.Collections.Hashtable"/> instances.</param>
        /// <param name="isSingleItemResult">Indicates that the results should be treated as a single result in the output.</param>
        public CompositeQuery(
            string displayName,
            string[] orderedFieldNames,
            IEnumerable<object> futureQuery,
            bool isSingleItemResult)
            : this(null, displayName, orderedFieldNames, futureQuery, isSingleItemResult, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeQuery"/> class for a 
        /// non-root composite query.
        /// </summary>
        /// <param name="parentCompositeQuery">The composite query that provides the data for the next level up in the composite resource.</param>
        /// <param name="displayName">The name to be used for the collection of data represented by the composite query.</param>
        /// <param name="orderedFieldNames">The names of the fields in selection order.</param>
        /// <param name="futureQuery">The results of the query, exposed by NHibernate as a collection of <see cref="System.Collections.Hashtable"/> instances.</param>
        /// <param name="isSingleItemResult">Indicates that the results should be treated as a single result in the output.</param>
        public CompositeQuery(
            CompositeQuery parentCompositeQuery,
            string displayName,
            string[] orderedFieldNames,
            IEnumerable<object> futureQuery,
            bool isSingleItemResult)
            : this(parentCompositeQuery, displayName, orderedFieldNames, futureQuery, isSingleItemResult, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeQuery"/> class for a
        /// non-root composite query that is recursive, specifying the child instance's join keys
        /// for the recursion.
        /// </summary>
        /// <param name="parentCompositeQuery">The composite query that provides the data for the next level up in the composite resource.</param>
        /// <param name="displayName">The name to be used for the collection of data represented by the composite query.</param>
        /// <param name="orderedFieldNames">The names of the fields in selection order.</param>
        /// <param name="futureQuery">The results of the query, exposed by NHibernate as a collection of <see cref="System.Collections.Hashtable"/> instances.</param>
        /// <param name="isSingleItemResult">Indicates that the results should be treated as a single result in the output.</param>
        /// <param name="recursiveChildKeyMap">For recursive relationship, contains the names of the child instance's keys by parent key name for performing the appropriate join for recursion.</param>
        public CompositeQuery(
            CompositeQuery parentCompositeQuery,
            string displayName,
            string[] orderedFieldNames,
            IEnumerable<object> futureQuery,
            bool isSingleItemResult,
            IDictionary<string, string> recursiveChildKeyMap)
        {
            DisplayName = displayName;
            OrderedFieldNames = orderedFieldNames;
            IsSingleItemResult = isSingleItemResult;

            IsRecursive = recursiveChildKeyMap != null;

            _parentCompositeQuery = parentCompositeQuery;

            _keyFields = new Lazy<string[]>(() => GetKeyFields(_futureQueryEnumerator.Value));
            _dataFields = new Lazy<string[]>(() => GetDataFields(_futureQueryEnumerator.Value));

            _dataByParentKey = new Lazy<IDictionary<string, List<Hashtable>>>(() => GetDataByParentKey(_futureQueryEnumerator.Value));

            _recursiveChildKeyMap = new Lazy<IDictionary<string, string>>(() => GetRecursiveChildMap(recursiveChildKeyMap));

            _futureQueryEnumerator = new Lazy<IEnumeratorWithCompletion>(
                () =>
                {
                    var enumerator = futureQuery.GetEnumerator();
                    
                    if (enumerator.MoveNext())
                        return new EnumeratorWithCompletionWrapper(enumerator);

                    return null;
                });

            ChildQueries = new List<CompositeQuery>();
        }

        public string DisplayName { get; }

        public string[] OrderedFieldNames { get; set; }

        public bool IsSingleItemResult { get; set; }

        public string[] KeyFields => _keyFields.Value;

        public string[] DataFields => _dataFields.Value;

        public List<CompositeQuery> ChildQueries { get; }

        public IDictionary<string, string> RecursiveChildKeyMap => _recursiveChildKeyMap.Value;

        public bool IsRecursive { get; }

        private bool RequiresDataReordering
        {
            get
            {
                if (_parentCompositeQuery != null
                    && (IsRecursive || _parentCompositeQuery.RequiresDataReordering))
                {
                    return true;
                }

                return false;
            }
        }

        private IDictionary<string, string> GetRecursiveChildMap(IDictionary<string, string> recursiveChildKeyMap)
        {
            return recursiveChildKeyMap?
                  .Select(
                       kvp => new
                              {
                                  Key = KeyFields.SingleOrDefault(x => x.Split('_')[1] == kvp.Key), DistinctChildKey = kvp.Key == kvp.Value
                                      ? null
                                      : DataFields.SingleOrDefault(x => x.EqualsIgnoreCase("H_" + kvp.Value))
                              })
                  .ToDictionary(x => x.Key, x => x.DistinctChildKey ?? x.Key, StringComparer.InvariantCultureIgnoreCase);
        }

        private Dictionary<string, List<Hashtable>> GetDataByParentKey(IEnumerator enumerator)
        {
            if (_parentCompositeQuery == null)
            {
                return new Dictionary<string, List<Hashtable>>();
            }

            var rows = new List<Hashtable>();

            // Handle empty resultset
            if (enumerator.Current == null)
            {
                return new Dictionary<string, List<Hashtable>>();
            }

            // Load all data from the query into memory
            do
            {
                rows.Add((Hashtable) enumerator.Current);
            }
            while (enumerator.MoveNext());

            // Group data by the parent's key
            return rows.GroupBy(GetParentKey)
                       .Select(g => g)
                       .ToDictionary(x => x.Key, x => x.ToList());
        }

        private static string[] GetDataFields(IEnumerator enumerator)
        {
            var hashMap = enumerator?.Current as Hashtable;

            return hashMap == null
                ? new string[0]
                : hashMap
                 .Keys.Cast<string>()
                 .Where(x => !x.StartsWith("PK"))
                 .ToArray();
        }

        private static string[] GetKeyFields(IEnumerator enumerator)
        {
            var hashMap = enumerator?.Current as Hashtable;

            return hashMap == null
                ? new string[0]
                : hashMap.Keys
                         .Cast<string>()
                         .Where(x => x.StartsWith("PK"))
                         .OrderBy(x => x) // Need consistent ordering for hierarchical processing
                         .ToArray();
        }

        private string GetParentKey(Hashtable row)
        {
            return _parentCompositeQuery == null
                ? null
                : string.Join("|", _parentCompositeQuery.KeyFields.Select(kf => row[kf]));
        }

        public IEnumeratorWithCompletion GetEnumerator(Hashtable parentRow, string[] parentKeys, IDictionary<string, string> recursiveChildKeyMap)
        {
            // For results that are in order for correct processing, the request for 
            // the enumerator always returns the underlying result enumerator
            if (!RequiresDataReordering)
            {
                return _futureQueryEnumerator.Value;
            }

            string currentParentContextKey = GetParentKey(parentRow);
            var currentContextualData = _dataByParentKey.Value.GetValueOrDefault(currentParentContextKey);

            // No data to process... then just return an empty enumerator
            if (currentContextualData == null)
            {
                return null;
            }

            IEnumerator enumerator;

            // Not a recursive query - Use the grouped list's enumerator
            if (!IsRecursive)
            {
                enumerator = currentContextualData.GetEnumerator();

                // Start the enumerator
                return enumerator.MoveNext()
                    ? new EnumeratorWithCompletionWrapper(enumerator)
                    : null;
            }

            // Get the hashtable's keys to an enumerable type for recursive call
            string[] parentRowKeys = new string[parentRow.Keys.Count];
            parentRow.Keys.CopyTo(parentRowKeys, 0);

            // Filter the data for the enumerator based on the recursive parent
            enumerator = currentContextualData
                        .Where(currentRow => IsChildRow(parentKeys, parentRow, currentRow))
                        .ToList()
                        .GetEnumerator();

            return enumerator.MoveNext()
                ? new EnumeratorWithCompletionWrapper(enumerator)
                : null;
        }

        private bool IsChildRow(string[] parentKeys, Hashtable parentRow, Hashtable currentRow)
        {
            // If no explicit key fields for the children are provided, match values based on name.
            if (!IsRecursive)
            {
                return parentKeys.All(k => Equals(parentRow[k], currentRow[k]));
            }

            // Is this a non-top level scenario?
            if (RecursiveChildKeyMap.Keys.All(parentKeys.Contains))
            {
                // Explicit child keys have been provided, so match based on values retrieved by name, but positionally for the child
                bool result1 = RecursiveChildKeyMap
                              .Select(
                                   kvp =>
                                       new
                                       {
                                           ParentKeyValue = parentRow[kvp.Key], ChildKeyValue = currentRow[kvp.Value]
                                       })
                              .All(x => Equals(x.ParentKeyValue, x.ChildKeyValue));

                return result1;
            }

            // Explicit child keys have been provided, so match based on values retrieved by name, but positionally for the child
            bool result2 = parentKeys.All(k => Equals(parentRow[k], currentRow[k]))
                           && RecursiveChildKeyMap.Where(x => x.Key != x.Value)
                                                  .All(x => currentRow[x.Value] == null);

            return result2;
        }
    }
}
