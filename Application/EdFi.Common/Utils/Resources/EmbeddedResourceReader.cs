// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.IO;

namespace EdFi.Ods.Common.Utils.Resources
{
    public class EmbeddedResourceReader
    {
        /// <summary>
        /// Get a resource stream for the embedded resource.  Using this signature, the resource should 
        /// reside in the same assembly and namespace as TMarkerType
        /// </summary>
        /// <typeparam name="TMarkerType">A marker type that is a sibling to the embedded resource</typeparam>
        /// <param name="resourceName">The filename of the resource to retrieve</param>
        /// <returns>A stream associated with the resource</returns>
        public static Stream GetResourceStream<TMarkerType>(string resourceName)
        {
            var markerType = typeof(TMarkerType);
            var assembly = markerType.Assembly;

            return assembly.GetManifestResourceStream(markerType, resourceName);
        }

        /// <summary>
        /// Get a resource stream for the embedded resource.  Using this signature, the resource should 
        /// reside in the same assembly and namespace as TMarkerType
        /// </summary>
        /// <typeparam name="TMarkerType">A marker type that is a sibling to the embedded resource</typeparam>
        /// <param name="resourceName">The filename of the resource to retrieve</param>
        /// <returns>The contents of the embedded resource as a string</returns>
        public static string GetResourceString<TMarkerType>(string resourceName)
        {
            using (var stream = GetResourceStream<TMarkerType>(resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
