// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Security.Authorization;

namespace EdFi.Ods.Security.AuthorizationStrategies.Relationships
{
    /// <summary>
    /// Represents a property to be used in building a <see cref="ClaimsAuthorizationSegment"/>, holding both
    /// the name of the associated property and, if appropriate, an authorization path modifier to be used during
    /// authorization.
    /// </summary>
    public class SegmentProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentProperty"/> class using the specified property name and type.
        /// </summary>
        public SegmentProperty(string propertyName, Type propertyType)
            : this(propertyName, propertyType, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentProperty"/> class using the specified property name and type and authorization query path modifier.
        /// </summary>
        public SegmentProperty(string propertyName, Type propertyType, string authorizationPathModifier)
            : this(propertyName, propertyType, null, authorizationPathModifier) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentProperty"/> class using the specified property name, type and value.
        /// </summary>
        public SegmentProperty(string propertyName, Type propertyType, object propertyValue)
            : this(propertyName, propertyType, propertyValue, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentProperty"/> class using the specified property name, type, value and authorization query path modifier.
        /// </summary>
        public SegmentProperty(string propertyName, Type propertyType, object propertyValue, string authorizationPathModifier)
        {
            PropertyName = propertyName;
            PropertyType = propertyType;
            PropertyValue = propertyValue;
            AuthorizationPathModifier = authorizationPathModifier;
        }

        /// <summary>
        /// The name of the property for the segment endpoint.
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// Gets the <see cref="Type"/> of the property.
        /// </summary>
        public Type PropertyType { get; }

        /// <summary>
        /// Gets the value for property (when used with a specific resource authorization context).
        /// </summary>
        public object PropertyValue { get; }

        /// <summary>
        /// Gets the optional textual modifier informing the path to be used within the ODS for authorization purposes.
        /// </summary>
        public string AuthorizationPathModifier { get; }
    }
}
