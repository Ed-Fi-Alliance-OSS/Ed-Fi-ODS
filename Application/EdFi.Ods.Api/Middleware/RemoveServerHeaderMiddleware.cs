#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Threading.Tasks;
using Microsoft.Owin;

namespace EdFi.Ods.Api.Middleware {
    public class RemoveServerHeaderMiddleware : OwinMiddleware
    {
        public RemoveServerHeaderMiddleware(OwinMiddleware next)
            : base(next) { }

        public override Task Invoke(IOwinContext context)
        {
            context.Response.Headers.Remove("Server");
            return Next.Invoke(context);
        }
    }
}
#endif