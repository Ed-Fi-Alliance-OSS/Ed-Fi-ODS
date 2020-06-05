// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using EdFi.Ods.Api.Common.ExceptionHandling;
using EdFi.Ods.Api.Common.ExceptionHandling.Translators;
using EdFi.Ods.Api.Common.ExceptionHandling.Translators.SqlServer;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Factories;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.InversionOfControl;
using Rhino.Mocks;

namespace EdFi.Ods.Tests.EdFi.Ods.WebApi.Controllers
{
    public class StubEtagProviderSinceWeReallyDontCareWhatTheValueIs : IETagProvider
    {
        public string GetETag(object value)
        {
            return "new" + value;
        }

        public DateTime GetDateTime(string etag)
        {
            return new DateTime(2000, 1, 1);
        }
    }

    public class StubCurrentSchoolYearContextProvider : ISchoolYearContextProvider
    {
        public int GetSchoolYear()
        {
            return DateTime.Now.Year;
        }

        public void SetSchoolYear(int schoolYear)
        {
            throw new NotImplementedException();
        }
    }

    internal class StubDatabaseMetadataProvider : IDatabaseMetadataProvider
    {
        public IndexDetails GetIndexDetails(string indexName)
        {
            return new IndexDetails
                   {
                       IndexName = "FK_TableName_IndexId", TableName = "TableName", ColumnNames = new List<string>
                                                                                                  {
                                                                                                      "TableNameId"
                                                                                                  }
                   };
        }
    }

    public static class TestControllerBuilder
    {
        public static T GetController<T>(IPipelineFactory factory, string id = null)
            where T : ApiController
        {
            var translators = new IExceptionTranslator[]
                              {
                                  new TypeBasedBadRequestExceptionTranslator(),
                                  new SqlServerConstraintExceptionTranslator(),
                                  new SqlServerUniqueIndexExceptionTranslator(new StubDatabaseMetadataProvider()),
                                  new EdFiSecurityExceptionTranslator(),
                                  new NotFoundExceptionTranslator(),
                                  new NotModifiedExceptionTranslator(),
                                  new ConcurrencyExceptionTranslator(),
                                  new DuplicateNaturalKeyCreateExceptionTranslator(new StubDatabaseMetadataProvider())
                              };

            var schoolYearContextProvider = MockRepository.GenerateStub<ISchoolYearContextProvider>();

            schoolYearContextProvider.Stub(x => x.GetSchoolYear())
                                     .Return(DateTime.Now.Year);

            var controller =
                (T)
                Activator.CreateInstance(
                    typeof(T),
                    factory,
                    new StubCurrentSchoolYearContextProvider(),
                    new RESTErrorProvider(translators));

            controller.Configuration = new HttpConfiguration();
            var uri = $@"http://localhost/api/ods/v3/ed-fi/Students/{id}";

            controller.Request = new HttpRequestMessage
                                 {
                                     RequestUri = new Uri(uri)
                                 };

            return controller;
        }

        public static WindsorContainerEx GetWindsorContainer()
        {
            var container = new WindsorContainerEx();
            container.AddSupportForEmptyCollections();

            container.Register(
                Component
                   .For<ISchoolYearContextProvider>()
                   .ImplementedBy<StubCurrentSchoolYearContextProvider>());

            container.Register(
                Component
                   .For<IETagProvider>()
                   .ImplementedBy<StubEtagProviderSinceWeReallyDontCareWhatTheValueIs>());

            container.Register(
                Classes.FromThisAssembly()
                       .BasedOn(typeof(IStep<,>)));

            return container;
        }
    }
}
