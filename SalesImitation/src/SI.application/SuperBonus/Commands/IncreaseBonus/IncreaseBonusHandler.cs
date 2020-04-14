using MediatR;
using SI.Common.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SI.Application.SuperBonus {
    public class IncreaseBonusHandler : IRequestHandler<IncreaseBonusRequest, Result> {
        public async Task<Result> Handle(IncreaseBonusRequest request, CancellationToken token) {
            return null;
        }
    }
}