using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimSimiServerApp.Services
{
    public class SimSimiResponse
    {
        public string methods { get; set; }
        public List<Message> messages { get; set; }
        public string error { get; set; }
        public string donate { get; set; }
    }

    public class Message
    {
        public string ask { get; set; }
        public string text { get; set; }
        public string response { get; set; }
        public int result { get; set; }
    }
}
