// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Text.RegularExpressions;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Infrastructure.Repositories;

namespace EdFi.Ods.Common.Models.Queries
{
    public partial class QueryParameters : IQueryParameters
    {
        // TODO: public string[] Fields { get; set; }

        private const int QueryExpressionMatchTimeoutMilliseconds = 1000;

        private string _q;

        // The q parameter comes from the client, so matching is bounded by a timeout.
        [GeneratedRegex(
            @"(?i)(?<PropertyName>[a-z]+)\:((?<NumericRange>(\[|\{)[\d]+\sto\s[\d]+(\]|\}))|(?<DateRange>\[\d{4}-\d{1,2}\-\d{1,2}\sto\s[\d\-]+\])|'(?<QuotedText>\*?[a-z\s]+\*?)'|(?<Text>\*?[a-z]+\*?))",
            RegexOptions.None,
            QueryExpressionMatchTimeoutMilliseconds)]
        private static partial Regex QueryExpressionRegex();

        public QueryParameters(UrlQueryParametersRequest parameters)
        {
            QueryCriteria = new List<IQueryCriteriaBase>();

            Offset = parameters.Offset;
            Limit = parameters.Limit;
            TotalCount = parameters.TotalCount;
            Q = parameters.Q;
            MinChangeVersion = parameters.MinChangeVersion;
            MaxChangeVersion = parameters.MaxChangeVersion;

            PageSize = parameters.PageSize;

            // Process the keyset paging page token, if supplied
            if (parameters.PageToken != null)
            {
                var range = PagingHelpers.GetAggregateIdRange(parameters.PageToken);
                MinAggregateId = range.minAggregateId;
                MaxAggregateId = range.maxAggregateId;
            }
        }

        public QueryParameters()
        {
            QueryCriteria = new List<IQueryCriteriaBase>();
        }

        /// <summary>
        /// Gets an empty instance of the <see cref="QueryParameters"/> class.
        /// </summary>
        public static QueryParameters Empty { get; } = new QueryParameters();

        public int? Offset { get; set; }

        public int? Limit { get; set; }

        public bool TotalCount { get; set; }

        public long? MinChangeVersion { get; set; }

        public long? MaxChangeVersion { get; set; }

        public int? PageSize { get; set; }

        public int? MinAggregateId { get; set; }

        public int? MaxAggregateId { get; set; }

        public string Q
        {
            get { return _q; }
            set
            {
                _q = value;

                if (_q == null)
                {
                    return;
                }

                var queryCriteria = new List<IQueryCriteriaBase>();

                var matches = QueryExpressionRegex().Matches(_q);

                try
                {
                    // MatchCollection is lazy; Count runs every match here so a timeout is handled below.
                    _ = matches.Count;
                }
                catch (RegexMatchTimeoutException ex)
                {
                    throw new BadRequestParameterException(
                        BadRequestException.DefaultDetail,
                        ["The query expression parameter 'q' could not be processed."],
                        ex);
                }

                foreach (Match match in matches)
                {
                    string propertyName = match.Groups["PropertyName"].Value;

                    // Supporting only non-quoted text searches for now
                    if (match.Groups["Text"].Success)
                    {
                        string text = match.Groups["Text"].Value;

                        bool leadingAsterisk = text[0] == '*';
                        bool trailingAsterisk = text[text.Length - 1] == '*';

                        string rawText = text.Trim('*');

                        var textCriteria = new TextCriteria
                        {
                            PropertyName = propertyName,
                            Value = rawText
                        };

                        if (leadingAsterisk && trailingAsterisk)
                        {
                            textCriteria.MatchMode = TextMatchMode.Anywhere;
                        }
                        else if (leadingAsterisk)
                        {
                            textCriteria.MatchMode = TextMatchMode.End;
                        }
                        else if (trailingAsterisk)
                        {
                            textCriteria.MatchMode = TextMatchMode.Start;
                        }
                        else
                        {
                            textCriteria.MatchMode = TextMatchMode.Exact;
                        }

                        queryCriteria.Add(textCriteria);
                    }
                }

                QueryCriteria = queryCriteria;
            }
        }

        public List<IQueryCriteriaBase> QueryCriteria { get; set; }
    }
}
