﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Common.Extensions
{
    public static class ExceptionExtensions
    {
        public static string GetAllMessages(this Exception ex, string delimiter = null)
        {
            delimiter ??= Environment.NewLine;

            string message = ex.Message;

            var currentException = ex.InnerException;

            while (currentException != null)
            {
                message += delimiter + currentException.Message;
                currentException = currentException.InnerException;
            }

            return message;
        }
    }
}
