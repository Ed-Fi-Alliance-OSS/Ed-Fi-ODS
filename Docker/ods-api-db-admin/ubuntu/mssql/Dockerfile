# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

# Base image with additional packages
FROM mcr.microsoft.com/mssql/server:2022-CU15-ubuntu-22.04@sha256:804e527187b16fe05c4321b58d76850966cbaf73e31942416ce0bbefe1b0eb63 AS base
ENV ACCEPT_EULA=Y

USER root
RUN apt-get update && \
    apt-get upgrade -y && \
    apt-get -y install --no-install-recommends unzip=6.0-26ubuntu3 dos2unix=7.4.2-2 &&\
    rm -rf /var/lib/apt/lists/* &&\
    # These steps are needed in order to mount the database to a host volume
    mkdir -p /var/opt/mssql/data /var/opt/mssql/log &&\
    chown -R mssql: /var/opt/mssql/data /var/opt/mssql/log
USER mssql

# Start a new layer so that the above layer can be cached
FROM base AS build
ARG ADMIN_VERSION
ARG SECURITY_VERSION
ARG STANDARD_VERSION
ARG ADMIN_URL=https://pkgs.dev.azure.com/ed-fi-alliance/Ed-Fi-Alliance-OSS/_apis/packaging/feeds/EdFi/nuget/packages/EdFi.Database.Admin.Standard.${STANDARD_VERSION}/versions/${ADMIN_VERSION}/content
ARG SECURITY_URL=https://pkgs.dev.azure.com/ed-fi-alliance/Ed-Fi-Alliance-OSS/_apis/packaging/feeds/EdFi/nuget/packages/EdFi.Database.Security.Standard.${STANDARD_VERSION}/versions/${SECURITY_VERSION}/content

LABEL maintainer="Ed-Fi Alliance, LLC and Contributors <techsupport@ed-fi.org>"

# These variables can be overwritten at runtime
ENV MSSQL_PID=Express

USER root
WORKDIR /app

RUN umask 0077 && \
    mkdir backups && \
    # Download and extract Admin and Security databases
    wget -q -O ./backups/EdFi_Admin.zip ${ADMIN_URL} && \
    wget -q -O ./backups/EdFi_Security.zip ${SECURITY_URL} && \
    unzip -p ./backups/EdFi_Admin.zip EdFi_Admin.bak >> ./backups/EdFi_Admin.bak && \
    unzip -p ./backups/EdFi_Security.zip EdFi_Security.bak >> ./backups/EdFi_Security.bak && \
    rm -f ./backups/*.zip && \
    apt-get --purge autoremove unzip -y

COPY --chmod=500 ./*.sh .

RUN dos2unix ./*.sh && \
    chown -R mssql . && \ 
    apt-get --purge autoremove dos2unix -y

EXPOSE 1433
USER mssql
ENTRYPOINT ["/app/init.sh"]
