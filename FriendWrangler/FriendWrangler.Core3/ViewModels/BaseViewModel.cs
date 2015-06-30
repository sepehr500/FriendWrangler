﻿using FriendWrangler.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FriendWrangler.Core.ViewModels
{
    public class BaseViewModel
    {
        protected readonly IWebService service = ServiceContainer.Resolve<IWebService>();
        protected readonly ISettings settings = ServiceContainer.Resolve<ISettings>();

        public event EventHandler IsBusyChanged = delegate { };

        private bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                IsBusyChanged(this, EventArgs.Empty);
            }
        }

    }
}