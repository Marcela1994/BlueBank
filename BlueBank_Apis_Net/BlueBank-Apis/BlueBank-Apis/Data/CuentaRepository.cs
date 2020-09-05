using BlueBank_Apis.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace BlueBank_Apis.Data
{
    public class CuentaRepository
    {
        private readonly string _connectionString;
        public CuentaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        public async Task CrearCuenta(CrearCuenta req)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("insertarCliente", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@pNombre", req.primer_nombre));
                        cmd.Parameters.Add(new SqlParameter("@sNombre", req.segundo_nombre));
                        cmd.Parameters.Add(new SqlParameter("@pApellido", req.primer_apellido));
                        cmd.Parameters.Add(new SqlParameter("@sApellido", req.segundo_apellido));
                        cmd.Parameters.Add(new SqlParameter("@documento", req.documento));
                        cmd.Parameters.Add(new SqlParameter("@nroCta", req.nro_cuenta));
                        cmd.Parameters.Add(new SqlParameter("@clave", req.clave));
                        cmd.Parameters.Add(new SqlParameter("@saldo", req.saldo));
                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                        Console.WriteLine("Se inserto correctamente");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error al insertar");
                Console.WriteLine("-> " + e.Message);
            }
        }

        public async Task<string> ConsultarSaldo(ValidarSaldo req)
        {
            string saldoCuenta = "No se pudo consultar el saldo";
            try
            {
                using (SqlConnection sql = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("consultaSaldo", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@cuenta", req.cuenta));
                        cmd.Parameters.Add(new SqlParameter("@pin", req.pin));
                        Console.WriteLine("Consulta del saldo");
                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            await sql.OpenAsync();
                            await cmd.ExecuteNonQueryAsync();
                            adapter.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                adapter.Fill(dt);
                                saldoCuenta = (dt.Rows[0]["saldo"].ToString());
                                return saldoCuenta;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al insertar");
                Console.WriteLine("-> " + e.Message);
                return saldoCuenta;
            }
        }


    }
}
