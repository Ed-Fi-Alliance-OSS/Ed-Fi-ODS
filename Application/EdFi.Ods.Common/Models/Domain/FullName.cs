// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Newtonsoft.Json;

namespace EdFi.Ods.Common.Models.Domain
{
    /// <summary>
    /// Represents the fully qualified name that includes a schema and an object name.
    /// </summary>
    public struct FullName : IComparable<FullName>, IEquatable<FullName>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FullName" /> class using the supplied schema and name.
        /// </summary>
        /// <param name="schema">The schema portion of the full name.</param>
        /// <param name="name">The name portion of the full name.</param>
        public FullName(string schema, string name)
            : this()
        {
            Schema = schema;
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FullName" /> class using the supplied fully-qualified name in the format of <i>{schema}.{name}</i>.
        /// </summary>
        /// <param name="fullyQualifiedName">The fully-qualified name in the format of <i>{schema}.{name}</i>.</param>
        public FullName(string fullyQualifiedName)
            : this()
        {
            var parts = fullyQualifiedName.Split('.', 2);

            if (parts.Length != 2)
            {
                throw new ArgumentException($"{nameof(fullyQualifiedName)} parameter is expected to be in the format of '{{schema}}.{{name}}'.");
            }

            Schema = parts[0];
            Name = parts[1];
        }

        /// <summary>
        /// Gets the name of the schema.
        /// </summary>
        [JsonProperty]
        public string Schema { get; private set; }

        /// <summary>
        /// Gets the name of the object.
        /// </summary>
        [JsonProperty]
        public string Name { get; private set; }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(FullName other)
        {
            int schemaCompareResult = string.Compare(Schema, other.Schema, StringComparison.InvariantCultureIgnoreCase);

            if (schemaCompareResult != 0)
            {
                return schemaCompareResult;
            }

            return string.Compare(Name, other.Name, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool operator ==(FullName first, FullName second)
        {
            return first.CompareTo(second) == 0;
        }

        public static bool operator !=(FullName first, FullName second)
        {
            return first.CompareTo(second) != 0;
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        /// <param name="obj">Another object to compare to. </param>
        public override bool Equals(object obj)
        {
            if (obj is FullName)
            {
                return this == (FullName) obj;
            }

            return false;
        }

        /// <summary>
        /// Indicates whether this instance and a specified FullName are equal.
        /// </summary>
        /// <returns>
        /// true if <paramref name="that"/> and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        /// <param name="that">Another object to compare to. </param>
        public bool Equals(FullName that)
        {
            return this == that;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            return ToString()
                  .ToLower()
                  .GetHashCode();
        }

        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> containing a fully qualified type name.
        /// </returns>
        public override string ToString()
        {
            var schemaSegment = Schema != null
                ? $"{Schema}."
                : string.Empty;

            return $"{schemaSegment}{Name}";
        }
    }
}
