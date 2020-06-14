using SI.Infrastructure.Storage;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SI.Application.Administrators;
using SI.Application.Categories;
using SI.Application.Players;
using SI.Application.CurrentMissions;
using SI.Common.Models;
using SI.Domain.Entities;
using SI.Domin.Abstractions.Authentication;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace SI.Web.Controllers
{
    [Route("api/identification/")]
    public class IdentificationController : ApiController
    {
        private readonly IFIleService fIleService;
        private readonly ICurrentUser currentUser;

        public IdentificationController(IFIleService fIleService, ICurrentUser currentUser)
        {
            this.fIleService = fIleService;
            this.currentUser = currentUser;
        }

        [HttpPost("IDCardFront")]
        public async Task<Result> IDCardFront(IFormFile file)
        {
            var res = await fIleService.SavePersonalFile(file, currentUser.ID.Value);
            if (res.IsSuccess)
            {
                return await Mediator.Send(new SaveIdentificationInfoRequest
                {
                    PlayerID = currentUser.ID.Value,
                    IDCardFrontUrl = "/media/identification/" + res.Data
                });
            }
            return res;
        }

        [HttpPost("IDCardBack")]
        public async Task<Result> IDCardBack(IFormFile file)
        {
            var res = await fIleService.SavePersonalFile(file, currentUser.ID.Value);
            if (res.IsSuccess)
            {
                return await Mediator.Send(new SaveIdentificationInfoRequest
                {
                    PlayerID = currentUser.ID.Value,
                    IDCardBackUrl = "/media/identification/" + res.Data
                });
            }
            return res;
        }

        [HttpPost("Selfie")]
        public async Task<Result> Selfie(IFormFile file)
        {
            var res = await fIleService.SavePersonalFile(file, currentUser.ID.Value);
            if (res.IsSuccess)
            {
                return await Mediator.Send(new SaveIdentificationInfoRequest
                {
                    PlayerID = currentUser.ID.Value,
                    SelfieUrl = "/media/identification/" + res.Data
                });
            }
            return res;
        }

        [HttpPost("PersonalID")]
        public async Task<Result> PersonalID([FromBody] SaveIDCard saveIDCard)
        {
            return await Mediator.Send(new SaveIdentificationInfoRequest
            {
                PlayerID = currentUser.ID.Value,
                IDNumber = saveIDCard.Value
            });
        }
    }

    public class SaveIDCard
    {
        public string Value { get; set; }
    }
}