using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClient;

namespace TrumpTwitterProxy
{
    class Program
    {
       
        static void Main(string[] args)
        {
            IRuntimeContext context = ReadRuntimeContext();

            new TwitterClient.TwitterClient(context).DisplayTrumpTweets();
        }

        private static IRuntimeContext ReadRuntimeContext()
        {
            IRuntimeContext context = new RuntimeContext();
            context.AdultMessagesAllowed = (ReadSetting("AdultFilterOn").ToLower() != "true");
            context.CacheExpiration = Int32.Parse(ReadSetting("CacheExpiration"));
            return context;
        }

        private static string ReadSetting(string key)
        {
            string result = "";
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings[key] ?? "Not Found";
            }
            catch (ConfigurationErrorsException)
                {
            Console.WriteLine("Error reading app settings");
               }
            return result;
        }
    }
}
