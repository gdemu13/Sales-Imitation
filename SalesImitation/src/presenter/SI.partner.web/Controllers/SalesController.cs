using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using SI.Domain.Entities;
using SI.Application.Players;
using SI.Common.Models;
using SI.Application.CurrentMissions;

namespace SI.Partner.Web.Controllers
{
    [Route("/api/Sales")]
    public class SalesController : ApiController
    {

        [HttpGet("CheckCode/{code}")]
        public async Task<GetCurrentMissionByCodeResponse> CheckCode(string code)
        {
            var request = new GetCurrentMissionByCodeRequest{Code = code};
            return await Mediator.Send(request);
        }

        [HttpPost("confirm")]
        public async Task<Result> Confirm(ConfirmSaleRequest request){
            return await Mediator.Send (request);
        }
    }
}