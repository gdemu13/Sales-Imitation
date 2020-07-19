using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using SI.Domain.Entities;
using SI.Application.Players;
using SI.Common.Models;
using SI.Domin.Abstractions.Authentication;
using SI.Application.Notifications;

namespace SI.Web.Controllers
{

    [Route("/api/notifications")]
    public class NotificationsController : ApiController
    {
        private readonly ICurrentUser currentUser;

        public NotificationsController(ICurrentUser currentUser)
        {
            this.currentUser = currentUser;
        }

        [HttpGet("New")]
        public async Task<Notification> GetNewNotifications()
        {
            var request = new GetNewNotificationsRequest() { PlayerID = currentUser.ID.Value };
            return await Mediator.Send(request);
        }
    }
}