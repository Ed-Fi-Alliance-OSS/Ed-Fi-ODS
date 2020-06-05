#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Specialized;

namespace EdFi.Ods.Common.Configuration
{
    public class NameValueCollectionConfigValueProvider : IConfigValueProvider
    {
        private readonly IConfigValueProvider _next;

        public NameValueCollectionConfigValueProvider() { }

        public NameValueCollectionConfigValueProvider(IConfigValueProvider next)
        {
            _next = next;
        }

        /// <summary>
        /// Gets or sets the <see cref="NameValueCollection"/> containing the configuration values.
        /// </summary>
        public NameValueCollection Values { get; set; } = new NameValueCollection();

        /// <summary>
        /// Gets the specified value from the collection by name.
        /// </summary>
        /// <param name="name">The name of the value to be retrieved.</param>
        /// <returns>The value as a string.</returns>
        public string GetValue(string name)
        {
            if (Values[name] != null)
            {
                return Values[name];
            }

            return _next?.GetValue(name);
        }
    }
}
#endif