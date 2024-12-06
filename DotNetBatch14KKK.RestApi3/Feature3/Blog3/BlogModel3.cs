namespace DotNetBatch14KKK.RestApi3.Feature3.Blog3
{
    public class BlogModel3
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

