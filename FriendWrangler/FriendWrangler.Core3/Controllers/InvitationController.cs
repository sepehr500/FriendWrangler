using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendWrangler.Core.Models
{
    public class InvitationController
    {
        #region Fields

        List<Invitation> _invitations;
        Invitation _initialInvitation;
        List<Friend> _friends;

        #endregion

        #region Constructors

        private InvitationController()
        {

        }

        public InvitationController(Invitation invitation, List<Friend> _friends)
        {
            _initialInvitation = invitation;
        }

        #endregion

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
            if ( _friends.Count == 0)
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
