// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Utils;

namespace EdFi.Ods.Tests.EdFi.Ods.CommonUtils._Stubs
{
    public class TestOutput : IOutput
    {
        private readonly List<string> _output = new List<string>();

        public string[] AllOutput
        {
            get { return _output.ToArray(); }
        }

        public void WriteLine(params string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    _output.Add(string.Empty);
                    break;
                case 1:
                    _output.Add(args[0]);
                    break;
                default:

                    _output.Add(
                        string.Format(
                            args[0],
                            args.Skip(1)
                                .ToArray()));

                    break;
            }
        }
    }
}
