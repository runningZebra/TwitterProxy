namespace TwitterClient
{
    public interface IRuntimeContext
    {
        bool AdultMessagesAllowed { get; set; }
        int CacheExpiration { get; set; }
    }
}