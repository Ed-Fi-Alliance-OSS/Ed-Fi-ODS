﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using Autofac;
using EdFi.Ods.Api.IdentityValueMappers;
using EdFi.Ods.Api.Validation;
using EdFi.Ods.Common;
using FluentValidation;

namespace EdFi.Ods.Api.Container.Modules
{
    public class ValidatorsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataAnnotationsEntityValidator>()
                .As<IEntityValidator>();

            builder.RegisterType<DescriptorNamespaceValidator>()
                .As<IValidator<IEdFiDescriptor>>();

            builder.RegisterType<FluentValidationPutPostRequestResourceValidator>()
                .As<IResourceValidator>();

            builder.RegisterType<DataAnnotationsResourceValidator>()
                .As<IResourceValidator>();
        }
    }
}
#endif