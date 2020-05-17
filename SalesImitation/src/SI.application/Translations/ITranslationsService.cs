using System.Collections.Generic;
using System.Threading.Tasks;

namespace SI.Application.Translations
{
    public interface ITranslationsService
    {
        Task Save(TranslationModel model);

        Task<TranslationModel> GetAllLanguages();
        Task<TranslationLanguageModel> GetLanguage(string languageKey);
    }
}