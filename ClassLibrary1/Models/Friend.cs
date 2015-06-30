using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendWrangler.Core.Classes;

namespace FriendWrangler.Core.Models
{
    /// <summary>
    /// Constains the status of the message
    /// </summary>
    enum Status
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
    enum Answer
    {
        Yes,
        No,
        Unknown
    }


    abstract class Friend
    {
        public delegate void StatusChangedEventHandler(object source, EventArgs eventArgs);

        public event StatusChangedEventHandler StatusChanged;

        protected Friend()
        {
            Status = Status.NotYetSent;
        }

        public Timer Timer;

        public Status Status;


        /// <summary>
        /// Starts the timer
        /// </summary>
        public async void StartTimer()
        {
            Status = Status.Sent;
           await this.Timer.Start();
            SendMessage();
        }
        //Needs be be triggered by an external source
        //When changes the status based on the analized sentiment then triggers status changed
        protected virtual void OnMessageReceived(string message)
        {
            Timer.Stop();
            var answer = AnalyzeSentiment(message);
            switch (answer)
            {
                case Answer.Yes:
                    Status = Status.Yes;
                    break;
                case Answer.No:
                    Status = Status.No;
                    break;
                case Answer.Unknown:
                    Status = Status.Unknown;
                    break;
            }
            if (StatusChanged != null)
            {
                StatusChanged(this.Status, EventArgs.Empty);
            }
            
        } 
        

        /// <summary>
        /// Sets the timeout for the timer
        /// </summary>
        /// <param name="time"></param>
        public void SetTimeout(int time)
        {
            this.Timer.WaitTime = time;
        }

        //Takes proper steps when timer elapses
        protected virtual void OnTimerElapsed()
        {
            Timer.Stop();
            Status = Status.NoResponse;
            if (StatusChanged != null)
            {
                StatusChanged(this.Status , EventArgs.Empty);
            }
        }



        
        


        /// <summary>
        /// Sends the message
        /// </summary>
        public abstract void SendMessage();
        /// <summary>
        /// Analyzes the sentiment
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public abstract Answer AnalyzeSentiment(string x);

    }
}
