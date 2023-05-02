// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Data.SqlClient;
using CommandLine;
using CommandLine.Text;
using Dapper;
using GenerateSecurityGraphs.Models.AuthorizationMetadata;
using GenerateSecurityGraphs.Models.Query;
using QuikGraph;
using QuikGraph.Graphviz;
using QuikGraph.Graphviz.Dot;

namespace GenerateSecurityGraphs
{
    // --------------------------------------------------------------------------------------------------------
    // To install Graphviz, recommendation is to use chololatey.
    // >  choco install Graphviz
    // --------------------------------------------------------------------------------------------------------
    // For additional icons for new authorization strategies, visit font awesome:
    // http://fortawesome.github.io/Font-Awesome/cheatsheet/
    // Screen grabs were taken, cropped to 16x16, and saved as PNGs and added to the Assets folder using the
    // naming convention of "{AuthorizationStrategyName}_icon.png".
    // NOTE: Be sure to set the Build Action to "Content", and the Copy option "Copy if newer" in the item's properties)
    // --------------------------------------------------------------------------------------------------------
    // Optional SVG viewer extension for Windows Explorer:  https://svgextension.codeplex.com/
    // --------------------------------------------------------------------------------------------------------
    internal class Options
    {
        [Option('o', "out", Required = true, HelpText = "The path to the folder where the graphs should be generated.")]
        public string OutputFolder { get; set; }

        [Option('f', "force", Default = false, HelpText = "Create a folder at that path if one doesn't already exist.")]
        public bool Force { get; set; }

        [Option('d', "database", Default = "EdFi_Security", HelpText = "The name of the database containing the authorization metadata.")]
        public string Database { get; set; }

        [Option(
            's', "server", Default = "(local)", HelpText = "The name of the SQL Server where the authorization metadata database is located.")]
        public string Server { get; set; }

        [Option(
            'u', "user", HelpText =
                "The SQL Server username to use for connecting to the authorization metadata database.  Leave username and password blank to use integrated security.")]
        public string User { get; set; }

        [Option(
            'p', "password", HelpText =
                "The password to use for connecting to the authorization metadata database.  Leave username and password blank to use integrated security.")]
        public string Password { get; set; }

        [Option(
            'g', "graphviz", Default = @"C:/Program Files/Graphviz/", HelpText =
                "Graphviz installation path.")]
        public string GraphvizPath { get; set; }

        //[HelpOption]
        public string GetUsage(string[] args)
        {
            var result = Parser.Default.ParseArguments<Options>(args);
            return HelpText.AutoBuild<Options>(result,
                current => HelpText.DefaultParsingErrorsHandler(result, current));
        }
    }

    internal class Program
    {
        private static string renderingClaimSetName;
        private static Dictionary<string, string> claimNamesToDisplayNames;

