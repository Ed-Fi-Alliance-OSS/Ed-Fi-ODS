// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

// Function Extensions
Function.prototype.method = function (name, func) {
    if (!func) {
        return this.prototype[name];
    }
    if (!this.prototype[name]) {
        this.prototype[name] = func;
        return this;
    }
    return undefined;
};

// String Extensions
String.prototype.method = Function.prototype.method;

String.method('endsWith', function (suffix) {
    return this.indexOf(suffix, this.length - suffix.length) !== -1;
});

String.method('replaceNewlinesWithBreaks', function () {
    return this.replace('\r\n', '<br/>').replace('\n', '<br/>');
});