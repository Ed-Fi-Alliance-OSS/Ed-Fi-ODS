// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace EdFi.Ods.Api.Common.Infrastructure.Composites
{
    /// <summary>
    /// A thread-safe alias generator for use in building filters requiring unique aliases.
    /// </summary>
    /// <remarks>The generator uses the Monostate Pattern where each instance uses shared state.</remarks>
    public class AliasGenerator
    {
        private static readonly ConcurrentDictionary<string, IEnumerator<string>> AliasesByPrefix =
            new ConcurrentDictionary<string, IEnumerator<string>>(StringComparer.InvariantCultureIgnoreCase);
        private readonly bool _useSharedState;

        private readonly IEnumerator<string> _aliases;

        public AliasGenerator()
            : this(string.Empty, false) { }

        public AliasGenerator(string prefix)
            : this(prefix, useSharedState: false) { }

        public AliasGenerator(string prefix, bool useSharedState)
        {
            _useSharedState = useSharedState;

            if (useSharedState)
            {
                _aliases = AliasesByPrefix.GetOrAdd(prefix, p => new AliasEnumerator(p));
            }
            else
            {
                _aliases = new AliasEnumerator(prefix);
            }
        }

        /// <summary>
        /// Gets the next unique alias as a 3-character string starting with "aaa" and ending with "zzz".
        /// </summary>
        /// <returns>The next unique alias.</returns>
        public string GetNextAlias()
        {
            if (!_aliases.MoveNext())
            {
                if (_useSharedState)
                {
                    _aliases.Reset();
                    _aliases.MoveNext();
                }
                else
                {
                    throw new InvalidOperationException("The generator has run out of unique 3-character aliases.");
                }
            }

            return _aliases.Current;
        }

        /// <summary>
        /// Restarts the alias generation for all instances of the generator.
        /// </summary>
        public void Reset()
        {
            _aliases.Reset();
        }

        private class AliasEnumerator : IEnumerator<string>
        {
            private static readonly object EnumeratorLock = new object();
            private readonly string _prefix;
            private bool started;
            private byte x, y, z;

            public AliasEnumerator(string prefix)
            {
                _prefix = prefix;

                Reset();
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public string Current
            {
                get
                {
                    if (!started)
                    {
                        return null;
                    }

                    return _prefix + new string(
                               new[]
                               {
                                   (char) (x + 97), (char) (y + 97), (char) (z + 97)
                               });
                }
            }

            public bool MoveNext()
            {
                lock (EnumeratorLock)
                {
                    if (!started)
                    {
                        started = true;
                        return true;
                    }

                    if (z < 25)
                    {
                        z++;
                        return true;
                    }

                    z = 0;

                    if (y < 25)
                    {
                        y++;
                        return true;
                    }

                    y = 0;

                    if (x < 25)
                    {
                        x++;
                        return true;
                    }

                    return false;
                }
            }

            public void Reset()
            {
                lock (EnumeratorLock)
                {
                    x = 0;
                    y = 0;
                    z = 0;
                    started = false;
                }
            }

            public void Dispose() { }
        }
    }
}
