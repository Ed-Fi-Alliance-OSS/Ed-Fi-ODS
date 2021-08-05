using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using log4net;

namespace EdFi.Ods.Generator.Rendering
{
    public static class RenderingHelper
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(RenderingHelper));

        public static string ApplyPropertiesToParameterMarkers(IDictionary<string, string> propertyByName, string textWithParameterMarkers)
        {
            string finalOutputFileName = textWithParameterMarkers;

            // Apply properties to parameter markers
            foreach (var kvp in propertyByName)
            {
                string propertyMarker = $"{{{{{kvp.Key}}}}}";

                if (finalOutputFileName.Contains(propertyMarker))
                {
                    finalOutputFileName = finalOutputFileName.Replace(propertyMarker, kvp.Value);
                }
            }

            return finalOutputFileName;
        }

        public static bool ShouldRunEnhancer(object enhancer, IDictionary<string, string> renderingContext)
        {
            var conditions = enhancer.GetType().GetCustomAttributes<RenderConditionAttribute>();

            return conditions.All(
                rc =>
                    {
                        if (!renderingContext.TryGetValue(rc.Name, out string contextValue))
                        {
                            Logger.Debug(
                                $"Condition for '{rc.Name}' of '{rc.Pattern}' on enhancer '{enhancer.GetType().Name}' was not satisfied by the global rendering context.");

                            return false;
                        }

                        return Regex.IsMatch(contextValue, rc.Pattern, RegexOptions.IgnoreCase);
                    });
        }
    }
    
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class RenderConditionAttribute : Attribute
    {
        public RenderConditionAttribute(string name, string pattern)
        {
            Name = name;
            Pattern = pattern;
        }

        public string Name { get; }
        public string Pattern { get; }
    }
}