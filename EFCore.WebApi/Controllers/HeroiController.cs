using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCore.WebApi.Data;
using EFCore.WebApi.Models;

namespace EFCore.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeroiController : ControllerBase
    {
        private HeroiContext dc;

        public HeroiController(HeroiContext context)
        {
            this.dc = context;
        }

        [HttpGet("api")]
        public async Task<ActionResult> Listar()
        {
            var data = await dc.Herois.ToListAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult> Gravar([FromBody] Heroi h)
        {
            dc.Herois.Add(h);
            await dc.SaveChangesAsync();

            return Created("Objeto de Heroi", h);
        }
    }
}
