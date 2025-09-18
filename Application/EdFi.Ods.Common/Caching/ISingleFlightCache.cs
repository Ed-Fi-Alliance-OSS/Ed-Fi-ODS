using System;
using System.Threading;
using System.Threading.Tasks;

namespace EdFi.Ods.Common.Caching.SingleFlight;

/// <summary>
/// Represents a cache abstraction that prevents duplicate concurrent requests for the same resource,
/// ensuring that only a single computation or retrieval is initiated per unique key at any time.
/// </summary>
/// <typeparam name="TKey">The type of the key used to look up cached values.</typeparam>
/// <typeparam name="TValue">The type of the values cached.</typeparam>
public interface ISingleFlightCache<TKey, TValue>
{
    /// <summary>
    /// Retrieves a cached value associated with the specified key if available;
    /// otherwise, computes the value using the provided factory function. Ensures that
    /// only a single computation or retrieval is initiated per unique key at any time.
    /// </summary>
    /// <typeparam name="TArg">The type of the additional argument passed to the factory function.</typeparam>
    /// <param name="key">The key used to look up cached values or to cache a new value.</param>
    /// <param name="factory">
    /// A factory function that computes or retrieves the value if it is not already cached.
    /// The function takes the key, an additional argument, and a cancellation token as parameters.
    /// </param>
    /// <param name="factoryArgument">An additional argument to pass to the factory function.</param>
    /// <param name="callerToken">A cancellation token to propagate notification that the operation should be canceled.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the cached value associated with the specified key.
    /// </returns>
    Task<TValue> GetOrCreateAsync<TArg>(
        TKey key,
        Func<TKey, TArg, CancellationToken, Task<TValue>> factory,
        TArg factoryArgument,
        CancellationToken callerToken);
}
