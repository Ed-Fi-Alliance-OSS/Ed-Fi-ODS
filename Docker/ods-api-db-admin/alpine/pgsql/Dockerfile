# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

# Base image with additional packages
FROM postgres:16.10-alpine3.22@sha256:1c6d2f6e4d30d49c529e09a627e8178db5011dde88d955eb08db2e135e64aa09 AS base
RUN apk --upgrade --no-cache add unzip=~6 dos2unix=~7

# Workaround to fix false positive CVEs using gosu
FROM golang:1.24 AS gosubuilder
ENV GOSU_VERSION=1.17
WORKDIR /go/src/github.com/tianon
RUN git clone https://github.com/tianon/gosu.git --branch $GOSU_VERSION
WORKDIR /go/src/github.com/tianon/gosu
RUN go mod download; go build

# Start a new layer so that the above layer can be cached
FROM base AS build
ARG ADMIN_VERSION
ARG SECURITY_VERSION
ARG STANDARD_VERSION
ARG ADMIN_URL=https://pkgs.dev.azure.com/ed-fi-alliance/Ed-Fi-Alliance-OSS/_apis/packaging/feeds/EdFi/nuget/packages/EdFi.Database.Admin.PostgreSQL.Standard.${STANDARD_VERSION}/versions/${ADMIN_VERSION}/content
ARG SECURITY_URL=https://pkgs.dev.azure.com/ed-fi-alliance/Ed-Fi-Alliance-OSS/_apis/packaging/feeds/EdFi/nuget/packages/EdFi.Database.Security.PostgreSQL.Standard.${STANDARD_VERSION}/versions/${SECURITY_VERSION}/content

LABEL maintainer="Ed-Fi Alliance, LLC and Contributors <techsupport@ed-fi.org>"

# These variables can be overwritten at runtime
ENV POSTGRES_DB=postgres

# Override provided gosu with the one built from source with updated go version
COPY --from=gosubuilder /go/src/github.com/tianon/gosu/gosu /usr/local/bin/gosu

COPY init-database.sh /docker-entrypoint-initdb.d/1-init-database.sh

RUN \
    wget -q -O /tmp/EdFi_Admin.zip ${ADMIN_URL} && \
    wget -q -O /tmp/EdFi_Security.zip ${SECURITY_URL} && \
    unzip -p /tmp/EdFi_Admin.zip EdFi_Admin.sql > /tmp/EdFi_Admin.sql && \
    unzip -p /tmp/EdFi_Security.zip EdFi_Security.sql > /tmp/EdFi_Security.sql && \
    rm -f /tmp/*.zip && \
    dos2unix /docker-entrypoint-initdb.d/1-init-database.sh && \
    dos2unix /tmp/EdFi_Admin.sql && \
    dos2unix /tmp/EdFi_Security.sql && \
    apk del unzip dos2unix

EXPOSE 5432
USER postgres
CMD ["docker-entrypoint.sh", "postgres"]
