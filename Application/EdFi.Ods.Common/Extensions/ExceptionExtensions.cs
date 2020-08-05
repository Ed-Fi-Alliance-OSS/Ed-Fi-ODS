// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Common.Extensions
{
    public static class ExceptionExtensions
    {
        public static string GetAllMessages(this Exception ex, string delimiter = "\r\n")
        {
            string message = ex.Message;

            var currentException = ex.InnerException;

            while (currentException != null)
            {
                message += delimiter + currentException.Message;
                currentException = currentException.InnerException;
            }

            return message;
        }

        public static string GetAllStackTraces(this Exception ex)
        {
            //This method is here for possible customization in future, but for now, the built in ToString method works fine with what we want
            return ex.ToString();
        }
    }
}
