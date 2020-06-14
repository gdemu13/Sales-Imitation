using System;
using System.Collections.Generic;
using MediatR;
using SI.Domain.Entities;

namespace SI.Application.Notifications
{
    public class GetNewNotificationsRequest : IRequest<IEnumerable<Notification>>
    {
        public Guid PlayerID { get;  set; }
    }
}