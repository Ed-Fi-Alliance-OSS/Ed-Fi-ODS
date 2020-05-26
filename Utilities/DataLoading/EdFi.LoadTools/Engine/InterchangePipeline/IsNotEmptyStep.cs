// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.IO;
using log4net;

namespace EdFi.LoadTools.Engine.InterchangePipeline
{
    public class IsNotEmptyStep : IInterchangePipelineStep
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(IsNotEmptyStep).Name);

        public bool Process(string sourceFileName, Stream stream)
        {
            var result = stream.Length > 0;

            if (result)
            {
                Log.Info("not empty");
            }
            else
            {
                Log.Warn("empty");
            }

            return result;
        }
    }
}
