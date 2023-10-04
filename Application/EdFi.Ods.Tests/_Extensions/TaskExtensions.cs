// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;

namespace EdFi.Ods.Tests._Extensions;

public static class TaskHelpers
{
    public static Task<TResult> FromResultWithDelay<TResult>(TResult result, int delayMilliseconds)
    {
        Thread.Sleep(delayMilliseconds);

        return Task.FromResult(result);
    }
}
