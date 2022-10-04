// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Serialization;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Profiles;
using EdFi.Ods.Common.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EdFi.Ods.Api.Startup;

public class NewtonsoftJsonOptionConfigurator : IConfigureOptions<MvcNewtonsoftJsonOptions>
{
    private readonly IContextProvider<ProfileContentTypeContext> _profileContentTypeContextProvider;
    private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
    private readonly IProfileResourceModelProvider _profileResourceModelProvider;

    public NewtonsoftJsonOptionConfigurator(
        IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider,
        IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
        IProfileResourceModelProvider profileResourceModelProvider)
    {
        _profileContentTypeContextProvider = profileContentTypeContextProvider;
        _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
        _profileResourceModelProvider = profileResourceModelProvider;
    }

    public void Configure(MvcNewtonsoftJsonOptions options)
    {
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
        options.SerializerSettings.DateParseHandling = DateParseHandling.None;
        options.SerializerSettings.Formatting = Formatting.Indented;
        options.SerializerSettings.ContractResolver 
            = new ProfilesAwareContractResolver(
                _profileContentTypeContextProvider, 
                _dataManagementResourceContextProvider, 
                _profileResourceModelProvider)
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
    }
}
