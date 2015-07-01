using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendWrangler.Core.Enumerations;
using FriendWrangler.Core.Models;

namespace FriendWrangler.Core.Services.Invitations
{
    class StandardInvitationService : IInvitationService
    {
        public int Limit { get; set; }
        public List<Invitation> AcceptedInvitations { get; set; }
        private int PendingInvitations { get; set; }

        public StandardInvitationService()
        {
            AcceptedInvitations = new List<Invitation>();
            PendingInvitations = 0;
        }

        public async Task SendInvitations(Models.Invitation invitation, IList<Models.Friend> friends, int limit = 0)
        {
            Limit = limit;

            foreach (var friend in friends)
            {
                var friendInvitation = invitation.Clone(friend);
                friendInvitation.invitationStatusChanged += InvitationOnInvitationStatusChanged;

            top:
                if (PendingInvitations == Limit)
                {
                    await Task.Delay(5000);
                    goto top;
                }
                friend.SendInvitation(friendInvitation);
                PendingInvitations += 1;

                if (AcceptedInvitations.Count() == Limit) break;
            }
        }

        public void InvitationOnInvitationStatusChanged(Invitation invitation, EventArgs eventArgs)
        {
            if (invitation.Status == InvitationStatus.Yes)
                AcceptedInvitations.Add(invitation);
            else ; // TODO
        }
      
    }
}
