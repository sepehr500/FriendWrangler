using System;
using System.Collections.Generic;
using System.Net.Http;
using FriendWrangler.Core.Enumerations;
using FriendWrangler.Core.Models;
using Newtonsoft.Json;

namespace FriendWrangler.Core.Classes
{
    public class InvitationAnalyzer
    {

        public Invitation Invitation { get; set; }
        public InvitationAnalyzer()
        {
            
        }

        public InvitationAnalyzer(Invitation invitation)
        {
            Invitation = invitation;
        }

        public InvitationAnalyzer(string message)
        {
            Invitation = new NullInvitation {Message = message};
        }

        public MessageSentiment Sentiment
        {
            get
            {
                var client = new HttpClient { BaseAddress = new Uri("http://text-processing.com") };
                var content = new FormUrlEncodedContent(new[] 
                {
                    new KeyValuePair<string, string>("text", Invitation.Message)
                });
                var result = client.PostAsync("/api/sentiment/", content).Result;
                var resultContent = result.Content.ReadAsStringAsync().Result;
                var sentiment = JsonConvert.DeserializeObject<Sentiment>(resultContent);

                switch (sentiment.Label)
                {
                    case "pos":
                        return MessageSentiment.Yes;
                    case "neg":
                        return MessageSentiment.No;
                    default:
                        return MessageSentiment.Unknown;
                }
            }
        }          
    }
}
