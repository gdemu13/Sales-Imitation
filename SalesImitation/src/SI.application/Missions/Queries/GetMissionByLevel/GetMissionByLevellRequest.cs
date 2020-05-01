using MediatR;
using SI.Domain.Entities;

namespace SI.Application.Categories  {
    public class GetMissionByLevellRequest : IRequest<Mission> {
        public int Level {get; set;}

        public GetMissionByLevellRequest(int level) {
            Level = level;
        }

         public GetMissionByLevellRequest() {
        }
    }
}