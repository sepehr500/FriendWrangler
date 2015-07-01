using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendWrangler.Core.Models
{
    public sealed class FacebookInvitation : Invitation
    {
        // all the stuff you need to send a FB invitation
        
        public override Task Send()
        {
            throw new NotImplementedException();
        }
    }
}
