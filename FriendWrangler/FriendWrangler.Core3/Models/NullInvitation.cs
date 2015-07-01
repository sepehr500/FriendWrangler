using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendWrangler.Core.Models
{
    public sealed class NullInvitation : Invitation
    {

        public override Task Send()
        {
            throw new NotImplementedException();
        }
    }
}
