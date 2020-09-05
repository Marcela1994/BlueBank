using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueBank_Apis.Data;
using BlueBank_Apis.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlueBank_Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly CuentaRepository _repository;

        public CuentaController(CuentaRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET: api/<CuentaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CuentaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CuentaController>
        [HttpPost]
        public async Task Post([FromBody] CrearCuenta req)
        {
            Console.WriteLine(req);
            await _repository.CrearCuenta(req);
            
        }

        // PUT api/<CuentaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CuentaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
