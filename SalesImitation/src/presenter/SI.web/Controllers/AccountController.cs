using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SI.Application.Player;
using SI.Common.Models;

namespace SI.Web.Controllers {
    [Route ("api/account/")]
    public class AccountController : ApiController {

        public AccountController () {

        }

        [HttpGet ("geto")]
        public int Get () {
            return 10;
        }

        [HttpPost ("register")]
        public async Task<Result> Register ([FromBody] RegisterPlayerRequest request) {
            return await Mediator.Send (request);
        }
    }
}