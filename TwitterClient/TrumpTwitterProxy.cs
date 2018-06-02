using System.Collections.Generic;
using TrumpsTwitterService;

namespace TwitterClient
{
    internal class TrumpTwitterProxy : ITrumpsTwitterService
    {
        private ITrumpsTwitterService _service;
        private IRuntimeContext _context;

        public TrumpTwitterProxy(IRuntimeContext context)
        {
            _service = TrumpsTwitterService.TrumpsTwitterService.GetInstance();
            _context = context;
        }

     
        public List<ITweet> GetTrumpsTweets()
        {
            List<ITweet> rawTweets = SimpleTwitterCache.GetInstance(_service, _context).GetTweets();

            List<ITweet> filteredTweets = new List<ITweet>();
         
            if (!_context.AdultMessagesAllowed)
            {
                filteredTweets = rawTweets.FindAll(t => t.Classification != TweetClassification.sexualHarrasment);
            }
            else
            {
                filteredTweets = rawTweets;
            }
            return filteredTweets;
        }
    }
}
