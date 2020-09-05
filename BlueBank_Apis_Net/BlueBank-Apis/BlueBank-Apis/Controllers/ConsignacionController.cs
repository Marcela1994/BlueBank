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
    public class ConsignacionController : ControllerBase
    {
        private readonly ConsignacionRepository _repository;

        public ConsignacionController(ConsignacionRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET: api/<ConsignacionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ConsignacionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ConsignacionController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] Consignacion req)
        {
            CrearCuenta cc = new CrearCuenta();
            try
            {
                Console.WriteLine(req);
                cc  = await _repository.Consignacion(req);
                object response = new object[] { 
                    new { nombre = cc.primer_nombre, apellido = cc.primer_apellido, numeroDeCuenta = cc.nro_cuenta, nuevoSaldo= cc.saldo}
                };
                return Ok(response);
            }
            catch {
                object response = new object[] { new { mensaje = "Ocurrio un error al retirar" } };
                return BadRequest(response);
            }

            
        }

        // PUT api/<ConsignacionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConsignacionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
