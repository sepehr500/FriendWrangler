using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendWrangler.Core.Classes;
using FriendWrangler.Core.Constants;

namespace FriendWrangler.Core.Models
{
    public abstract class Friend
    {
          
        #region Properties

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public InvitationLog InvitationLog { get; set; }
        

        #endregion
#region Methods
        /// <summary>
        /// A More effective way of adding invitations to the list
        /// </summary>
        /// <param name="invitation"></param>
        public void AddInvitation(Invitation invitation)
        {
            invitation.Friend = this;
            InvitationLog.Invitations.Add(invitation);

        }

#endregion

        #region Constructors

        protected Friend()
        {

        }

        protected Friend(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        

        #endregion
        
    }
}
