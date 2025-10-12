// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Xml;
using EdFi.Admin.DataAccess.Models;
using EdFi.Admin.DataAccess.Repositories;
using EdFi.Admin.DataAccess.Utils;
using EdFi.Common.Configuration;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Api.Startup;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using log4net;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Formatting = Newtonsoft.Json.Formatting;
using TenantConfiguration = EdFi.Ods.Common.Configuration.TenantConfiguration;

namespace EdFi.Ods.Api.IntegrationTestHarness
{
    public class UpdateAdminDatabaseStartupCommand : IStartupCommand
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(UpdateAdminDatabaseStartupCommand));
        private readonly IClientAppRepo _clientAppRepo;
        private readonly IDefaultApplicationCreator _defaultApplicationCreator;
        private readonly IConfiguration _configuration;
        private readonly IFeatureManager _featureManager;
        private readonly DatabaseEngine _databaseEngine;
        private readonly TestHarnessConfiguration _testHarnessConfiguration;
        private readonly ITenantConfigurationMapProvider _tenantConfigurationMapProvider;
        private readonly IContextProvider<TenantConfiguration> _tenantConfigurationContextProvider;
        private readonly IDomainModelProvider _domainModelProvider;
        private readonly Version _edfiDomainModelVersion;
        private readonly long _maxSafeEducationOrganizationId;

        public UpdateAdminDatabaseStartupCommand(IClientAppRepo clientAppRepo,
            IDefaultApplicationCreator defaultApplicationCreator,
            IConfiguration configuration,
            IFeatureManager featureManager,
            DatabaseEngine databaseEngine,
            TestHarnessConfigurationProvider testHarnessConfigurationProvider,
            IDomainModelProvider domainModelProvider)
        {
            _clientAppRepo = clientAppRepo;
            _defaultApplicationCreator = defaultApplicationCreator;
            _configuration = configuration;
            _featureManager = featureManager;
            _databaseEngine = databaseEngine;
            _testHarnessConfiguration = testHarnessConfigurationProvider.GetTestHarnessConfiguration();
            _domainModelProvider = domainModelProvider;

            _edfiDomainModelVersion = Version.Parse(
                _domainModelProvider
                    .GetDomainModel()
                    .Schemas
                    .Single(x => x.LogicalName.EqualsIgnoreCase(EdFiConventions.LogicalName))
                    .Version
            );

            // The biggest int64 value that can be stored in a double precision floating point format
            // that can be used in Javascript for Postman tests. See Number.MAX_SAFE_INTEGER for reference.
            const long maxSafeInt64 = 9007199254740991;
            _maxSafeEducationOrganizationId = _edfiDomainModelVersion.Major < 5 ? int.MaxValue : maxSafeInt64;
        }

        public UpdateAdminDatabaseStartupCommand(IClientAppRepo clientAppRepo,
            IDefaultApplicationCreator defaultApplicationCreator,
            IConfiguration configuration,
            IFeatureManager featureManager,
            DatabaseEngine databaseEngine,
            TestHarnessConfigurationProvider testHarnessConfigurationProvider,
            IContextProvider<TenantConfiguration> tenantConfigurationContextProvider,
            ITenantConfigurationMapProvider tenantConfigurationMapProvider,
            IDomainModelProvider domainModelProvider)
            : this(clientAppRepo, defaultApplicationCreator, configuration, featureManager, databaseEngine, testHarnessConfigurationProvider, domainModelProvider)
        {
            _tenantConfigurationMapProvider = tenantConfigurationMapProvider;
            _tenantConfigurationContextProvider = tenantConfigurationContextProvider;
        }

        public Task ExecuteAsync()
        {
            PostmanEnvironment postmanEnvironment;

            if (!_featureManager.IsFeatureEnabled(ApiFeature.MultiTenancy))
            {
                _logger.Debug($"Loading test data in Admin Database.");
                postmanEnvironment = UpdateAdminDatabase();
            }
            else
            {
                postmanEnvironment = new PostmanEnvironment();
                foreach (var tenantConfigurationMap in _tenantConfigurationMapProvider.GetMap())
                {
                    _tenantConfigurationContextProvider.Set(tenantConfigurationMap.Value);

                    _logger.Debug($"Loading test data in Admin Database for tenant {tenantConfigurationMap.Key}.");
                    var ret = UpdateAdminDatabase(tenantConfigurationMap.Key);
                    postmanEnvironment.Values.AddRange(ret.Values);

                    _tenantConfigurationContextProvider.Set(null);
                }
            }

            CreateEnvironmentFile();

            return Task.CompletedTask;

            void CreateEnvironmentFile()
            {
                // This checks if the Ed-Fi Data Standard in use has a Parent entity,
                // which was renamed to Contact in Data Standard version 5.0.0.
                var parentOrContactProperName = _edfiDomainModelVersion.Major < 5 ? "Parent" : "Contact";

                var environmentFilePath = _configuration.GetValue<string>("environmentFilePath");

                if (!string.IsNullOrEmpty(environmentFilePath) && new DirectoryInfo(environmentFilePath).Exists)
                {
                    postmanEnvironment.Values.Add(
                        new ValueItem
                        {
                            Enabled = true,
                            Value = _configuration.GetValue<string>("Urls") ?? "http://localhost:8765/",
                            Key = "ApiBaseUrl"
                        });

                    postmanEnvironment.Values.Add(
                        new ValueItem
                        {
                            Enabled = true,
                            Value =  _featureManager.IsFeatureEnabled(ApiFeature.Composites),
                            Key = "CompositesFeatureIsEnabled"
                        });

                    postmanEnvironment.Values.Add(
                        new ValueItem
                        {
                            Enabled = true,
                            Value = _featureManager.IsFeatureEnabled(ApiFeature.Profiles),
                            Key = "ProfilesFeatureIsEnabled"
                        });

                    postmanEnvironment.Values.Add(
                        new ValueItem
                        {
                            Enabled = true,
                            Value = _featureManager.IsFeatureEnabled(ApiFeature.ChangeQueries),
                            Key = "ChangeQueriesFeatureIsEnabled"
                        });

                    // The following variable provides the Postman collections with the correct parent/
                    // contact related entity name for the Ed-Fi data standard currently in use.
                    postmanEnvironment.Values.Add(
                        new ValueItem
                        {
                            Enabled = true, 
                            Value = parentOrContactProperName,
                            Key = "ParentOrContactProperName"
                        });

                    postmanEnvironment.Values.Add(
                        new ValueItem
                        {
                            Enabled = true,
                            Value = _maxSafeEducationOrganizationId,
                            Key = "MaxSafeEducationOrganizationId"
                        });

                    var jsonString = JsonConvert.SerializeObject(
                        postmanEnvironment,
                        Formatting.Indented,
                        new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

                    var fileName = Path.Combine(environmentFilePath, "environment.json");

                    File.WriteAllText(fileName, jsonString);
                }
            }
        }

        private PostmanEnvironment UpdateAdminDatabase(string tenantIdentifier = null)
        {
            var postmanEnvironment = new PostmanEnvironment();

            _clientAppRepo.Reset();

            // Add ODS instance
            string odsConnectionString = string.Format(_configuration.GetConnectionString("EdFi_Ods"), tenantIdentifier);

            var dbConnectionStringBuilderAdapterFactory =
                new DbConnectionStringBuilderAdapterFactory(_databaseEngine);

            var connectionStringBuilderAdapter = dbConnectionStringBuilderAdapterFactory.Get();
            connectionStringBuilderAdapter.ConnectionString = odsConnectionString;
            string odsDatabaseName = connectionStringBuilderAdapter.DatabaseName;

            var odsInstance = _clientAppRepo.CreateOdsInstance(
                new OdsInstance()
                {
                    Name = odsDatabaseName,
                    InstanceType = "ODS",
                    ConnectionString = odsConnectionString,
                });

            // Add Profiles
            string[] profileFilenames = Directory.GetFiles(Directory.GetParent(AppContext.BaseDirectory).FullName, $"*Profiles.xml");

            if(!string.IsNullOrEmpty(tenantIdentifier))
            {
                profileFilenames = profileFilenames.Union(Directory.GetFiles(Directory.GetParent(AppContext.BaseDirectory).FullName, $"*Profiles{tenantIdentifier}.xml")).ToArray();
            }
            
            var profileDefinitionByName = new Dictionary<string, XmlNode>(StringComparer.OrdinalIgnoreCase);

            foreach (var profileFilename in profileFilenames)
            {
                var _allDocs = new XmlDocument();
                _allDocs.Load(profileFilename);

                var profiles = new List<Profile>();
                var profileDefinitions = _allDocs.SelectNodes("/Profiles/Profile");
                foreach (XmlNode profileDefinition in profileDefinitions)
                {
                    string profileName = profileDefinition.Attributes["name"].Value;

                    profiles.Add(
                        new Profile()
                        {
                            ProfileDefinition = profileDefinition.OuterXml,
                            ProfileName = profileName
                        });
                    
                    profileDefinitionByName.Add(profileName, profileDefinition);
                }
                _clientAppRepo.CreateProfilesWithProfileDefinition(profiles);
            }

            foreach (var vendor in _testHarnessConfiguration.Vendors.Where(x =>
                string.IsNullOrEmpty(tenantIdentifier) ||
                x.TenantIdentifier.Equals(tenantIdentifier, StringComparison.InvariantCultureIgnoreCase)))
            {
                var user = _clientAppRepo.GetUser(vendor.Email) ??
                           _clientAppRepo.CreateUser(
                               new User
                               {
                                   FullName = vendor.VendorName,
                                   Email = vendor.Email,
                                   Vendor = _clientAppRepo.CreateOrGetVendor(
                                       vendor.Email, vendor.VendorName, vendor.NamespacePrefixes)
                               });

                foreach (var app in vendor.Applications)
                {
                    var application = _clientAppRepo.CreateApplicationForVendor(
                        user.Vendor.VendorId, app.ApplicationName, app.ClaimSetName);

                    var edOrgIds = app.ApiClients
                        .SelectMany(s => s.LocalEducationOrganizations)
                        .SelectMany(l => Range(l.Start, l.Count))
                        .Select(PreventEducationOrganizationIdOverflow)
                        .Distinct()
                        .ToList();

                    _defaultApplicationCreator.AddEdOrgIdsToApplication(edOrgIds, application.ApplicationId);

                    foreach (var client in app.ApiClients)
                    {
                        var key = !string.IsNullOrEmpty(client.Key)
                            ? client.Key
                            : client.ApiClientName;

                        var secret = !string.IsNullOrEmpty(client.Secret)
                            ? client.Secret
                            : client.ApiClientName;

                        var isApproved = client.IsApproved ?? true;

                        var apiClient = _clientAppRepo.CreateApiClient(user.UserId, client.ApiClientName, key, secret, isApproved);

                        postmanEnvironment.Values.Add(
                            new ValueItem
                            {
                                Enabled = true,
                                Value = key,
                                Key = "ApiKey_" + client.ApiClientName
                            });

                        postmanEnvironment.Values.Add(
                            new ValueItem
                            {
                                Enabled = true,
                                Value = secret,
                                Key = "ApiSecret_" + client.ApiClientName
                            });

                        var clientEdOrgIds = client.LocalEducationOrganizations
                            .SelectMany(l => Range(l.Start, l.Count))
                            .Select(PreventEducationOrganizationIdOverflow)
                            .Distinct()
                            .ToList();

                        _clientAppRepo.AddEdOrgIdsToApiClient(
                            user.UserId, apiClient.ApiClientId, clientEdOrgIds,
                            application.ApplicationId);

                        _clientAppRepo.AddOdsInstanceToApiClient(apiClient.ApiClientId, odsInstance.OdsInstanceId);

                        postmanEnvironment.Values.Add(
                            new ValueItem
                            {
                                Enabled = true,
                                Value = client.LocalEducationOrganizations,
                                Key = client.ApiClientName + "LeaId"
                            });

                        if (client.OwnershipToken != null)
                        {
                            _clientAppRepo.AddOwnershipTokensToApiClient(client.OwnershipToken, apiClient.ApiClientId);
                        }

                        if (client.ApiClientOwnershipTokens != null)
                        {
                            _clientAppRepo.AddApiClientOwnershipTokens(client.ApiClientOwnershipTokens, apiClient.ApiClientId);
                        }
                    }

                    if (app.Profiles != null)
                    {
                        var _profiles = new List<Profile>();
                        foreach (var profileName in app.Profiles)
                        {
                            var profileDefinition = profileDefinitionByName[profileName].OuterXml;
                            _profiles.Add(new Profile() { ProfileDefinition = profileDefinition, ProfileName = profileName });
                        }
                        _clientAppRepo.AddProfilesToApplication(_profiles, application.ApplicationId);
                    }
                }
            }

            return postmanEnvironment;
        }

        private long PreventEducationOrganizationIdOverflow(long educationOrganizationId)
        {
            return Math.Min(educationOrganizationId, _maxSafeEducationOrganizationId);
        }

        /// <summary>
        /// Similar to Enumerable.Range(). 
        /// Allows any numeric range (instead of only int32 ranges).
        /// </summary>
        private IEnumerable<T> Range<T>(T start, T count)
            where T : INumber<T>
        {
            for (var i = start; i < start + count; i++)
            {
                yield return i;
            }
        }
    }
}
