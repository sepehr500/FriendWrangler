﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendWrangler.Core.Models;

namespace FriendWrangler.Core.Services.Invitations
{
    public interface IInvitationService
    {
        Task SendInvitations(Invitation invitation, IList<Friend> friends );
        Task ReceiveInvitations();
    }
}
