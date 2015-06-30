using System;
using NUnit.Framework;
using FriendWrangler.Core.ViewModels;
using FriendWrangler.Core.Services;

namespace FriendWranglerTests.ViewModels
{
    [TestFixture ()]
    public class LoginViewModelTests
    {
        LoginViewModel loginViewModel;
        ISettings settings;

        [SetUp]
        public void SetUp()
        {
            Test.SetUp(); // sets up dependencies
            settings = ServiceContainer.Resolve<ISettings>();
            loginViewModel = new LoginViewModel();

        }

        [Test ()]
        public async void LoginSuccessfully()
        {
            loginViewModel.Username = "christopher";
            loginViewModel.Password = "password";

            await loginViewModel.Login();

            Assert.That(settings.User, Is.Not.Null);
        }
    }
}
