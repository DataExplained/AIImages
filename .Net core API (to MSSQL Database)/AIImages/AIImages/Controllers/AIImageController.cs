using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImageAiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AIimageController : ControllerBase
    {
        private readonly ImageAiContext _context;

        public AIimageController(ImageAiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetImages()
        {
            return Ok(await _context.AiimageDetails.ToListAsync());
        }


        [HttpPost]
        public async Task<IActionResult> PostImages(AiimageDetail aiImage1)
        {
            Console.WriteLine(aiImage1);
            _context.AiimageDetails.Add(aiImage1);
            await _context.SaveChangesAsync();

            return Ok(await _context.AiimageDetails.ToListAsync());
        }
    }
}
