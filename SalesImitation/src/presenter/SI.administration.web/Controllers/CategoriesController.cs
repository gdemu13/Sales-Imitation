using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SI.Application.Categories;
using SI.Common.Models;
using SI.Domain.Entities;

namespace SI.Administration.Web.Controllers {

    [Route ("/api/Categories")]
    public class CategoriesController : ApiController {

        [HttpGet ("All")]
        public async Task<IEnumerable<Category>> GetPendingBonus () {
            var request = new GetAllCategoriesRequest ();
            return await Mediator.Send (request);
        }

        [HttpPost ("SaveNew")]
        public async Task<Result> SaveBonus (SaveNewCategoryRequest request) {
            return await Mediator.Send (request);
        }

        [HttpPut ("ChangeName")]
        public async Task<Result> ChangeName (ChangeCategoryNameRequest request) {
            return await Mediator.Send (request);
        }

         [HttpPatch ("SetIsActive")]
        public async Task<Result> SetIsActive (SetIsActiveToCategoryRequest request) {
            return await Mediator.Send (request);
        }
    }
}