// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common._Stubs
{
    public class StubUploadFileSourcingResults : IUploadFileSourcingResults
    {
        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            IsDisposed = true;
        }

        public string FilePathIfValid { get; set; }

        public bool IsFailure { get; set; }

        public string[] ValidationErrorMessages { get; set; }

        public static StubUploadFileSourcingResults WithSuccessPath(string filePath)
        {
            return new StubUploadFileSourcingResults
                   {
                       IsFailure = false, FilePathIfValid = filePath
                   };
        }
    }
}
