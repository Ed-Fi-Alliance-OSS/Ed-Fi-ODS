// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace EdFi.Ods.Api.ETag
{
    public abstract class ETagMatchAttribute : ParameterBindingAttribute
    {
        protected ETagMatchAttribute(ETagMatch match)
        {
            ETagMatch = match;
        }

        public ETagMatch ETagMatch { get; }

        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            if (parameter.ParameterType == typeof(ETag))
            {
                return new ETagParameterBinding(parameter, ETagMatch);
            }

            return parameter.BindAsError("Wrong parameter type");
        }
    }

    /// <summary>
    /// Attribute used to map the if_match header to an ETag parameter
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public class IfMatchAttribute : ETagMatchAttribute
    {
        public IfMatchAttribute()
            : base(ETagMatch.IfMatch) { }
    }

    /// <summary>
    /// Attribute used to map the if_none_match header to an ETag parameter
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public class IfNoneMatchAttribute : ETagMatchAttribute
    {
        public IfNoneMatchAttribute()
            : base(ETagMatch.IfNoneMatch) { }
    }
}
