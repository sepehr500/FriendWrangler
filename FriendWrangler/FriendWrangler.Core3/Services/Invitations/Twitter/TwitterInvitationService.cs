using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendWrangler.Core.Models;

namespace FriendWrangler.Core.Services.Invitations.Twitter
{
    public class TwitterInvitationService : IInvitationService
    {
        private List<Invitation> invitations; 
       
        public Task SendInvitations(Models.Invitation invitation, IList<Friend> friends)
        {
            if (invitation == null)
            {
                throw new Exception("Null invitation.");
            }
            if (friends == null)
            {
                throw new Exception("Null friend's list.");
            }
            if (friends.Count == 0)
            {
                throw new Exception("No friends selected.");
            }

            try
            {


            }

            finally
            {

            }

            return null;
        }
    }
}
