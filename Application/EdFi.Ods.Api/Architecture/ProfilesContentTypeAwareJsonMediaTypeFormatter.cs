// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection;

namespace EdFi.Ods.Api.Architecture
{
    /// <summary>
    /// Implements a JSON content-type media formatter that inspects the targeted .NET types 
    /// (identified by Web API for reading incoming messages) for the <see cref="ProfileContentTypeAttribute"/>
    /// attribute, and then dynamically adds the media type to the list of suppoted media types.
    /// </summary>
    public class ProfilesContentTypeAwareJsonMediaTypeFormatter : JsonMediaTypeFormatter
    {
        // Local cache of already
        private readonly ConcurrentDictionary<Type, bool> _alreadyProcessedByDotNetType =
            new ConcurrentDictionary<Type, bool>();

        /// <summary>
        /// Determines whether this <see cref="T:System.Net.Http.Formatting.JsonMediaTypeFormatter"/> can read objects of the specified <paramref name="type"/>.
        /// </summary>
        /// <returns>
        /// true if objects of this <paramref name="type"/> can be read, otherwise false.
        /// </returns>
        /// <param name="type">The type of object that will be read.</param>
        public override bool CanReadType(Type type)
        {
            string supportedMediaType = null;

            // Make note of the inquiry for this .NET type and add its media type to the supported media type collection
            _alreadyProcessedByDotNetType.GetOrAdd(
                type,
                t =>
                {
                    var attribute = type.GetCustomAttributes<ProfileContentTypeAttribute>()
                                        .SingleOrDefault();

                    if (attribute != null)
                    {
                        supportedMediaType = attribute.MediaTypeName;
                    }

                    return true;
                });

            // Perform just-in-time media type addition
            if (supportedMediaType != null)
            {
                SupportedMediaTypes.Add(new MediaTypeHeaderValue(supportedMediaType));
            }

            // Now, return to buiness as usual
            return base.CanReadType(type);
        }
    }
}
