using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Common.Models;

namespace SI.Application.Translations
{
    public class SaveAllLanguagesHandler : IRequestHandler<SaveAllLanguagesRequest, Result>
    {
        private readonly ITranslationsService service;

        public SaveAllLanguagesHandler(ITranslationsService service)
        {
            this.service = service;
        }

        public async Task<Result> Handle(SaveAllLanguagesRequest request, CancellationToken cancellationToken)
        {
            var neutralKeys = await service.GetNeutralTexts();
            var model = new TranslationModel(neutralKeys)
            {
                Languages = request.Languages.Where(s => s.Code != "neutral").Select(l => new LanguageModel
                {
                    Code = l.Code,
                    Name = l.Name
                }).ToList(),
            };

            foreach (var t in request.Texts)
            {
                model.AddTexts(t.Key,
                t.Value.Select(m => new TextModel { Value = m.Value, LanguageCode = m.LanguageCode }));
            }

            return await service.Save(model);
        }
    }

}