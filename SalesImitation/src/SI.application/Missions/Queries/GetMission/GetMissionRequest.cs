using MediatR;
using SI.Common.Models;
using System;
using System.Collections.Generic;
using SI.Domain.Entities;

namespace SI.Application.Missions  {
    public class GetMissionRequest : IRequest<Mission> {
        public Guid ID {get; set;}
        public GetMissionRequest(Guid id) {
            ID = id;
        }
    }
}