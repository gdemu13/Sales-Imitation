using System.Collections.Generic;
using System.Threading.Tasks;
using SI.Common.Models;

namespace SI.Application.Translations
{
    public interface ITranslationsRepository
    {
        Task<Result> Save(TranslationModel model);

        Task<TranslationModel> GetAllLanguages();
    }
}