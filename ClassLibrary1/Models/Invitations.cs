using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FriendWrangler.Core.Models
{
    public class Invitations
    {
        #region Fields

        private List<Invitation> _invitations;
        
        #endregion

        #region Indexer

        public Invitation this[int i]
        {
            get
            {
                // This indexer is very simple, and just returns or sets 
                // the corresponding element from the internal array. 
                return _invitations[i];
            }
            set
            {
                _invitations[i] = value;
            }
        }

        #endregion
      
    }
}
