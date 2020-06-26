// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Security.Claims;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.Sandbox.Provisioners;
using EdFi.Ods.Sandbox.Repositories;
using EdFi.Ods.Api;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Api.Identity;
using EdFi.Ods.Api.Services.Authorization;
using EdFi.Ods.Api.Services.Controllers.IdentityManagement;
using EdFi.Ods.Common.Composites;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.IO;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Models.Graphs;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Profiles.Test;
using EdFi.Ods.Security.Claims;
using EdFi.Ods.Standard;

namespace EdFi.Ods.WebService.Tests._Installers
{
    public class WebApiInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IApiKeyContextProvider, IHttpContextStorageTransferKeys>()
                    .ImplementedBy<ApiKeyContextProvider>());

            container.Register(
                Component
                    .For<ISchoolYearContextProvider, IHttpContextStorageTransferKeys>()
                    .ImplementedBy<SchoolYearContextProvider>());

            container.Register(
                Component
                    .For(typeof(ICompositeDefinitionProcessor<,>))
                    .ImplementedBy(typeof(CompositeDefinitionProcessor<,>)));

            container.Register(
                Component
                    .For<IResourceJoinPathExpressionProcessor>()
                    .ImplementedBy<ResourceJoinPathExpressionProcessor>());

            container.Register(
                Component
                    .For<IFileSystem>()
                    .ImplementedBy<FileSystemWrapper>());

            container.Register(Component
                .For<IResourceLoadGraphFactory>()
                .ImplementedBy<ResourceLoadGraphFactory>());

            container.Register(
                Component.For<IRESTErrorProvider>().ImplementedBy<RESTErrorProvider>(),
                Classes.FromAssemblyContaining<Marker_EdFi_Ods_Api>().BasedOn<IExceptionTranslator>()
                    .WithService.Base());

            // TODO: GKM - Profiles - temporary workaround for lack of composability
            RegisterNHibernateComponents(container);

            container.Install(new LegacyEdFiOdsApiInstaller());

            RegisterEduIdDependencies(container);
            RegisterOAuthTokenValidator(container);

            // Register specific implementations
            // -----------------------------------

            // Controllers
            // These are api controllers so they need to be scoped to fit the Windsor integration for resolving dependencies
            container.Register(
                Classes.FromAssemblyContaining<Marker_EdFi_Ods_Standard>()
                       .BasedOn<ApiController>()
                       .LifestyleScoped());

            container.Register(
                Classes.FromAssemblyContaining<Marker_EdFi_Ods_Profiles_Test>()
                    .BasedOn<ApiController>()
                    .LifestyleScoped());

            // Register main API assembly's controllers
            container.Register(
                Classes.FromAssemblyContaining<Marker_EdFi_Ods_Api>()
                       .BasedOn<ApiController>()
                       .LifestyleScoped());

            // TODO: GKM - IMPORTANT: Review these registrations from Muhammad's pull request
            container.Register(
                Component.For<ISandboxProvisioner>()
                         .ImplementedBy<SqlSandboxProvisioner>());

            container.Register(
                Component.For<IClaimsIdentityProvider>()
                         .ImplementedBy<ClaimsIdentityProvider>());

            ClaimsPrincipal.ClaimsPrincipalSelector =
                () => EdFiClaimsPrincipalSelector.GetClaimsPrincipal(container.Resolve<IClaimsIdentityProvider>());

            // TODO: Remove with ODS-2973, deprecated by ProfilesFeatureInstaller
            container.Register(
                Component.For<IProfileResourceNamesProvider, IProfileMetadataProvider>()
                         .ImplementedBy<ProfileResourceNamesProvider>());

            // TODO: Remove with ODS-2973, deprecated by CompositesFeatureInstaller
            container.Register(
                Component.For<ICompositesMetadataProvider>()
                         .ImplementedBy<CompositesMetadataProvider>());
        }

        protected virtual void RegisterNHibernateComponents(IWindsorContainer container)
        {
            // TODO: GKM - Profiles - temporary workaround for lack of composability
            container.Install(new LegacyEdFiOdsNHibernateInstaller());
        }

        protected virtual void RegisterOAuthTokenValidator(IWindsorContainer container)
        {
            container.Register(Component.For<IAccessTokenClientRepo>().ImplementedBy<AccessTokenClientRepo>());

            container.Register(
                Component.For<IOAuthTokenValidator>()
                         .ImplementedBy<OAuthTokenValidator>());

            container.Register(
                Component.For<IOAuthTokenValidator>()
                         .ImplementedBy<CachingOAuthTokenValidatorDecorator>()
                         .IsDefault());
        }

        protected virtual void RegisterEduIdDependencies(IWindsorContainer container)
        {
            // registrations for IIdentityService (IdentityController2)
            container.Register(
                Component.For<IIdentityService, IIdentityServiceAsync>()
                         .ImplementedBy<UnimplementedIdentityService>()
            );
        }
    }
}
