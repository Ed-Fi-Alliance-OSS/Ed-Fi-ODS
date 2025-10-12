#!/bin/bash
# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

set -e
set +x

envsubst < /app/appsettings.template.json > /app/appsettings.json

until PGPASSWORD=$POSTGRES_PASSWORD \
      PGHOST=$ODS_POSTGRES_HOST \
      PGPORT=$POSTGRES_PORT \
      PGUSER=$POSTGRES_USER \
      pg_isready -d "$POSTGRES_DB" > /dev/null
do
  >&2 echo "Postgres is unavailable - sleeping"
  sleep 10
done

>&2 echo "Postgres is up - executing command"
exec $cmd

dotnet EdFi.Ods.Sandbox.Admin.dll
