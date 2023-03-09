// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Autofac;
using Autofac.Builder;
using Autofac.Core;

namespace EdFi.Ods.Common.Container;

public static class AutofacExtensions
{
    public static IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle>
        WithParameterInstance<TLimit, TReflectionActivatorData, TStyle, TParameter>(
        this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> registration,
        TParameter instance)
        where TReflectionActivatorData : ReflectionActivatorData
    {
        return registration.WithParameter(
            new ResolvedParameter(
                (p, ctx) => p.ParameterType == typeof(TParameter), 
                (p, ctx) => instance));
    }
        
    public static IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle>
        WithParameter<TLimit, TReflectionActivatorData, TStyle, TParameter>(
        this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> registration,
        Func<IComponentContext, TParameter> factory)
        where TReflectionActivatorData : ReflectionActivatorData
    {
        return registration.WithParameter(
            new ResolvedParameter(
                (p, ctx) => p.ParameterType == typeof(TParameter), 
                (p, ctx) => factory(ctx)));
    }
}
