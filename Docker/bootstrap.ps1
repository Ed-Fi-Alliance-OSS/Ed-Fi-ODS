# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

# This script will startup a local ODS/API environment in a single tenant mode,
# using local images built from NuGet packages. This process includes
# provisioning of a self-signed development certificate and of an initial key
# and secret with the "Ed-Fi Sandbox" claimset.

param(
    [switch]
    $Hub,
    [switch]
    $MsSql
)

$ErrorActionPreference = "Stop"

$template = "local"
if ($Hub) {
    $template = "hub"
}
else {
  ./get-versions.ps1 -StandardVersion 6.0.0 -ExtensionVersion 1.1.0 -PreRelease
}

$database = "pgsql"
if ($MsSql) {
  $database = "mssql"

  # Build using MsSql env variables
  docker compose -f ./docker-compose-$template-$database.yml build `
  --build-arg ADMIN_VERSION=$env:MSSQL_ADMIN_VERSION `
  --build-arg SECURITY_VERSION=$env:MSSQL_SECURITY_VERSION `
  --build-arg ODS_VERSION=$env:MSSQL_ODS_MINIMAL_VERSION `
  --build-arg TPDM_VERSION=$env:MSSQL_TPDM_MINIMAL_VERSION `
  --build-arg API_VERSION=$env:API_VERSION `
  --build-arg SWAGGER_VERSION=$env:SWAGGER_VERSION
}
else {
  # Build using default (PgSql) env variables
  docker compose -f ./docker-compose-$template-$database.yml build `
  --build-arg ADMIN_VERSION=$env:ADMIN_VERSION `
  --build-arg SECURITY_VERSION=$env:SECURITY_VERSION `
  --build-arg ODS_VERSION=$env:ODS_MINIMAL_VERSION `
  --build-arg TPDM_VERSION=$env:TPDM_MINIMAL_VERSION `
  --build-arg API_VERSION=$env:API_VERSION `
  --build-arg SWAGGER_VERSION=$env:SWAGGER_VERSION
}

docker compose  -f ./docker-compose-$template-$database.yml up -d

Start-Sleep -Seconds 20

docker cp ./bootstrap-$database.sql ed-fi-db-admin:/tmp/bootstrap.sql

if ($MsSql) {
  docker exec -i --env-file .env ed-fi-db-admin sh -c '/opt/mssql-tools/bin/sqlcmd -U "$SQLSERVER_USER" -P "$SQLSERVER_PASSWORD" -d EdFi_Admin -i /tmp/bootstrap.sql'
}
else {
  docker exec -i ed-fi-db-admin sh -c "psql -U `$POSTGRES_USER  -d EdFi_Admin -f /tmp/bootstrap.sql"
}
