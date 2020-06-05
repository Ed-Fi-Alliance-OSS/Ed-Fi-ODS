// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using EdFi.Ods.Api.Common.ExceptionHandling;
using EdFi.Ods.Api.Common.ExceptionHandling.EdFi;
using EdFi.Ods.Api.Common.ExceptionHandling.Translators;
using EdFi.Ods.Api.Common.ExceptionHandling.Translators.SqlServer;
using EdFi.Ods.Common.Utils;
using Rhino.Mocks;

namespace Test.Common
{
    public class TestBase
    {
        protected T Stub<T>()
            where T : class
        {
            return MockRepository.GenerateStub<T>();
        }

        protected void InitSystemClock(DateTime time)
        {
            SystemClock.Now = () => time;
        }

        protected IRESTErrorProvider GetErrorProvider()
        {
            return new RESTErrorProvider(BuildExceptionTranslators());
        }

        private static IEnumerable<IExceptionTranslator> BuildExceptionTranslators()
        {
            return new IExceptionTranslator[]
                   {
                       new TypeBasedBadRequestExceptionTranslator(),
                       new SqlServerConstraintExceptionTranslator(),
                       new SqlServerUniqueIndexExceptionTranslator(new DatabaseMetadataProvider()),
                       new EdFiSecurityExceptionTranslator(),
                       new NotFoundExceptionTranslator(),
                       new NotModifiedExceptionTranslator(),
                       new ConcurrencyExceptionTranslator()
                   };
        }

        protected TException TestForException<TException>(Action action)
            where TException : Exception
        {
            try
            {
                action();
                return null;
            }
            catch (TException e)
            {
                return e;
            }
        }
    }
}
