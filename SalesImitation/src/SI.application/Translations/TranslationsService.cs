using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using SI.Common.Models;

namespace SI.Application.Translations
{
    public class TranslationsService : ITranslationsService
    {
        public TranslationsService(ITranslationsRepository repo, IMemoryCache cache)
        {
            this.repo = repo;
            this.cache = cache;
        }
        private readonly ITranslationsRepository repo;
        private readonly IMemoryCache cache;

        public async Task<Result> Save(TranslationModel model)
        {
            return await repo.Save(model);
        }

        public async Task<TranslationModel> GetAllLanguages()
        {
            return await repo.GetAllLanguages();
        }

        public async Task<Dictionary<string, string>> GetNeutralTexts()
        {
            return await repo.GetNeutral();
        }

        public async Task<Dictionary<string, string>> GetLanguage(string languageKey)
        {
            Dictionary<string, string> res;

            // Look for cache key.
            if (!cache.TryGetValue("LANGUAGE_KEY_" + languageKey, out res))
            {
                res = await repo.GetByCountryCode(languageKey);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(15));

                // Save data in cache.
                cache.Set("LANGUAGE_KEY_" + languageKey, res, cacheEntryOptions);
            }

            return res;
        }
    }
}