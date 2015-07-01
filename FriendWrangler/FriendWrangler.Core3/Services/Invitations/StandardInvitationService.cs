using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendWrangler.Core.Services.Invitations
{
    class StandardInvitationService : IInvitationService
    {
        public Task SendInvitations(Models.Invitation invitation, IList<Models.Friend> friends)
        {
            throw new NotImplementedException();
        }

        public Task ReceiveInvitations()
        {
            throw new NotImplementedException();
        }
    }
}
