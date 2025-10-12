// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.


var EdFiAdmin = EdFiAdmin || {};
EdFiAdmin.Auth = {};

EdFiAdmin.Auth = (function () {

    var Auth = {};

    function makeFunction(f) {
        if (typeof (f) == "function") {
            return f;
        }
        return function () {
        };
    }

    function ajax(options) {
        options.type = options.type || 'GET';
        options.dataType = options.dataType || 'json';
        options.success = makeFunction(options.success);
        options.error = makeFunction(options.error);
        $.ajax(options);
    }

    function postAuth(data, success, error) {
        var options = {
            type: "POST",
            url: EdFiAdmin.Urls.auth,
            data: data,
            success: success,
            error: error
        };
        ajax(options);
    }

    function hideLoginModal() {
        $('#loginModal').modal('hide');
    }

    function clearInputs() {
        $('#loginModal input').val('');
        clearInputStatus();
    }

    function clearInputStatus() {
        $('#loginModal .form-group').removeClass('has-error');
    }

    function gatherInputs(containerSelector) {
        var selector = containerSelector + ' input';
        var inputs = {};
        $(selector).each(function () {
            var el = $(this);
            var type = el.attr('type');
            var name = el.attr('name');

            var value = {};
            if (type == "checkbox") {
                value = el.is(':checked');
            } else {
                value = el.val();
            }

            inputs[name] = value;
        });
        return inputs;
    }

    function setLoginMessage(id, message) {
        $('#' + id)
            .html(message)
            .removeClass('d-none')
            .addClass('show')
            .alert();
    }

    var createMessageId = 'message-login-create';
    var loginMessageId = 'message-login';

    function clearLoginMessage(id) {
        if (typeof id == "undefined") {
            id = [createMessageId, loginMessageId];
        } else if (typeof id == "string") {
            id = [id];
        }

        $.each(id, function (elemIndex) {
            $('#' + id[elemIndex])
                .addClass('d-none')
                .removeClass('show')
                .text('');
        });
    }

    function getInputGroup(name) {
        return $(".form-group[data-groupname='" + name + "']");
    }

    function showTab(tabName) {
        $("#login-tabs a[href=#" + tabName + "]").tab('show');
    }

    function clearFailures() {
        clearLoginMessage();
        clearInputStatus();
    }

    function updateAuthAndRedirectHome(data) {
        if (data.authenticated) {
            $('.authUserName').text(data.name);
            $('.hideWhenAuthenticated').addClass('d-none');
            $('.showWhenAuthenticated').removeClass('d-none');
        } else {
            $('.showWhenAuthenticated').addClass('d-none');
            $('.hideWhenAuthenticated').removeClass('d-none');
        }
        window.location = EdFiAdmin.Urls.home;
    }

    function clearSessionInfoDisplay() {

    }

    Auth.getSessionInfo = function (success) {
        var options = {
            url: EdFiAdmin.Urls.session,
            success: success
        };
        ajax(options);
    };

    var loginInputGroups = {
        email: 'emailaddress',
        password: 'password',
        rememberme: 'rememberme'
    };

    Auth.login = function (hideModalOnSuccess) {

        function getInput(name) {
            return $("#tab-login input[name='" + name + "']");
        }

        var creds = gatherInputs('#tab-login');
        creds.Provider = 'credentials';

        var success = function (data) {
            updateAuthAndRedirectHome(data);
        };

        var error = function (jqXHR, textStatus, errorThrown) {
            clearSessionInfoDisplay();
            var responseJson = jqXHR.responseJSON || {};
            var errorMessage = responseJson.message || 'login failed';
            errorMessage = errorMessage.replaceNewlinesWithBreaks();
            if (jqXHR.status == 400) {
                if (responseJson.failingFields) {
                    _.each(responseJson.failingFields, function (field) {
                        var inputName = field.toLowerCase();
                        getInputGroup(inputName).addClass('has-error');
                    });
                }
            } else if (jqXHR.status == 401) {
                getInputGroup(loginInputGroups.email).addClass('has-error');
                getInputGroup(loginInputGroups.password).addClass('has-error');
            }
            setLoginMessage(loginMessageId, errorMessage);
        };

        clearFailures();

        var options = {
            type: "POST",
            url: EdFiAdmin.Urls.login,
            data: creds,
            success: success,
            error: error
        };
        ajax(options);
    };

    Auth.createLogin = function () {
        var success = function (data) {
            if (data.Success) {
                hideLoginModal();
                if (data.RedirectRoute) {
                    window.location = data.RedirectRoute;
                }
                return;
            }

            if (data.UserStatusMessage === "NeedsEmailConfirmation") {
                $('#create-resend').removeClass('d-none');
            }

            $.each(data.FailingFields, function (index, value) {
                getInputGroup(value).addClass('has-error');
            });

            if (data.HasMessage) {
                setLoginMessage(createMessageId, data.Message.replaceNewlinesWithBreaks());
            }
        };

        var creds = gatherInputs('#create-account-form');

        var error = function (jqXHR, textStatus, errorThrown) {
            var responseJson = jqXHR.responseJSON || {};
            var errorMessage = responseJson.message || errorThrown || 'login failed';
            errorMessage = errorMessage.replaceNewlinesWithBreaks();
            if (jqXHR.status == 400) {
                if (responseJson.failingFields) {
                    _.each(responseJson.failingFields, function (field) {
                        var inputName = field.toLowerCase();
                        getInputGroup(inputName).addClass('has-error');
                    });
                }
            }

            setLoginMessage(createMessageId, errorMessage);
        };

        var ajaxOptions = {
            url: EdFiAdmin.Urls.createLogin,
            success: success,
            error: error,
            type: "POST",
            data: creds
        };
        clearFailures();
        ajax(ajaxOptions);
    };

    Auth.logout = function () {
        var options = {
            type: "POST",
            url: EdFiAdmin.Urls.logout,
            success: updateAuthAndRedirectHome,
            error: clearSessionInfoDisplay
        };
        ajax(options);
    };

    Auth.clearDialog = function () {
        clearLoginMessage();
        clearInputs();
        showTab('tab-login');
    };

    return Auth;
})();

$(function () {
    $('#btn-login').click(function () {
        EdFiAdmin.Auth.login(true);
    });

    $('#btn-logout').click(EdFiAdmin.Auth.logout);

    $('#btn-createAccount').click(function () {
        EdFiAdmin.Auth.createLogin();
    });

    $('#btn-showLogin').click(EdFiAdmin.Auth.clearDialog);

    $('#loginModal input[type!=checkbox]').keyup(function (event) {
        if (event.keyCode == 13) {
            $("#btn-login").click();
        }
    });
});