using System.Collections.Generic;
using Newtonsoft.Json;

/*
    SPDX-License-Identifier: BSD-3-Clause

    Copyright (c) 2013, Richard Morris
    All rights reserved.

    Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

    1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

    2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer
        in the documentation and/or other materials provided with the distribution.

    3. Neither the name of the copyright holder nor the names of its contributors may be used to endorse or promote products derived 
        from this software without specific prior written permission.

    THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, 
    INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
    IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
    OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS;
    OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, 
    OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE
*/

// NOTE: the original document(s) have a vendorExtensions dictionary that has been removed.
namespace EdFi.Ods.Features.OpenApiMetadata.Models
{
    public class OpenApiMetadataDocument
    {
        public readonly string swagger = "2.0";

        public string basePath;

        public IList<string> consumes;

        public IDictionary<string, Schema> definitions;

        public ExternalDocs externalDocs;

        public string host;

        public Info info;

        public IDictionary<string, Parameter> parameters;

        public IDictionary<string, PathItem> paths;

        public IList<string> produces;

        public IDictionary<string, Response> responses;

        public IList<string> schemes;

        public IList<IDictionary<string, IEnumerable<string>>> security;

        public IDictionary<string, SecurityScheme> securityDefinitions;

        public IList<Tag> tags;
    }

    public class Info
    {
        public Contact contact;

        public string description;

        public License license;

        public string termsOfService;

        public string title;
        public string version;
    }

    public class Contact
    {
        public string email;
        public string name;

        public string url;
    }

    public class License
    {
        public string name;

        public string url;
    }

    public class PathItem
    {
        public Operation delete;

        public Operation get;

        public Operation head;

        public Operation options;

        public IList<Parameter> parameters;

        public Operation patch;

        public Operation post;

        public Operation put;
        [JsonProperty("$ref")]
        public string @ref;
    }

    public class Operation
    {
        public IList<string> consumes;

        public bool? deprecated;

        public string description;

        public ExternalDocs externalDocs;

        public string operationId;

        public IList<Parameter> parameters;

        public IList<string> produces;

        public IDictionary<string, Response> responses;

        public IList<string> schemes;

        public IList<IDictionary<string, IEnumerable<string>>> security;

        public string summary;
        public IList<string> tags;
    }

    public class Tag
    {
        public string description;

        public ExternalDocs externalDocs;
        public string name;
    }

    public class ExternalDocs
    {
        public string description;

        public string url;
    }

    public class Parameter : PartialSchema
    {
        public string description;

        public string @in;

        [JsonProperty("x-Ed-Fi-isIdentity")]
        public bool? isIdentity;

        public string name;

        [JsonProperty("$ref")]
        public string @ref;

        public bool? required;

        public Schema schema;

        [JsonProperty("x-Ed-Fi-isDeprecated")]
        public bool? isDeprecated;

        [JsonProperty("x-Ed-Fi-deprecatedReasons")]
        public string deprecatedReasons;
    }

    public class Schema
    {
        public Schema additionalProperties;

        public IList<Schema> allOf;

        public object @default;

        public string description;

        public string discriminator;

        public IList<object> @enum;

        public object example;

        public bool? exclusiveMaximum;

        public bool? exclusiveMinimum;

        public ExternalDocs externalDocs;

        public string format;

        [JsonProperty("x-Ed-Fi-isIdentity")]
        public bool? isIdentity;

        public Schema items;

        public int? maximum;

        public int? maxItems;

        public int? maxLength;

        public int? maxProperties;

        public int? minimum;

        public int? minItems;

        public int? minLength;

        public int? minProperties;

        public int? multipleOf;

        public string pattern;

        public IDictionary<string, Schema> properties;

        public bool? readOnly;

        [JsonProperty("$ref")]
        public string @ref;

        public IList<string> required;

        public string title;

        public string type;

        public bool? uniqueItems;

        public Xml xml;

        [JsonProperty("x-Ed-Fi-isDeprecated")]
        public bool? isDeprecated;

        [JsonProperty("x-Ed-Fi-deprecatedReasons")]
        public string deprecatedReasons;
    }

    public class PartialSchema
    {
        public string collectionFormat;

        public object @default;

        public IList<object> @enum;

        public bool? exclusiveMaximum;

        public bool? exclusiveMinimum;

        public string format;

        public PartialSchema items;

        public int? maximum;

        public int? maxItems;

        public int? maxLength;

        public int? minimum;

        public int? minItems;

        public int? minLength;

        public int? multipleOf;

        public string pattern;
        public string type;

        public bool? uniqueItems;
    }

    public class Response
    {
        public string description;

        public object examples;

        public IDictionary<string, Header> headers;
        [JsonProperty("$ref")]
        public string @ref;

        public Schema schema;
    }

    public class Header : PartialSchema
    {
        public string description;
    }

    public class Xml
    {
        public bool? attribute;
        public string name;

        public string @namespace;

        public string prefix;

        public bool? wrapped;
    }

    public class SecurityScheme
    {
        public string authorizationUrl;

        public string description;

        public string flow;

        public string @in;

        public string name;

        public IDictionary<string, string> scopes;

        public string tokenUrl;
        public string type;
    }
}
