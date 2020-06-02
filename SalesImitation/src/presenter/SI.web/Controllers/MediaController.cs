using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SI.Common.Models;
using Microsoft.AspNetCore.Http;
using SI.Infrastructure.Storage;

namespace SI.Web.Controllers
{
    [Route("/media")]
    public class MediaController : ApiController
    {
        private readonly IFIleService fIleService;

        public MediaController(IFIleService fIleService)
        {
            this.fIleService = fIleService;
        }

        [HttpPost("images")]
        public async Task<Result<string>> SaveImage([FromBody]IFormFile file)
        {
            var res = await fIleService.SaveFile(file);
            if (res.IsSuccess)
                res.Message = "/media/images/" + res.Message;
            return res;
        }

         [HttpGet("images/{filename}")]
        public async Task<IActionResult> GetImage(string filename)
        {
            var res = await fIleService.GetFile(filename);
            return File(res, "application/image");
        }
    }
}