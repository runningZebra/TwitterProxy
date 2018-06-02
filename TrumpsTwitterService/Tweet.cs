using System;
using System.Collections.Generic;
using System.Text;

namespace TrumpsTwitterService
{
    public class Tweet : ITweet
    {
        public string Author { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public TweetClassification Classification { get; set; } 
    }

    public enum TweetClassification
    {
        smart = 0,
        stupid = 1,
        embarrasing = 2,
        sexualHarrasment = 3,
    }
}
