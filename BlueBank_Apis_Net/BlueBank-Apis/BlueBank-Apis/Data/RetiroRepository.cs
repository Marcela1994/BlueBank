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
    public class RetiroRepository
    {
        private readonly string _connectionString;
        public RetiroRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        public async Task<string> Retiro(Retiro req)
        {
            string resultadoRetiro;

            try
            {
                using (SqlConnection sql = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("retiro", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@cuenta", req.cuenta));
                        cmd.Parameters.Add(new SqlParameter("@valor", req.valor));
                        cmd.Parameters.Add(new SqlParameter("@pin", req.pin));
                        Console.WriteLine("Se inserto correctamente");
                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            await sql.OpenAsync();
                            adapter.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                adapter.Fill(dt);
                                resultadoRetiro = (dt.Rows[0]["mensaje"].ToString());
                                return resultadoRetiro;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al insertar");
                Console.WriteLine("-> " + e.Message);
                return "error";
            }
        }
    }
}
