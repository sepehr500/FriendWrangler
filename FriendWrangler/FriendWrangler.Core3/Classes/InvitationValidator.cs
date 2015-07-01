using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendWrangler.Core.Models
{
    public class InvitationValidator
    {
        public Invitation Invitation { get; set; }
        private InvitationValidator() { }
        public InvitationValidator(Invitation invitation)
        {
            Invitation = invitation;
        }

        public bool IsValid()
        {
            return true;
        }
    }
}
