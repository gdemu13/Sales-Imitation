using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SI.Common.Models;
using Microsoft.AspNetCore.Http;
using SI.Infrastructure.Storage;
using System.Linq;

namespace SI.Administration.Web.Controllers
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
        public async Task<Result<string>> SaveImage( IFormFile file)
        {
            var res = await fIleService.SaveFile(file);
            if (res.IsSuccess)
                res.Data = "/media/images/" + res.Data;
            return res;
        }

        [HttpGet("images/{filename}")]
        public async Task<IActionResult> GetImage(string filename)
        {
            var res = await fIleService.GetFile(filename);
            return File(res, "image/" + filename.Split('.').Last());
        }
    }
}