using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestBlocklyHtml.Controllers
{
    public class ReturnImage
    {
        public string name { get; set; }
        public byte[] Image { get; set; }

    }
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestImageController : ControllerBase
    {

        [HttpGet]
        public async Task<ReturnImage> GetImageSprite()
        {
            
            var data = await System.IO.File.ReadAllBytesAsync("wwwroot/media/sprites.png");
            var rt = new ReturnImage
            {
                name = "sprites.png",
                Image = data
            };
            return rt;
        }
    
    }
}