﻿using System.Threading.Tasks;
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

        [HttpPost("api")]
        public async Task<ActionResult> Cadastrar([FromBody] Heroi h)
        {
            dc.Herois.Add(h);
            await dc.SaveChangesAsync();

            return Created("Objeto herois", h);
        }

        [HttpGet("api")]
        public async Task<ActionResult> Listar()
        {
            var data = await dc.Armas.ToListAsync();
            return Ok(data);
        }

        private ActionResult Created()
        {
            throw new NotImplementedException();
        }

        [HttpGet("Hello")]
        public string Hello()
        {
            return "Hello";
        }
    }
}
