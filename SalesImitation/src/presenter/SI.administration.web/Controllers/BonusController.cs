using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using SI.Domain.Entities;
using SI.Application.Players;
using SI.Common.Models;
using SI.Application.SuperBonus;

namespace SI.Administration.Web.Controllers {
    [Route("/api/Bonus")]
    public class BonusController : ApiController {

        [HttpGet("GetPending")]
        public async Task<SuperBonus> GetPendingBonus(){
            var request = new GetPendingBonusRequest();
            return await Mediator.Send (request);
        }

        [HttpPost("Save")]
        public async Task<Result> SaveBonus(SaveBaseBonusRequest request){
            return await Mediator.Send (request);
        }
    }
}