/// <reference path="globals.js" />
/// <reference path="edfiadmin.auth.js" />
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

/*global EdFiAdmin*/
var Sandbox = function (sandboxType, dedicated) {
    this.sandboxType = sandboxType;
    this.dedicated = dedicated;
    this.value = function () {
        switch (this.sandboxType) {
            case "minimal":
                return 1;
            case "sample":
                return 2;
            default:
                return 0;
        }
    };
};

var addApplicationDialogInstance = null;

var ModalController = function (modalOptions) {
    var self = this;

    this.callback = null;
    this.confirmChecked = ko.observable(false);

    var getModal = function () {
        return $('#' + modalOptions.htmlId);
    };

    var getWaitSpinner = function () {
        return $('#' + modalOptions.htmlId + ' .wait-spinner');
    };

    var showWait = function () {
        getWaitSpinner().removeClass('d-none');
    };

    var hideWait = function () {
        getWaitSpinner().addClass('d-none');
    };

    this.show = function (onOk) {
        self.callback = onOk;
        self.confirmChecked(false);
        hideWait();

        getModal().modal('show');
    };

    this.hide = function () {
        getModal().modal('hide');
    };

    this.onOkClicked = function (buttonText) {

        if (buttonText() === "Add") {
            addApplicationDialogInstance.markFieldsAsTouched(true);

            if (!addApplicationDialogInstance.canAdd()) {
                return;
            }
        }

        if (modalOptions.closeOnOk) {
            self.hide();
            self.callback();
        } else {
            showWait();
            self.callback(self.hide);
        }
    };

    getModal().modal({ show: false, backdrop: 'static', keyboard: false });
};

var ConfirmationDialog = function () {
    var self = this;

    this.htmlId = "modal-confirm";
    var modal = new ModalController({ htmlId: self.htmlId });

    this.message = ko.observable("");
    this.buttonText = ko.observable("");

    this.disableOkButton = ko.computed(function () {
        return !modal.confirmChecked();
    });
    this.onOkClicked = modal.onOkClicked;
    this.confirmChecked = modal.confirmChecked;

    this.show = function (options) {
        self.message(options.message);
        self.buttonText(options.buttonText);

        modal.show(options.callback);
    };
};

var TokenDialog = function () {
    var self = this;

    this.htmlId = "modal-token";
    var modal = new ModalController({ htmlId: self.htmlId });

    this.message = ko.observable("");

    this.show = function (options) {
        self.message(options.message);
        modal.show(options.callback);
    };
};

var ResetDialog = function () {
    var self = this;

    this.htmlId = "modal-reset";
    var modal = new ModalController({ htmlId: self.htmlId });

    this.message = ko.observable("");

    this.show = function (options) {
        self.message(options.message);
        modal.show(options.callback);
    };
};

var AddApplicationDialog = function () {
    var self = this;

    self.fieldsTouched = ko.observable(false);
    self.buttonText = ko.observable("");
    self.sandboxName = ko.observable(null).extend({
        required: {
            message: 'The Sandbox Name field is required.',
            onlyIf: function () { return self.fieldsTouched(); }
        }
    });

    self.useSampleData = ko.observable(false);
    self.applicationList = ko.observableArray();

    self.selectedApplication = ko.observable(null).extend({
        required: {
            message: 'Please select an application.',
            onlyIf: function () { return self.fieldsTouched(); }
        }
    });


    self.errors = ko.validation.group(self);


    self.htmlId = "modal-add";

    addApplicationDialogInstance = self;

    self.markFieldsAsTouched = function (value) {
        self.fieldsTouched(value);
    };

    var modal = new ModalController({ htmlId: self.htmlId });

    this.disableOkButton = ko.computed(function () {
        return !modal.confirmChecked();
    });
    this.onOkClicked = modal.onOkClicked;
    this.confirmChecked = modal.confirmChecked;

    var firstStepValidation = [
        self.sandboxName,
        self.selectedApplication
    ];

    self.canAdd = ko.computed(function () {
        var errors = ko.validation.group(firstStepValidation);
        return errors().length === 0;
    });

    function ApplicationTemplate(data) {
        var self = this;
        self.Id = ko.observable(data.Id);
        self.Name = ko.observable(data.Name);
    }

    self.show = function (options) {
        self.sandboxName('');
        self.useSampleData(false);
        self.applicationList([]);
        self.buttonText('Add');

        $.each(options.applications, function (Id, data) {
            if (data.Name !== "") {
                self.applicationList.push(new ApplicationTemplate(data));
            }
        });

        modal.show(options.callback);
    };
};

