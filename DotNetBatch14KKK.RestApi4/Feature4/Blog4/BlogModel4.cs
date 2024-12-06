namespace DotNetBatch14KKK.RestApi4.Feature4.Blog4
{
    public class BlogModel4
    {
        public string? BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogAuthor { get; set; }
        public string? BlogContent { get; set; }

    }

    public class BlogResponse1
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}

