// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Newtonsoft.Json;

namespace EdFi.Ods.Generator.Rendering
{
    public class RenderingsManifestProvider : IRenderingsManifestProvider
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(RenderingsManifestProvider));

        public async Task<IList<Rendering>> GetRenderingsAsync(Assembly pluginAssembly)
        {
            // Get the renderings manifest
            string renderingsManifestResourceName = $"{pluginAssembly.GetName().Name}.renderings.json";

            var renderingsManifestStream = pluginAssembly.GetManifestResourceStream(renderingsManifestResourceName);

            if (renderingsManifestStream == null)
            {
                _logger.Debug($@"No 'renderings.settings' file was found in plugin assembly '{pluginAssembly.FullName}'.");

                return new Rendering[0];
            }

            string renderingsManifestContents = await GetStreamContents(renderingsManifestStream);

            var renderingSettings = JsonConvert.DeserializeObject<RenderingsManifest>(renderingsManifestContents);

            return renderingSettings.Renderings;
            
            async Task<string> GetStreamContents(Stream stream)
            {
                await using (stream)
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        return await sr.ReadToEndAsync();
                    }
                }
            }
        }
    }
}
