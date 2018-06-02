using System;
using System.Configuration;
using System.Collections.Generic;
using TrumpsTwitterService;
using System.Threading;


namespace TwitterClient
{
    public class TwitterClient
    {
        private ITrumpsTwitterService _service;
        private IRuntimeContext _context;

        public TwitterClient(IRuntimeContext context) 
        {
            _context = context;
            _service = new TrumpTwitterProxy(_context);
        }

        public void DisplayTrumpTweets()
        {

            do
            {
                Console.WriteLine("TweetMessages of THEDONALD at " + DateTime.Now.ToShortTimeString() + " AdultFilter : " + (_context.AdultMessagesAllowed?"Aus":"An"));
                Console.WriteLine("-------------------------------------------------------------");
                DisplayCurrentTweets();
                Console.ReadLine();
            } while (true);
            
        }

        public void DisplayCurrentTweets()
        {
            List<ITweet> tweets = _service.GetTrumpsTweets();
            
            foreach(ITweet tweet in tweets)
            {
                Console.WriteLine("-> " + tweet.Message + "  //  Classification: " + tweet.Classification);
            }
           
        }

     
    }
}
