namespace DotNetBatch14KKK.RestApi2.Feature2.AdoDotNetExamples2
{
    public class BlogModel2
    {
        public string ? BlogId {  get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogContent { get; set; }
        public string? BlogAuthor { get; set; }
    }

    public class BlogResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