var ClientViewModel = function (data) {
    var self = this;
    ko.mapping.fromJS(data, {}, this);
    this.HasSampleData = ko.computed(function () {
        return self.SandboxTypeName() == "Sample" ? 'Yes' : 'No';
    });
};

var IsFullyLoaded = function (data) {
    var retval = true;
    $.each(data, function (i, item) {
        if (item.IsLoading) {
            retval = false;
        }
    });
    return retval;
}

function ClientsViewModel() {
    var self = this;
    var clientMapping = {
        create: function (options) {
            return new ClientViewModel(options.data);
        }
    };
    self.apiClients = ko.mapping.fromJS([], clientMapping);
    self.error = ko.observable();
    self.confirmationDialog = new ConfirmationDialog();
    self.addApplicationDialog = new AddApplicationDialog();
    self.tokenDialog = new TokenDialog();
    self.resetDialog = new ResetDialog();

    self.shouldShowTable = ko.computed(function () {
        return self.apiClients().length > 0;
    });

    self.clientStatus = ko.computed(function () {
        switch (self.apiClients().length) {
            case 0:
                return "You have no sandboxes";
            case 1:
                return "You have 1 sandbox";
            default:
                return "You have " + self.apiClients().length + " sandboxes";
        }

    });

    self.getData = function () {
        $.ajax(
            {
                type: "GET",
                url: EdFiAdmin.Urls.client,
                dataType: 'json',
                success: function (data, textStatus, jqXHR) {
                    ko.mapping.fromJS(data, self.apiClients);
                    if (!IsFullyLoaded(data)) {
                        with (self) { setTimeout(function () { getData(); }, 3000); }
                    }
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

    self.doAddClient = function (onComplete) {
        self.error("");
        var sandboxName = self.addApplicationDialog.sandboxName();
        var sandboxType = self.addApplicationDialog.useSampleData() ? "sample" : "minimal";
        var applicationId = self.addApplicationDialog.selectedApplication().Id();

        $.ajax({
            type: "POST",
            data: { "Name": sandboxName, "SandboxType": sandboxType, "IsDedicated": true, "ApplicationId": applicationId },
            url: EdFiAdmin.Urls.client,
            dataType: 'json',
            success: function (data, textStatus, jqXHR) {
                onComplete();
                var newApplication = new ClientViewModel(data);
                self.apiClients.push(newApplication);
                if (newApplication.IsLoading) {
                    with (self) { setTimeout(function () { getData(); }, 3000); }
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                onComplete();
                switch (jqXHR.status) {
                    case 400:
                        self.error(jqXHR.responseText);
                        break;
                    case 406:
                        self.error("You must provide a name for your client application sandbox.");
                        break;
                    default:
                        self.error(textStatus);
                }
                return 0;
            }
        });
    };

    self.updateClientClicked = function (client) {
        var updateClient = function (onComplete) {
            var mydata = ko.mapping.toJS(client);
            $.ajax({
                type: "PUT",
                data: mydata,
                url: EdFiAdmin.Urls.client + "/" + client.Id(),
                dataType: 'json',
                success: function (data, textStatus, jqXHR) {
                    var updatedClient = new ClientViewModel(data);
                    self.apiClients.replace(client, updatedClient);
                    onComplete();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    self.error(errorThrown);
                    onComplete();
                    return 0;
                }
            });
        };
        self.error("");
        self.confirmationDialog.show({
            message: "This operation will permanently change the client secret for this sandbox.  " +
                "Any existing client applications should also be modified to use the new secret." +
                "<br/><br/>" +
                "This operation cannot be undone.",
            buttonText: "Change Secret",
            callback: updateClient
        });
    };

    self.tokenClientClicked = function (client) {
        var mydata = ko.mapping.toJS(client);
        var auth = { Client_id: mydata.Key.toString(), Response_type: "code" };
        $.support.cors = true;

        var token = { Client_id: mydata.Key, Client_secret: mydata.Secret, grant_type: "client_credentials" };
        $.post(EdFiAdmin.Urls.oauth + "token/", token, function (d, e) {
            self.tokenDialog.show({
                message: (d.Access_token || d.access_token),
                buttonText: "OK",
                callback: null
            });
        }, "json")
            .error(function (s, e) {
                alert("Unable to retrieve an access token. Please verify that your application secret is correct.");
            });

    };

    self.deleteClientClicked = function (client) {
        var deleteClient = function (onComplete) {
            var clientData = ko.mapping.toJS(client);
            $.ajax({
                type: "DELETE",
                data: clientData,
                url: EdFiAdmin.Urls.client + "/" + client.Key(),
                success: function (data, textStatus, jqXHR) {
                    self.apiClients.remove(client);
                    onComplete();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    self.error(errorThrown);
                    onComplete();
                    return 0;
                }
            });
        };

        self.error("");
        self.confirmationDialog.show({
            message: "This operation will permanently delete this sandbox, and all uploaded data will be lost.  " +
                "<br/><br/>" +
                "This operation cannot be undone.",
            buttonText: "Delete",
            callback: deleteClient
        });
    };

    self.resetSandboxClicked = function(client) {
        var resetClient = function (onComplete) {
            var clientData = ko.mapping.toJS(client);
            $.ajax({
                type: "PUT",
                data: clientData,
                url: EdFiAdmin.Urls.client + "/reset",
                dataType: 'json',
                success: function (data, textStatus, jqXHR) {
                    self.resetDialog.show({
                        message: ("Sandbox reset successfully."),
                        buttonText: "OK",
                        callback: null
                    });
                    onComplete();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    self.error(errorThrown);
                    onComplete();
                    return 0;
                }
            });
        };

        self.error("");
        self.confirmationDialog.show({
            message: "This operation will reset this sandbox, and all uploaded data will be lost.  " +
                "<br/><br/>" +
                "This operation cannot be undone.",
            buttonText: "Reset",
            callback: resetClient
        });
    };

    self.getApplications = function (callback) {
        $.ajax(
            {
                type: "GET",
                url: EdFiAdmin.Urls.application,
                dataType: 'json',
                success: function (data, textStatus, jqXHR) {
                    var applications = data.map(function (item) {
                        return { Id: item.Id, Name: item.ApplicationName };
                    });

                    if (typeof callback === 'function') {
                        callback(applications);
                    }

                    if (!IsFullyLoaded(data)) {
                        with (self) { setTimeout(function () { getApplications(); }, 3000); }
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    self.error(errorThrown);
                    return 0;
                }
            });
    };
    self.addApplicationClicked = function () {
        self.getApplications(function (applications) {
            addApplicationDialogInstance.markFieldsAsTouched(false);            
            self.addApplicationDialog.applicationList(applications);
            self.addApplicationDialog.show({ callback: self.doAddClient, applications });
        });
    };

    // Load the original data
    self.getData();
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

    ko.validation.init({

        registerExtenders: true,
        messagesOnModified: true,
        insertMessages: true,
        parseInputAttributes: true,
        decorateInputElement: true,
        errorElementClass: 'is-invalid',
        errorClass: 'invalid-feedback',
        messageTemplate: null

    }, true);

    var viewModel = new ClientsViewModel();
    ko.applyBindings(viewModel);
});