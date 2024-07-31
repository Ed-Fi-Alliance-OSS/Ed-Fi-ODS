using System;
using System.Collections.Concurrent;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Infrastructure.Interceptors;
using Standart.Hash.xxHash;

namespace EdFi.Ods.Common.Security.CustomViewBased;

public static class CustomViewHelpers
{
    private static readonly ConcurrentDictionary<string, string> _authViewAliasPrefixByName = new();
    private static readonly ConcurrentDictionary<string, string> _viewNameByAuthViewAliasPrefix = new();

    public const string CustomViewAliasPrefixBase = "acvw_";
    
    /// <summary>
    /// Gets a unique alias prefix to be used with the supplied view name to help identify it in the database engine-specific
    /// SQL produced by NHibernate for subsequent manipulation by the <see cref="EdFiOdsInterceptor"/>.
    /// </summary>
    /// <param name="viewName">The name of the view to be aliased.</param>
    /// <returns>The view-specific alias prefix for use in SQL generation.</returns>
    public static string GetAliasPrefix(string viewName)
    {
        string aliasPrefix = _authViewAliasPrefixByName.GetOrAdd(
            viewName,
            vn =>
            {
                var bytes = viewName.GetBytes();
                uint hash = xxHash32.ComputeHash(bytes, bytes.Length);

                uint hashShort = (ushort)(hash & 0xFFFF);
                string prefix = $"{CustomViewAliasPrefixBase}{hashShort:x}_";

                // Add the reverse entry
                _viewNameByAuthViewAliasPrefix.TryAdd(prefix, vn);

                return prefix;
            });

        return aliasPrefix;
    }

    /// <summary>
    /// Performs a reverse lookup for a previously generated view-specific alias prefix.
    /// </summary>
    /// <param name="aliasPrefix">The alias prefix for which the corresponding view name should be returned.</param>
    /// <returns>The view name corresponding to the supplied alias prefix.</returns>
    /// <exception cref="Exception">Occurs when the view name cannot be identified for the supplied alias prefix.</exception>
    public static string GetViewName(string aliasPrefix)
    {
        if (_viewNameByAuthViewAliasPrefix.TryGetValue(aliasPrefix, out string viewName))
        {
            return viewName;
        }

        throw new Exception($"Unable to find view name for alias prefix '{aliasPrefix}'.");
    }
}
