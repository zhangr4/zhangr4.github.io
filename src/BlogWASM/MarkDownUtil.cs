using Markdig;
using Markdig.Extensions.Yaml;
using Markdig.Syntax;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace BlogWASM;

public static class MarkDownUtil
{
    public static (Dictionary<string, object>? metadata, string html) ToHtml(
        string markdownTxt,
        MarkdownPipeline pipeline
    )
    {
        if (string.IsNullOrWhiteSpace(markdownTxt))
        {
            return (null, string.Empty);
        }

        TryParseYaml(markdownTxt, pipeline, out var metadata);

        // Parse the markdown to HTML using the provided pipeline
        return (metadata, Markdown.ToHtml(markdownTxt, pipeline));
    }

    public static bool TryParseYaml(
        string markdownTxt,
        MarkdownPipeline pipeline,
        out Dictionary<string, object>? result
    )
    {
        try
        {
            // parse yml front matter if needed
            var document = Markdown.Parse(markdownTxt, pipeline);

            // extract the front matter from markdown document
            var yamlBlock = document.Descendants<YamlFrontMatterBlock>().FirstOrDefault();

            var yaml = yamlBlock?.Lines.ToString();

            // deserialize the yaml block into a custom type
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            result = deserializer.Deserialize<Dictionary<string, object>?>(yaml);
        }
        catch (Exception)
        {
            // Handle any exceptions that occur during parsing
            // For example, log the error or return a default value
            result = null;
        }

        return result is not null;
    }
}
