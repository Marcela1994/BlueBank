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
    public class ConsultarSaldoController : ControllerBase
    {
        private readonly CuentaRepository _repository;
        public ConsultarSaldoController(CuentaRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET: api/<ConsultarSaldoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ConsultarSaldoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ConsultarSaldoController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ValidarSaldo req)
        {
            try
            {
                Console.WriteLine(req);
                string saldo = await _repository.ConsultarSaldo(req);
                object response = new object[] { new { saldoActual = saldo } };
                return Ok(response);
            }
            catch
            {
                object response = new object[] { new { mensaje = "Error al consultar el saldo" } };
                return BadRequest(response);
            }
        }

        // PUT api/<ConsultarSaldoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConsultarSaldoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
