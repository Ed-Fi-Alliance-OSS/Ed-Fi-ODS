// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using EdFi.Admin.DataAccess.Security;
using EdFi.Common.Configuration;
using EdFi.Common.Security;
using EdFi.Ods.Api.Authentication;
using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Api.Conventions;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Api.Filters;
using EdFi.Ods.Api.IdentityValueMappers;
using EdFi.Ods.Api.Infrastructure.Pipelines.Factories;
using EdFi.Ods.Api.Infrastructure.Pipelines.Steps;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Api.Validation;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Infrastructure.Extensibility;
using EdFi.Ods.Common.Infrastructure.Pipelines;
using EdFi.Ods.Common.IO;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Providers;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Http;
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
            RegisterMiddleware();

            builder.RegisterType<ExceptionHandlingFilter>()
                .As<IFilterMetadata>()
                .SingleInstance();
            
            builder.RegisterType<DataManagementRequestContextFilter>()
                .As<IFilterMetadata>()
                .SingleInstance();
            
            builder.RegisterType<DataManagementRequestContextProvider>()
                .As<IDataManagementRequestContextProvider>()
                .SingleInstance();

            builder.RegisterType<EnterpriseApiVersionProvider>()
                .As<IApiVersionProvider>()
                .SingleInstance();

            // api model conventions should be singletons
            builder.RegisterType<MvcOptionsConfigurator>()
                .As<IConfigureOptions<MvcOptions>>()
                .SingleInstance();

            builder.RegisterType<DataManagementControllerRouteConvention>()
                .As<IApplicationModelConvention>()
                .SingleInstance();

            builder.RegisterType<ApiKeyContextProvider>()
                .As<IApiKeyContextProvider>()
                .As<IHttpContextStorageTransferKeys>()
                .SingleInstance();

            builder.RegisterType<SchoolYearContextProvider>()
                .As<ISchoolYearContextProvider>()
                .As<IHttpContextStorageTransferKeys>()
                .SingleInstance();

            builder.RegisterType<CallContextStorage>()
                .As<IContextStorage>()
                .SingleInstance();

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
                .SingleInstance();

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
                .SingleInstance();

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
                .SingleInstance();

            builder.RegisterType<ETagProvider>()
                .As<IETagProvider>()
                .SingleInstance();

            builder.RegisterType<RESTErrorProvider>()
                .As<IRESTErrorProvider>()
                .SingleInstance();

            // All exception translators
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => typeof(IExceptionTranslator).IsAssignableFrom(t))
                .As<IExceptionTranslator>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<ClientCredentialsTokenRequestProvider>()
                .As<ITokenRequestProvider>()
                .SingleInstance();

            builder.RegisterType<ApiClientDetailsProvider>()
                .As<IApiClientDetailsProvider>()
                .SingleInstance();

            builder.RegisterType<ApiClientDetailsCacheKeyProvider>()
                .As<IApiClientDetailsCacheKeyProvider>()
                .SingleInstance();
            
            builder.RegisterDecorator<CachingApiClientDetailsProviderDecorator, IApiClientDetailsProvider>();

            builder.RegisterType<OAuthTokenAuthenticator>()
                .As<IOAuthTokenAuthenticator>()
                .SingleInstance();

            builder.RegisterType<PersonIdentifiersProvider>()
                .As<IPersonIdentifiersProvider>()
                .SingleInstance();

            builder.RegisterType<PipelineFactory>()
                .As<IPipelineFactory>()
                .SingleInstance();

            builder.RegisterType<ApiClientAuthenticator>()
                .As<IApiClientAuthenticator>()
                .SingleInstance();

            builder.RegisterType<EdFiAdminApiClientIdentityProvider>()
                .As<IApiClientIdentityProvider>()
                .As<IApiClientSecretProvider>()
                .SingleInstance();

            builder.RegisterType<PackedHashConverter>()
                .As<IPackedHashConverter>()
                .SingleInstance();

            builder.RegisterType<SecurePackedHashProvider>()
                .As<ISecurePackedHashProvider>()
                .SingleInstance();

            builder.RegisterType<DefaultHashConfigurationProvider>()
                .As<IHashConfigurationProvider>()
                .SingleInstance();

            builder.RegisterType<Pbkdf2HmacSha1SecureHasher>()
                .As<ISecureHasher>()
                .SingleInstance();

            builder.RegisterType<DataAnnotationsEntityValidator>()
                .As<IEntityValidator>()
                .SingleInstance();

            builder.RegisterType<DescriptorNamespaceValidator>()
                .As<IValidator<IEdFiDescriptor>>()
                .SingleInstance();

            builder.RegisterType<FluentValidationPutPostRequestResourceValidator>()
                .As<IResourceValidator>()
                .SingleInstance();

            builder.RegisterType<DataAnnotationsResourceValidator>()
                .As<IResourceValidator>()
                .SingleInstance();

            builder.RegisterType<NoEntityExtensionsFactory>()
                .As<IEntityExtensionsFactory>()
                .PreserveExistingDefaults()
                .SingleInstance();

            RegisterPipeLineStepProviders();
            RegisterModels();

            void RegisterModels()
            {
                builder.RegisterGeneric(typeof(GetEntityModelById<,,,>))
                    .AsSelf()
                    .SingleInstance();

                builder.RegisterGeneric(typeof(DetectUnmodifiedEntityModel<,,,>))
                    .AsSelf()
                    .SingleInstance();

                builder.RegisterGeneric(typeof(MapEntityModelToResourceModel<,,,>))
                    .AsSelf()
                    .SingleInstance();

                builder.RegisterGeneric(typeof(MapResourceModelToEntityModel<,,,>))
                    .AsSelf()
                    .SingleInstance();

                builder.RegisterGeneric(typeof(GetEntityModelsBySpecification<,,,>))
                    .AsSelf()
                    .SingleInstance();

                builder.RegisterGeneric(typeof(ValidateResourceModel<,,,>))
                    .AsSelf()
                    .SingleInstance();

                builder.RegisterGeneric(typeof(DeleteEntityModel<,,,>))
                    .AsSelf()
                    .SingleInstance();

                builder.RegisterGeneric(typeof(MapResourceModelToEntityModel<,,,>))
                    .AsSelf()
                    .SingleInstance();

                builder.RegisterGeneric(typeof(MapEntityModelsToResourceModels<,,,>))
                    .AsSelf()
                    .SingleInstance();

                builder.RegisterGeneric(typeof(PersistEntityModel<,,,>))
                    .AsSelf()
                    .SingleInstance();
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

                builder.RegisterType<PutPipelineStepsProvider>()
                    .As<IPutPipelineStepsProvider>()
                    .As<IPipelineStepsProvider>()
                    .SingleInstance();

                builder.RegisterType<DeletePipelineStepsProvider>()
                    .As<IDeletePipelineStepsProvider>()
                    .As<IPipelineStepsProvider>()
                    .SingleInstance();
            }

            void RegisterMiddleware()
            {
                builder.RegisterType<SchoolYearRouteContextMiddleware>()
                    .As<IMiddleware>()
                    .AsSelf()
                    .SingleInstance();

                builder.RegisterType<InstanceIdSpecificRouteContextMiddleware>()
                    .As<IMiddleware>()
                    .AsSelf()
                    .SingleInstance();
            }
        }
    }
}
