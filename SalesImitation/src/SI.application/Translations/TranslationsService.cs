using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SI.Application.Translations
{
    public class TranslationsService : ITranslationsService
    {
        public TranslationsService(ITranslationsRepository repo)
        {
            this.repo = repo;
        }
        private readonly ITranslationsRepository repo;

        public async Task Save(TranslationModel model)
        {
            foreach (var m in model)
            {
                m.Value.ID = Guid.NewGuid();
                m.Value.LanguageCode = m.Key;
            }
            await repo.Save(model);
        }

        public async Task<TranslationModel> GetAllLanguages()
        {
            return await repo.GetAllLanguages();
        }

        public async Task<TranslationLanguageModel> GetLanguage(string languageKey)
        {
            return null;
        }
    }
}