namespace NetDevPL.Features.Facebook
{
    public class FacebookLike
    {
        public string UserId { get; set; }
        public string PostId { get; set; }
    }

    public class FacebookComment
    {
        public string UserId { get; set; }
        public string PostId { get; set; }
        public string Message { get; set; }
    }
}