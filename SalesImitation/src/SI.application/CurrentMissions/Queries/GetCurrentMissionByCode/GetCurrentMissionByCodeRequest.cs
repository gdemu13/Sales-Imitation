using MediatR;

namespace SI.Application.CurrentMissions {
    public class GetCurrentMissionByCodeRequest : IRequest<GetCurrentMissionByCodeResponse>
    {
        public string Code { get;  set; }
    }
}