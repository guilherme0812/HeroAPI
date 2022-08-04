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

        [HttpPost("api")]
        public async Task<ActionResult> Gravar([FromBody] Heroi h)
        {
            dc.Herois.Add(h);
            await dc.SaveChangesAsync();

            return Created("Objeto de Heroi", h);
        }

        [HttpGet("api/{id}")]
        public Heroi Filtrar(int id)
        {
            Heroi h = dc.Herois.Find(id);
            return h;
        }

        [HttpPut("api")]
        public async Task<ActionResult> Editar([FromBody]Heroi h) 
        {
            dc.Herois.Update(h);
            await dc.SaveChangesAsync();
            return Ok(h);
        }

        [HttpDelete("api/{id}")]
        public async Task<ActionResult> Deletar(int id)
        {
            Heroi h = Filtrar(id);
            if (h == null)
            {
                return NotFound(h);
            } else
            {
                dc.Herois.Remove(h);
                await dc.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
