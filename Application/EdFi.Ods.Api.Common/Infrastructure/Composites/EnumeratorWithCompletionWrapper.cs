// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;
using EdFi.Ods.Common;

namespace EdFi.Ods.Api.Common.Infrastructure.Composites
{
    /// <summary>
    /// Provides an implementation of <see cref="IEnumeratorWithCompletion" /> that wraps an existing enumerator
    /// and monitors usage and results of the <see cref="MoveNext" /> method to determine and expose completion state.
    /// </summary>
    public class EnumeratorWithCompletionWrapper : IEnumeratorWithCompletion
    {
        private readonly IEnumerator _wrappedEnumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumeratorWithCompletionWrapper" /> class using the supplied
        /// enumerator to be wrapped.
        /// </summary>
        /// <param name="wrappedEnumerator">The enumerator to wrap and watch for completion status during enumeration.</param>
        public EnumeratorWithCompletionWrapper(IEnumerator wrappedEnumerator)
        {
            _wrappedEnumerator = Preconditions.ThrowIfNull(wrappedEnumerator, nameof(wrappedEnumerator));
        }

        /// <summary>Advances the enumerator to the next element of the collection.</summary>
        /// <returns>
        /// <see langword="true" /> if the enumerator was successfully advanced to the next element; <see langword="false" /> if the enumerator has passed the end of the collection.</returns>
        /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created.</exception>
        public bool MoveNext()
        {
            bool result = _wrappedEnumerator.MoveNext();
            IsComplete = result == false;
            return result;
        }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the collection.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created.</exception>
        public void Reset()
        {
            IsComplete = false;
            _wrappedEnumerator.Reset();
        }

        /// <summary>Gets the element in the collection at the current position of the enumerator.</summary>
        /// <returns>The element in the collection at the current position of the enumerator.</returns>
        public object Current
        {
            get => _wrappedEnumerator.Current;
        }

        /// <summary>
        /// Indicates whether enumeration of the enumerator has completed.
        /// </summary>
        public bool IsComplete { get; private set; }
    }
}
