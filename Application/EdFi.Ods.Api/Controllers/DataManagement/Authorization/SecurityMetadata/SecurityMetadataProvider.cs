// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.SqlClient;
using System.Xml.Linq;
using EdFi.Security.DataAccess.Providers;

namespace EdFi.Ods.Api.Controllers.DataManagement.Authorization.SecurityMetadata
{
    public class SqlServerSecurityMetadataProvider : ISecurityMetadataProvider
    {
        private readonly ISecurityDatabaseConnectionStringProvider _securityDatabaseConnectionStringProvider;
        private readonly Lazy<XDocument> _securityMetadata;

        public SqlServerSecurityMetadataProvider(ISecurityDatabaseConnectionStringProvider securityDatabaseConnectionStringProvider)
        {
            _securityDatabaseConnectionStringProvider = securityDatabaseConnectionStringProvider;

            _securityMetadata = new Lazy<XDocument>(CreateSecurityMetadataDocument);
        }
        
        public XDocument GetSecurityMetadata()
        {
            return _securityMetadata.Value;
        }

        private XDocument CreateSecurityMetadataDocument()
        {
            using var conn = new SqlConnection(_securityDatabaseConnectionStringProvider.GetConnectionString());

            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT dbo.GetAuthorizationMetadataDocument()";

            using var reader = cmd.ExecuteXmlReader();
            var xml = XDocument.Load(reader);

            // using var fs = File.OpenRead(@"C:\temp\junk.xml");
            // var xml = XDocument.Load(fs);

            return xml;
        }
    }
}
