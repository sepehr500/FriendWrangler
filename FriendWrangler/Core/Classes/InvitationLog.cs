using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FriendWrangler.Core.Models
{
    public class InvitationLog
    {
        #region Fields

        public List<Invitation> Invitations;
        
        #endregion
        #region Methods





        #endregion

        #region Indexer

        public Invitation this[int i]
        {
            get
            {
                // This indexer is very simple, and just returns or sets 
                // the corresponding element from the internal array. 
                return Invitations[i];
            }
            set
            {
                Invitations[i] = value;
            }
        }

        #endregion
      
    }
}
