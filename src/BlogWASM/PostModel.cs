namespace BlogWASM;

public class PostModel
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public DateTime Created { get; set; } = DateTime.MinValue;
    public DateTime LastUpdated { get; set; } = DateTime.MinValue;
    public List<string> Tags { get; set; } = [];
    public string MarkdownContent { get; private set; } = string.Empty;
    public string HtmlContent { get; private set; } = string.Empty;
}
