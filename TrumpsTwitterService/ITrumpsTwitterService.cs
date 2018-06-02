using System.Collections.Generic;

namespace TrumpsTwitterService
{
    public interface ITrumpsTwitterService
    {
        List<ITweet> GetTrumpsTweets();
    }
}