using System;
using MediatR;
using SI.Common.Models;

namespace SI.Application.Players {
    public class SaveIdentificationInfoRequest : IRequest<Result>
    {
        public string IDCardFrontUrl { get; set; }
        public Guid PlayerID { get; set; }
        public string IDCardBackUrl { get; set; }
        public string SelfieUrl { get; set; }
        public string IDNumber { get; set; }
    }
}