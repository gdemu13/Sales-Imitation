using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using SI.Domain.Entities;
using SI.Common.Models;
using SI.Application.SuperBonus;
using System;
using MediatR;
using SI.Domin.Abstractions.Authentication;
using SI.Application.Administrators;
using SI.Application.Translations;
using SI.Common.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace SI.Web.Controllers
{
    [Route("/api/Languages")]
    public class LanguagesController : ApiController
    {
        private readonly ITranslationsService translationsService;
        private readonly ILogger logger;

        public LanguagesController(ITranslationsService translationsService, ILogger logger)
        {
            this.translationsService = translationsService;
            this.logger = logger;
        }

        [HttpGet("allLanguages")]
        [AllowAnonymous]
        public async Task<TranslationModel> GetAllLanguages()
        {
            return await translationsService.GetAllLanguages();
        }


        [HttpGet("byLanguageCode/{code}")]
        [AllowAnonymous]
        public async Task<IDictionary<string, string>> GetByLanguageCode(string code)
        {
            return await translationsService.GetLanguage(code);
        }

    }
}