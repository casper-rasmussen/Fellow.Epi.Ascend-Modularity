using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EPiServer.Globalization;
using EPiServer.Shell.Security;
using EPiServer.Web.Mvc;
using Valtech.Sandbox.Communication.Manager.Messaging;
using Valtech.Sandbox.Communication.Manager.Notification;
using Valtech.Sandbox.Core.Implementation.Areas.Core.Models.Pages;
using Valtech.Sandbox.Core.Implementation.Models.Pages;
using Valtech.Sandbox.Core.Infrastructure.Lazy;

namespace Valtech.Sandbox.Core.Implementation.Areas.Core.Controllers.Pages
{
    public class StartPageController : PageController<StartPageType>
    {
        private readonly IMessagingManager _messagingManager;
        private readonly INotificationManager _notificationManager;

        public StartPageController(IMessagingManager messagingManager, INotificationManager notificationManager)
        {
            this._notificationManager = notificationManager;
            this._messagingManager = messagingManager;
        }

        public ActionResult Index(StartPageType currentPage)
        {
            //Example use of Messaging Contract - ex. would be for "Reset Password"
            this._messagingManager.SendMessageToCurrentUser("Test Subject", "Test Message");

            //Example use of Notification Contract - ex. would be during "Order Lifecycle"
            this._notificationManager.SendNotificationToCurrentUser("Test Notification");

            var viewModel = new StartPageViewModel()
            {
                FirstContentAreaTitle = currentPage.FirstContentAreaTitle,
                FirstContentArea = currentPage.FirstContentArea,
            };

            return View(viewModel);
        }
    }
}