        private static async Task Main(string[] args)
        {
            // Parse the command line arguments
            var options = new Options();
            var failedToParse = false;

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(opt => options = opt)
                .WithNotParsed(e =>
                {
                    failedToParse = true;
                    e.Output(); // show error and help
                });

            if (failedToParse) return;

            string connectionString;

            if (options.User == null || options.Password == null)
            {
                connectionString = string.Format(
                    "Server={0};Database={1};Trusted_Connection=True",
                    options.Server,
                    options.Database);
            }
            else
            {
                connectionString = string.Format(
                    "Server={0};Database={1};User ID={2};Password={3}",
                    options.Server,
                    options.Database,
                    options.User,
                    options.Password);
            }

            string baseFolderPath;

            if (Path.IsPathRooted(options.OutputFolder))
            {
                baseFolderPath = options.OutputFolder;
            }
            else
            {
                baseFolderPath = Path.Combine(Directory.GetCurrentDirectory(), options.OutputFolder);
            }

            if (!options.Force && !Directory.Exists(baseFolderPath))
            {
                Console.WriteLine(
                    "Output folder '{0}' does not exist.  Use the --force option to create the directory automatically.", baseFolderPath);

                return;
            }

            if (options.GraphvizPath != options.GetType().GetProperty(nameof(options.GraphvizPath))
                    .GetCustomAttribute<OptionAttribute>().Default.ToString()
                && !Directory.Exists(options.GraphvizPath))
            {
                // A custom Graphviz path was provided but it is invalid, exit
                Console.WriteLine($"Graphviz installation path '{options.GraphvizPath}' does not exist.");
                return;
            }

            var graphvizPath = options.GraphvizPath;
            if (!Path.IsPathRooted(options.GraphvizPath))
            {
                graphvizPath = Path.Combine(Directory.GetCurrentDirectory(), options.GraphvizPath);
            }

            if (!Directory.Exists(graphvizPath))
            {
                // Fall back to a portable Graphviz
                graphvizPath = Path.Combine(AppContext.BaseDirectory, "Graphviz");

                // If Graphviz was previously downloaded then don't download it again
                if (!Directory.Exists(graphvizPath))
                {
                    Console.WriteLine("Downloading Graphviz ...");

                    try
                    {
                        await DownloadGraphviz(graphvizPath);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(
                            "Couldn't download Graphviz, check your internet connection or manually install it and use --graphviz option to set the installation path.");

                        return;
                    }

                    Console.WriteLine($"Successfully downloaded Graphviz and stored it in {graphvizPath}");
                }
            }

            Console.WriteLine("Generating graphs, please wait ...");

            // Load all authorization metadata into a graph and a list of claim sets
            var resourceGraph = LoadAuthorizationMetadataGraph(connectionString, out var claimSetNames);
            var rootNodes = GetRootNodes(resourceGraph);

            var assetsSourceFolder = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Assets");

            foreach (string claimSetName in claimSetNames.Concat(
                new[]
                {
                    string.Empty
                }))
            {
                renderingClaimSetName = claimSetName;

                var outputFolder = string.IsNullOrEmpty(claimSetName)
                    ? baseFolderPath

                    // TODO: Make whitespace more robust, or embed quotes in command-line arguments
                    : Path.Combine(
                        baseFolderPath,
                        claimSetName);

                // Copy assets to the output folder (to support SVG files, which doesn't embed the images)
                Directory.CreateDirectory(outputFolder);
                var iconFiles = Directory.GetFiles(assetsSourceFolder, "*_icon.png").ToList();
                iconFiles.ForEach(x => File.Copy(x, Path.Combine(outputFolder, Path.GetFileName(x)), true));

                // Create all the subgraphs

                var subgraphs = rootNodes
                    .Select(rootNode =>
                    {
                        var subgraph = GetSubgraph(resourceGraph, rootNode);

                        return new
                        {
                            Subgraph = subgraph,
                            OutputFileName = Path.Combine(outputFolder, claimNamesToDisplayNames[rootNode.ClaimName]),
                            UnflattenToDepth =
                                    subgraph.Vertices.Count() < 20
                                        ? 0
                                        : subgraph.Vertices.Count() / 5
                        };
                    })
                    .ToList();

                var subgraphsToCombine = subgraphs
                    .Where(subgraph => subgraph.Subgraph.Vertices.Count() < 2)
                    .ToList();

                // Generate all larger graphs
                foreach (var subgraph in subgraphs.Except(subgraphsToCombine))
                {
                    var graphVizResources = new GraphvizAlgorithm<Resource, Edge<Resource>>(subgraph.Subgraph);
                    graphVizResources.FormatVertex += FormatVertex;
                    graphVizResources.Generate(new FileDotEngine(graphvizPath, assetsSourceFolder, subgraph.UnflattenToDepth), subgraph.OutputFileName);
                }

                if (subgraphsToCombine.Any())
                {
                    // Generate a combined graph of smaller graphs
                    var combinedGraph = new AdjacencyGraph<Resource, Edge<Resource>>();

                    // Add all the vertices
                    combinedGraph.AddVertexRange(subgraphsToCombine.SelectMany(x => x.Subgraph.Vertices));

                    // Add all the edges
                    combinedGraph.AddEdgeRange(subgraphsToCombine.SelectMany(x => x.Subgraph.Edges));

                    var graphVizCombined = new GraphvizAlgorithm<Resource, Edge<Resource>>(combinedGraph);
                    graphVizCombined.FormatVertex += FormatVertex;
                    graphVizCombined.Generate(new FileDotEngine(graphvizPath, assetsSourceFolder), Path.Combine(outputFolder, "StandAlone"));
                }
            }
        }

