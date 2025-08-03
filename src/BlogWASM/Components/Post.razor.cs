using Markdig;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace BlogWASM.Components;

public partial class Post
{
    private string _markDownHtml = string.Empty;
    private string? _title;
    private string? _description;
    private string? _author;
    private DateTime _created;
    private DateTime _lastUpdated;

    [Inject]
    public MarkdownPipeline RenderPipeline { get; set; } = default!;

    [Inject]
    public ILogger<Post> Logger { get; set; } = default!;

    /// <summary>
    /// Post file name without extension.
    /// </summary>
    [Parameter]
    public string Name { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        var path = Path.Combine("_posts", $"{Name}.md");
        var markdown = await Http.GetStringAsync(path);
        (var metadata, _markDownHtml) = MarkDownUtil.ToHtml(markdown, RenderPipeline);

        if(metadata is not null)
        {
            metadata.TryGetValue("title", out var title);
            _title = title as string;
            metadata.TryGetValue("description", out var description);
            _description = description as string;
            metadata.TryGetValue("author", out var author);
            _author = author as string;

            metadata.TryGetValue("date", out var created);
            if(created is string createdStr)
            {
                _ = DateTime.TryParse(createdStr, out _created);
            }

            metadata.TryGetValue("lastUpdated", out var lastUpdated);
            if (lastUpdated is string lastUpdatedStr)
            {
                _ = DateTime.TryParse(lastUpdatedStr, out _lastUpdated);
            }
        }

#if DEBUG
        var metadataJson = metadata is not null
            ? JsonSerializer.Serialize(metadata)
            : "null";
        Logger.LogInformation(
            "Post {Name} metadata: {@Metadata}",
            Name,
            metadataJson
        );
#endif
    }
}
