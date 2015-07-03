using System;
using Android.Content;
using FriendWrangler.Core.Models;
using FriendWrangler.Droid.Classes;
using NUnit.Framework;


namespace AndroidTests
{
    [TestFixture]
    public class Messaging
    {
        //public BroadcastReceiver SmsBroadcastReceiver { get; set; }
        public Friend AndroidFriend { get; set; }

        [SetUp]
        public void Setup()
        {
            //SmsBroadcastReceiver = new SmsBroadcastReceiver();

            AndroidFriend = new AndroidFriend
            {
                PhoneNumber = "5407356190",
                FirstName = "Chris",
                LastName = "Zimmerman",
                Id = "1"
            };
        }


        [TearDown]
        public void Tear() { }

        [Test]
        public void Pass()
        {
            AndroidFriend.SendInvitation("hello world");
            string helloWorld = AndroidFriend.ReceiveMessages();

            Assert.That(helloWorld, Is.EqualTo("hello_world"));
        }

        [Test]
        public void Fail()
        {
            Assert.False(true);
        }

        [Test]
        [Ignore("another time")]
        public void Ignore()
        {
            Assert.True(false);
        }

        [Test]
        public void Inconclusive()
        {
            Assert.Inconclusive("Inconclusive");
        }
    }
}