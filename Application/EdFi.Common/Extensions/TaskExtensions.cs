// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Threading.Tasks;

namespace EdFi.Ods.Common.Extensions
{
    public static class TaskExtensions
    {
        /// <summary>
        /// Gets the result of a asynchronous Task configuring the await to not try to continue
        /// on the captured context, thereby avoiding deadlocks.
        /// </summary>
        /// <param name="task">The asynchronous task to be synchronously completed.</param>
        /// <typeparam name="T">The return type of the Task.</typeparam>
        /// <returns>The task's result.</returns>
        public static T GetResultSafely<T>(this Task<T> task)
        {
            return task.ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Runs a asynchronous Task configuring the await to not try to continue
        /// on the captured context, thereby avoiding deadlocks.
        /// </summary>
        /// <param name="task">The asynchronous task to be synchronously completed.</param>
        public static void WaitSafely(this Task task)
        {
            task.ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}
