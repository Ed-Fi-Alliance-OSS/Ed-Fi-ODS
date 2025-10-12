// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

var EdFiAdmin = EdFiAdmin || {};

function SandboxViewModel() {
    var self = this;

    self.status = ko.observable("");

    self.error = ko.observable("");

    self.showSubmit = ko.computed(function () {
        return !self.status().length;
    });

    self.doResetSandbox = function () {
        $.ajax(
            {
                type: "PUT",
                data: { "Command": 'reset' },
                url: EdFiAdmin.Urls.sandbox,
                dataType: 'json',
                success: function (data, textStatus, jqXHR) {
                    self.status("resetting...");
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    self.error(errorThrown);
                    return 0;
                },
                statusCode: {
                    302: function () {
                        console.log('302');
                    }
                }
            });
    };
}

$(function () {

    $.ajaxSetup({
        contentType: 'application/json',
        processData: false
    });
    $.ajaxPrefilter(function (options, originalOptions, jqXHR) {
        if (options.data) {
            options.data = JSON.stringify(options.data);
        }
    });

    var viewModel = new SandboxViewModel();
    ko.applyBindings(viewModel);
});