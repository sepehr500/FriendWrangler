using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendWrangler.Core.Models;

namespace FriendWrangler.Core.Services.Facebook
{
    public class FacebookInvitationService
    {

        List<Invitation> _invitations;
        Invitation _initialInvitation;
        List<Friend> _friends;

        public async Task SendInvitations()
        {
            if (_initialInvitation == null)
            {
                throw new Exception("Null invitation.");
            }
            if (_friends == null)
            {
                throw new Exception("Null friend's list.");
            }
            if (_friends.Count == 0)
            {
                throw new Exception("No friends selected.");
            }

            try
            {


            }

            finally
            {

            }

        }
    }
}
