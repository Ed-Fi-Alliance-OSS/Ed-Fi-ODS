// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Common;
using EdFi.Ods.Common.Database.Querying.Compilers;

namespace EdFi.Ods.Common.Database.Querying
{
    public class QueryFactory
    {
        public QueryFactory(DbConnection connection, Compiler compiler)
        {
            
        }

        public Query FromQuery(Query query)
        {
            return query;
        }
        
        public Func<Query> Logger;
    }
}
