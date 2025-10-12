/// <reference path="globals.js" />
/// <reference path="edfiadmin.auth.js" />
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

/*global EdFiAdmin*/

var addVendorDialogInstance = null;

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
                addVendorDialogInstance.markFieldsAsTouched(true);

                if (!addVendorDialogInstance.canAdd()) {
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

var addVendorDialog = function () {
    var self = this;

    self.fieldsTouched = ko.observable(false);

    self.buttonText = ko.observable("");

    self.vendorName = ko.observable(null).extend({
        required: {
            message: 'The Vendor Name field is required.',
            onlyIf: function () { return self.fieldsTouched(); }
        }
    });

    self.namespacePrefix = ko.observable(null).extend({
        required: {
            message: 'The Namespace Prefix field is required.',
            onlyIf: function () { return self.fieldsTouched(); }
        }
    });

    self.contactName = ko.observable(null).extend({
        required: {
            message: 'The Contact Name field is required.',
            onlyIf: function () { return self.fieldsTouched(); }
        }
    });

    self.contactEmailAddress = ko.observable(null).extend({
        required: {
            message: 'The Contact EmailAddress field is required.',
            onlyIf: function () { return self.fieldsTouched(); }
        }
    });

    self.markFieldsAsTouched = function (value) {
        self.fieldsTouched(value);
    };



    self.htmlId = "modal-add";

    addVendorDialogInstance = self;
    var modal = new ModalController({ htmlId: self.htmlId });

    this.disableOkButton = ko.computed(function () {
        return !modal.confirmChecked();
    });
    this.onOkClicked = modal.onOkClicked;
    this.confirmChecked = modal.confirmChecked;

    this.show = function (options) {
        self.vendorName('');
        self.namespacePrefix('');
        self.contactName('');
        self.contactEmailAddress('');
        self.buttonText('Add');
        modal.show(options.callback);
    };

    var firstStepValidation = [
        self.vendorName,
        self.namespacePrefix,
        self.contactName,
        self.contactEmailAddress
    ];

    self.canAdd = ko.computed(function () {
        var errors = ko.validation.group(firstStepValidation);
        return errors().length === 0;
    });
};

var VendorViewModel = function (data) {
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

function VendorsViewModel() {
    var self = this;
    var VendorMapping = {
        create: function (options) {
            return new VendorViewModel(options.data);
        }
    };
    self.vendors = ko.mapping.fromJS([], VendorMapping);
    self.error = ko.observable();
    self.confirmationDialog = new confirmationDialog();
    self.addVendorDialog = new addVendorDialog();

    self.shouldShowTable = ko.computed(function () {
        return self.vendors().length > 0;
    });

    self.vendorStatus = ko.computed(function () {
        switch (self.vendors().length) {
            case 0:
                return "You have no vendors";
            case 1:
                return "You have 1 vendor";
            default:
                return "You have " + self.vendors().length + " vendors";
        }

    });

    self.getData = function () {
        $.ajax(
            {
                type: "GET",
                url: EdFiAdmin.Urls.vendor,
                dataType: 'json',
                success: function (data, textStatus, jqXHR) {
                    ko.mapping.fromJS(data, self.vendors);
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

    self.doAddVendor = function (onComplete) {
        self.error("");
        var vendorName = self.addVendorDialog.vendorName();
        var namespacePrefix = self.addVendorDialog.namespacePrefix();
        var contactName = self.addVendorDialog.contactName();
        var contactEmailAddress = self.addVendorDialog.contactEmailAddress();
        $.ajax({
            type: "POST",
            data: { "VendorName": vendorName, "NamespacePrefixesString": namespacePrefix, "ContactName": contactName, "ContactEmailAddress": contactEmailAddress },
            url: EdFiAdmin.Urls.vendor,
            dataType: 'json',
            success: function (data, textStatus, jqXHR) {
                onComplete();
                var newVendor = new VendorViewModel(data);
                self.vendors.push(newVendor);
                if (newVendor.IsLoading) {
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

    self.deleteVendorClicked = function (Vendor) {
        var deleteVendor = function (onComplete) {
           var VendorData = ko.mapping.toJS(Vendor);
            $.ajax({
                type: "DELETE",
                data: VendorData,
                url: EdFiAdmin.Urls.vendor + "/" + Vendor.Id(),
                success: function (data, textStatus, jqXHR) {
                    self.vendors.remove(Vendor);
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
            message: "Proceeding with this operation will permanently delete the selected vendor, along with all associated data." +
                "<br/><br/>" +
                "This operation cannot be undone.",
            buttonText: "Delete",
            callback: deleteVendor
        });
    };

    self.addVendorClicked = function () {

        addVendorDialogInstance.markFieldsAsTouched(false);
        self.addVendorDialog.show({ callback: self.doAddVendor });
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

    var viewModel = new VendorsViewModel();
    ko.applyBindings(viewModel);
});