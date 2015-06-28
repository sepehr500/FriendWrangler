using System;
using NUnit.Framework;
using FriendWrangler.Core.Services;
using FriendWrangler.Core.Fakes; 

namespace FriendWranglerTests
{
    [TestFixture ()]
    public class Test
    {
        public static void SetUp()
        {
            ServiceContainer.Register<IWebService>(() => new FakeWebService { SleepDuration = 1 });
            ServiceContainer.Register<ISettings>(() => new FakeSettings());

            // Register Dependencies
        }

        [Test ()]
        public void TestMethod1()
        {
        }
    }
}
