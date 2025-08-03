using Markdig;
using Markdig.Extensions.Yaml;
using Markdig.Syntax;
using Microsoft.Build.Framework;
using System.Text.Json;
using YamlDotNet.Serialization;

namespace BlogWASM.PostIndexGenerator;

public class PostIndexGenerate : Microsoft.Build.Utilities.Task
{
    private static readonly JsonSerializerOptions _jsonSerializerOptions = 
        new JsonSerializerOptions { WriteIndented = true };

    [System.ComponentModel.DataAnnotations.Required]
    public string PostsDirectory { get; set; } = null!;

    public string OutputFilePath { get; set; } = string.Empty;

    public override bool Execute()
    {
        try
        {
            var index = new List<Dictionary<string, object>>();
            var postFiles = Directory.GetFiles(PostsDirectory, "*.md", SearchOption.AllDirectories);

            foreach (var file in postFiles)
            {
                var content = File.ReadAllText(file);
                var pipeline = new MarkdownPipelineBuilder().UseYamlFrontMatter().Build();
                var document = Markdown.Parse(content, pipeline);

                var yamlBlock = document.Descendants<YamlFrontMatterBlock>().FirstOrDefault();

                var metadata = new Dictionary<string, object>
                {
                    ["file"] = Path.GetRelativePath(PostsDirectory, file).Replace("\\", "/")
                };

                if (yamlBlock != null)
                {
                    var lines = content.Split('\n').Skip(1).TakeWhile(l => !l.StartsWith("---")).ToArray();
                    var yamlText = string.Join("\n", lines);

                    var deserializer = new Deserializer();
                    var yamlData = deserializer.Deserialize<Dictionary<string, object>>(new StringReader(yamlText));

                    foreach (var pair in yamlData)
                        metadata[pair.Key.ToLower()] = pair.Value;
                }

                index.Add(metadata);
            }

            if(string.IsNullOrEmpty(OutputFilePath))
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
