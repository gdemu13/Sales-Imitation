using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SI.Application.Missions;
using SI.Application.Contents;
using SI.Common.Models;
using SI.Domain.Entities;
using SI.Application.FAQs;
using System;

namespace SI.Administration.Web.Controllers
{

    [Route("/api/faq")]
    public class FAQController : ApiController
    {
        private readonly IFAQsRepository repository;

        public FAQController(IFAQsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet()]
        public async Task<IEnumerable<FAQModel>> GetAll()
        {
            return await repository.GetAll();
        }

        [HttpPost()]
        public async Task<Result> Post([FromBody] FAQModel faqItem)
        {
            return await repository.Save(faqItem);
        }

        [HttpDelete("{id}")]
        public async Task<Result> Delete(Guid id)
        {
            return await repository.Remove(id);
        }
    }
}