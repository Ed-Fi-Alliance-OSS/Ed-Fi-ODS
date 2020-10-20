// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using EdFi.Common.Configuration;
using EdFi.Common.Security;
using EdFi.Ods.Api.Authentication;
using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Api.Context;
using EdFi.Ods.Api.Conventions;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Api.Filters;
using EdFi.Ods.Api.IdentityValueMappers;
using EdFi.Ods.Api.Infrastructure.Pipelines.Factories;
using EdFi.Ods.Api.Infrastructure.Pipelines.Get;
using EdFi.Ods.Api.Infrastructure.Pipelines.GetDeletedResource;
using EdFi.Ods.Api.Infrastructure.Pipelines.GetMany;
using EdFi.Ods.Api.Infrastructure.Pipelines.Put;
using EdFi.Ods.Api.Infrastructure.Pipelines.Steps;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Api.Validation;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Infrastructure.Extensibility;
using EdFi.Ods.Common.Infrastructure.Pipelines;
using EdFi.Ods.Common.Infrastructure.Pipelines.Delete;
using EdFi.Ods.Common.Infrastructure.Pipelines.GetDeletedResource;
using EdFi.Ods.Common.Infrastructure.Pipelines.GetMany;
using EdFi.Ods.Common.IO;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Providers;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Validation;
using EdFi.Ods.Sandbox.Security;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Module = Autofac.Module;

