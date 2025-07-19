// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Models.Domain;
using NHibernate;

namespace EdFi.Ods.Common.Infrastructure.Interceptors
{
    public class EdFiOdsInterceptor : EmptyInterceptor
    {
        public override bool? IsTransient(object entity)
        {
            // New implementation -- avoid reflection if possible
            if (entity is DomainObjectBase domainObject)
            {
                return domainObject.CreateDate == default;
            }

            // Fallback legacy logic (kept intact here, just in case)
            var property = entity.GetType().GetProperty("CreateDate");

            if (property != null)
            {
                bool isTransient = Convert.ToDateTime(property.GetValue(entity)) == default(DateTime);

                return isTransient;
            }

            return base.IsTransient(entity);
        }
    }
}
