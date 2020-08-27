// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace EdFi.Ods.Tests
{
    [TestFixture]
    public class UtilityTest
    {
        private IEnumerable<IGrouping<string, Reference>> FindReferencesWithTheSameShortNameButDiffererntFullNames(List<Reference> references)
        {
            return from reference in references
                   group reference by reference.ReferencedAssembly.Name
                   into referenceGroup
                   where referenceGroup.ToList()
                                       .Select(reference => reference.ReferencedAssembly.FullName)
                                       .Distinct()
                                       .Count() > 1
                   select referenceGroup;
        }

        private List<Reference> GetReferencesFromAllAssemblies(List<Assembly> assemblies)
        {
            var references = new List<Reference>();

            foreach (var assembly in assemblies)
            {
                foreach (var referencedAssembly in assembly.GetReferencedAssemblies())
                {
                    references.Add(
                        new Reference
                        {
                            Assembly = assembly.GetName(), ReferencedAssembly = referencedAssembly
                        });
                }
            }

            return references;
        }

        private List<Assembly> GetAllAssemblies(string path)
        {
            var files = new List<FileInfo>();
            var directoryToSearch = new DirectoryInfo(path);
            files.AddRange(directoryToSearch.GetFiles("*.dll", SearchOption.AllDirectories));
            files.AddRange(directoryToSearch.GetFiles("*.exe", SearchOption.AllDirectories));
            return files.ConvertAll(file => Assembly.LoadFile(file.FullName));
        }

        private class Reference
        {
            public AssemblyName Assembly { get; set; }

            public AssemblyName ReferencedAssembly { get; set; }
        }

        [Test]
        [Ignore("Example to find conflicting references")]
        public void FindConflictingReferences()
        {
            var assemblies = GetAllAssemblies(@"C:\Projects\TennesseeDOE\TDOE\src\EdFi.Ods.Admin\bin");

            var references = GetReferencesFromAllAssemblies(assemblies);

            var groupsOfConflicts = FindReferencesWithTheSameShortNameButDiffererntFullNames(references);

            foreach (var group in groupsOfConflicts)
            {
                Console.Out.WriteLine("Possible conflicts for {0}:", group.Key);

                foreach (var reference in group)
                {
                    Console.Out.WriteLine(
                        "{0} references {1}",
                        reference.Assembly.Name.PadRight(25),
                        reference.ReferencedAssembly.FullName);
                }
            }
        }
    }
}
