// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
#if NETFRAMEWORK
using log4net;
using Microsoft.Owin;

namespace EdFi.Ods.Api.Middleware {
    public class InvalidWindsorContainerMiddleware : OwinMiddleware
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(InvalidWindsorContainerMiddleware));

        public InvalidWindsorContainerMiddleware(OwinMiddleware next)
            : base(next) { }

        public override Task Invoke(IOwinContext context)
        {
            _logger.Debug("Windsor container is invalid");

            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            context.Response.Body = new MemoryStream(Encoding.UTF8.GetBytes("An unexpected error occurred"));
            return Task.FromResult(0);
        }
    }
}
#endif