        private static AdjacencyGraph<Resource, Edge<Resource>> LoadAuthorizationMetadataGraph(
            string connectionString, out List<string> claimSetNames)
        {
            var resourceGraph = new AdjacencyGraph<Resource, Edge<Resource>>();

            var calimsSql = @"
SELECT rc.ClaimName,
       rc.DisplayName,
       prc.ClaimName   AS ParentClaimName,
       prc.DisplayName AS ParentDisplayName,
       a.ActionName,
       as_.AuthorizationStrategyName
FROM   dbo.ResourceClaims rc
       LEFT JOIN dbo.ResourceClaims prc ON rc.ParentResourceClaimId = prc.ResourceClaimId
       LEFT JOIN dbo.ResourceClaimActions rca ON rc.ResourceClaimId = rca.ResourceClaimId
       LEFT JOIN dbo.ResourceClaimActionAuthorizationStrategies rcaas ON rca.ResourceClaimActionId = rcaas.ResourceClaimActionId
       LEFT JOIN dbo.AuthorizationStrategies as_ ON rcaas.AuthorizationStrategyId = as_.AuthorizationStrategyId
       LEFT JOIN dbo.Actions a ON rca.ActionId = a.ActionId
ORDER  BY rc.DisplayName,
          a.ActionId,
          as_.AuthorizationStrategyName
";

            var claimSetsSql = @"
SELECT ClaimSetName,
       ClaimName,
       ActionName,
       AuthorizationStrategyName AS StrategyName
FROM   dbo.ClaimSets cs
       LEFT JOIN dbo.ClaimSetResourceClaimActions csrca ON cs.ClaimSetId = csrca.ClaimSetId
	   LEFT JOIN dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides csrcaaso ON csrca.ClaimSetResourceClaimActionId = csrcaaso.ClaimSetResourceClaimActionId
       LEFT JOIN dbo.AuthorizationStrategies as_ ON csrcaaso.AuthorizationStrategyId = as_.AuthorizationStrategyId
	   LEFT JOIN dbo.Actions a ON csrca.ActionId = a.ActionId
       LEFT JOIN dbo.ResourceClaims rc ON csrca.ResourceClaimId = rc.ResourceClaimId
ORDER  BY ClaimSetName,
          rc.DisplayName,
          a.ActionId 
";
            using var conn = new SqlConnection(connectionString);
            var claims = conn.Query<ResourceSegmentData>(calimsSql);
            var claimSets = conn.Query<ClaimsetResourceActionData>(claimSetsSql);

            // Ignore ClaimSets that don't have ClaimSetResourceClaimActions ('Ownership Based Test', for example)
            claimSets = claimSets
                .Where(x => x.ClaimName != null)
                .ToList();

            var uniqueEdges = claims
                .GroupBy(e => (e.ClaimName, e.ParentClaimName))
                .Select(grp => grp.First());

            claimNamesToDisplayNames = uniqueEdges.ToDictionary(e => e.ClaimName, e => e.DisplayName);

            // First add empty vertices and edges to the graph, each claim is a vertex
            foreach (var edge in uniqueEdges)
            {
                var vertex = GetOrAddVertex(resourceGraph, edge.ClaimName);

                if (!string.IsNullOrEmpty(edge.ParentClaimName))
                {
                    var parentVertex = GetOrAddVertex(resourceGraph, edge.ParentClaimName);
                    resourceGraph.AddEdge(new Edge<Resource>(parentVertex, vertex));
                }
            }

            var edgesGroupedByClaim = claims
                .Where(resource => resource.ActionName != null)
                .GroupBy(resource => resource.ClaimName)
                .Select(resourcesByClaim => new
                {
                    ClaimName = resourcesByClaim.Key,
                    Actions = resourcesByClaim
                        .GroupBy(resource => resource.ActionName)
                        .Select(resourcesByAction => new
                        {
                            Name = resourcesByAction.Key,
                            Strategies = resourcesByAction.Select(resource => resource.AuthorizationStrategyName).ToHashSet()
                        })
                });

            // Now augment the vertices with authorization strategies and actions
            foreach (var edge in edgesGroupedByClaim)
            {
                var vertex = resourceGraph.Vertices.Single(x => x.ClaimName == edge.ClaimName);

                vertex.ActionAndStrategyPairs.AddRange(
                    edge.Actions.Select(action => new ActionAndStrategy
                    {
                        ActionName = action.Name,
                        AuthorizationStrategy = action.Strategies
                    })
                );
            }

            var claimSetsGroupedByName = claimSets
                .GroupBy(csra => csra.ClaimSetName)
                .Select(csrasByClaimSet => new
                {
                    ClaimSetName = csrasByClaimSet.Key,
                    Resources = csrasByClaimSet
                                    .GroupBy(csra => csra.ClaimName)
                                    .Select(csrasByClaim => new
                                    {
                                        ClaimName = csrasByClaim.Key,
                                        ActionStrategy = csrasByClaim
                                                            .Where(csra => !string.IsNullOrEmpty(csra.ActionName))
                                                            .Select(csra => new
                                                            {
                                                                csra.ActionName,
                                                                csra.StrategyName
                                                            })
                                                            .ToList()
                                    })
                                    .ToList()
                })
                .ToList();

            claimSetNames = claimSetsGroupedByName.Select(x => x.ClaimSetName).ToList();

            // Now augment the vertices with claimSet overrides
            foreach (var claimSet in claimSetsGroupedByName)
            {
                var claimSetName = claimSet.ClaimSetName;

                foreach (var resource in claimSet.Resources)
                {
                    var vertex = resourceGraph.Vertices.Single(x => x.ClaimName == resource.ClaimName);

                    foreach (var actionStrategy in resource.ActionStrategy)
                    {
                        var actionAndStrategyPair = vertex.ActionAndStrategyPairs.SingleOrDefault(x => x.ActionName == actionStrategy.ActionName);

                        if (actionAndStrategyPair == null)
                        {
                            // There are no ActionAndStrategyPairs because the resource doesn't have explicit metadata,
                            //      but it has an override so add the ActionAndStrategyPair now
                            var newActionAndStrategyPair = new ActionAndStrategy
                            {
                                ActionName = actionStrategy.ActionName
                                // AuthorizationStrategy stays null since it only stores metadata,
                                //      overrides go to StrategyOverridesByClaimSetName
                            };

                            vertex.ActionAndStrategyPairs.Add(newActionAndStrategyPair);

                            actionAndStrategyPair = newActionAndStrategyPair;
                        }

                        // Make note that we've got an override explicitly assigned
                        if (!actionAndStrategyPair.StrategyOverridesByClaimSetName.ContainsKey(claimSetName))
                        {
                            actionAndStrategyPair.StrategyOverridesByClaimSetName.Add(claimSetName, new HashSet<string>());
                        }

                        if (actionStrategy.StrategyName != null)
                        {
                            actionAndStrategyPair.StrategyOverridesByClaimSetName[claimSetName].Add(actionStrategy.StrategyName);
                        }
                    }
                }

                // Now process each of the root nodes from top to bottom to determine effective permissions at each vertex
                foreach (var rootVertex in GetRootNodes(resourceGraph))
                {
                    SetParentReferences(null, rootVertex, resourceGraph);
                }
            }

            return resourceGraph;
        }

