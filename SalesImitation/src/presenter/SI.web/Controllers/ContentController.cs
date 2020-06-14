using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SI.Application.Missions;
using SI.Application.Contents;
using SI.Common.Models;
using SI.Domain.Entities;
using System;

namespace SI.Web.Controllers
{

    [Route("/api/Content")]
    public class ContentController : ApiController
    {
        private readonly IContentRepository repository;

        public ContentController(IContentRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("{name}")]
        public async Task<ContentModel> Get(string name)
        {
            return await repository.Get(name);
        }
    }
}