using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendWrangler.Core.Classes;
using FriendWrangler.Core.Enumerations;
using FriendWrangler.Core.Models;
using FriendWrangler.Core.Services;
using FriendWrangler.Core.ViewModels;
using NUnit.Framework;

namespace FriendWranglerTests.ViewModels
{
   

    [TestFixture()]
    public class AnalyzeSentimentTest
    {
        public Invitation Invitation { get; set; }
        public InvitationAnalyzer Analyzer { get; set; }
        [SetUp]
        public void SetUp()
        {
            Test.SetUp(); // sets up dependencies

            Invitation = new Invitation {Message = "I hate the earth"};
            Analyzer = new InvitationAnalyzer(Invitation);
        }

        [Test()]
        public void AnalyzeSentiment()
        {
            var x = Analyzer.Sentiment;
            Console.WriteLine(x);
            Assert.AreSame(MessageSentiment.No.ToString() , x.ToString());

        }
    }


    
}
