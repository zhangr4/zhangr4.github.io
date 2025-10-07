using System.Text.Json;
using Markdig;
using Markdig.Extensions.Yaml;
using Markdig.Syntax;
using Microsoft.Build.Framework;

namespace BlogWASM.MSBuild.Tasks;

/// <summary>
/// It is a MSBuild task to generate a JSON index of blog posts from markdown files with YAML front matter.
/// </summary>
public class PostIndexGenerator : Microsoft.Build.Utilities.Task
{
    private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Directory containing markdown blog posts.
    /// </summary>
    [System.ComponentModel.DataAnnotations.Required]
    public string PostsDirectory { get; set; } = null!;

    /// <summary>
    /// Output file path for the generated JSON index.
    /// </summary>
    public string OutputFilePath { get; set; } = string.Empty;

    /// <summary>
    /// Executes the task to generate the post index.
    /// </summary>
    /// <returns></returns>
    public override bool Execute()
    {
        try
        {
            var index = new List<Dictionary<string, object>>();

            // Get all markdown files in post directory recursively.
            var postFiles = Directory.GetFiles(PostsDirectory, "*.md", SearchOption.AllDirectories);

            foreach (var file in postFiles)
            {
                var content = File.ReadAllText(file);
                var pipeline = new MarkdownPipelineBuilder().UseYamlFrontMatter().Build();
                var document = Markdown.Parse(content, pipeline);

                // Extract YAML front matter block.
                var yamlBlock = document.Descendants<YamlFrontMatterBlock>().FirstOrDefault();

                // Prepare metadata dictionary. TODO: not understand this line
                var metadata = new Dictionary<string, object>
                {
                    ["file"] = Path.GetRelativePath(PostsDirectory, file).Replace("\\", "/"), // get file name from relative path
                };

                if (yamlBlock != null)
                {
                    var lines = content
                        .Split(Environment.NewLine)
                        .Skip(1)
                        .TakeWhile(l => !l.StartsWith("---")) // Skip the starting '---' and take until the ending '---'
                        .ToArray();
                    var yamlText = string.Join(Environment.NewLine, lines);

                    var deserializer = new YamlDotNet.Serialization.Deserializer();
                    var yamlData = deserializer.Deserialize<Dictionary<string, object>>(
                        new StringReader(yamlText)
                    );

                    foreach (var pair in yamlData)
                        metadata[pair.Key.ToLower()] = pair.Value;
                }

                index.Add(metadata);
            }

            // use index.json as default output file name if not specified.
            if (string.IsNullOrEmpty(OutputFilePath))
            {
                OutputFilePath = Path.Combine(PostsDirectory, "index.json");
            }

            var json = JsonSerializer.Serialize(index, _jsonSerializerOptions);
            File.WriteAllText(OutputFilePath, json);

            Log.LogMessage(MessageImportance.High, $"Post index written to: {OutputFilePath}");

            return true;
        }
        catch (Exception ex)
        {
            Log.LogErrorFromException(ex);
            return false;
        }
    }
}
