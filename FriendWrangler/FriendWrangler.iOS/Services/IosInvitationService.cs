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

        public System.Threading.Tasks.Task SendInvitations(Core.Models.Invitation invitation, IList<Core.Models.Friend> friends)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task ReceiveInvitations()
        {
            throw new NotImplementedException();
        }
    }
}