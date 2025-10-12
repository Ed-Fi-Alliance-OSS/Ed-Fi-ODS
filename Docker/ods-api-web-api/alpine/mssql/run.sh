#!/bin/bash
# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

set -e
set +x

if [[ "$TPDM_ENABLED" != "true" ]]; then
    export Plugin__Folder="./Plugin_Disabled"
fi

if [[ "$ENCRYPT_CONNECTION" == true ]]; then
    export ENCRYPT_CONNECTION=""
else
    export ENCRYPT_CONNECTION="Encrypt=false;"
fi

envsubst < /app/appsettings.template.json > /app/appsettings.json

if [[ -z "$ODS_WAIT_HOSTS" ]]; then
  # if there are no hosts to wait then fallback to $SQLSERVER_ODS_DATASOURCE
  export ODS_WAIT_HOSTS=$SQLSERVER_ODS_DATASOURCE
fi

export ODS_WAIT_HOSTS_ARR=($ODS_WAIT_HOSTS)
for HOST in ${ODS_WAIT_HOSTS_ARR[@]}
do
  STATUS_ODS=1
  until [[ $STATUS_ODS -eq 0 ]]; do
    >&2 echo "SQL Server '$HOST' is unavailable - sleeping"
    STATUS_ODS=$(/opt/mssql-tools18/bin/sqlcmd -C -W -h -1 -U ${SQLSERVER_USER} -P "${SQLSERVER_PASSWORD}" -S ${HOST} -Q "SET NOCOUNT ON; SELECT SUM(state) FROM sys.databases" 2> /dev/null || echo 1) 

    sleep 10
  done
  >&2 echo "SQL Server '$HOST' is up"
done

>&2 echo "All SQL Server hosts are up - executing command"
exec $cmd

dotnet EdFi.Ods.WebApi.dll
