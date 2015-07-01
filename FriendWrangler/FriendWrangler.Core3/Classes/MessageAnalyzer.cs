using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FriendWrangler.Core.Enumerations;
using FriendWrangler.Core.Models;
using Newtonsoft.Json;

namespace FriendWrangler.Core.Classes
{
    class MessageAnalyzer
    {
        
        private MessageAnalyzer() {}
        public string Message { get; set; }
        public MessageAnalyzer(string message)
        {
            Message = message;
        }

       
    }
}
