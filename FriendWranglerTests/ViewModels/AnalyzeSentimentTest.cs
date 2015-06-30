using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendWrangler.Core.Models;
using FriendWrangler.Core.Services;
using FriendWrangler.Core.ViewModels;
using NUnit.Framework;

namespace FriendWranglerTests.ViewModels
{
    class AnalyzeSentimentTest
    {

        [TestFixture()]
        public class LoginViewModelTests
        {
            public Invitation Invitation { get; set; }

            [SetUp]
            public void SetUp()
            {
                Test.SetUp(); // sets up dependencies
                
                this.Invitation = new Invitation();
            }

            [Test()]
            public async void AnalyzeSentiment()
            {
                var x = Invitation.AnalyzeSentiment("Hello My name is jim");
                
            }
        }


    }
}
