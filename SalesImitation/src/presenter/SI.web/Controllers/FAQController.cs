using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SI.Application.Missions;
using SI.Application.Contents;
using SI.Common.Models;
using SI.Domain.Entities;
using System;
using SI.Application.FAQs;

namespace SI.Web.Controllers
{

    [Route("/api/FAQ")]
    public class FAQController : ApiController
    {
        private readonly IFAQsRepository repository;

        public FAQController(IFAQsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet()]
        public async Task<IEnumerable<FAQModel>> Get()
        {
            return await repository.GetAll();
        }
    }
}