using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueBank_Apis.Contexts;
using BlueBank_Apis.Entities;
using Microsoft.AspNetCore.Mvc;
C:\BlueBank\BlueBank\BlueBank_Apis_Net\BlueBank-Apis\BlueBank-Apis\Controllers\PersonaController.cs
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlueBank_Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly AppDBContext context;

        public PersonaController(AppDBContext context)
        {
            this.context = context;
        }
        // GET: api/<PersonaController>
        [HttpGet]
        public IEnumerable<Personas> Get()
        {
            Console.Out.Write("LLamado al api de consultar listado personas");
            return context.personas.ToList();
        }

        // GET api/<PersonaController>/5
        [HttpGet("{id}")]
        public Personas Get(string id)
        {
            var persona = context.personas.FirstOrDefault(p => p.documento == id);
            return persona;
        }

        // POST api/<PersonaController>
        [HttpPost]
        public ActionResult Post([FromBody] Personas persona)
        {
            try {
                context.personas.Add(persona);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex){
                return BadRequest();
            }
            
        }

        // PUT api/<PersonaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Personas persona)
        {
            if (persona.documento == id)
            {
                context.Entry(persona).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();

                return Ok();
            }
            else {
                return BadRequest();
            }
        }

        // DELETE api/<PersonaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var persona = context.personas.FirstOrDefault(p => p.documento == id);
            if (persona != null)
            {
                context.personas.Remove(persona);
                context.SaveChanges();
                return Ok();
            }
            else {
                return BadRequest();
            }
        }
    }
}
