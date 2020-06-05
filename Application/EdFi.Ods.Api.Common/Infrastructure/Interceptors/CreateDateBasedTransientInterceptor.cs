// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using NHibernate;

namespace EdFi.Ods.Api.Common.Infrastructure.Interceptors
{
    public class CreateDateBasedTransientInterceptor : EmptyInterceptor
    {
        public override bool? IsTransient(object entity)
        {
            var property = entity.GetType()
                                 .GetProperty("CreateDate");

            if (property != null)
            {
                bool isTransient = Convert.ToDateTime(property.GetValue(entity)) == default(DateTime);

                return isTransient;
            }

            return base.IsTransient(entity);
        }
    }
}
