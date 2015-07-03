using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace FriendWrangler.iOS.Services
{
    public class IosInvitationService : FriendWrangler.Core.Services.Invitations.IInvitationService
    {

 
      

        public void SendInvitations(Core.Models.Invitation invitation, IList<Core.Models.Friend> friends, int waitTime, int TargetTotalGuests, string message, int limit = 1)
        {
            throw new NotImplementedException();
        }
    }
}