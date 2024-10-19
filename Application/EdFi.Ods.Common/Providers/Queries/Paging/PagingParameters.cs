using System;

namespace EdFi.Ods.Common.Providers.Queries.Paging;

public class PagingParameters
{
    public PagingParameters() { }

    public PagingParameters(IQueryParameters queryParameters)
    {
        if (queryParameters.MinAggregateId != null && queryParameters.MaxAggregateId != null)
        {
            PageSize = queryParameters.PageSize;
            MinAggregateId = queryParameters.MinAggregateId;
            MaxAggregateId = queryParameters.MaxAggregateId;
            PagingStrategy = PagingStrategy.KeySet;
        }
        else
        {
            PagingStrategy = PagingStrategy.LimitOffset;
            Limit = queryParameters.Limit;
            Offset = queryParameters.Offset;
        }
    }

    /// <summary>
    /// Identifies which paging strategy is in use.
    /// </summary>
    public PagingStrategy PagingStrategy { get; init; }

    /// <summary>
    /// The number of items to skip before including items in the results. Used with offset paging.
    /// </summary>
    public int? Offset { get; init; }

    /// <summary>
    /// The maximum number of items to be returned in the results. Used with both offset and keyset paging.
    /// </summary>
    public int? Limit { get; init; }
        
    /// <summary>
    /// The inclusive minimum AggregateId to be applied to the query. Used with keyset paging.
    /// </summary>
    public int? MinAggregateId { get; init; }

    /// <summary>
    /// The inclusive maximum AggregateId to be applied to the query. Used with keyset paging.
    /// </summary>
    public int? MaxAggregateId { get; init; }
        
    /// <summary>
    /// The size of the page. Used with keyset paging.
    /// </summary>
    public int? PageSize { get; init; }
}