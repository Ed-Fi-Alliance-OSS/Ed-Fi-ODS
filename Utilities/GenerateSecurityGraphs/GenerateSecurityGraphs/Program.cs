// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
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
            'g', "graphviz", Default = @"C:\Program Files\Graphviz\", HelpText =
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

    internal struct AuthorizationKey
    {
        public AuthorizationKey(string claimSetName, string claimName, string actionName)
            : this()
        {
            ClaimSetName = claimSetName;
            ClaimName = claimName;
            ActionName = actionName;
        }

        public string ClaimSetName { get; set; }

        public string ClaimName { get; set; }

        public string ActionName { get; set; }

        public override string ToString()
        {
            return ClaimName + " (" + ClaimSetName + "; " + ActionName + ")";
        }
    }

    internal class Program
    {
        private static string renderingClaimSetName;
        private static Dictionary<string, string> claimNamesToDisplayNames;

        private static void Main(string[] args)
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
                        DownloadGraphviz(graphvizPath);
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

            // Load all authorization metadata into a graph and a list of claim sets
            var authorizationMetadata = new Dictionary<AuthorizationKey, EffectiveActionAndStrategy>();

            List<string> claimSetNames;
            var resourceGraph = LoadAuthorizationMetadataGraph(connectionString, out claimSetNames);

            foreach (string claimSetName in claimSetNames)
            {
                // Process every resource claim in the graph, for each claim set for effective claims
                foreach (Resource resource in resourceGraph.Vertices)
                {
                    foreach (string actionName in new[]
                                                  {
                                                      "Create", "Read", "Update", "Delete"
                                                  })
                    {
                        authorizationMetadata.Add(
                            new AuthorizationKey(claimSetName, resource.Name, actionName),
                            GetEffectiveActionPermissions(resource, actionName, claimSetName)
                        );
                    }
                }
            }

            var rootNodes = GetRootNodes(resourceGraph);

            //ClearOutputFolder();
            string assetsSourceFolder = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Assets");

            foreach (string claimSetName in claimSetNames.Concat(
                new[]
                {
                    string.Empty
                }))
            {
                renderingClaimSetName = claimSetName;

                string outputFolder = string.IsNullOrEmpty(claimSetName)
                    ? baseFolderPath

                    // TODO: Make whitespace more robust, or embed quotes in command-line arguments
                    : Path.Combine(
                        baseFolderPath,
                        claimSetName);

                //claimSetName.Replace(" ", "_"));

                // Copy assets to the output folder (to support SVG files, which doesn't embed the images)
                Directory.CreateDirectory(outputFolder);
                var iconFiles = Directory.GetFiles(assetsSourceFolder, "*_icon.png").ToList();
                iconFiles.ForEach(x => File.Copy(x, Path.Combine(outputFolder, Path.GetFileName(x)), true));

                // Create all the subgraphs
                var subgraphs =
                    (from rootNode in rootNodes
                     let subgraph = GetSubgraph(resourceGraph, rootNode)
                     select new
                     {
                         Subgraph = subgraph,
                         OutputFileName = Path.Combine(outputFolder, claimNamesToDisplayNames[rootNode.Name]),
                         UnflattenToDepth =
                                    subgraph.Vertices.Count() < 20
                                        ? 0
                                        : subgraph.Vertices.Count() / 5
                     })
                   .ToList();

                var subgraphsToCombine =
                    (from sg in subgraphs
                     where sg.Subgraph.Vertices.Count() < 2
                     select sg)
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

        //private static void ClearOutputFolder()
        //{
        //    if (Directory.Exists(BaseOutputFolder))
        //    {
        //        Directory
        //            .GetFiles(BaseOutputFolder)
        //            .ToList()
        //            .ForEach(File.Delete);
        //    }
        //}

        private static AdjacencyGraph<Resource, Edge<Resource>> LoadAuthorizationMetadataGraph(
            string connectionString, out List<string> claimSetNames)
        {
            var resourceGraph = new AdjacencyGraph<Resource, Edge<Resource>>();

            string metadataSql = @"
select	
	  rc.ClaimName
	, rc.DisplayName
	, prc.ClaimName as ParentClaimName
    , prc.DisplayName as ParentDisplayName
	, a.ActionName
	, as_.AuthorizationStrategyName
from dbo.ResourceClaims rc
        left join dbo.ResourceClaims prc ON rc.ParentResourceClaimId = prc.ResourceClaimId
        left join dbo.ResourceClaimAuthorizationMetadatas rcas ON rc.ResourceClaimId = rcas.ResourceClaim_ResourceClaimId
        left join dbo.AuthorizationStrategies as_ ON rcas.AuthorizationStrategy_AuthorizationStrategyId = as_.AuthorizationStrategyId
        left join dbo.Actions a ON rcas.Action_ActionId = a.ActionId
order by 
	  rc.DisplayName
	, a.ActionId
	, as_.AuthorizationStrategyName
";

            string claimSetSql = @"
select	
	  ClaimSetName
	, ClaimName
	, ActionName, null As StrategyName
from	dbo.ClaimSets cs
        left join dbo.ClaimSetResourceClaims csrc ON cs.ClaimSetId = csrc.ClaimSet_ClaimSetId
        left join dbo.Actions a ON csrc.Action_ActionId = a.ActionId
        left join dbo.ResourceClaims rc ON csrc.ResourceClaim_ResourceClaimId = rc.ResourceClaimId
order by 
	  ClaimSetName
	, DisplayName
	, Action_ActionId
";

            using var conn = new SqlConnection(connectionString);
            var metadataEdges = conn.Query<ResourceSegmentData>(metadataSql);
            var claimsetResourceActions = conn.Query<ClaimsetResourceActionData>(claimSetSql);

            var distinctMetadataEdges = metadataEdges
                .GroupBy(e => (e.ClaimName, e.ParentClaimName))
                .Select(grp => grp.First());

            claimNamesToDisplayNames = distinctMetadataEdges.ToDictionary(e => e.ClaimName, e => e.DisplayName);

            // First process the segments into the graph
            foreach (var metadataEdge in distinctMetadataEdges)
            {
                if (string.IsNullOrEmpty(metadataEdge.ParentClaimName))
                {
                    resourceGraph.AddVertex(new Resource(metadataEdge.ClaimName));
                }
                else
                {
                    resourceGraph.AddVerticesAndEdge(
                        new Edge<Resource>(new Resource(metadataEdge.ParentClaimName), new Resource(metadataEdge.ClaimName)));
                }
            }

            // Now augment the vertices with authorization strategies and actions
            var edgesGroupedByResoureName =
                from e in metadataEdges
                where e.ActionName != null
                group e by e.ClaimName
                into g
                select new
                {
                    ClaimName = g.Key,
                    Actions = g.Select(
                               x => new
                               {
                                   x.ActionName,
                                   StrategyName = x.AuthorizationStrategyName
                               })
                };

            // Augment each vertex with the actions/strategies
            foreach (var edge in edgesGroupedByResoureName)
            {
                var vertex = resourceGraph.Vertices.Single(x => x.Name == edge.ClaimName);

                vertex.ActionAndStrategyPairs.AddRange(
                    from e in edge.Actions
                    select new ActionAndStrategy
                    {
                        ActionName = e.ActionName,
                        AuthorizationStrategy = e.StrategyName
                    });
            }

            // Process claim set data
            var claimsetMetadata =
                (from c in claimsetResourceActions
                 group c by c.ClaimSetName
                 into mainGroup
                 select new
                 {
                     ClaimSetName = mainGroup.Key,
                     Resources =
                                (from mg in mainGroup
                                 group mg by mg.ClaimName
                                 into subGroup
                                 select new
                                 {
                                     ClaimName = subGroup.Key,
                                     ActionStrategy =
                                                (from sg in subGroup
                                                 where !string.IsNullOrEmpty(sg.ActionName)
                                                 select new
                                                 {
                                                     sg.ActionName,
                                                     sg.StrategyName
                                                 })
                                               .ToList()
                                 }).ToList()
                 }).ToList();

            claimSetNames = claimsetMetadata.Select(x => x.ClaimSetName).ToList();

            foreach (var claimsetItem in claimsetMetadata)
            {
                string claimSetName = claimsetItem.ClaimSetName;

                foreach (var resourceItem in claimsetItem.Resources)
                {
                    var resourceVertex = resourceGraph.Vertices.Single(x => x.Name == resourceItem.ClaimName);

                    foreach (var actionStrategyItem in resourceItem.ActionStrategy)
                    {
                        var actionVertex = resourceVertex.ActionAndStrategyPairs.SingleOrDefault(x => x.ActionName == actionStrategyItem.ActionName);

                        // If action vertex doesn't yet exist in the graph, create it implicitly now
                        if (actionVertex == null)
                        {
                            var newAction = new ActionAndStrategy
                            {
                                ActionName = actionStrategyItem.ActionName
                            };

                            resourceVertex.ActionAndStrategyPairs.Add(newAction);

                            actionVertex = newAction;
                        }

                        // Make note that we've got metadata explicitly assigning this action
                        actionVertex.ExplicitActionAndStrategyByClaimSetName[claimSetName] = new ActionAndStrategy
                        {
                            ActionName = actionStrategyItem.ActionName,
                            AuthorizationStrategy =
                                                                                                     actionStrategyItem.StrategyName
                        };
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

        //private static List<ClaimsetResourceActionData> GetClaimSetMetadata(string connectionString, string providerName, string claimSetSql)
        //{
        //    using (var conn = new Database(connectionString, providerName))
        //    {
        //        var claimsetResourceActions = conn.Query<ClaimsetResourceActionData>(claimSetSql).ToList();
        //        return claimsetResourceActions;
        //    }
        //}

        //private static List<ResourceSegmentData> GetResourceClaimMetadata(string connectionString, string providerName, string metadataSql)
        //{
        //    using (var conn = new Database(connectionString, providerName))
        //    {
        //        var metadataEdges = conn.Query<ResourceSegmentData>(metadataSql).ToList();
        //        return metadataEdges;
        //    }
        //}

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
                if (resourceGraph.Edges.All(x => x.Target.Name != vertex.Name))
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
            var f = e.VertexFormat;

            string htmlLabel;

            Resource resource = e.Vertex;

            var effectiveCreatePermissions = GetEffectiveActionPermissions(resource, "Create", renderingClaimSetName);
            var effectiveReadPermissions = GetEffectiveActionPermissions(resource, "Read", renderingClaimSetName);
            var effectiveUpdatePermissions = GetEffectiveActionPermissions(resource, "Update", renderingClaimSetName);
            var effectiveDeletePermissions = GetEffectiveActionPermissions(resource, "Delete", renderingClaimSetName);

            if (effectiveCreatePermissions.IsIndeterminate()
                && effectiveReadPermissions.IsIndeterminate()
                && effectiveUpdatePermissions.IsIndeterminate()
                && effectiveDeletePermissions.IsIndeterminate())
            {
                htmlLabel = string.Format(
                    @"<
<TABLE BORDER=""0"" CELLBORDER=""1"" CELLSPACING=""0"" CELLPADDING=""4"">
<TR><TD COLSPAN=""4"" BGCOLOR=""#{1}""><B>{0}</B></TD></TR>
<TR>
    <TD bgcolor=""#{2}"">{3}C{4}</TD>
    <TD bgcolor=""#{5}"">{6}R{7}</TD>
    <TD bgcolor=""#{8}"">{9}U{10}</TD>
    <TD bgcolor=""#{11}"">{12}D{13}</TD>
</TR>
</TABLE>
>",
                    claimNamesToDisplayNames[resource.Name],
                    Colors.Header,
                    GetActionColor(effectiveCreatePermissions),
                    EmphasizeExplicitStart(effectiveCreatePermissions),
                    EmphasizeExplicitStop(effectiveCreatePermissions),
                    GetActionColor(effectiveReadPermissions),
                    EmphasizeExplicitStart(effectiveReadPermissions),
                    EmphasizeExplicitStop(effectiveReadPermissions),
                    GetActionColor(effectiveUpdatePermissions),
                    EmphasizeExplicitStart(effectiveUpdatePermissions),
                    EmphasizeExplicitStop(effectiveUpdatePermissions),
                    GetActionColor(effectiveDeletePermissions),
                    EmphasizeExplicitStart(effectiveDeletePermissions),
                    EmphasizeExplicitStop(effectiveDeletePermissions));
            }
            else
            {
                htmlLabel = string.Format(
                    @"<
<TABLE BORDER=""0"" CELLBORDER=""1"" CELLSPACING=""0"" CELLPADDING=""4"">
<TR>
    <TD COLSPAN=""2"" BGCOLOR=""#{13}""><font point-size=""16""><B>{0}</B></font></TD>
</TR>
<TR>
    <TD bgcolor=""#{1}"">{14}C{15}</TD>
    <TD>
        <TABLE border=""0"" cellborder=""0"">
            <TR>
                <TD align=""left""><IMG SRC=""{2}_icon.png""/></TD>
                <TD align=""left"">{3}</TD>
            </TR>
        </TABLE>
    </TD>
</TR>
<TR>
    <TD bgcolor=""#{4}"">{16}R{17}</TD>
    <TD>
        <TABLE border=""0"" cellborder=""0"">
            <TR>
                <TD align=""left""><IMG SRC=""{5}_icon.png""/></TD>
                <TD align=""left"">{6}</TD>
            </TR>
        </TABLE>
    </TD>
</TR>
<TR>
    <TD bgcolor=""#{7}"">{18}U{19}</TD>
    <TD>
        <TABLE border=""0"" cellborder=""0"">
            <TR>
                <TD align=""left""><IMG SRC=""{8}_icon.png""/></TD>
                <TD align=""left"">{9}</TD>
            </TR>
        </TABLE>
    </TD>
</TR>
<TR>
    <TD bgcolor=""#{10}"">{20}D{21}</TD>
    <TD>
        <TABLE border=""0"" cellborder=""0"">
            <TR>
                <TD align=""left""><IMG SRC=""{11}_icon.png""/></TD>
                <TD align=""left"">{12}</TD>
            </TR>
        </TABLE>
    </TD>
</TR>
</TABLE>
>",
                    claimNamesToDisplayNames[resource.Name],
                    GetActionColor(effectiveCreatePermissions), effectiveCreatePermissions.AuthorizationStrategy,
                    GetAuthorizationStrategyText(effectiveCreatePermissions),
                    GetActionColor(effectiveReadPermissions), effectiveReadPermissions.AuthorizationStrategy,
                    GetAuthorizationStrategyText(effectiveReadPermissions),
                    GetActionColor(effectiveUpdatePermissions), effectiveUpdatePermissions.AuthorizationStrategy,
                    GetAuthorizationStrategyText(effectiveUpdatePermissions),
                    GetActionColor(effectiveDeletePermissions), effectiveDeletePermissions.AuthorizationStrategy,
                    GetAuthorizationStrategyText(effectiveDeletePermissions),
                    Colors.Header,
                    EmphasizeExplicitStart(effectiveCreatePermissions),
                    EmphasizeExplicitStop(effectiveCreatePermissions),
                    EmphasizeExplicitStart(effectiveReadPermissions),
                    EmphasizeExplicitStop(effectiveReadPermissions),
                    EmphasizeExplicitStart(effectiveUpdatePermissions),
                    EmphasizeExplicitStop(effectiveUpdatePermissions),
                    EmphasizeExplicitStart(effectiveDeletePermissions),
                    EmphasizeExplicitStop(effectiveDeletePermissions));
            }

            f.Label = htmlLabel;
            f.Shape = GraphvizVertexShape.Plaintext;
        }

        private static string EmphasizeExplicitStart(EffectiveActionAndStrategy effectiveActionAndStrategy)
        {
            return !effectiveActionAndStrategy.ActionInherited
                ? @"<B>"
                : string.Empty;
        }

        private static string EmphasizeExplicitStop(EffectiveActionAndStrategy effectiveActionAndStrategy)
        {
            return !effectiveActionAndStrategy.ActionInherited
                ? "</B>"
                : string.Empty;
        }

        private static string GetAuthorizationStrategyText(EffectiveActionAndStrategy effectiveActionAndStrategy)
        {
            // If there is no authorization strategy in effect, just return an empty string
            if (string.IsNullOrEmpty(effectiveActionAndStrategy.AuthorizationStrategy))
            {
                return string.Empty;
            }

            //bool authStrategyLocalAndClaimSetSpecific =
            //!effectiveActionAndStrategy.AuthorizationStrategyInherited
            //&& !effectiveActionAndStrategy.AuthorizationStrategyIsDefault;

            var sb = new StringBuilder();

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
            sb.Append(effectiveActionAndStrategy.AuthorizationStrategy);

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

            // Look for overrides
            if (effectiveActionAndStrategy.OverriddenClaimSetAuthorizationStrategy != null)
            {
                // Overrides are displayed in red, strikethrough font (Claim Set overrides are bold-faced too)
                sb.Append(@"<BR/><font color=""#FF0000""><s><b>");

                if (effectiveActionAndStrategy.OverriddenClaimSetAuthorizationStrategyInherited)
                {
                    sb.Append(@"<i>");
                }

                sb.Append(effectiveActionAndStrategy.OverriddenClaimSetAuthorizationStrategy);

                if (effectiveActionAndStrategy.OverriddenClaimSetAuthorizationStrategyInherited)
                {
                    // Add on originating resource name for the inherited overrides
                    sb.Append(@" (" + claimNamesToDisplayNames[effectiveActionAndStrategy.OverriddenClaimSetAuthorizationStrategyOriginatingClaimName] + ")");
                    sb.Append(@"</i>");
                }

                sb.Append(@"</b></s></font>");
            }

            if (effectiveActionAndStrategy.OverriddenDefaultAuthorizationStrategy != null)
            {
                // Overrides are displayed in red, strikethrough font
                sb.Append(@"<BR/><font color=""#FF0000""><s>");

                if (effectiveActionAndStrategy.OverriddenDefaultAuthorizationStrategyInherited)
                {
                    sb.Append(@"<i>");
                }

                sb.Append(effectiveActionAndStrategy.OverriddenDefaultAuthorizationStrategy);

                if (effectiveActionAndStrategy.OverriddenDefaultAuthorizationStrategyInherited)
                {
                    // Add on originating resource name for the inherited overrides
                    sb.Append(@" (" + claimNamesToDisplayNames[effectiveActionAndStrategy.OverriddenDefaultAuthorizationStrategyOriginatingClaimName] + ")");
                    sb.Append(@"</i>");
                }

                sb.Append(@"</s></font>");
            }

            return sb.ToString();
        }

        private static EffectiveActionAndStrategy GetEffectiveActionPermissions(
            Resource resource, string actionName, string claimSetName)
        {
            var effectiveActionAndStrategy = new EffectiveActionAndStrategy(resource.Name, actionName);

            // Step 1: Process default metadata, top to bottom (least to most in terms of priority)

            // Process ancestors first, top to bottom
            var inheritedDefaultActionAndStrategyPairs =
                (from r in resource.Ancestors
                 let pair = r.ActionAndStrategyPairs.SingleOrDefault(x => x.ActionName == actionName)
                 where pair != null
                 select new
                 {
                     OriginatingClaimName = r.Name,
                     ActionAndStrategy = pair
                 })
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

            var localActionAndStrategy = resource
                                        .ActionAndStrategyPairs
                                        .SingleOrDefault(x => x.ActionName == actionName)
                                         ?? ActionAndStrategy.Empty;

            effectiveActionAndStrategy.TrySetAuthorizationStrategy(
                localActionAndStrategy.AuthorizationStrategy,
                resource.Name,
                inherited: false,
                isDefault: true);

            // Step 2: Process from bottom to top (least to most in terms of priority)

            // Are there any explicit settings on the resource for the current actiona and claim set?
            ActionAndStrategy explicitActionAndStrategyForAction;

            if (localActionAndStrategy.ExplicitActionAndStrategyByClaimSetName.TryGetValue(
                claimSetName,
                out explicitActionAndStrategyForAction))
            {
                // There was a claim set specific setting on the current resource
                effectiveActionAndStrategy.TrySetActionGranted(inherited: false);

                effectiveActionAndStrategy.TrySetAuthorizationStrategy(
                    explicitActionAndStrategyForAction.AuthorizationStrategy,
                    resource.Name,
                    inherited: false,
                    isDefault: false);
            }

            // Now look for explicit claim set overrides up the resource claim lineage
            var claimsetOverridePermissions =
                (from r in resource.Ancestors
                 let pair = r.ActionAndStrategyPairs.SingleOrDefault(x => x.ActionName == actionName)
                 let claimsetPair = GetClaimSetSpecificActionAndStrategy(pair, claimSetName)
                 where claimsetPair != null
                 select new
                 {
                     OriginatingClaimName = r.Name,
                     ActionAndStrategy = claimsetPair
                 })
               .ToList();

            foreach (var pair in claimsetOverridePermissions)
            {
                effectiveActionAndStrategy.TrySetActionGranted(inherited: true);

                effectiveActionAndStrategy.TrySetAuthorizationStrategy(
                    pair.ActionAndStrategy.AuthorizationStrategy,
                    pair.OriginatingClaimName,
                    inherited: true,
                    isDefault: false);
            }

            return effectiveActionAndStrategy;
        }

        private static ActionAndStrategy GetClaimSetSpecificActionAndStrategy(ActionAndStrategy pair, string claimSetName)
        {
            if (pair == null)
            {
                return null;
            }

            if (!pair.ExplicitActionAndStrategyByClaimSetName.ContainsKey(claimSetName))
            {
                return null;
            }

            return pair.ExplicitActionAndStrategyByClaimSetName[claimSetName];
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

        private static void DownloadGraphviz(string destinationDirectoryName)
        {
            var tempZipPath = Path.Combine(AppContext.BaseDirectory, "temp_graphviz.zip");
            var tempDirPath = Path.Combine(AppContext.BaseDirectory, "temp_graphviz");

            using var webClient = new WebClient();
            webClient.DownloadFile(
                new Uri(
                    "https://gitlab.com/api/v4/projects/4207231/packages/generic/graphviz-releases/2.48.0/stable_windows_10_msbuild_Release_Win32_graphviz-2.48.0-win32.zip"),
                tempZipPath
            );

            ZipFile.ExtractToDirectory(tempZipPath, tempDirPath);
            Directory.Move(Path.Combine(tempDirPath, @"Graphviz"), destinationDirectoryName);

            File.Delete(tempZipPath);
            Directory.Delete(tempDirPath);
        }
    }
}
