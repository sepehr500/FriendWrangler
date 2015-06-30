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
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public InvitationLog InvitationLog { get; set; }

        #endregion

        #region Constructors

        private Friend()
        {

        }

        public Friend(string firstName, string lastName) : this (
            firstName: firstName,
            lastName: lastName,
            emailAddress: FriendConstants.DEFAULT_EMAIL)
        {

        }

        public Friend(string firstName, string lastName, string emailAddress)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailAddress = emailAddress;
        }

        #endregion
        
    }
}
