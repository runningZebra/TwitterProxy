using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClient
{
    public class RuntimeContext : IRuntimeContext
    {
        public int CacheExpiration { get; set; }
        public bool AdultMessagesAllowed { get; set; }
    }
}