        private static void SetParentReferences(
            Resource parentResource,
            Resource childResource,
            AdjacencyGraph<Resource, Edge<Resource>> resourceGraph)
        {
            childResource.Parent = parentResource;

            // Establish effective permissions by claimset
            IEnumerable<Edge<Resource>> outboundEdges;

            // Get the outbound edges (this should never fail)
            if (!resourceGraph.TryGetOutEdges(childResource, out outboundEdges))
            {
                throw new Exception("Unable to get outbound edges from root vertex.");
            }

            // Process the children, recursively
            foreach (var edge in outboundEdges)
            {
                SetParentReferences(childResource, edge.Target, resourceGraph);
            }
        }

        private static List<Resource> GetRootNodes(AdjacencyGraph<Resource, Edge<Resource>> resourceGraph)
        {
            var rootNodes = new List<Resource>();

            // Identify each sub-graph by identifying all root nodes.
            foreach (Resource vertex in resourceGraph.Vertices)
            {
                if (resourceGraph.Edges.All(x => x.Target.ClaimName != vertex.ClaimName))
                {
                    // We have a root node, so add its elements to a new graph
                    rootNodes.Add(vertex);
                }
            }

            return rootNodes;
        }

        private static AdjacencyGraph<Resource, Edge<Resource>> GetSubgraph(AdjacencyGraph<Resource, Edge<Resource>> resourceGraph, Resource rootNode)
        {
            var subgraph = new AdjacencyGraph<Resource, Edge<Resource>>();

            AddChildren(resourceGraph, subgraph, rootNode);

            return subgraph;
        }

