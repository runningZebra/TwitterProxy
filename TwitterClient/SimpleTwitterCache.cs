using System;
using System.Collections.Generic;
using System.Text;
using TrumpsTwitterService;

namespace TwitterClient
{
    internal class SimpleTwitterCache
    {
        private static SimpleTwitterCache instance = null;

        private ITrumpsTwitterService _service;
        private TimeSpan _cacheExpiration = new TimeSpan(0, 0, 0);
        private List<ITweet> _tweetsCached = new List<ITweet>();
        private DateTime _lastUpdate;

        private SimpleTwitterCache(ITrumpsTwitterService service, IRuntimeContext context)
        {
            _service = service;
            _cacheExpiration = new TimeSpan(0, 0, context.CacheExpiration);
        }

        internal static SimpleTwitterCache GetInstance(ITrumpsTwitterService service, IRuntimeContext context)
        {
            if (instance == null)
            {
                instance = new SimpleTwitterCache(service, context);
            }

            return instance;
        }

        internal List<ITweet> GetTweets()
        {

            bool cacheIsExpired = (DateTime.Now.Subtract(_lastUpdate)) > _cacheExpiration;
            if (cacheIsExpired)
            {
                _tweetsCached = _service.GetTrumpsTweets();
                _lastUpdate = DateTime.Now;
            }

            return _tweetsCached;
        }
    }
}
