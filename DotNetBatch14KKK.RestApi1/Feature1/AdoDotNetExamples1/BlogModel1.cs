namespace DotNetBatch14KKK.RestApi1.Feature1.AdoDotNetExamples1
{
    public class BlogModel1
    {
        public string? BlogId {  get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogAuthor { get; set; }
        public string? BlogContent { get; set; }

    }

    public class BlogResponse1
    { public bool? IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
