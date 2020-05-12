using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SI.Application.Administrators;
using SI.Application.Categories;
using SI.Application.CurrentMissions;
using SI.Application.Players;
using SI.Application.Products;
using SI.Common.Models;
using SI.Domain.Entities;
using SI.Domin.Abstractions.Authentication;

namespace SI.Web.Controllers
{
    [Route("api/game/")]
    public class GameController : ApiController
    {

        ICurrentUser _currentUser;
        public GameController(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        [HttpGet("getAvaliableCategories")]
        public async Task<IEnumerable<GetCategoriesListbyIDsResponse>> GetAvaliableCategories()
        {
            var player = await Mediator.Send(new GetPlayerByIDRequest(_currentUser.ID.Value));
            var mission = await Mediator.Send(new GetMissionByLevellRequest(player.CurrentLevel));
            var productCategories = await Mediator.Send(new GetProductCategoriesByPriceRangeRequest(mission.PriceRange.From, mission.PriceRange.To));
            var avaliableCategoryIDs = productCategories.Select(pc => pc.ID);
            return await Mediator.Send(new GetCategoriesListbyIDsRequest(avaliableCategoryIDs));
        }

        [HttpPost("startMission")]
        public async Task<Result> StartMission([FromBody] StartNewMissionRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpGet("CurrentMission")]
        public async Task<CurrentMission> GetCurrentMission()
        {
            return await Mediator.Send(new GetCurrentMissionRequest());
        }

        [HttpPost("buyExtraTime")]
        public async Task<Result> BuyExtraTime([FromBody] BuyExtraTimeRequest request) {
            return await Mediator.Send(request);
        }
    }
}
