using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using SI.Domain.Entities;
using SI.Application.Player;
using SI.Common.Models;

namespace SI.Web.Controllers {
    [Route("/api/players")]
    public class PlayersController : ApiController {

        [HttpGet("Leaderboard")]
        public async Task<IEnumerable<Player>> GetLeaderBoard(){
            var request = new GetLeaderboardRequest();
            return await Mediator.Send (request);
        }
    }
}