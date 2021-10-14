// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using QuikGraph.Graphviz;
using QuikGraph.Graphviz.Dot;

namespace GenerateSecurityGraphs
{
    public sealed class FileDotEngine : IDotEngine
    {
        private readonly int _unflattenToDepth;
        private readonly string _graphvizFolder;
        private readonly string _assetsFolder;

        public FileDotEngine(string graphvizFolder, string assetsFolder)
        {
            _graphvizFolder = graphvizFolder;
            _assetsFolder = assetsFolder;
        }

        public FileDotEngine(string graphvizFolder, string assetsFolder, int unflattenToDepth)
        {
            _graphvizFolder = graphvizFolder;
            _assetsFolder = assetsFolder;
            _unflattenToDepth = unflattenToDepth;
        }

        public string Run(GraphvizImageType imageType, string dot, string outputFileName)
        {
            // Make sure directory exists
            var outputDirectory = Path.GetDirectoryName(outputFileName);

            Directory.CreateDirectory(outputDirectory);

            // API doesn't seem to support HTML based nodes, so we need to drop the quotes on the label output.
            string mungedDot = Regex.Replace(
                Regex.Unescape(dot),
                @"label=""(<.*?>)""",
                "label=$1", RegexOptions.Singleline);

            // API doesn't support "none" border type, but we don't want anything around our HTML
            mungedDot = mungedDot.Replace("plaintext", "none, margin=0");

            // Write out the "munged" dot file
            File.WriteAllText(outputFileName, mungedDot);

            // Now unflatten the dot file (if requested)
            if (_unflattenToDepth > 0)
            {
                var unflattenArgs = string.Format(@"-o ""{0}.unflattened"" -l{1} ""{0}""", outputFileName, _unflattenToDepth);

                Process.Start(
                    new ProcessStartInfo(Path.Combine(_graphvizFolder, @"bin\unflatten.exe"), unflattenArgs)
                    {
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true
                    })
                    // Wait, otherwise parent process might exit and kill this process before it completes
                    .WaitForExit();

                outputFileName = outputFileName + ".unflattened";
            }

            string[] outputTypes =
            {
                "png", "svg"
            };

            Parallel.ForEach(outputTypes, outputType =>
            {
                string outputImageFileName = Path.ChangeExtension(outputFileName, outputType);

                var args = string.Format(
                    @"""{0}"" -T{2} -o""{1}""",
                    outputFileName,
                    outputImageFileName,
                    outputType);

                Process.Start(
                    new ProcessStartInfo(Path.Combine(_graphvizFolder, @"bin\dot.exe"), args)
                    {
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        WorkingDirectory = _assetsFolder
                    })
                     // Wait, otherwise parent process might exit and kill this process before it completes
                    .WaitForExit();
            });

            return outputFileName;
        }
    }
}
