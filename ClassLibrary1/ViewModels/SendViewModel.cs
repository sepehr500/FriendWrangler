using FriendWrangler.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendWrangler.Core.ViewModels
{
    class SendViewModel : BaseViewModel
    {
        public User[] friends { get; set; }
        public int DurationInSeconds { get; set; }
        public int InvitedCount { get; set; }
        public int AskThisManyAtATimeCount { get; set; }

        public async void SendMessage()
        {
            if (friends == null || friends.Count() == 0)
            {
                throw new Exception("No friends selected.");
            }

            IsBusy = true;
            try
            {
                int acceptedCount = 0;
                int askedCount = 0;
                foreach (var friend in friends)
                {
                    await service.SendMessage(friend);
                    askedCount++;

                    if (askedCount >= AskThisManyAtATimeCount)
                    {
                        // wait this long before asking the next friend
                        await Task.Delay(DurationInSeconds);
                        askedCount--;
                    }
                    // check to see if they replied positively
                    // InviteCount++
                    if (acceptedCount == InvitedCount) break;
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
