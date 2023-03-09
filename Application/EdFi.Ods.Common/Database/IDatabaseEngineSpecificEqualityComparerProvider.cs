using System.Collections.Generic;
using Autofac.Builder;
using EdFi.Common.Configuration;

namespace EdFi.Ods.Common.Database
{
    /// <summary>
    /// Provides a method for getting an <see cref="System.Collections.Generic.IEqualityComparer{T}" /> 
    /// that aligns with the default collation of the database engine currently in use.
    /// </summary>
    /// <remarks>
    /// <typeparam nam ="T" >
    /// The type of entities to be compared by the 
    /// <see cref="System.Collections.Generic.IEqualityComparer{T}" />. 
    /// </typeparam>
    /// </remarks>
    public  interface IDatabaseEngineSpecificEqualityComparerProvider<in T>
    {

        /// <summary>
        /// Returns an instance of a <see cref="System.Collections.Generic.IEqualityComparer{T}" /> 
        /// that aligns with the default collation of the database engine currently in use.
        /// </summary>
        /// <returns>
        /// The type of entities to be compared by the 
        /// <see cref="System.Collections.Generic.IEqualityComparer{T}" />.
        /// <typeparamref name="T"/>
        /// </returns>
        public IEqualityComparer<T> GetEqualityComparer ();
    }
}
