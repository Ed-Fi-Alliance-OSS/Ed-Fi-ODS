# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

# Base image with additional packages
FROM mcr.microsoft.com/dotnet/aspnet:8.0.18-alpine3.21@sha256:d600a99dbc2076ceadc60c4ba60afc294e7916a652cffd88a0f62630d1b3c1fa AS base
RUN apk --upgrade --no-cache add unzip=~6 dos2unix=~7 bash=~5 gettext=~0 icu=~74 curl=~8 && \
    addgroup -S edfi && adduser -S edfi -G edfi

# Add the sqlcmd tool to the base image
WORKDIR /tmp
SHELL ["/bin/bash", "-o", "pipefail", "-c"]
RUN apk --upgrade --no-cache add gnupg=~2.4 && \
  curl -O https://download.microsoft.com/download/b/9/f/b9f3cce4-3925-46d4-9f46-da08869c6486/msodbcsql18_18.0.1.1-1_amd64.apk && \
  curl -O https://download.microsoft.com/download/b/9/f/b9f3cce4-3925-46d4-9f46-da08869c6486/mssql-tools18_18.0.1.1-1_amd64.apk && \
  #Verify signature
  curl -O https://download.microsoft.com/download/b/9/f/b9f3cce4-3925-46d4-9f46-da08869c6486/msodbcsql18_18.0.1.1-1_amd64.sig && \
	curl -O https://download.microsoft.com/download/b/9/f/b9f3cce4-3925-46d4-9f46-da08869c6486/mssql-tools18_18.0.1.1-1_amd64.sig  && \
  curl https://packages.microsoft.com/keys/microsoft.asc | gpg --import -  && \
	gpg --verify msodbcsql18_18.0.1.1-1_amd64.sig msodbcsql18_18.0.1.1-1_amd64.apk  && \
	gpg --verify mssql-tools18_18.0.1.1-1_amd64.sig mssql-tools18_18.0.1.1-1_amd64.apk  && \
  #Install the package(s)
  apk --upgrade --no-cache add --allow-untrusted msodbcsql18_18.0.1.1-1_amd64.apk mssql-tools18_18.0.1.1-1_amd64.apk  && \
	rm -f msodbcsql18_18.0.1.1-1_amd64.apk mssql-tools18_18.0.1.1-1_amd64.apk msodbcsql18_18.0.1.1-1_amd64.sig mssql-tools18_18.0.1.1-1_amd64.sig  && \
  apk del gnupg

# Start a new layer so that the above layer can be cached
FROM base AS build
ARG API_VERSION
ARG STANDARD_VERSION

LABEL maintainer="Ed-Fi Alliance, LLC and Contributors <techsupport@ed-fi.org>"

# These variables can be overwritten at runtime
ENV PATH_BASE=api
ENV TPDM_ENABLED=true
ENV ENCRYPT_CONNECTION=false

# Alpine image does not contain Globalization Cultures library so we need to
# install ICU library to get LINQ expression to work and disable the
# globaliztion invariant mode, which is set in the base image.
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

WORKDIR /app
COPY --chmod=600 appsettings.template.json /app/appsettings.template.json
COPY --chmod=500 run.sh /app/run.sh
COPY log4net.config /app/log4net.txt

RUN umask 0077 && \
    wget -q -O /app/WebApi.zip https://pkgs.dev.azure.com/ed-fi-alliance/Ed-Fi-Alliance-OSS/_apis/packaging/feeds/EdFi/nuget/packages/EdFi.Suite3.Ods.WebApi.Standard.${STANDARD_VERSION}/versions/${API_VERSION}/content && \
    unzip /app/WebApi.zip -d /app && \
    rm -f /app/WebApi.zip && \
    cp /app/log4net.txt /app/log4net.config && \
    rm -f /app/log4net.txt && \
    dos2unix /app/*.json && \
    dos2unix /app/*.sh && \
    dos2unix /app/log4net.config && \
    rm -f /app/*.exe && \
    apk del unzip dos2unix curl && \
    chown -R edfi /app

ENV ASPNETCORE_HTTP_PORTS=80
EXPOSE 80
USER edfi
ENTRYPOINT [ "/app/run.sh" ]
