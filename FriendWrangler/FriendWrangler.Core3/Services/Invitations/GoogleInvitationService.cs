using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendWrangler.Core.Models;

namespace FriendWrangler.Core.Services.Invitations
{
    public class GoogleInvitationService : IInvitationService
    {
        public Task SendInvitations(Invitation invitation, IList<Friend> friends)
        {
            return null;
        }

        public Task ReceiveInvitations()
        {
            return null;
        }
    }
}
