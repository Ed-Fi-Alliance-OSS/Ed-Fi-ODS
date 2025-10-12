# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

# Base image with additional packages
FROM mcr.microsoft.com/mssql/server:2022-CU15-ubuntu-22.04@sha256:804e527187b16fe05c4321b58d76850966cbaf73e31942416ce0bbefe1b0eb63 AS base
ENV ACCEPT_EULA=Y

USER root
RUN apt-get update && \
    apt-get upgrade -y &&\
    apt-get -y install --no-install-recommends unzip=6.0-26ubuntu3 dos2unix=7.4.2-2 nodejs=12.* npm=8.* &&\
    npm install -g semver@7 &&\
    rm -rf /var/lib/apt/lists/* &&\
    # These steps are needed in order to mount the database to a host volume
    mkdir -p /var/opt/mssql/data /var/opt/mssql/log &&\
    chown -R mssql: /var/opt/mssql/data /var/opt/mssql/log
USER mssql

# Start a new layer so that the above layer can be cached
FROM base AS build
ARG ODS_MINIMAL_VERSION
ARG ODS_POPULATED_VERSION
ARG TPDM_MINIMAL_VERSION
ARG TPDM_POPULATED_VERSION
ARG STANDARD_VERSION
ARG EXTENSION_VERSION
ARG ODS_MINIMAL_URL=https://pkgs.dev.azure.com/ed-fi-alliance/Ed-Fi-Alliance-OSS/_apis/packaging/feeds/EdFi/nuget/packages/EdFi.Suite3.Ods.Minimal.Template.Standard.${STANDARD_VERSION}/versions/${ODS_MINIMAL_VERSION}/content
ARG ODS_POPULATED_URL=https://pkgs.dev.azure.com/ed-fi-alliance/Ed-Fi-Alliance-OSS/_apis/packaging/feeds/EdFi/nuget/packages/EdFi.Suite3.Ods.Populated.Template.Standard.${STANDARD_VERSION}/versions/${ODS_POPULATED_VERSION}/content
ARG TPDM_MINIMAL_URL=https://pkgs.dev.azure.com/ed-fi-alliance/Ed-Fi-Alliance-OSS/_apis/packaging/feeds/EdFi/nuget/packages/EdFi.Suite3.Ods.Minimal.Template.TPDM.Core.${EXTENSION_VERSION}.Standard.${STANDARD_VERSION}/versions/${TPDM_MINIMAL_VERSION}/content
ARG TPDM_POPULATED_URL=https://pkgs.dev.azure.com/ed-fi-alliance/Ed-Fi-Alliance-OSS/_apis/packaging/feeds/EdFi/nuget/packages/EdFi.Suite3.Ods.Populated.Template.TPDM.Core.${EXTENSION_VERSION}.Standard.${STANDARD_VERSION}/versions/${TPDM_POPULATED_VERSION}/content

LABEL maintainer="Ed-Fi Alliance, LLC and Contributors <techsupport@ed-fi.org>"

# These variables can be overwritten at runtime
ENV MSSQL_PID=Express

USER root
WORKDIR /app

RUN umask 0077 && \
    mkdir backups && \
    # Download and extract Minimal and Populated Templates for core Ed-Fi Data Model
    wget -q -O ./backups/OdsPopulatedDatabase.zip ${ODS_POPULATED_URL} && \
    unzip -p ./backups/OdsPopulatedDatabase.zip EdFi.Ods.Populated.Template.bak >> ./backups/EdFi_Ods_Populated_Template.bak && \
    wget -q -O ./backups/OdsMinimalDatabase.zip ${ODS_MINIMAL_URL} && \
    unzip -p ./backups/OdsMinimalDatabase.zip EdFi.Ods.Minimal.Template.bak >> ./backups/EdFi_Ods_Minimal_Template.bak && \
    # Download and extract Minimal Template for Teacher Prep Data Model (TPDM) when the data standard version is less than 6.0.0
    if semver -r "<6.0.0" "$STANDARD_VERSION"; then \
        wget -q -O ./backups/TPDMOdsPopulatedDatabase.zip ${TPDM_POPULATED_URL} && \
        unzip -p ./backups/TPDMOdsPopulatedDatabase.zip EdFi.Ods.Populated.Template.TPDM.Core.bak > ./backups/EdFi_Ods_Populated_Template_TPDM_Core.bak && \
        wget -q -O ./backups/TPDMOdsMinimalDatabase.zip ${TPDM_MINIMAL_URL} && \
        unzip -p ./backups/TPDMOdsMinimalDatabase.zip EdFi.Ods.Minimal.Template.TPDM.Core.bak > ./backups/EdFi_Ods_Minimal_Template_TPDM_Core.bak; \
    fi && \
    rm -f ./backups/*.zip && \
    apt-get --purge autoremove unzip nodejs npm -y &&\
    apt-get clean

COPY --chmod=500 ./*.sh .

RUN dos2unix ./*.sh && \
    chown -R mssql . && \ 
    apt-get --purge autoremove dos2unix -y &&\
    apt-get clean

EXPOSE 1433
USER mssql
ENTRYPOINT ["/app/init.sh"]
