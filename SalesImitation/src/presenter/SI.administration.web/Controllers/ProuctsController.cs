using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SI.Application.Products;
using SI.Common.Models;
using SI.Domain.Entities;

namespace SI.Administration.Web.Controllers
{

    [Route("/api/Products")]
    public class ProductsController : ApiController
    {

        [HttpGet("Get/{ID}")]
        public async Task<Product> Get(Guid ID)
        {
            var request = new GetProductRequest(ID);
            return await Mediator.Send(request);
        }

        [HttpGet("Group/{id}")]
        public async Task<IEnumerable<Product>> GetRange(Guid id)
        {
            return await Mediator.Send(new GetProductsBuGroupRequest { GroupID = id });
        }

        [HttpGet("Range")]
        public async Task<GetRangeOfProductResponse> GetRange([FromQuery] GetRangeOfProductsRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPost("SaveNew")]
        public async Task<Result> Save([FromBody] SaveNewProductRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPut("Update")]
        public async Task<Result> Update([FromBody] UpdateProductRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPatch("SetIsActive")]
        public async Task<Result> SetIsActive([FromBody] SetIsActiveToProductRequest request)
        {
            return await Mediator.Send(request);
        }
    }
}