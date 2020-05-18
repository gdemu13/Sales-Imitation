using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Common.Models;

namespace SI.Application.Translations
{
    public class GetAllLanuages : IRequestHandler<GetAllLanuagesRequest, TranslationModel>
    {
        private readonly ITranslationsService service;

        public GetAllLanuages(ITranslationsService service)
        {
            this.service = service;
        }

        public async Task<TranslationModel> Handle(GetAllLanuagesRequest request, CancellationToken cancellationToken)
        {
            return await service.GetAllLanguages();
        }
    }

}