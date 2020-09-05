using BlueBank_Apis.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBank_Apis.Data
{
    public class ConsignacionRepository
    {
        private readonly string _connectionString;
        public ConsignacionRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        public async Task<CrearCuenta> Consignacion(Consignacion req)
        {
            CrearCuenta cc = new CrearCuenta();

            try
            {
                using (SqlConnection sql = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("consignacion", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@cuenta", req.cuenta));
                        cmd.Parameters.Add(new SqlParameter("@valor", req.valor));
                        Console.WriteLine("Se inserto correctamente");
                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            await sql.OpenAsync();
                            adapter.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                adapter.Fill(dt);
                                cc.primer_nombre = (dt.Rows[0]["primer_nombre"].ToString());
                                cc.primer_apellido = (dt.Rows[0]["primer_apellido"].ToString());
                                cc.nro_cuenta = (dt.Rows[0]["nro_cuenta"].ToString());
                                cc.saldo = Decimal.Parse((dt.Rows[0]["saldoFinal"].ToString()));
                                return cc;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al insertar");
                Console.WriteLine("-> " + e.Message);
                return cc;
            }
        }
    }
}
