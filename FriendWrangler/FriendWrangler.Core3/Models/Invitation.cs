using FriendWrangler.Core.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FriendWrangler.Core.Enumerations;
using Newtonsoft.Json;

namespace FriendWrangler.Core.Models
{
    public abstract class Invitation
    {
        #region Events
        public delegate void InvitationStatusChanged(object source, EventArgs eventArgs);
        public event InvitationStatusChanged invitationStatusChanged;
        #endregion

        #region Constructors

        protected Invitation()
        {
            _timer = new Timer(0);
            Status = InvitationStatus.NotYetSent;
        }

        protected Invitation(Friend friend)
        {
            Status = InvitationStatus.NotYetSent;
            Friend = friend;
            _timer = new Timer(0);
        }

        #endregion

        #region Properties


        public int Id { get; set; }
        public Event Event { get; set; }
        public string Message { get; set; }
        public InvitationStatus Status { get; set; }

        public Friend Friend { get; set; }
        #endregion

        #region Fields

        readonly Timer _timer; 
        
        #endregion

        #region Methods
       

            

        

            /// <summary>
            /// Starts the timer
            /// </summary>
            public async void StartTimer(string message)
            {
            Status = InvitationStatus.Sent;
                await _timer.Start();
            }

            //Needs be be triggered by an external source
            //Each invitiation needs to subscrib to a delegate in its fiend class. Then the friend class will trigger the OnMessageReceived. This is because receiving messages changes based on the implementation.(facebook , google , text ect) 
            //When changes the status based on the analyzed sentiment then triggers status changed
            protected virtual void OnMessageReceived(string message)
            {
                _timer.Stop();
            InvitationAnalyzer analyzer = new InvitationAnalyzer(message);
            var sentiment = analyzer.Sentiment;
            switch (sentiment)
                {
                case MessageSentiment.Yes:
                    Status = InvitationStatus.Yes;
                        break;
                case MessageSentiment.No:
                    Status = InvitationStatus.No;
                        break;
                case MessageSentiment.Unknown:
                    Status = InvitationStatus.Unknown;
                        break;
                }
                if (invitationStatusChanged != null)
                {
                    invitationStatusChanged(Status, EventArgs.Empty);
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
            Status = InvitationStatus.NoResponse;
                if (invitationStatusChanged != null)
                {
                    invitationStatusChanged(Status, EventArgs.Empty);
                }
            }
        #endregion

        #region AbstractMethods
        
        public abstract Task Send();
            
        #endregion
       
    }




}