namespace EdFi.Ods.Api.Container.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SchoolYearContextFilter>()
                .As<IFilterMetadata>();

            builder.RegisterType<EnterpriseApiVersionProvider>()
                .As<IApiVersionProvider>();

            // api model conventions should be singletons
            builder.RegisterType<MvcOptionsConfigurator>()
                .As<IConfigureOptions<MvcOptions>>()
                .SingleInstance();

            builder.RegisterType<DataManagementControllerRouteConvention>()
                .As<IApplicationModelConvention>()
                .SingleInstance();

            builder.RegisterType<ApiKeyContextProvider>()
                .As<IApiKeyContextProvider>()
                .As<IHttpContextStorageTransferKeys>();

            builder.RegisterType<SchoolYearContextProvider>()
                .As<ISchoolYearContextProvider>()
                .As<IHttpContextStorageTransferKeys>()
                .InstancePerLifetimeScope();

            // Primary context storage for ASP.NET web applications
            builder.RegisterType<HttpContextStorage>()
                .As<IContextStorage>()
                .InstancePerLifetimeScope();

            // Secondary context storage for background tasks running in ASP.NET web applications
            // Allows selected context to flow to worker Tasks (see IHttpContextStorageTransferKeys and IHttpContextStorageTransfer)
            builder.RegisterType<CallContextStorage>()
                .As<IContextStorage>()
                .InstancePerLifetimeScope();

            // Features to transfer context from HttpContext to the secondary storage in ASP.NET applications
            builder.RegisterType<HttpContextStorageTransfer>()
                .As<IHttpContextStorageTransfer>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DescriptorLookupProvider>()
                .As<IDescriptorLookupProvider>()
                .SingleInstance();

            builder.RegisterType<DomainModelProvider>()
                .As<IDomainModelProvider>()
                .SingleInstance();

            // Schemas
            builder.Register(c => c.Resolve<IDomainModelProvider>().GetDomainModel().Schemas.ToArray())
                .As<Schema[]>()
                .SingleInstance();

            // Schema Name Map Provider
            builder.Register(c => c.Resolve<IDomainModelProvider>().GetDomainModel().SchemaNameMapProvider)
                .As<ISchemaNameMapProvider>()
                .SingleInstance();

            // Resource Model Provider
            builder.RegisterType<ResourceModelProvider>()
                .As<IResourceModelProvider>()
                .SingleInstance();

            // Validator for the domain model provider
            builder.RegisterType<FluentValidationObjectValidator>()
                .As<IExplicitObjectValidator>()
                .InstancePerLifetimeScope();

            // Domain Models definitions provider
            builder.RegisterType<DomainModelDefinitionsJsonEmbeddedResourceProvider>()
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.ParameterType == typeof(Assembly),
                        (p, c) => c.Resolve<IAssembliesProvider>().GetAssemblies().SingleOrDefault(x => x.IsStandardAssembly())))
                .As<IDomainModelDefinitionsProvider>()
                .SingleInstance();

            builder.RegisterType<AssembliesProvider>()
                .As<IAssembliesProvider>()
                .SingleInstance();

            builder.RegisterType<FileSystemWrapper>()
                .As<IFileSystem>()
                .SingleInstance();

            builder.RegisterType<ConfigConnectionStringsProvider>()
                .As<IConfigConnectionStringsProvider>()
                .SingleInstance();

            builder.RegisterType<DefaultPageSizeLimitProvider>()
                .As<IDefaultPageSizeLimitProvider>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SystemDateProvider>()
                .As<ISystemDateProvider>()
                .SingleInstance();

            builder.RegisterType<ProfilePassthroughResourceModelProvider>()
                .As<IProfileResourceModelProvider>()
                .PreserveExistingDefaults()
                .SingleInstance();

            builder.RegisterType<EdFiDescriptorReflectionProvider>()
                .As<IEdFiDescriptorReflectionProvider>()
                .SingleInstance();

            builder.RegisterType<EdFiOdsInstanceIdentificationProvider>()
                .As<IEdFiOdsInstanceIdentificationProvider>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ETagProvider>()
                .As<IETagProvider>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RESTErrorProvider>()
                .As<IRESTErrorProvider>()
                .InstancePerLifetimeScope();

            // All exception translators
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => typeof(IExceptionTranslator).IsAssignableFrom(t))
                .As<IExceptionTranslator>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<ClientCredentialsTokenRequestProvider>()
                .As<ITokenRequestProvider>()
                .InstancePerLifetimeScope();

            builder.RegisterType<OAuthTokenValidator>()
                .As<IOAuthTokenValidator>()
                .InstancePerLifetimeScope();

            builder.RegisterDecorator<CachingOAuthTokenValidatorDecorator, IOAuthTokenValidator>();

            builder.RegisterType<AuthenticationProvider>()
                .As<IAuthenticationProvider>()
                .SingleInstance();

            builder.RegisterType<PersonIdentifiersProvider>()
                .As<IPersonIdentifiersProvider>()
                .SingleInstance();

            builder.RegisterType<PipelineFactory>()
                .As<IPipelineFactory>()
                .SingleInstance();

            builder.RegisterType<ApiClientAuthenticator>()
                .As<IApiClientAuthenticator>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EdFiAdminApiClientIdentityProvider>()
                .As<IApiClientIdentityProvider>()
                .As<IApiClientSecretProvider>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PackedHashConverter>()
                .As<IPackedHashConverter>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SecurePackedHashProvider>()
                .As<ISecurePackedHashProvider>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DefaultHashConfigurationProvider>()
                .As<IHashConfigurationProvider>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Pbkdf2HmacSha1SecureHasher>()
                .As<ISecureHasher>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DataAnnotationsEntityValidator>()
                .As<IEntityValidator>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DescriptorNamespaceValidator>()
                .As<IValidator<IEdFiDescriptor>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<FluentValidationPutPostRequestResourceValidator>()
                .As<IResourceValidator>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DataAnnotationsResourceValidator>()
                .As<IResourceValidator>()
                .InstancePerLifetimeScope();

            builder.RegisterType<NoEntityExtensionsFactory>()
                .As<IEntityExtensionsFactory>()
                .PreserveExistingDefaults()
                .SingleInstance();

            RegisterPipeLineStepProviders();
            RegisterModels();
            RegisterContexts();
            RegisterResults();

            void RegisterResults()
            {
                builder.RegisterGeneric(typeof(GetResult<>))
                    .AsSelf()
                    .InstancePerLifetimeScope();

                builder.RegisterGeneric(typeof(GetManyResult<>))
                    .AsSelf()
                    .InstancePerLifetimeScope();

                builder.RegisterType<GetDeletedResourceResult>()
                    .AsSelf()
                    .InstancePerLifetimeScope();

                builder.RegisterType<PutResult>()
                    .AsSelf()
                    .InstancePerLifetimeScope();

                builder.RegisterType<DeleteResult>()
                    .AsSelf()
                    .InstancePerLifetimeScope();
            }

            void RegisterContexts()
            {
                builder.RegisterGeneric(typeof(GetContext<>))
                    .AsSelf()
                    .InstancePerLifetimeScope();

                builder.RegisterGeneric(typeof(GetManyContext<,>))
                    .AsSelf()
                    .InstancePerLifetimeScope();

                builder.RegisterGeneric(typeof(GetDeletedResourceContext<>))
                    .AsSelf()
                    .InstancePerLifetimeScope();

                builder.RegisterGeneric(typeof(PutContext<,>))
                    .AsSelf()
                    .InstancePerLifetimeScope();

                builder.RegisterType<DeleteContext>()
                    .AsSelf()
                    .InstancePerLifetimeScope();
            }

            void RegisterModels()
            {
                builder.RegisterGeneric(typeof(GetEntityModelById<,,,>))
                    .AsSelf()
                    .InstancePerLifetimeScope();

                builder.RegisterGeneric(typeof(DetectUnmodifiedEntityModel<,,,>))
                    .AsSelf()
                    .InstancePerLifetimeScope();

                builder.RegisterGeneric(typeof(MapEntityModelToResourceModel<,,,>))
                    .AsSelf()
                    .InstancePerLifetimeScope();

                builder.RegisterGeneric(typeof(MapResourceModelToEntityModel<,,,>))
                    .AsSelf()
                    .InstancePerLifetimeScope();

                builder.RegisterGeneric(typeof(GetEntityModelsBySpecification<,,,>))
                    .AsSelf()
                    .InstancePerLifetimeScope();

                builder.RegisterGeneric(typeof(GetDeletedResourceModelByIds<,,>))
                    .AsSelf()
                    .InstancePerLifetimeScope();

                builder.RegisterGeneric(typeof(ValidateResourceModel<,,,>))
                    .AsSelf()
                    .InstancePerLifetimeScope();

                builder.RegisterGeneric(typeof(DeleteEntityModel<,,,>))
                    .AsSelf()
                    .InstancePerLifetimeScope();

                builder.RegisterGeneric(typeof(MapResourceModelToEntityModel<,,,>))
                    .AsSelf()
                    .InstancePerLifetimeScope();

                builder.RegisterGeneric(typeof(MapEntityModelsToResourceModels<,,,>))
                    .AsSelf()
                    .InstancePerLifetimeScope();

                builder.RegisterGeneric(typeof(PersistEntityModel<,,,>))
                    .AsSelf()
                    .InstancePerLifetimeScope();
            }

            void RegisterPipeLineStepProviders()
            {
                builder.RegisterType<GetPipelineStepsProvider>()
                    .As<IGetPipelineStepsProvider>()
                    .As<IPipelineStepsProvider>()
                    .SingleInstance();

                builder.RegisterType<GetBySpecificationPipelineStepsProvider>()
                    .As<IGetBySpecificationPipelineStepsProvider>()
                    .As<IPipelineStepsProvider>()
                    .SingleInstance();

                builder.RegisterType<GetDeletedResourceIdsPipelineStepsProvider>()
                    .As<IGetDeletedResourceIdsPipelineStepsProvider>()
                    .As<IPipelineStepsProvider>()
                    .SingleInstance();

                builder.RegisterType<PutPipelineStepsProvider>()
                    .As<IPutPipelineStepsProvider>()
                    .As<IPipelineStepsProvider>()
                    .SingleInstance();

                builder.RegisterType<DeletePipelineStepsProvider>()
                    .As<IDeletePipelineStepsProvider>()
                    .As<IPipelineStepsProvider>()
                    .SingleInstance();
            }
        }
    }
}
