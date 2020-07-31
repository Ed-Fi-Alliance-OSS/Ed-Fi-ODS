// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.Sandbox.Security;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.ETag;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Api.IdentityValueMappers;
using EdFi.Ods.Api.NHibernate.Architecture;
using EdFi.Ods.Api.Pipelines.Factories;
using EdFi.Ods.Api.Services.Authentication;
using EdFi.Ods.Api.Services.Authentication.ClientCredentials;
using EdFi.Ods.Api.Services.Authorization;
using EdFi.Ods.Api.Services.Providers;
using EdFi.Ods.Api.Validation;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Http.Context;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Graphs;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Validation;
using EdFi.Ods.Pipelines;
using EdFi.Ods.Pipelines.Common;
using EdFi.Ods.Pipelines.Factories;
using EdFi.Ods.Sandbox.Provisioners;
using EdFi.Ods.Security.Claims;
using FluentValidation;

namespace EdFi.Ods.Api.Startup.Features.Installers
{
    public class CoreApiInstaller : IWindsorInstaller
    {
        private const string DescriptorCacheAbsoluteExpirationSecondsKey = "caching:descriptors:absoluteExpirationSeconds";
        private const string PersonCacheAbsoluteExpirationSecondsKey = "caching:personUniqueIdToUsi:absoluteExpirationSeconds";
        private const string PersonCacheSlidingExpirationSecondsKey = "caching:personUniqueIdToUsi:slidingExpirationSeconds";

        private readonly IConfigValueProvider _configValueProvider;
        private readonly Assembly _apiAssembly;
        private readonly IApiConfigurationProvider _apiConfigurationProvider;
        private readonly Assembly _standardAssembly;

        public CoreApiInstaller(IAssembliesProvider assembliesProvider, IApiConfigurationProvider apiConfigurationProvider, IConfigValueProvider configValueProvider)
        {
            Preconditions.ThrowIfNull(assembliesProvider, nameof(assembliesProvider));
            _apiConfigurationProvider = Preconditions.ThrowIfNull(apiConfigurationProvider, nameof(apiConfigurationProvider));
            _configValueProvider = Preconditions.ThrowIfNull(configValueProvider, nameof(configValueProvider));

            var installedAssemblies = assembliesProvider.GetAssemblies().ToList();

            _standardAssembly = installedAssemblies.SingleOrDefault(x => x.IsStandardAssembly());

            // TODO JSM - remove the calls using this once we move to the api assembly in ODS-2152. This makes it easy to find the specific locations in the file for now
            _apiAssembly = installedAssemblies.SingleOrDefault(x => x.GetName().Name.Equals("EdFi.Ods.Api"));
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterDomainModel(container);
            RegisterAuthenticationProvider(container);
            RegisterContextProviders(container);
            RegisterContextStorage(container);
            RegisterCacheProvider(container);
            RegisterDomainModelDefinitionsProvider(container);
            RegisterDatabaseMetadataProvider(container);
            RegisterEdFiDescriptorReflectionProvider(container);
            RegisterOAuthTokenValidator(container);
            RegisterClaims(container);
            RegisterEdFiOdsInstanceIdentificationProvider(container);
            RegisterETagProvider(container);
            RegisterUniqueIdToUsiValueMapper(container);
            RegisterPersonUniqueIdToUsiCache(container);
            RegisterValidators(container);
            RegisterEdFiOdsBasedPersonIdentifiersProvider(container);
            RegisterDescriptorCache(container);
            RegisterTokenRequestHandlers(container);
            RegisterExceptionHandling(container);
            RegisterSecureHashing(container);
            RegisterPipeline(container);
            RegisterResourceLoadGraphFactory(container);
            RegisterApiControllers(container);
            RegisterProfilesProcessing(container);
            RegisterApiVersionProvider(container);
            RegisterDefaultPageSizeLimitProvider(container);
        }

        private void RegisterDefaultPageSizeLimitProvider(IWindsorContainer container)
        {
            container.Register(Component.For<IDefaultPageSizeLimitProvider>().ImplementedBy<DefaultPageSizeLimitProvider>());
        }

        private void RegisterResourceLoadGraphFactory(IWindsorContainer container)
        {
            // Graph Model
            container.Register(
                Component.For<IResourceLoadGraphFactory>().ImplementedBy<ResourceLoadGraphFactory>());
        }

        private void RegisterDomainModel(IWindsorContainer container)
        {
            container.Register(

                // Domain Model
                Component.For<IDomainModelProvider>().ImplementedBy<DomainModelProvider>(),
                Component.For<DomainModel>()
                    .UsingFactoryMethod(kernel => kernel.Resolve<IDomainModelProvider>().GetDomainModel()),

                // Schema Name Map Provider
                Component.For<Schema[]>().UsingFactoryMethod(kernel => kernel.Resolve<DomainModel>().Schemas.ToArray()),
                Component.For<ISchemaNameMapProvider>()
                    .UsingFactoryMethod(kernel => kernel.Resolve<DomainModel>().SchemaNameMapProvider),

                // Resource Model Provider
                Component.For<IResourceModelProvider>().ImplementedBy<ResourceModelProvider>(),

                // Validator for the domain model provider
                Component.For<IExplicitObjectValidator>().ImplementedBy<FluentValidationObjectValidator>());
        }

