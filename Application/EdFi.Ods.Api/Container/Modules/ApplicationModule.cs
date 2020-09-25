// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
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
            builder.RegisterType<SchoolYearContextFilter>().As<IFilterMetadata>();

            builder.RegisterType<EnterpriseApiVersionProvider>().As<IApiVersionProvider>();

            // api model conventions should be singletons
            builder.RegisterType<MvcOptionsConfigurator>().As<IConfigureOptions<MvcOptions>>().SingleInstance();
            builder.RegisterType<DataManagementControllerRouteConvention>().As<IApplicationModelConvention>().SingleInstance();

            builder.RegisterType<ApiKeyContextProvider>().As<IApiKeyContextProvider>().As<IHttpContextStorageTransferKeys>()
                .AsSelf();

            builder.RegisterType<SchoolYearContextProvider>().As<ISchoolYearContextProvider>()
                .As<IHttpContextStorageTransferKeys>().AsSelf();

            // Primary context storage for ASP.NET web applications
            builder.RegisterType<HttpContextStorage>().As<IContextStorage>().AsSelf();

            // Secondary context storage for background tasks running in ASP.NET web applications
            // Allows selected context to flow to worker Tasks (see IHttpContextStorageTransferKeys and IHttpContextStorageTransfer)
            builder.RegisterType<CallContextStorage>().As<IContextStorage>().AsSelf();

            // Features to transfer context from HttpContext to the secondary storage in ASP.NET applications
            builder.RegisterType<HttpContextStorageTransfer>().As<IHttpContextStorageTransfer>();

            builder.RegisterType<DescriptorLookupProvider>().As<IDescriptorLookupProvider>().SingleInstance();

            builder.RegisterType<DomainModelProvider>().As<IDomainModelProvider>();

            // Schemas
            builder.Register(c => c.Resolve<IDomainModelProvider>().GetDomainModel().Schemas.ToArray())
                .As<Schema[]>();

            // Schema Name Map Provider
            builder.Register(c => c.Resolve<IDomainModelProvider>().GetDomainModel().SchemaNameMapProvider)
                .As<ISchemaNameMapProvider>();

            // Resource Model Provider
            builder.RegisterType<ResourceModelProvider>().As<IResourceModelProvider>();

            // Validator for the domain model provider
            builder.RegisterType<FluentValidationObjectValidator>().As<IExplicitObjectValidator>();

            // Domain Models definitions provider
            builder.RegisterType<DomainModelDefinitionsJsonEmbeddedResourceProvider>()
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.ParameterType == typeof(Assembly),
                        (p, c) => c.Resolve<IAssembliesProvider>().GetAssemblies().SingleOrDefault(x => x.IsStandardAssembly())))
                .As<IDomainModelDefinitionsProvider>();

            builder.RegisterType<AssembliesProvider>().As<IAssembliesProvider>();
            builder.RegisterType<FileSystemWrapper>().As<IFileSystem>();
            builder.RegisterType<ConfigConnectionStringsProvider>().As<IConfigConnectionStringsProvider>();
            builder.RegisterType<DefaultPageSizeLimitProvider>().As<IDefaultPageSizeLimitProvider>();
            builder.RegisterType<SystemDateProvider>().As<ISystemDateProvider>();

            builder.RegisterType<ProfilePassthroughResourceModelProvider>()
                .As<IProfileResourceModelProvider>()
                .PreserveExistingDefaults();

            builder.RegisterType<EdFiDescriptorReflectionProvider>().As<IEdFiDescriptorReflectionProvider>().SingleInstance();

            builder.RegisterType<EdFiOdsInstanceIdentificationProvider>()
                .As<IEdFiOdsInstanceIdentificationProvider>();

            builder.RegisterType<ETagProvider>().As<IETagProvider>();

            builder.RegisterType<RESTErrorProvider>().As<IRESTErrorProvider>();

            // All exception translators
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => typeof(IExceptionTranslator).IsAssignableFrom(t))
                .As<IExceptionTranslator>()
                .AsSelf();

            builder.RegisterType<ClientCredentialsTokenRequestProvider>().As<ITokenRequestProvider>();
            builder.RegisterType<OAuthTokenValidator>().As<IOAuthTokenValidator>();
            builder.RegisterDecorator<CachingOAuthTokenValidatorDecorator, IOAuthTokenValidator>();
            builder.RegisterType<AuthenticationProvider>().As<IAuthenticationProvider>();

            builder.RegisterType<PersonIdentifiersProvider>().As<IPersonIdentifiersProvider>();

            builder.RegisterType<PipelineFactory>()
                .As<IPipelineFactory>();

            RegisterPipeLineStepProviders();
            RegisterModels();
            RegisterContexts();
            RegisterResults();

            void RegisterResults()
            {
                builder.RegisterGeneric(typeof(GetResult<>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(GetManyResult<>))
                    .AsSelf();

                builder.RegisterType<GetDeletedResourceResult>()
                    .AsSelf();

                builder.RegisterType<PutResult>()
                    .AsSelf();

                builder.RegisterType<DeleteResult>()
                    .AsSelf();
            }

            void RegisterContexts()
            {
                builder.RegisterGeneric(typeof(GetContext<>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(GetManyContext<,>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(GetDeletedResourceContext<>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(PutContext<,>))
                    .AsSelf();

                builder.RegisterType<DeleteContext>()
                    .AsSelf();
            }

            void RegisterModels()
            {
                builder.RegisterGeneric(typeof(GetEntityModelById<,,,>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(DetectUnmodifiedEntityModel<,,,>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(MapEntityModelToResourceModel<,,,>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(MapResourceModelToEntityModel<,,,>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(GetEntityModelsBySpecification<,,,>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(GetDeletedResourceModelByIds<,,>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(ValidateResourceModel<,,,>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(DeleteEntityModel<,,,>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(MapResourceModelToEntityModel<,,,>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(MapEntityModelsToResourceModels<,,,>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(PersistEntityModel<,,,>))
                    .AsSelf();
            }

            void RegisterPipeLineStepProviders()
            {
                builder.RegisterType<GetPipelineStepsProvider>()
                    .As<IGetPipelineStepsProvider>()
                    .As<IPipelineStepsProvider>();

                builder.RegisterType<GetBySpecificationPipelineStepsProvider>()
                    .As<IGetBySpecificationPipelineStepsProvider>()
                    .As<IPipelineStepsProvider>();

                builder.RegisterType<GetDeletedResourceIdsPipelineStepsProvider>()
                    .As<IGetDeletedResourceIdsPipelineStepsProvider>()
                    .As<IPipelineStepsProvider>();

                builder.RegisterType<PutPipelineStepsProvider>()
                    .As<IPutPipelineStepsProvider>()
                    .As<IPipelineStepsProvider>();

                builder.RegisterType<DeletePipelineStepsProvider>()
                    .As<IDeletePipelineStepsProvider>()
                    .As<IPipelineStepsProvider>();
            }

            builder.RegisterType<ApiClientAuthenticator>()
                .As<IApiClientAuthenticator>();

            builder.RegisterType<EdFiAdminApiClientIdentityProvider>()
                .As<IApiClientIdentityProvider>()
                .As<IApiClientSecretProvider>();

            builder.RegisterType<PackedHashConverter>()
                .As<IPackedHashConverter>();

            builder.RegisterType<SecurePackedHashProvider>()
                .As<ISecurePackedHashProvider>();

            builder.RegisterType<DefaultHashConfigurationProvider>()
                .As<IHashConfigurationProvider>();

            builder.RegisterType<Pbkdf2HmacSha1SecureHasher>()
                .As<ISecureHasher>();

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