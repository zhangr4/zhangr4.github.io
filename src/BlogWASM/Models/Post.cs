namespace BlogWASM.Models;

public class Post
{
    /// <summary>
    /// Post title, should read from yaml block of raw post .md file
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Post author, should read from yaml block of raw post .md file
    /// </summary>
    public string Author { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public DateTime Created { get; set; } = DateTime.MinValue;
    public DateTime LastUpdated { get; set; } = DateTime.MinValue;
    public List<string> Tags { get; set; } = [];
    public string MarkdownContent { get; private set; } = string.Empty;
    public string HtmlContent { get; private set; } = string.Empty;
}
