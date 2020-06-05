// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Features.OpenApiMetadata.Models;

namespace EdFi.Ods.Features.OpenApiMetadata.Factories
{
    public class SwaggerResponsesFactory
    {
        public IDictionary<string, Response> Create()
        {
            return new Dictionary<string, Response>
                   {
                       // 201
                       {
                           "Created", new Response
                                      {
                                          description =
                                              "The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                                      }
                       },

                       // 204
                       {
                           "Updated", new Response
                                      {
                                          description =
                                              "The resource was updated.  An updated ETag value is available in the ETag header of the response."
                                      }
                       },

                       // 204
                       {
                           "Deleted", new Response
                                      {
                                          description = "The resource was successfully deleted."
                                      }
                       },

                       // 304
                       {
                           "NotModified", new Response
                                          {
                                              description =
                                                  "The resource's current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                                          }
                       },

                       // 400
                       {
                           "BadRequest", new Response
                                         {
                                             description =
                                                 "Bad Request. The request was invalid and cannot be completed. See the response body for specific validation errors. This will typically be an issue with the query parameters or their values."
                                         }
                       },

                       // 401
                       {
                           "Unauthorized", new Response
                                           {
                                               description =
                                                   "Unauthorized. The request requires authentication. The OAuth bearer token was either not provided or is invalid. The operation may succeed once authentication has been successfully completed."
                                           }
                       },

                       // 403
                       {
                           "Forbidden", new Response
                                        {
                                            description =
                                                "Forbidden. The request cannot be completed in the current authorization context. Contact your administrator if you believe this operation should be allowed."
                                        }
                       },

                       // 404
                       {
                           "NotFound", new Response
                                       {
                                           description = "The resource could not be found."
                                       }
                       },

                       // 409
                       {
                           "Conflict", new Response
                                       {
                                           description =
                                               "Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                                       }
                       },

                       // 412
                       {
                           "PreconditionFailed", new Response
                                                 {
                                                     description =
                                                         "The resource's current server-side ETag value does not match the supplied If-Match header value in the request. This indicates the resource has been modified by another consumer."
                                                 }
                       },

                       // 500
                       {
                           "Error", new Response
                                    {
                                        description =
                                            "An unhandled error occurred on the server. See the response body for details."
                                    }
                       }
                   };
        }
    }
}
