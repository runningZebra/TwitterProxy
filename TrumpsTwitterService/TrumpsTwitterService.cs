using System;
using System.Collections.Generic;
using System.Linq;

namespace TrumpsTwitterService
{
    public class TrumpsTwitterService : ITrumpsTwitterService
    {
        private static TrumpsTwitterService instance = null;
        private List<ITweet> _TrumpTweets { get; set; } = new List<ITweet>();
        private List<ITweet> _AllTrumpTweets { get; set; } = new List<ITweet>();
        private int pointer = 0;
        private ITweet _actualTweet = new Tweet();

        private TrumpsTwitterService()
        {
            LoadAllTweets();
        }

        public static ITrumpsTwitterService GetInstance()
        {
            if (instance == null)
            {
                instance = new TrumpsTwitterService();
            }

            return instance;
        }


        public List<ITweet> GetTrumpsTweets()
        {
            FireNewTweet();
            return _TrumpTweets;
        }

        private void FireNewTweet()
        {
            if (pointer < _AllTrumpTweets.Count())
            {
                ITweet actualTweed = _AllTrumpTweets[pointer];
                actualTweed.Date = DateTime.Now;
                _TrumpTweets.Add(actualTweed);
                pointer++;
            }
        }
        
        private void LoadAllTweets()
        {
            _AllTrumpTweets.Add(new Tweet()
            {
                Message = "Belgien ist eine wunderschöne Stadt und ein herrlicher Ort - großartige Gebäude. Ich war mal dort, vor vielen, vielen Jahren.",
                Classification = TweetClassification.stupid
            });

            _AllTrumpTweets.Add(new Tweet()
            {
                Message = "Ich glaube, sich zu entschuldigen ist eine großartige Sache, aber du must etwas falsch gemacht haben." +
              "Ich werde mich irgendwann in entfernter Zukunft auch entschuldigen. Wenn ich jemals etwas falsch mache.",
                Classification = TweetClassification.embarrasing
            });

            _AllTrumpTweets.Add(new Tweet()
            {
                Message = "Sie ist sehr gut in Form (zu Brigitte Macron während des letzten Staatsbesuchs)" ,
                Classification = TweetClassification.sexualHarrasment
            });

            _AllTrumpTweets.Add(new Tweet()
            {
                Message = "Sie hat soviele Kerle gehabt, dass sogar ich dagegen alt aussehe (über Angelina Jolie)",
                Classification = TweetClassification.sexualHarrasment
            });

          

            _AllTrumpTweets.Add(new Tweet()
            {
                Message = "Wenn Ivanka nicht meine Tochter wäre, würde ich sie wahrscheinlich daten",
                Classification = TweetClassification.embarrasing
            });
            _AllTrumpTweets.Add(new Tweet()
            {
                Message = "Obama ist der Gründer des IS",
                Classification = TweetClassification.stupid
            });
            _AllTrumpTweets.Add(new Tweet()
            {
                Message = "Die Globale Erwärmung wurde von und für die Chinesen erfunden, um die US-Produktion wettbewerbsunfähig zu machen.",
                Classification = TweetClassification.stupid
            });

        }
    }

}
