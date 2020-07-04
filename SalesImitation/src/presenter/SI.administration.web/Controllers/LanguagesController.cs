using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using SI.Domain.Entities;
using SI.Common.Models;
using System;
using MediatR;
using SI.Domin.Abstractions.Authentication;
using SI.Application.Administrators;
using SI.Application.Translations;
using SI.Common.Models;
using SI.Common.Abstractions;



namespace SI.Administration.Web.Controllers
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
        public async Task<TranslationModel> GetAllLanguages()
        {
            return await translationsService.GetAllLanguages();
        }

        [HttpPost("allLanguages")]
        public async Task<Result> SaveAllLanguages([FromBody] SaveAllLanguagesRequest request)
        {
              return await Mediator.Send (request);
        }


    }
}