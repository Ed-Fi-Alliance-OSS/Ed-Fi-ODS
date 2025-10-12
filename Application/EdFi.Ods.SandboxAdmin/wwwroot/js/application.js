/// <reference path="globals.js" />
/// <reference path="edfiadmin.auth.js" />
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

/*global EdFiAdmin*/

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

        if (buttonText() !== "Delete") {
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

var confirmationDialog = function () {
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

var addApplicationDialog = function () {
    var self = this;

    self.fieldsTouched = ko.observable(false);

    self.buttonText = ko.observable("");

    self.applicationName = ko.observable(null).extend({
        required: {
            message: 'The Application Name field is required.',
            onlyIf: function () { return self.fieldsTouched(); }
        }
    });

    self.educationOrganizationId = ko.observable(null).extend({
        required: {
            message: 'The EducationOrganizationId field is required.',
            onlyIf: function () { return self.fieldsTouched(); }
        },
        pattern: {
            message: 'Please enter a valid number with at least six digits of educationOrganizationId',
            params: /^(?:\s*\d{6,18},?)+$/
        }
    });
    self.vendorList = ko.observableArray();

    self.selectedVendor = ko.observable(null).extend({
        required: {
            message: 'Please select a vendor.',
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
        self.applicationName,
        self.educationOrganizationId,
        self.selectedVendor
    ];
    function VendorTemplate(data) {
        var self = this;
        self.Id = ko.observable(data.Id);
        self.Name = ko.observable(data.Name);
    }

    self.show = function (options) {
        self.applicationName('');
        self.educationOrganizationId('');
        self.vendorList([]);
        self.buttonText('Add');

        $.each(options.vendors, function (Id, data) {
            if (data.Name !== "" && data.Name !== "Test Admin") {
                self.vendorList.push(new VendorTemplate(data));
            }
        });

        modal.show(options.callback);
    };

    self.canAdd = ko.computed(function () {
        var errors = ko.validation.group(firstStepValidation);
        return errors().length === 0;
    });
};

var ApplicationViewModel = function (data) {
    ko.mapping.fromJS(data, {}, this);
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

function ApplicationsViewModel() {
    var self = this;
    var ApplicationMapping = {
        create: function (options) {
            return new ApplicationViewModel(options.data);
        }
    };
    self.applications = ko.mapping.fromJS([], ApplicationMapping);
    self.error = ko.observable();
    self.confirmationDialog = new confirmationDialog();
    self.addApplicationDialog = new addApplicationDialog();

    self.shouldShowTable = ko.computed(function () {
        return self.applications().length > 0;
    });

    self.applicationStatus = ko.computed(function () {
        switch (self.applications().length) {
            case 0:
                return "You have no applications";
            case 1:
                return "You have 1 application";
            default:
                return "You have " + self.applications().length + " applications";
        }

    });

    self.getData = function () {
        $.ajax(
            {
                type: "GET",
                url: EdFiAdmin.Urls.application,
                dataType: 'json',
                success: function (data, textStatus, jqXHR) {
                    ko.mapping.fromJS(data, self.applications);
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

    self.getVendors = function (callback) {
        $.ajax(
            {
                type: "GET",
                url: EdFiAdmin.Urls.vendor,
                dataType: 'json',
                success: function (data, textStatus, jqXHR) {
                    var vendors = data
                        .filter(function (item) {
                            return item.Name.trim() !== ""; 
                        })
                        .map(function (item) {
                            return { Id: item.Id, Name: item.Name };
                        });

                    if (typeof callback === 'function') {
                        callback(vendors); 
                    }

                    if (!IsFullyLoaded(data)) {
                        with (self) { setTimeout(function () { getVendors(); }, 3000); }
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    self.error(errorThrown);
                    return 0;
                }
            });
    };

    self.doAddApplication = function (onComplete) {
        self.error("");
        var applicationName = self.addApplicationDialog.applicationName();
        var educationOrganizationId = self.addApplicationDialog.educationOrganizationId();
        var vendorId = self.addApplicationDialog.selectedVendor().Id();

        $.ajax({
            type: "POST",
            data: { "ApplicationName": applicationName, "EducationOrganizationIdsString": educationOrganizationId, "VendorId": vendorId },
            url: EdFiAdmin.Urls.application,
            dataType: 'json',
            success: function (data, textStatus, jqXHR) {
                onComplete();
                var newApplication = new ApplicationViewModel(data);
                self.applications.push(newApplication);
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
                    default:
                        self.error(textStatus);
                }
                return 0;
            }
        });
    };

    self.deleteApplicationClicked = function (application) {
        var deleteApplication = function (onComplete) {
            var applicationData = ko.mapping.toJS(application);
            $.ajax({
                type: "DELETE",
                data: applicationData,
                url: EdFiAdmin.Urls.application + "/" + applicationData.Id,
                success: function (data, textStatus, jqXHR) {
                    self.applications.remove(application);
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
            message: "Proceeding with this operation will permanently delete the selected application, along with all associated data." +
                "<br/><br/>" +
                "This operation cannot be undone.",
            buttonText: "Delete",
            callback: deleteApplication
        });
    };


   self.addApplicationClicked = function () {
       self.getVendors(function (vendors) {
            addApplicationDialogInstance.markFieldsAsTouched(false);
            self.addApplicationDialog.vendorList(vendors);
            self.addApplicationDialog.show({ callback: self.doAddApplication ,vendors });
        });
    };

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

    var viewModel = new ApplicationsViewModel();
    ko.applyBindings(viewModel);
});