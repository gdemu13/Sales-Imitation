using System;
using MediatR;
using SI.Common.Models;
using SI.Domain.Entities;

namespace SI.Application.Players {
    public class UpdatePlayerInfoRequest : IRequest<Result>
    {
        public Guid ID { get;  set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public PlayerAvatars Avatar { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
    }
}