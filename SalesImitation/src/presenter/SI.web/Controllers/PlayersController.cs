using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using SI.Domain.Entities;
using SI.Application.Players;
using SI.Common.Models;

namespace SI.Web.Controllers {
    [Route("/api/players")]
    public class PlayersController : ApiController {

        [HttpGet("Leaderboard")]
        public async Task<GetLeaderboardResponse> GetLeaderBoard(int quantity = 10){
            var request = new GetLeaderboardRequest(){ShowTop = quantity};
            return await Mediator.Send (request);
        }
    }
}