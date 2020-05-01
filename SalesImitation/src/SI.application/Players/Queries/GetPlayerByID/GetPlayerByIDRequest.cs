using System;
using MediatR;
using SI.Domain.Entities;

namespace SI.Application.Categories  {
    public class GetPlayerByIDRequest : IRequest<Player> {
        public Guid ID {get; set;}

        public GetPlayerByIDRequest(Guid id) {
            ID = id;
        }

         public GetPlayerByIDRequest() {
        }
    }
}