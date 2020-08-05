// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EdFi.Ods.Common
{
    public class UploadFileSourcingResults : IUploadFileSourcingResults
    {
        private UploadFileSourcingResults() { }

        public string FilePathIfValid { get; private set; }

        public bool IsFailure { get; private set; }

        public string[] ValidationErrorMessages { get; private set; }

        public void Dispose()
        {
            if (string.IsNullOrWhiteSpace(FilePathIfValid))
            {
                return;
            }

            File.Delete(FilePathIfValid);
        }

        public static UploadFileSourcingResults WithSuccessPath(string filePath)
        {
            return new UploadFileSourcingResults
                   {
                       IsFailure = false, FilePathIfValid = filePath
                   };
        }

        public static UploadFileSourcingResults WithValidationErrorMessages(IEnumerable<string> validationErrorMessages)
        {
            return new UploadFileSourcingResults
                   {
                       IsFailure = true, ValidationErrorMessages = validationErrorMessages.ToArray()
                   };
        }

        public static UploadFileSourcingResults WithValidationErrorMessage(string failureMessage)
        {
            return new UploadFileSourcingResults
                   {
                       IsFailure = true, ValidationErrorMessages = new[]
                                                                   {
                                                                       failureMessage
                                                                   }
                   };
        }
    }
}
