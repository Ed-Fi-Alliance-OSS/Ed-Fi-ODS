#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Linq;

namespace EdFi.Ods.Common.Utils
{
    public class ConsoleOutput : IOutput
    {
        public void WriteLine(params string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    Console.WriteLine();
                    break;
                case 1:
                    Console.WriteLine(args[0]);
                    break;
                default:

                    Console.WriteLine(
                        args[0],
                        args.Skip(1)
                            .ToArray());

                    break;
            }
        }
    }
}
#endif