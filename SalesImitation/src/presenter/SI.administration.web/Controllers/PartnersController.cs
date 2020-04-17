using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SI.Application.Partners;
using SI.Common.Models;
using SI.Domain.Entities;

namespace SI.Administration.Web.Controllers {

    [Route ("/api/Partners")]
    public class PartnersController : ApiController {

        [HttpGet ("Range")]
        public async Task<IEnumerable<Partner>> GetRange ([FromQuery] GetRangeOfPartnersRequest request) {
            return await Mediator.Send (request);
        }

        [HttpPost ("SaveNew")]
        public async Task<Result> Save ([FromBody] SaveNewPartnerRequest request) {
            return await Mediator.Send (request);
        }

        [HttpPut ("Update")]
        public async Task<Result> Update ([FromBody] UpdatePartnerRequest request) {
            return await Mediator.Send (request);
        }

        [HttpPatch ("SetIsActive")]
        public async Task<Result> SetIsActive ([FromBody] SetIsActiveToPartnerRequest request) {
            return await Mediator.Send (request);
        }
    }
}