#!/bin/bash -e

# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

# Sourced and adapted from: 
# https://github.com/actions/runner-images/blob/main/images/ubuntu/scripts/build/install-mono.sh

# This script shall be removed in ODS-6572

REPO_URL="https://download.mono-project.com/repo/ubuntu"
GPG_KEY="/usr/share/keyrings/mono-official-stable.gpg"
REPO_PATH="/etc/apt/sources.list.d/mono-official-stable.list"

# There are no packages for Ubuntu 22 and 24 in the repo, but developers confirmed that packages from Ubuntu 20 should work
os_label="focal"

# Install Mono repo
curl -fsSL https://download.mono-project.com/repo/xamarin.gpg | gpg --dearmor -o $GPG_KEY
echo "deb [signed-by=$GPG_KEY] $REPO_URL stable-$os_label main" > $REPO_PATH

# Install Mono
apt-get update
apt-get install --no-install-recommends apt-transport-https mono-complete nuget

# Remove Mono's apt repo
rm $REPO_PATH
rm -f "${REPO_PATH}.save"
rm $GPG_KEY

# Document source repo
echo "mono https://download.mono-project.com/repo/ubuntu stable-$os_label main" >> $HELPER_SCRIPTS/apt-sources.txt
