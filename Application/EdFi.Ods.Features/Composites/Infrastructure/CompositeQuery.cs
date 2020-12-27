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
        private readonly Lazy<IDictionary<string, List<IDictionary<string, object>>>> _dataByParentKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeQuery"/> class for a
        /// root composite query.
        /// </summary>
        /// <param name="displayName">The name to be used for the collection of data represented by the composite query.</param>
        /// <param name="orderedFieldNames">The names of the fields in selection order.</param>
        /// <param name="futureQuery">The results of the query, exposed by NHibernate as a collection of <see cref="Hashtable"/> instances.</param>
        /// <param name="isSingleItemResult">Indicates that the results should be treated as a single result in the output.</param>
        public CompositeQuery(
            string displayName,
            string[] orderedFieldNames,
            IEnumerable<object> futureQuery,
            bool isSingleItemResult)
            : this(null, displayName, orderedFieldNames, futureQuery, isSingleItemResult) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeQuery"/> class for a
        /// non-root composite query.
        /// </summary>
        /// <param name="parentCompositeQuery">The composite query that provides the data for the next level up in the composite resource.</param>
        /// <param name="displayName">The name to be used for the collection of data represented by the composite query.</param>
        /// <param name="orderedFieldNames">The names of the fields in selection order.</param>
        /// <param name="futureQuery">The results of the query, exposed by NHibernate as a collection of <see cref="Hashtable"/> instances.</param>
        /// <param name="isSingleItemResult">Indicates that the results should be treated as a single result in the output.</param>
        public CompositeQuery(
            CompositeQuery parentCompositeQuery,
            string displayName,
            string[] orderedFieldNames,
            IEnumerable<object> futureQuery,
            bool isSingleItemResult)
        {
            DisplayName = displayName;
            OrderedFieldNames = orderedFieldNames;
            IsSingleItemResult = isSingleItemResult;

            _parentCompositeQuery = parentCompositeQuery;

            _keyFields = new Lazy<string[]>(() => GetKeyFields(_futureQueryEnumerator.Value));
            _dataFields = new Lazy<string[]>(() => GetDataFields(_futureQueryEnumerator.Value));

            _dataByParentKey = new Lazy<IDictionary<string, List<IDictionary<string, object>>>>(() => GetDataByParentKey(_futureQueryEnumerator.Value));

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

        private bool RequiresDataReordering
        {
            get
            {
                if (_parentCompositeQuery != null
                    && (_parentCompositeQuery.RequiresDataReordering))
                {
                    return true;
                }

                return false;
            }
        }

        private Dictionary<string, List<IDictionary<string, object>>> GetDataByParentKey(IEnumerator enumerator)
        {
            if (_parentCompositeQuery == null)
            {
                return new Dictionary<string, List<IDictionary<string, object>>>();
            }

            var rows = new List<IDictionary<string, object>>();

            // Handle empty resultset
            if (enumerator.Current == null)
            {
                return new Dictionary<string, List<IDictionary<string, object>>>();
            }

            // Load all data from the query into memory
            do
            {
                rows.Add((IDictionary<string, object>) enumerator.Current);
            }
            while (enumerator.MoveNext());

            // Group data by the parent's key
            return rows.GroupBy(GetParentKey)
                       .Select(g => g)
                       .ToDictionary(x => x.Key, x => x.ToList());
        }

        private static string[] GetDataFields(IEnumerator enumerator)
        {
            var hashMap = enumerator?.Current as IDictionary<string, object>;

            return hashMap == null
                ? new string[0]
                : hashMap
                 .Keys.Cast<string>()
                 .Where(x => !x.StartsWith("PK"))
                 .ToArray();
        }

        private static string[] GetKeyFields(IEnumerator enumerator)
        {
            var hashMap = enumerator?.Current as IDictionary<string, object>;

            return hashMap == null
                ? new string[0]
                : hashMap.Keys
                         .Cast<string>()
                         .Where(x => x.StartsWith("PK"))
                         .OrderBy(x => x) // Need consistent ordering for hierarchical processing
                         .ToArray();
        }

        private string GetParentKey(IDictionary<string, object> row)
        {
            return _parentCompositeQuery == null
                ? null
                : string.Join("|", _parentCompositeQuery.KeyFields.Select(kf => row[kf]));
        }

        public IEnumeratorWithCompletion GetEnumerator(IDictionary<string, object> parentRow)
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

            var enumerator = currentContextualData.GetEnumerator();

            // Start the enumerator
            return enumerator.MoveNext()
                ? new EnumeratorWithCompletionWrapper(enumerator)
                : null;
        }
    }
}
