using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public MessageSentiment Sentiment
        {
            get
            {
                //var client = new HttpClient {BaseAddress = new Uri("http://text-processing.com")};
                //var content = new FormUrlEncodedContent(new[] 
                //{
                //    new KeyValuePair<string, string>("text", Message)
                //});
                //var result = client.PostAsync("/api/sentiment/", content).Result;
                //var resultContent = result.Content.ReadAsStringAsync().Result;
                //var sentiment = JsonConvert.DeserializeObject<Sentiment>(resultContent);

                //switch (sentiment.Label)
                //{
                //    case "pos":
                //        return MessageSentiment.Yes;
                //    case "neg":
                //        return MessageSentiment.No;
                //    default:
                //        return MessageSentiment.Unknown;
                //}
                return MessageSentiment.Yes;
                
            }
        }          
    }
}
