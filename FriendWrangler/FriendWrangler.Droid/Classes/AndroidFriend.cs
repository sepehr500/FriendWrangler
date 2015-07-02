using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Telephony;
using Android.Views;
using Android.Widget;
using FriendWrangler.Core.Models;

namespace FriendWrangler.Droid.Classes
{
    class AndroidFriend : Friend 
    {
        public string PhoneNumber { get; set; }

        private string TextMessage { get; set; }
        public override void SendInvitation(string message)
        { 
            SmsManager.Default.SendTextMessage(PhoneNumber , null , message , null ,null);
        }

        public override string ReceiveMessages()
        {
            TextMessage = null;
            var receiver = new SMSBroadcastReceiver();
            receiver.Received += SetProp;
            while (TextMessage == null)
            {

            }
            return TextMessage;
        }

      

        public void SetProp(string message , string number)
        {
            if (number == PhoneNumber)
            {
                TextMessage = message;
            }
            
        }


    }
}