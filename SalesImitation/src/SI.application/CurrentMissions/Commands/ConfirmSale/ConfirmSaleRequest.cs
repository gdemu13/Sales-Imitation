using System;
using MediatR;
using SI.Common.Models;

namespace SI.Application.CurrentMissions
{
    public class ConfirmSaleRequest : IRequest<Result>
    {
        public string Code { get; set; }
        public Guid ProductID { get; set; }
    }
}