using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBank_Apis.Entities
{
    public class CrearCuenta
    {
        public string documento { get; set; }
        public string nro_cuenta { get; set; }
        public string clave { get; set; }
        public decimal saldo { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
    }
}
