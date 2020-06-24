using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Domain.Abstractions.Repositories;

namespace SI.Application.CurrentMissions
{
    public class GetCurrentMissionByCodeHandler : IRequestHandler<GetCurrentMissionByCodeRequest, GetCurrentMissionByCodeResponse>
    {
        private readonly ICurrentMissionRepository repository;

        public GetCurrentMissionByCodeHandler(ICurrentMissionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetCurrentMissionByCodeResponse> Handle(GetCurrentMissionByCodeRequest request, CancellationToken cancellationToken)
        {
            var currentMIssion = await repository.GetActiveByCode(request.Code);
            if (currentMIssion.Item1 == null)
                return null;
            var prod1 = currentMIssion.Item1.Product1;
            var prod2 = currentMIssion.Item1.Product2;
            return new GetCurrentMissionByCodeResponse
            {
                Product1 = new GetCurrentMissionByCodeResponseProduct
                {
                    ID = prod1.ID,
                    ImageUrl = prod1.ImageUrl,
                    Name = prod1.Name
                },
                Product2 = new GetCurrentMissionByCodeResponseProduct
                {
                    ID = prod2.ID,
                    ImageUrl = prod2.ImageUrl,
                    Name = prod2.Name
                },
            };
        }
    }
}