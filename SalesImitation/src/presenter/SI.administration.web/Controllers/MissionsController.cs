using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SI.Application.Missions;
using SI.Common.Models;
using SI.Domain.Entities;
using System;

namespace SI.Administration.Web.Controllers {

    [Route ("/api/Missions")]
    public class MissionsController : ApiController {

        [HttpGet ("Get/{ID}")]
        public async Task<Mission> Get (Guid ID) {
            var request = new GetMissionRequest (ID);
            return await Mediator.Send (request);
        }

        [HttpGet ("All")]
        public async Task<IEnumerable<Mission>> GetRange () {
            var request = new GetAllMissionsRequest();
            return await Mediator.Send (request);
        }

        [HttpPost ("SaveNew")]
        public async Task<Result> Save ([FromBody] SaveNewMissionRequest request) {
            return await Mediator.Send (request);
        }

        [HttpPut ("Update")]
        public async Task<Result> Update ([FromBody] UpdateMissionRequest request) {
            return await Mediator.Send (request);
        }

    }
}