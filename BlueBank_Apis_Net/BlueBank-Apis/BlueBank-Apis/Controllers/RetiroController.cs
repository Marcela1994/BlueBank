using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueBank_Apis.Data;
using BlueBank_Apis.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlueBank_Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetiroController : ControllerBase
    {

        private readonly RetiroRepository _repository;

        public RetiroController(RetiroRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET: api/<RetiroController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RetiroController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RetiroController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] Retiro req)
        {
            try
            {
                Console.WriteLine(req);
                string respuesta = await _repository.Retiro(req);
                object response = new object[] { new { mensaje = respuesta } };
                return Ok(response);
            }
            catch {
                object response = new object[] { new { mensaje = "Ocurrio un error al retirar" } };
                return BadRequest(response);
            }


            
        }

        // PUT api/<RetiroController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RetiroController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