        private void RegisterContextProviders(IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<IApiKeyContextProvider, IHttpContextStorageTransferKeys>()
                    .ImplementedBy<ApiKeyContextProvider>()
                    .IsFallback(),
                Component
                    .For<ISchoolYearContextProvider, IHttpContextStorageTransferKeys>()
                    .ImplementedBy<SchoolYearContextProvider>()
                    .IsFallback()
            );
        }

        private void RegisterContextStorage(IWindsorContainer container)
        {
            container.Register(

                // Primary context storage for ASP.NET web applications
                Component
                    .For<IContextStorage, HttpContextStorage>()
                    .ImplementedBy<HttpContextStorage>(),

                // Secondary context storage for background tasks running in ASP.NET web applications
                // Allows selected context to flow to worker Tasks (see IHttpContextStorageTransferKeys and IHttpContextStorageTransfer)
                Component
                    .For<IContextStorage, CallContextStorage>()
                    .ImplementedBy<CallContextStorage>(),

                // Features to transfer context from HttpContext to the secondary storage in ASP.NET applications
                Component
                    .For<IHttpContextStorageTransfer>()
                    .ImplementedBy<HttpContextStorageTransfer>());
        }

        private void RegisterCacheProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<ICacheProvider>()
                    .ImplementedBy<AspNetCacheProvider>()
                    .IsFallback());
        }

        private void RegisterDomainModelDefinitionsProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<IDomainModelDefinitionsProvider>()
                    .ImplementedBy<DomainModelDefinitionsJsonEmbeddedResourceProvider>()
                    .DependsOn(Dependency.OnValue("sourceAssembly", _standardAssembly)));
        }

        private void RegisterDatabaseMetadataProvider(IWindsorContainer container)
        {
            container.Register(
                Classes.FromAssembly(_standardAssembly).BasedOn<IDatabaseMetadataProvider>().WithService.Base());
        }

        private void RegisterEdFiDescriptorReflectionProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<IEdFiDescriptorReflectionProvider>()
                    .ImplementedBy<EdFiDescriptorReflectionProvider>());
        }

        private void RegisterOAuthTokenValidator(IWindsorContainer container)
        {
            container.Register(
                Component.For<IOAuthTokenValidator>().ImplementedBy<CachingOAuthTokenValidatorDecorator>().IsDecorator(),
                Component.For<IOAuthTokenValidator>().ImplementedBy<OAuthTokenValidator>());
        }

        private void RegisterApiControllers(IWindsorContainer container)
        {
            container.Register(

                // Controllers from code generation
                Classes.FromAssembly(_standardAssembly).BasedOn<ApiController>().LifestyleScoped(),

                // Register main API assembly's controllers.
                Classes.FromAssembly(_apiAssembly).BasedOn<ApiController>().LifestyleScoped());
        }

        private void RegisterClaims(IWindsorContainer container)
        {
            container.Register(Component.For<IClaimsIdentityProvider>().ImplementedBy<ClaimsIdentityProvider>());
        }

        private void RegisterEdFiOdsInstanceIdentificationProvider(IWindsorContainer container)
        {
            container.Register(
                Component.For<IEdFiOdsInstanceIdentificationProvider>().ImplementedBy<EdFiOdsInstanceIdentificationProvider>());
        }

        private void RegisterETagProvider(IWindsorContainer container)
        {
            container.Register(Component.For<IETagProvider>().ImplementedBy<ETagProvider>());
        }

        private void RegisterUniqueIdToUsiValueMapper(IWindsorContainer container)
        {
            container.Register(Component.For<IUniqueIdToUsiValueMapper>().ImplementedBy<UniqueIdToUsiValueMapper>().IsFallback());
        }

        private void RegisterPersonUniqueIdToUsiCache(IWindsorContainer container)
        {
            container.Register(Component.For<IPersonUniqueIdToUsiCache>()
                .ImplementedBy<PersonUniqueIdToUsiCache>()
                .DependsOn(Dependency.OnValue("slidingExpiration",
                    TimeSpan.FromSeconds(Convert.ToInt32(_configValueProvider.GetValue(PersonCacheSlidingExpirationSecondsKey) ?? "14400"))))
                .DependsOn(Dependency.OnValue("absoluteExpirationPeriod",
                    TimeSpan.FromSeconds(Convert.ToInt32(_configValueProvider.GetValue(PersonCacheAbsoluteExpirationSecondsKey) ?? "86400"))))
                .DependsOn(Dependency.OnValue("synchronousInitialization", false)));
        }

        private void RegisterDescriptorCache(IWindsorContainer container)
        {
            var absoluteExpirationPeriod = TimeSpan.FromSeconds(
                Convert.ToInt32(_configValueProvider.GetValue(DescriptorCacheAbsoluteExpirationSecondsKey) ?? "60"));

            var cacheProvider = new ExpiringConcurrentDictionaryCacheProvider(absoluteExpirationPeriod);

            container.Register(
                Component.For<IDescriptorsCache>()
                .ImplementedBy<DescriptorsCache>()
                .DependsOn(Dependency.OnValue<ICacheProvider>(cacheProvider)));
        }

        private void RegisterAuthenticationProvider(IWindsorContainer container)
        {
            container.Register(
                Component.For<IAuthenticationProvider>()
                    .ImplementedBy<OAuthAuthenticationProvider>());
        }

        private void RegisterTokenRequestHandlers(IWindsorContainer container)
        {
            container.Register(Component.For<ITokenRequestHandler>().ImplementedBy<ClientCredentialsTokenRequestHandler>());
        }

        private void RegisterValidators(IWindsorContainer container)
        {
            container.Register(
                Component.For<IEntityValidator>().ImplementedBy<DataAnnotationsEntityValidator>(),
                Component.For<IValidator<IEdFiDescriptor>>().ImplementedBy<DescriptorNamespaceValidator>(),
                Component.For<IResourceValidator>().ImplementedBy<FluentValidationPutPostRequestResourceValidator>(),
                Component.For<IResourceValidator>().ImplementedBy<DataAnnotationsResourceValidator>());
        }

        private void RegisterEdFiOdsBasedPersonIdentifiersProvider(IWindsorContainer container)
        {
            container.Register(
                Component.For<IPersonIdentifiersProvider>().ImplementedBy<PersonIdentifiersProvider>());
        }

        private void RegisterExceptionHandling(IWindsorContainer container)
        {
            container.Register(
                Component.For<IRESTErrorProvider>().ImplementedBy<RESTErrorProvider>(),
                Classes.FromAssemblyContaining<Marker_EdFi_Ods_Api>().BasedOn<IExceptionTranslator>()
                    .WithService.Base());
        }

        private void RegisterSecureHashing(IWindsorContainer container)
        {
            if (_apiConfigurationProvider.Mode.Equals(ApiMode.Sandbox))
            {
                container.Register(Component.For<ISecretVerifier>().ImplementedBy<PlainTextSecretVerifier>().IsFallback());
            }
            else
            {
                container.Register(

                    // decorators need to be registered first.
                    Component.For<ISecretVerifier>().ImplementedBy<AutoUpgradingHashedSecretVerifierDecorator>().IsDecorator(),
                    Component.For<ISecretVerifier>().ImplementedBy<SecureHashAwareSecretVerifier>().IsFallback());
            }

            container.Register(
                Component.For<IApiClientAuthenticator>().ImplementedBy<ApiClientAuthenticator>(),
                Component.For<IApiClientIdentityProvider, IApiClientSecretProvider>()
                    .ImplementedBy<EdFiAdminApiClientIdentityProvider>(),
                Component.For<IPackedHashConverter>().ImplementedBy<PackedHashConverter>(),
                Component.For<ISecurePackedHashProvider>().ImplementedBy<SecurePackedHashProvider>(),
                Component.For<IHashConfigurationProvider>().ImplementedBy<DefaultHashConfigurationProvider>(),
                Component.For<ISecureHasher>().ImplementedBy<Pbkdf2HmacSha1SecureHasher>());
        }

        private void RegisterPipeline(IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<IPipelineFactory>()
                    .ImplementedBy<PipelineFactory>()
                    .DependsOn(
                        new {locator = container}),
                Classes.FromAssembly(_standardAssembly)
                    .BasedOn(typeof(ICreateOrUpdatePipeline<,>))
                    .WithService.AllInterfaces(),
                Classes
                    .FromAssembly(_apiAssembly)
                    .BasedOn(typeof(IStep<,>))
                    .WithService
                    .Self(),

                // Register the providers of the core pipeline steps
                Classes
                    .FromAssembly(_apiAssembly)
                    .BasedOn<IPipelineStepsProvider>()
                    .WithServiceFirstInterface());
        }

        private void RegisterProfilesProcessing(IWindsorContainer container)
        {
            container.Register(
                Component.For<IProfileResourceNamesProvider, IProfileMetadataProvider>()
                    .ImplementedBy<ProfileResourceNamesProvider>());
        }

        private void RegisterApiVersionProvider(IWindsorContainer container)
        {
            container.Register(
                Component.For<IApiVersionProvider>()
                    .ImplementedBy<EnterpriseApiVersionProvider>()
                    .IsFallback());
        }
    }
}
