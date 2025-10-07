using System;

namespace BlogWASM.Models;

/// <summary>
/// Metadata for a blog post. Should map to yml block of origin markdown file
/// </summary>
public class PostMetadata
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string[] Tags { get; set; } = [];
    public DateTime CreatedAt { get; set; } = DateTime.MinValue;
    public DateTime UpdatedAt { get; set; } = DateTime.MinValue;
}
