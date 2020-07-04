using System;
using MediatR;
using SI.Common.Models;

namespace SI.Application.Players
{
    public class AddCoinsToPlayerRequest : IRequest<Result>
    {
        public Guid PlayerID { get; set; }
        public decimal Coins { get; set; }
        public string Reason { get; set; }
    }
}