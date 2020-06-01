// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.CodeGen.Models.Application;

namespace EdFi.Ods.CodeGen.Processing
{
    public interface ITemplateWriter
    {
        Task WriteAsync(TemplateWriterData codeGenTemplateWriterData, CancellationToken onCaptureContext);
    }
}