        private static Resource GetOrAddVertex(AdjacencyGraph<Resource, Edge<Resource>> resourceGraph, string claimName)
        {
            var vertex = resourceGraph.Vertices.SingleOrDefault(v => v.ClaimName == claimName);

            if (vertex == null)
            {
                vertex = new Resource(claimName);
                resourceGraph.AddVertex(vertex);
            }

            return vertex;
        }

        private static void AddChildren(AdjacencyGraph<Resource, Edge<Resource>> resourceGraph, AdjacencyGraph<Resource, Edge<Resource>> subgraph,
                                        Resource vertex)
        {
            IEnumerable<Edge<Resource>> childEdges;

            subgraph.AddVertex(vertex);

            if (resourceGraph.TryGetOutEdges(vertex, out childEdges))
            {
                subgraph.AddVerticesAndEdgeRange(childEdges);

                foreach (var childEdge in childEdges)
                {
                    AddChildren(resourceGraph, subgraph, childEdge.Target);
                }
            }
        }

        private static void FormatVertex(object sender, FormatVertexEventArgs<Resource> e)
        {
            string htmlLabel;

            var resource = e.Vertex;

            var effectiveCreatePermissions = GetEffectiveActionPermissions(resource, "Create", renderingClaimSetName);
            var effectiveReadPermissions = GetEffectiveActionPermissions(resource, "Read", renderingClaimSetName);
            var effectiveUpdatePermissions = GetEffectiveActionPermissions(resource, "Update", renderingClaimSetName);
            var effectiveDeletePermissions = GetEffectiveActionPermissions(resource, "Delete", renderingClaimSetName);

            if (effectiveCreatePermissions.IsIndeterminate()
                && effectiveReadPermissions.IsIndeterminate()
                && effectiveUpdatePermissions.IsIndeterminate()
                && effectiveDeletePermissions.IsIndeterminate())
            {
                htmlLabel = $@"
<TABLE BORDER=""0"" CELLBORDER=""1"" CELLSPACING=""0"" CELLPADDING=""4"">
    <TR>
        <TD COLSPAN=""4"" BGCOLOR=""#{Colors.Header}"">
            <B>{GetVertexDisplayName(resource.ClaimName)}</B>
        </TD>
    </TR>
    <TR>
        <TD bgcolor=""#{GetActionColor(effectiveCreatePermissions)}"">
            {EmphasizeExplicit(effectiveCreatePermissions, "C")}
        </TD>
        <TD bgcolor=""#{GetActionColor(effectiveReadPermissions)}"">
            {EmphasizeExplicit(effectiveReadPermissions, "R")}
        </TD>
        <TD bgcolor=""#{GetActionColor(effectiveUpdatePermissions)}"">
            {EmphasizeExplicit(effectiveUpdatePermissions, "U")}
        </TD>
        <TD bgcolor=""#{GetActionColor(effectiveDeletePermissions)}"">
            {EmphasizeExplicit(effectiveDeletePermissions, "D")}
        </TD>
    </TR>
</TABLE>";
            }
            else
            {
                htmlLabel = $@"
<TABLE BORDER=""0"" CELLBORDER=""1"" CELLSPACING=""0"" CELLPADDING=""4"">
<TR>
    <TD COLSPAN=""2"" BGCOLOR=""#{Colors.Header}"">
        <font point-size=""16"">
            <B>{GetVertexDisplayName(resource.ClaimName)}</B>
        </font>
    </TD>
</TR>
<TR>
    <TD bgcolor=""#{GetActionColor(effectiveCreatePermissions)}"">
        {EmphasizeExplicit(effectiveCreatePermissions, "C")}
    </TD>
    <TD>
        <TABLE border=""0"" cellborder=""0"">
            {GetAuthorizationStrategyRows(effectiveCreatePermissions)}
        </TABLE>
    </TD>
</TR>
<TR>
    <TD bgcolor=""#{GetActionColor(effectiveReadPermissions)}"">
        {EmphasizeExplicit(effectiveReadPermissions, "R")}
    </TD>
    <TD>
        <TABLE border=""0"" cellborder=""0"">
            {GetAuthorizationStrategyRows(effectiveReadPermissions)}
        </TABLE>
    </TD>
</TR>
<TR>
    <TD bgcolor=""#{GetActionColor(effectiveUpdatePermissions)}"">
        {EmphasizeExplicit(effectiveUpdatePermissions, "U")}
    </TD>
    <TD>
        <TABLE border=""0"" cellborder=""0"">
            {GetAuthorizationStrategyRows(effectiveUpdatePermissions)}
        </TABLE>
    </TD>
</TR>
<TR>
    <TD bgcolor=""#{GetActionColor(effectiveDeletePermissions)}"">
        {EmphasizeExplicit(effectiveDeletePermissions, "D")}
    </TD>
    <TD>
        <TABLE border=""0"" cellborder=""0"">
            {GetAuthorizationStrategyRows(effectiveDeletePermissions)}
        </TABLE>
    </TD>
</TR>
</TABLE>";
            }

            e.VertexFormat.Label = $"<{RemoveSpaces(htmlLabel)}>";
            e.VertexFormat.Shape = GraphvizVertexShape.Plaintext;
        }

