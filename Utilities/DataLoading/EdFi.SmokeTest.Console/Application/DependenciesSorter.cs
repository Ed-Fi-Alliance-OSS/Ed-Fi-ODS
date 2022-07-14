using System;
using System.Collections.Generic;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.SmokeTest;

namespace EdFi.SmokeTest.Console.Application
{
    public class DependenciesSorter : Dictionary<Type, Func<IEnumerable<Dependency>, IEnumerable<Dependency>>>, IDependenciesSorter
    { }
}
