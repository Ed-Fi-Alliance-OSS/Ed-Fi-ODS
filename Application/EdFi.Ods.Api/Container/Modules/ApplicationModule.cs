// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using EdFi.Admin.DataAccess.Security;
using EdFi.Common.Configuration;
using EdFi.Common.Security;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Api.Conventions;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Api.ExternalTasks;
using EdFi.Ods.Api.Filters;
using EdFi.Ods.Api.IdentityValueMappers;
using EdFi.Ods.Api.Infrastructure.Pipelines.Factories;
using EdFi.Ods.Api.Infrastructure.Pipelines.Steps;
using EdFi.Ods.Api.Jobs.Extensions;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Api.Security.Authentication;
using EdFi.Ods.Api.Serialization;
using EdFi.Ods.Api.Validation;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Configuration.Sections;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Infrastructure.Extensibility;
using EdFi.Ods.Common.Infrastructure.Pipelines;
using EdFi.Ods.Common.IO;
using EdFi.Ods.Common.Logging;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions.Transformers;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.ProblemDetails;
using EdFi.Ods.Common.Providers;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Common.Validation;
using FluentValidation;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Module = Autofac.Module;

namespace EdFi.Ods.Api.Container.Modules
{
    public class ApplicationModule : Module
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(ApplicationModule));
        
        protected override void Load(ContainerBuilder builder)
        {
            RegisterMiddleware();

            builder.RegisterType<Log4NetLogContextAccessor>()
                .As<ILogContextAccessor>()
                .SingleInstance();
            
            builder.RegisterType<ExceptionHandlingFilter>()
                .As<IFilterMetadata>()
                .SingleInstance();

            builder.RegisterType<EdFiClientErrorFactory>()
                .As<IClientErrorFactory>()
                .SingleInstance();

            builder.RegisterType<DataManagementRequestContextFilter>()
                .As<IFilterMetadata>()
                .SingleInstance();

            builder.RegisterType<EnforceAssignedProfileUsageFilter>()
                .SingleInstance();
            
            builder.RegisterType<EnterpriseApiVersionProvider>()
                .As<IApiVersionProvider>()
                .SingleInstance();

            // api model conventions should be singletons
            builder.RegisterType<MvcOptionsConfigurator>()
                .As<IConfigureOptions<MvcOptions>>()
                .SingleInstance();

            builder.RegisterType<ProfilesAwareContractResolver>()
                .WithProperty("NamingStrategy", 
                    new CamelCaseNamingStrategy
                    {
                        ProcessDictionaryKeys = true,
                        OverrideSpecifiedNames = true
                    })
                .SingleInstance();

            builder.RegisterType<VersionRouteConvention>()
                .As<IApplicationModelConvention>()
                .SingleInstance();

            builder.RegisterType<OdsRouteRootTemplateConvention>()
                .As<IApplicationModelConvention>()
                .SingleInstance();

            builder.RegisterType<OdsRouteRootTemplateProvider>()
                .As<IOdsRouteRootTemplateProvider>()
                .SingleInstance();

            builder.RegisterType<ApiClientContextProvider>()
                .As<IApiClientContextProvider>()
                .SingleInstance();

            builder.RegisterType<CallContextStorage>()
                .As<IContextStorage>()
                .SingleInstance();

            builder.RegisterType<DomainModelProvider>()
                .As<IDomainModelProvider>()
                .SingleInstance();

            // Domain model transformers
            builder.RegisterType<PriorDescriptorIdRemover>()
                .As<IDomainModelDefinitionsTransformer>()
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
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.ParameterType == typeof(int) && p.Name == "defaultPageSizeLimit",
                        (p, c) => c.Resolve<ApiSettings>().DefaultPageSizeLimit))
                .As<IDefaultPageSizeLimitProvider>()
                .SingleInstance();

            builder.RegisterType<SystemDateProvider>()
                .As<ISystemDateProvider>()
                .SingleInstance();

            builder.RegisterType<EdFiOdsInstanceIdentificationProvider>()
                .As<IEdFiOdsInstanceIdentificationProvider>()
                .SingleInstance();

            builder.RegisterType<ETagProvider>()
                .As<IETagProvider>()
                .SingleInstance();

            builder.RegisterType<EdFiProblemDetailsProvider>()
                .As<IEdFiProblemDetailsProvider>()
                .SingleInstance();

            // All exception translators
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => typeof(IProblemDetailsExceptionTranslator).IsAssignableFrom(t))
                .As<IProblemDetailsExceptionTranslator>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<ClientCredentialsTokenRequestProvider>()
                .As<ITokenRequestProvider>()
                .SingleInstance();

            builder.RegisterType<ApiClientDetailsProvider>()
                .As<IApiClientDetailsProvider>()
                .EnableInterfaceInterceptors()
                .SingleInstance();

            builder.RegisterType<CachingInterceptor>()
                .Named<IInterceptor>(InterceptorCacheKeys.ApiClientDetails)
                .WithParameter(
                    ctx =>
                    {
                        var apiSettings = ctx.Resolve<ApiSettings>();

                        return (ICacheProvider<ulong>) new ExpiringConcurrentDictionaryCacheProvider<ulong>(
                            "API Client Details",
                            TimeSpan.FromSeconds(apiSettings.Caching.ApiClientDetails.AbsoluteExpirationSeconds));
                    })
                .SingleInstance();

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

            builder.RegisterType<EdFiAdminApiClientSecretWriter>()
                .As<IApiClientSecretWriter>()
                .SingleInstance();

            builder.RegisterType<EdFiAdminRawApiClientDetailsProvider>()
                .As<IEdFiAdminRawApiClientDetailsProvider>()
                .SingleInstance();
            
            builder.RegisterType<EdFiAdminAccessTokenFactory>()
                .As<IAccessTokenFactory>()
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.Name == "tokenDurationMinutes",
                        (p, c) => c.Resolve<ApiSettings>().BearerTokenTimeoutMinutes))
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

            builder.RegisterType<DescriptorNamespaceValidator>()
                .As<IValidator<IEdFiDescriptor>>()
                .SingleInstance();

            builder.RegisterType<DataAnnotationsResourceValidator>()
                .As<IResourceValidator>()
                .SingleInstance();

            builder.RegisterType<NoEntityExtensionsFactory>()
                .As<IEntityExtensionsFactory>()
                .PreserveExistingDefaults()
                .SingleInstance();

            builder.RegisterType<MappingContractProvider>()
                .As<IMappingContractProvider>()
                .SingleInstance();
            
            builder.RegisterGeneric(typeof(ContextProvider<>))
                .As(typeof(IContextProvider<>))
                .SingleInstance();

            builder.RegisterType<DatabaseEngineSpecificStringComparerProvider>()
                .As<IDatabaseEngineSpecificEqualityComparerProvider<string>>()
                .SingleInstance();

            builder.RegisterType<OdsInstanceConfigurationProvider>()
                .As<IOdsInstanceConfigurationProvider>()
                .EnableInterfaceInterceptors()
                .SingleInstance();

            builder.RegisterType<ConnectionStringOverridesApplicator>()
                .As<IConnectionStringOverridesApplicator>()
                .SingleInstance();

            builder.RegisterType<EdFiAdminRawOdsInstanceConfigurationDataProvider>()
                .As<IEdFiAdminRawOdsInstanceConfigurationDataProvider>()
                .SingleInstance();

            builder.RegisterType<EdFiAdminRawOdsInstanceConfigurationDataTransformer>()
                .As<IEdFiAdminRawOdsInstanceConfigurationDataTransformer>()
                .SingleInstance();
            
            builder.RegisterDecorator<
                AutoEncryptingEdFiAdminRawOdsInstanceConfigurationDataTransformerDecorator, 
                IEdFiAdminRawOdsInstanceConfigurationDataTransformer>();

            builder.RegisterType<OdsInstanceHashIdGenerator>()
                .As<IOdsInstanceHashIdGenerator>()
                .SingleInstance();

            builder.RegisterType<OdsDatabaseConnectionStringProvider>()
                .As<IOdsDatabaseConnectionStringProvider>()
                .SingleInstance();

            builder.RegisterType<OdsDatabaseAccessIntentProvider>()
                .As<IOdsDatabaseAccessIntentProvider>()
                .SingleInstance();

            builder.RegisterType<PersonEntitySpecification>()
                .As<IPersonEntitySpecification>()
                .SingleInstance();

            builder.RegisterType<PersonTypesProvider>()
                .As<IPersonTypesProvider>()
                .SingleInstance();

            builder.RegisterType<CachingInterceptor>()
                .Named<IInterceptor>(InterceptorCacheKeys.OdsInstances)
                .WithParameter(
                    ctx =>
                    {
                        var apiSettings = ctx.Resolve<ApiSettings>();

                        var cacheProvider = new ExpiringConcurrentDictionaryCacheProvider<ulong>(
                            "ODS Instance Configurations",
                            TimeSpan.FromSeconds(apiSettings.Caching.OdsInstances.AbsoluteExpirationSeconds));

                        // Subscribe to any changes related to the ODS instances section of the configuration, and clear interceptor's cache provider explicitly
                        var options = ctx.Resolve<IOptionsMonitor<OdsInstancesSection>>();
                        options.OnChange(config =>
                        {
                            if (_logger.IsDebugEnabled)
                            {
                                _logger.Debug($"ODS instances connection string configuration changes detected. Clearing interceptor cache provider...");
                            }

                            cacheProvider.Clear();
                        });

                        return (ICacheProvider<ulong>) cacheProvider;
                    })
                .SingleInstance();

            builder.RegisterType<InitializeScheduledJobs>()
                .As<IExternalTask>();

            // Register components for string encryption/decryption 
            builder.RegisterType<Aes256SymmetricStringEncryptionProvider>()
                .As<ISymmetricStringEncryptionProvider>()
                .SingleInstance();
            builder.RegisterType<Aes256SymmetricStringDecryptionProvider>()
                .As<ISymmetricStringDecryptionProvider>()
                .SingleInstance();
            
            builder.RegisterType<EdFiAdminOdsConnectionStringDatabaseWriter>()
                .As<IEdFiOdsConnectionStringWriter>()
                .SingleInstance();

            builder.RegisterInstance(TimeProvider.System)
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
                
                builder.RegisterGeneric(typeof(ResolveUniqueIds<,,,>))
                    .AsSelf()
                    .SingleInstance();
                
                builder.RegisterGeneric(typeof(ResolveUsis<,,,>))
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

                builder.RegisterType<UpsertPipelineStepsProvider>()
                    .As<IUpsertPipelineStepsProvider>()
                    .As<IPipelineStepsProvider>()
                    .SingleInstance();

                builder.RegisterType<DeletePipelineStepsProvider>()
                    .As<IDeletePipelineStepsProvider>()
                    .As<IPipelineStepsProvider>()
                    .SingleInstance();
            }

            void RegisterMiddleware()
            {
                builder.RegisterType<RequestCorrelationMiddleware>()
                    .As<IMiddleware>()
                    .AsSelf()
                    .SingleInstance();

                builder.RegisterType<ProblemDetailsErrorEnrichmentMiddleware>()
                    .As<IMiddleware>()
                    .AsSelf()
                    .SingleInstance();

                builder.RegisterType<OAuthContentTypeValidationMiddleware>()
                    .As<IMiddleware>()
                    .AsSelf()
                    .SingleInstance();

                builder.RegisterType<RequestResponseDetailsLoggerMiddleware>()
                    .As<IMiddleware>()
                    .WithParameter(
                        new ResolvedParameter(
                            (p, c) => p.Name == "logRequestResponseContentForMinutes",
                            (p, c) => c.Resolve<ApiSettings>().LogRequestResponseContentForMinutes))
                    .WithParameter(
                        new ResolvedParameter(
                        (p, c) => p.ParameterType == typeof(ReverseProxySettings),
                        (p, c) => c.Resolve<ApiSettings>().GetReverseProxySettings()))
                    .AsSelf()
                    .SingleInstance();

                builder.RegisterType<OdsInstanceIdentificationMiddleware>()
                    .As<IMiddleware>()
                    .AsSelf()
                    .SingleInstance();

                builder.RegisterType<OdsInstanceSelector>()
                    .As<IOdsInstanceSelector>()
                    .SingleInstance();

                builder.RegisterType<ErrorTranslator>().SingleInstance();

                builder.RegisterType<ModelStateKeyConverter>().EnableClassInterceptors().SingleInstance();

                builder.RegisterType<CachingInterceptor>()
                    .Named<IInterceptor>(InterceptorCacheKeys.ModelStateKey)
                    .WithParameter(ctx => (ICacheProvider<ulong>) new ConcurrentDictionaryCacheProvider<ulong>())
                    .SingleInstance();
            }
        }
    }
}