        private static string GetVertexDisplayName(string claimName)
        {
            // If it has "domains" in the URI. Just use the display name, unmodified in the graph.
            // If the next to last segment is "claims", add "(ed-fi)" to the display name. Example: student(ed - fi)
            // If the next to last semgent is anything else, add that segment in parenthesis to the display name.Example: teacherCandidate(tpdm)

            var displayName = claimNamesToDisplayNames[claimName];

            if (claimName.Contains("/domains/", StringComparison.InvariantCultureIgnoreCase))
            {
                return displayName;
            }

            var nextToLastSegment = claimName.Split('/')[^2];

            return string.Equals(nextToLastSegment, "claims", StringComparison.InvariantCultureIgnoreCase) ?
                $"{displayName} (ed-fi)"
                : $"{displayName} ({nextToLastSegment})";
        }

        private static string EmphasizeExplicit(EffectiveActionAndStrategy effectiveActionAndStrategy, string text)
        {
            return !effectiveActionAndStrategy.ActionInherited
                ? $"<B>{text}</B>"
                : $"<FONT>{text}</FONT>";
        }

        private static string GetAuthorizationStrategyRows(EffectiveActionAndStrategy effectiveActionAndStrategy)
        {
            if (effectiveActionAndStrategy.AuthorizationStrategy == null)
            {
                return @"
<TR>
    <TD></TD>
</TR>";
            }

            var sb = new StringBuilder();

            foreach (var strategy in effectiveActionAndStrategy.AuthorizationStrategy)
            {
                sb.Append(@$"
<TR>
    <TD align=""left""><IMG SRC=""{strategy}_icon.png""/></TD>
    <TD align=""text"">");

                // Inherited settings are grayed and italicized
                if (effectiveActionAndStrategy.AuthorizationStrategyInherited)
                {
                    sb.Append(@"<font color=""#a0a0a0""><i>");
                }

                // Claim Set specific settings are bold-faced
                if (!effectiveActionAndStrategy.AuthorizationStrategyIsDefault)
                {
                    sb.Append("<b>");
                }

                // Append the strategy name
                sb.Append(strategy);

                // Claim Set specific settings are bold-faced
                if (!effectiveActionAndStrategy.AuthorizationStrategyIsDefault)
                {
                    sb.Append("</b>");
                }

                // Inherited settings are grayed and italicized
                if (effectiveActionAndStrategy.AuthorizationStrategyInherited)
                {
                    sb.Append(@"</i></font>");
                }

                sb.Append("</TD><TD></TD></TR>");
            }

            // Look for overrides
            foreach (var strategy in effectiveActionAndStrategy.OverriddenClaimSetAuthorizationStrategy ?? Enumerable.Empty<string>())
            {
                sb.Append(@$"
<TR>
    <TD align=""left""><IMG SRC=""_icon.png""/></TD>
    <TD align=""text"">");

                // Overrides are displayed in red, strikethrough font (Claim Set overrides are bold-faced too)
                sb.Append(@"<font color=""#FF0000""><s><b>");

                if (effectiveActionAndStrategy.OverriddenClaimSetAuthorizationStrategyInherited)
                {
                    sb.Append(@"<i>");
                }

                sb.Append(strategy);

                if (effectiveActionAndStrategy.OverriddenClaimSetAuthorizationStrategyInherited)
                {
                    // Add on originating resource name for the inherited overrides
                    sb.Append(@" (" + claimNamesToDisplayNames[effectiveActionAndStrategy.OverriddenClaimSetAuthorizationStrategyOriginatingClaimName] + ")");
                    sb.Append(@"</i>");
                }

                sb.Append(@"</b></s></font></TD><TD></TD></TR>");
            }

            foreach (var strategy in effectiveActionAndStrategy.OverriddenDefaultAuthorizationStrategy ?? Enumerable.Empty<string>())
            {
                sb.Append(@$"
<TR>
    <TD align=""left""><IMG SRC=""_icon.png""/></TD>
    <TD align=""text"">");

                // Overrides are displayed in red, strikethrough font
                sb.Append(@"<font color=""#FF0000""><s>");

                if (effectiveActionAndStrategy.OverriddenDefaultAuthorizationStrategyInherited)
                {
                    sb.Append(@"<i>");
                }

                sb.Append(strategy);

                if (effectiveActionAndStrategy.OverriddenDefaultAuthorizationStrategyInherited)
                {
                    // Add on originating resource name for the inherited overrides
                    sb.Append(@" (" + claimNamesToDisplayNames[effectiveActionAndStrategy.OverriddenDefaultAuthorizationStrategyOriginatingClaimName] + ")");
                    sb.Append(@"</i>");
                }

                sb.Append(@"</s></font></TD><TD></TD></TR>");
            }

            return sb.ToString();
        }

        private static string RemoveSpaces(string htmlText)
        {
            // Load the HTML string into an XmlWriter and write it back without indentation
            using (var stringWriter = new StringWriter(new StringBuilder()))
            {
                using (var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings
                {
                    OmitXmlDeclaration = true,
                    ConformanceLevel = ConformanceLevel.Auto,
                    Indent = false
                }))
                {
                    var xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(htmlText);
                    xmlDocument.Save(xmlWriter);
                }

                return stringWriter.ToString();
            }
        }

        private static EffectiveActionAndStrategy GetEffectiveActionPermissions(
            Resource resource, string actionName, string claimSetName)
        {
            var effectiveActionAndStrategy = new EffectiveActionAndStrategy(resource.ClaimName, actionName);

            // Step 1: Process default metadata, top to bottom (least to most in terms of priority)

            // Process ancestors first, top to bottom
            var inheritedDefaultActionAndStrategyPairs = resource.Ancestors
                .Select(ancestor => new
                {
                    OriginatingClaimName = ancestor.ClaimName,
                    ActionAndStrategy = ancestor.ActionAndStrategyPairs
                                                .SingleOrDefault(x => x.ActionName == actionName)
                })
                .Where(i => i.ActionAndStrategy != null)
                .Reverse()
                .ToList();

            foreach (var pair in inheritedDefaultActionAndStrategyPairs)
            {
                effectiveActionAndStrategy.TrySetAuthorizationStrategy(
                    pair.ActionAndStrategy.AuthorizationStrategy,
                    pair.OriginatingClaimName,
                    inherited: true,
                    isDefault: true);
            }

            var localActionAndStrategy = resource.ActionAndStrategyPairs
                                        .SingleOrDefault(x => x.ActionName == actionName) ?? ActionAndStrategy.Empty;

            effectiveActionAndStrategy.TrySetAuthorizationStrategy(
                localActionAndStrategy.AuthorizationStrategy,
                resource.ClaimName,
                inherited: false,
                isDefault: true);

            // Step 2: Process from top to bottom (least to most in terms of priority)

            // Look for explicit claim set overrides up the resource claim lineage
            var claimsetOverridePermissions = resource.Ancestors
                .Select(ancestor => new
                {
                    OriginatingClaimName = ancestor.ClaimName,
                    Strategy = GetClaimSetSpecificActionAndStrategy(ancestor.ActionAndStrategyPairs.SingleOrDefault(x => x.ActionName == actionName), claimSetName)
                })
                .Where(i => i.Strategy != null)
                .Reverse()
                .ToList();

            foreach (var pair in claimsetOverridePermissions)
            {
                effectiveActionAndStrategy.TrySetActionGranted(inherited: true);

                effectiveActionAndStrategy.TrySetAuthorizationStrategy(
                    pair.Strategy,
                    pair.OriginatingClaimName,
                    inherited: true,
                    isDefault: false);
            }

            // Are there any explicit settings on the resource for the current action and claim set?
            if (localActionAndStrategy.StrategyOverridesByClaimSetName.ContainsKey(claimSetName))
            {
                var explicitStrategyForAction = localActionAndStrategy
                    .StrategyOverridesByClaimSetName[claimSetName];

                // There was a claim set specific setting on the current resource
                effectiveActionAndStrategy.TrySetActionGranted(inherited: false);

                effectiveActionAndStrategy.TrySetAuthorizationStrategy(
                    explicitStrategyForAction,
                    resource.ClaimName,
                    inherited: false,
                    isDefault: false);
            }

            return effectiveActionAndStrategy;
        }

        private static HashSet<string> GetClaimSetSpecificActionAndStrategy(ActionAndStrategy pair, string claimSetName)
        {
            if (pair == null)
            {
                return null;
            }

            if (!pair.StrategyOverridesByClaimSetName.ContainsKey(claimSetName))
            {
                return null;
            }

            return pair.StrategyOverridesByClaimSetName[claimSetName];
        }

        private static string GetActionColor(EffectiveActionAndStrategy effectiveActionAndStrategy)
        {
            if (effectiveActionAndStrategy.ActionGranted != true)
            {
                return Colors.Default;
            }

            switch (effectiveActionAndStrategy.ActionName)
            {
                case "Create":

                    return effectiveActionAndStrategy.ActionInherited
                        ? SecondaryColors.Create
                        : Colors.Create;
                case "Read":

                    return effectiveActionAndStrategy.ActionInherited
                        ? SecondaryColors.Read
                        : Colors.Read;
                case "Update":

                    return effectiveActionAndStrategy.ActionInherited
                        ? SecondaryColors.Update
                        : Colors.Update;
                case "Delete":

                    return effectiveActionAndStrategy.ActionInherited
                        ? SecondaryColors.Delete
                        : Colors.Delete;
                default:
                    return Colors.Default;
            }
        }

        private static async Task DownloadGraphviz(string destinationDirectoryName)
        {
            var tempZipPath = Path.Combine(AppContext.BaseDirectory, "temp_graphviz.zip");
            var tempDirPath = Path.Combine(AppContext.BaseDirectory, "temp_graphviz");

            // Some antiviruses have false positives and detect Graphviz as a trojan, more info: https://gitlab.com/graphviz/graphviz/-/issues/1773
            using var httpClient = new HttpClient();

            using var httpResponse = await httpClient.GetAsync(
                new Uri("https://gitlab.com/api/v4/projects/4207231/packages/generic/graphviz-releases/2.46.1/stable_windows_10_msbuild_Release_Win32_graphviz-2.46.1-win32.zip")
            );

            using (var fileStream = new FileStream(tempZipPath, FileMode.Create))
            {
                await httpResponse.Content.CopyToAsync(fileStream);
            }

            ZipFile.ExtractToDirectory(tempZipPath, tempDirPath);
            Directory.Move(Path.Combine(tempDirPath, @"Graphviz"), destinationDirectoryName);

            File.Delete(tempZipPath);
            Directory.Delete(tempDirPath);
        }
    }
}
