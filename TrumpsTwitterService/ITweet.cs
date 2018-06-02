using System;
using System.Collections.Generic;

namespace TrumpsTwitterService
{
    public interface ITweet
    {
        string Author { get; set; }
        TweetClassification Classification { get; set; }
        DateTime Date { get; set; }
        string Message { get; set; }
    }
}