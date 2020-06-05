// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Models;
using EdFi.Ods.Api.Services.Metadata;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using Newtonsoft.Json;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Metadata.Helpers
{
    public static class OpenApiMetadataHelper
    {
        public static OpenApiMetadataDocument DeserializeSwaggerDocument(string json)
        {
            return JsonConvert.DeserializeObject<OpenApiMetadataDocument>(
                json,
                new JsonSerializerSettings {MetadataPropertyHandling = MetadataPropertyHandling.Ignore}
            );
        }

        public static OpenApiContent GetIdentityContent()
        {
            var identityJson = @"{  
                       ""swagger"":""2.0"",
                       ""info"":{  
                          ""description"":""The Ed-Fi ODS / API enables applications to read and write education data stored in an Ed-Fi ODS through a secure REST interface. \n***\n > *Note: Consumers of ODS / API information should sanitize all data for display and storage. The ODS / API provides reasonable safeguards against cross-site scripting attacks and other malicious content, but the platform does not and cannot guarantee that the data it contains is free of all potentially harmful content.* \n***\n"",
                          ""title"":""Identity API Endpoints"",
                          ""version"":""2""
                       },
                       ""host"":""%HOST%"",
                       ""basePath"":""%BASE_PATH%"",
                       ""paths"":{  
                          ""/identities"":{  
                             ""post"":{  
                                ""consumes"":[  
                                   ""application/json"",
                                   ""text/json""
                                ],
                                ""produces"":[  
                                   ""application/json"",
                                   ""text/json""
                                ],
                                ""parameters"":[  
                                   {  
                                      ""description"":""Identity object to be created."",
                                      ""in"":""body"",
                                      ""name"":""request"",
                                      ""required"":true,
                                      ""schema"":{  
                                         ""$ref"":""#/definitions/IdentityCreateRequest""
                                      }
                                   }
                                ],
                                ""responses"":{  
                                   ""200"":{  
                                      ""description"":""An Identity was created. The new Unique Id is returned in the returned Identity record."",
                                      ""schema"":{  
                                         ""type"":""string""
                                      }
                                   },
                                   ""400"":{  
                                      ""description"":""There were invalid properties.""
                                   },
                                   ""501"":{  
                                      ""description"":""The server does not support the requested function.""
                                   },
                                   ""502"":{  
                                      ""description"":""The underlying identity system returned an error.""
                                   }
                                },
                                ""tags"":[  
                                   ""Identities""
                                ],
                                ""description"":""Assumption here is that the user has verified that possible matches are not correct matches. Returns the created identity information along with the assigned Unique Id."",
                                ""operationId"":""Identities_Create"",
                                ""summary"":""Creates a new Unique Id for the given Identity information.""
                             }
                          }
	                    },
	                    ""securityDefinitions"": {
                        ""oauth2_client_credentials"": {
                          ""type"": ""oauth2"",
                          ""description"": ""Ed-Fi ODS/API OAuth 2.0 Client Credentials Grant Type authorization"",
                          ""flow"": ""application"",
                          ""tokenUrl"": ""%TOKEN_URL%"",
                          ""scopes"": {}
                        }
                      },                       
                    }";

            return new OpenApiContent(
                "Other", "identity", new Lazy<string>(() => identityJson), $"Identity/v{ApiVersionConstants.Identity}");
        }
    }
}
