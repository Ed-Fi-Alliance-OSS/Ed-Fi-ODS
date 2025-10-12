#!/bin/bash
# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

set -e
set +x

envsubst < /tmp/log4net.template.config > /opt/bin/.store/edfi.suite3.bulkloadclient.console/$ENV_BULKLOAD_VERSION/edfi.suite3.bulkloadclient.console/$ENV_BULKLOAD_VERSION/tools/net8.0/any/log4net.config 

EdFi.BulkLoadClient.Console $@ -w /var/bulkload/working -d /var/bulkload/data
