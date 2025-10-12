// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

var EdFiAdmin = EdFiAdmin || {};

function setUrls() {
    var urls = EdFiAdmin.Urls = EdFiAdmin.Urls || {};

    urls.apiBase = urls.home + '/api';
    urls.login = urls.home + '/account/login';
    urls.logout = urls.home + '/account/logout';
    urls.client = urls.apiBase + '/client';
    urls.sandbox = urls.apiBase + '/sandbox';
    urls.vendor = urls.apiBase + '/vendor';
    urls.application = urls.apiBase + '/application';
}

function setWindowOrigin() {
    if (!window.location.origin) {
        window.location.origin = window.location.protocol + "//" + window.location.host;
    }
}

$(function () {
    setWindowOrigin();
    setUrls();
});