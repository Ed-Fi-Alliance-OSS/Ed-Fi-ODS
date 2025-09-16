using System;
using System.Threading;
using System.Threading.Tasks;

namespace EdFi.Ods.Common.Caching.SingleFlight;

public interface ISingleFlightCache<TKey, TValue>
{
    // Return cached value or compute it using the factory.
    Task<TValue> GetOrCreateAsync<TArg>(
        TKey key,
        Func<TKey, TArg, CancellationToken, Task<TValue>> factory,
        TArg factoryArgument,
        TimeSpan singleFlightTimeout,
        CancellationToken cancellationToken);
    
    TValue GetOrCreate<TArg>(
        TKey key,
        Func<TKey, TArg, TValue> factory,
        TArg factoryArgument,
        TimeSpan singleFlightTimeout,
        CancellationToken cancellationToken);
}
