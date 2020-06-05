// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace EdFi.Ods.Api.Common.Infrastructure.Composites
{
    /// <summary>
    /// Represents a resource member selected via a 'fields' query string parameter.
    /// </summary>
    public class SelectedResourceMember : IEquatable<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectedResourceMember"/> class using the specified member name.
        /// </summary>
        /// <param name="memberName">The name of the resourc member.</param>
        public SelectedResourceMember(string memberName)
        {
            MemberName = memberName;
            Children = new List<SelectedResourceMember>();
        }

        /// <summary>
        /// The name of the resource member to be included in the results.
        /// </summary>
        public string MemberName { get; }

        /// <summary>
        /// A collection of child members also to be included.
        /// </summary>
        public List<SelectedResourceMember> Children { get; }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(string other)
        {
            return string.Equals(MemberName, other, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return MemberName +
                   (Children.Count > 0
                       ? " {" + string.Join(",", Children.Select(x => x.ToString())) + "}"
                       : string.Empty);
        }
    }
}
