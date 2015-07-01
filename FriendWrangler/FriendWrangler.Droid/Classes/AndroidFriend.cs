using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FriendWrangler.Core.Models;

namespace FriendWrangler.Droid.Classes
{
    class AndroidFriend : Friend
    {
        public override void SendInvitation(string message)
        {
            throw new NotImplementedException();
        }

        public override string ReceiveMessages()
        {
            throw new NotImplementedException();
        }
    }
}