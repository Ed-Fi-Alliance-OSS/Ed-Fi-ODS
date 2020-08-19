// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Net.Http.Formatting;
using System.Reflection;

namespace EdFi.Ods.Api.Services
{
    /// <summary>
    /// Provides an implementation of <see cref="IRequiredMemberSelector"/> that 
    /// disables required member validation on objects being deserialized from JSON.
    /// </summary>
    public class NoRequiredMemberSelector : IRequiredMemberSelector
    {
        /// <summary>
        /// Always indicates that the member is not required.
        /// </summary>
        /// <param name="member">Metadata about the property being deserialized.</param>
        /// <returns>This implementation always returns <b>false</b>.</returns>
        public bool IsRequiredMember(MemberInfo member)
        {
            // Do not let JSON serialization perform validation on required members
            // Validation is handled separately, and certain members are always required
            // because the resources can be used in multiple contexts (e.g. query by example).
            return false;
        }
    }
}
