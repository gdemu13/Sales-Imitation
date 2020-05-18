using System.Collections.Generic;
using System.Threading.Tasks;
using SI.Common.Models;

namespace SI.Application.Translations
{
    public interface ITranslationsService
    {
        Task<Result> Save(TranslationModel model);

        Task<TranslationModel> GetAllLanguages();

         Task<Dictionary<string, string>> GetNeutralTexts();

         Task<Dictionary<string, string>> GetLanguage(string languageKey);
    }
}