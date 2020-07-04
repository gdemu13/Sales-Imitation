using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using SI.Domain.Entities;
using SI.Common.Models;
using SI.Application.SuperBonuses;
using System;
using MediatR;
using SI.Domin.Abstractions.Authentication;
using SI.Application.Administrators;
using SI.Application.Translations;
using SI.Common.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace SI.Web.Controllers
{
    [Route("/api/Bonus")]
    public class BonusController : ApiController
    {

        public BonusController()
        {
        }

        [HttpGet("Current")]
        public async Task<decimal> GetCurrentBonus()
        {
            var sb = await Mediator.Send(new GetActiveBonusRequest());
            return sb?.CurrentAmount ?? 0;
        }

    }
}