namespace DotnetBackend.DTOs;
public class GoogleBooksApiResponse
{
    public List<GoogleBooksApiItem> Items { get; set; }
}

public class GoogleBooksApiItem
{
    public VolumeInfo VolumeInfo { get; set; }
}

public class VolumeInfo
{
    public string? Title { get; set; }
    public List<string?> Authors { get; set; }
    public string? Publisher { get; set; }
    public string? PublishedDate { get; set; }
    public string? Description { get; set; }
    public int PageCount { get; set; }
    public ImageLinks ImageLinks { get; set; }
    public string? PreviewLink { get; set; }
    public string? InfoLink { get; set; }
}

public class ImageLinks
{
    public string? SmallThumbnail { get; set; }
    public string? Thumbnail { get; set; }
}