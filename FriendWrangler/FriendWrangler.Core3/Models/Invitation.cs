using FriendWrangler.Core.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace FriendWrangler.Core.Models
{
    public class Invitation
    {
        #region Events
        public delegate void InvitationStatusChanged(object source, EventArgs eventArgs);
        public event InvitationStatusChanged invitationStatusChanged;
        #endregion

        #region Constructors

        public Invitation()
        {
            Status = MessageStatus.NotYetSent;
        }

        #endregion

        #region Properties

        public int Id { get; set; }
        public string EventName { get; set; }
        public MessageStatus Status { get; set; }

        #endregion

        #region Fields

        Timer _timer;
        
        
        #endregion

        #region Methods
            /// <summary>
            /// Starts the timer
            /// </summary>
            public async void StartTimer()
            {
                Status = MessageStatus.Sent;
                await _timer.Start();
                SendMessage();
            }

            //Needs be be triggered by an external source
            //When changes the status based on the analyzed sentiment then triggers status changed
            protected virtual void OnMessageReceived(string message)
            {
                _timer.Stop();
                var answer = AnalyzeSentiment(message);
                switch (answer)
                {
                    case Answer.Yes:
                        Status = MessageStatus.Yes;
                        break;
                    case Answer.No:
                        Status = MessageStatus.No;
                        break;
                    case Answer.Unknown:
                        Status = MessageStatus.Unknown;
                        break;
                }
                if (invitationStatusChanged != null)
                {
                    invitationStatusChanged(this.Status, EventArgs.Empty);
                }

            }


            /// <summary>
            /// Sets the timeout for the timer
            /// </summary>
            /// <param name="time"></param>
            public void SetTimeout(int time)
            {
                _timer.WaitTime = time;
            }

            //Takes proper steps when timer elapses
            protected virtual void OnTimerElapsed()
            {
                _timer.Stop();
                Status = MessageStatus.NoResponse;
                if (invitationStatusChanged != null)
                {
                    invitationStatusChanged(this.Status, EventArgs.Empty);
                }
            }
        #endregion

        #region AbstractMethods
        /// <summary>
        /// Sends the message
        /// </summary>
        public void SendMessage() { }

        /// <summary>
        /// Analyzes the sentiment
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Answer AnalyzeSentiment(string message)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://text-processing.com");
            var content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("text", message)
            });
            var result = client.PostAsync("/api/sentiment/", content).Result;
            string resultContent = result.Content.ReadAsStringAsync().Result;
            var Sentiment = JsonConvert.DeserializeObject<Sentiment>(resultContent);

            if (Sentiment.Label == "pos")
            {
                return Answer.Yes;
            }
            if (Sentiment.Label == "neg")
            {
                return  Answer.No;
            }
            else
            {
                return Answer.Unknown;
            }

            

        }


        #endregion
       
    }

    #region Enumerations

    /// <summary>
    /// Constains the status of the message
    /// </summary>
    public enum MessageStatus
    {
        NotYetSent,
        Sent,
        Yes,
        No,
        NoResponse,
        Unknown
    }

    /// <summary>
    /// Contains the outcome of the answer
    /// </summary>
    public enum Answer
    {
        Yes,
        No,
        Unknown
    }


    #endregion
}
