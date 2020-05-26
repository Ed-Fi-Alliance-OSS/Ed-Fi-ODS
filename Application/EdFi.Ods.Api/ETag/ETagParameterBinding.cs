// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;

namespace EdFi.Ods.Api.ETag
{
    /// <summary>
    /// Retrieve an ETag from the appropriate header and place it in a method parameter
    /// </summary>
    public class ETagParameterBinding : HttpParameterBinding
    {
        private readonly ETagMatch _match;

        public ETagParameterBinding(HttpParameterDescriptor parameter, ETagMatch match)
            : base(parameter)
        {
            _match = match;
        }

        public override Task ExecuteBindingAsync(
            ModelMetadataProvider metadataProvider,
            HttpActionContext actionContext,
            CancellationToken cancellationToken)
        {
            string tag = string.Empty;
            IEnumerable<string> values;

            switch (_match)
            {
                case ETagMatch.IfNoneMatch:

                    //etagHeader = actionContext.Request.Headers.IfNoneMatch.FirstOrDefault();
                    actionContext.Request.Headers.TryGetValues("If-None-Match", out values);
                    tag = values.FirstOrDefault();
                    break;

                case ETagMatch.IfMatch:

                    //etagHeader = actionContext.Request.Headers.IfMatch.FirstOrDefault();
                    actionContext.Request.Headers.TryGetValues("If-Match", out values);
                    tag = values.FirstOrDefault();
                    break;
            }

            ETag etag = null;

            if (!string.IsNullOrEmpty(tag))
            {
                etag = new ETag
                       {
                           Tag = tag
                       };
            }

            actionContext.ActionArguments[Descriptor.ParameterName] = etag;

            var tsc = new TaskCompletionSource<object>();
            tsc.SetResult(null);
            return tsc.Task;
        }
    }
}
