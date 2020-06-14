using System;
using MediatR;
using SI.Common.Models;
using SI.Domain.Entities;

namespace SI.Application.Players {
    public class UpdatePlayerInfoRequest : IRequest<Result>
    {
        public Guid ID { get; internal set; }
        public string Firstname { get; internal set; }
        public string Lastname { get; internal set; }
        public PlayerAvatars Avatar { get; internal set; }
        public string Mail { get; internal set; }
        public string Phone { get; internal set; }
    }
}