using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using WebAPI.Models;


namespace CapaDatos
{
    public class DetallePC
    {
        public static bool Insertar(DetallesCompu detallesCompu)
        {
            using (SqlConnection Con = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand Comando = new SqlCommand("InsetarProductos", Con);

                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@Codigo", detallesCompu.Codigo);
                Comando.Parameters.AddWithValue("@Tipo_de_Computadora", detallesCompu.Tipo_de_Computadora);
                Comando.Parameters.AddWithValue("@Procesador", detallesCompu.Procesador);
                Comando.Parameters.AddWithValue("@Memoria_RAM", detallesCompu.Memoria_RAM);
                Comando.Parameters.AddWithValue("@Tipo_de_disco_duro", detallesCompu.Tipo_de_disco_duro);
                Comando.Parameters.AddWithValue("@Almacenamiento", detallesCompu.Almacenamiento);

                Comando.Parameters.Clear();
                try
                {
                    Con.Open();
                    Comando.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool Editar(DetallesCompu detallesCompu)
        {
            using (SqlConnection Con = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand Comando = new SqlCommand("EditarProductos", Con);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@Codigo", detallesCompu.Codigo);
                Comando.Parameters.AddWithValue("@Tipo_de_Computadora", detallesCompu.Tipo_de_Computadora);
                Comando.Parameters.AddWithValue("@Procesador", detallesCompu.Procesador);
                Comando.Parameters.AddWithValue("@Memoria_RAM", detallesCompu.Memoria_RAM);
                Comando.Parameters.AddWithValue("@Tipo_de_disco_duro", detallesCompu.Tipo_de_disco_duro);
                Comando.Parameters.AddWithValue("@Almacenamiento", detallesCompu.Almacenamiento);


                Comando.Parameters.Clear();
                try
                {
                    Con.Open();
                    Comando.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }
        public static bool Eliminar(int Codigo)
        {
            using (SqlConnection Con = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand Comando = new SqlCommand("EliminarProductos", Con);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@Codigo", Codigo);

                
                try
                {
                    Con.Open();
                    Comando.Parameters.Clear();
                    Comando.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public static List<DetallesCompu> Mostrar()
        {
            List<DetallesCompu> detallesCompu = new List<DetallesCompu>();
            using (SqlConnection Con = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Mostrar", Con);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    Con.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            detallesCompu.Add(new DetallesCompu()
                            {
                                Codigo = Convert.ToInt32(dr["Codigo"]),
                                Tipo_de_Computadora = dr["Tipo_de_Computadora"].ToString(),
                                Procesador = dr["Procesador"].ToString(),
                                Memoria_RAM = dr["Memoria_RAM"].ToString(),
                                Tipo_de_disco_duro = dr["Tipo_de_disco_duro"].ToString(),
                                Almacenamiento = dr["Almacenamiento"].ToString(),
                            });
                        }

                    }



                    return detallesCompu;
                }
                catch (Exception ex)
                {
                    return detallesCompu;
                }
            }
        }

        public static DetallesCompu Obtener(int Codigo)
        {
            DetallesCompu detallesCompu = new DetallesCompu();
            using (SqlConnection Con = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", Codigo);

                try
                {
                    Con.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            detallesCompu = new DetallesCompu()
                            {
                                Codigo = Convert.ToInt32(dr["Codigo"]),
                                Tipo_de_Computadora = dr["Tipo_de_Computadora"].ToString(),
                                Procesador = dr["Procesador"].ToString(),
                                Memoria_RAM = dr["Memoria_RAM"].ToString(),
                                Tipo_de_disco_duro = dr["Tipo_de_disco_duro"].ToString(),
                                Almacenamiento = dr["Almacenamiento"].ToString(),
                            };
                        }

                    }



                    return detallesCompu;
                }
                catch (Exception ex)
                {
                    return detallesCompu;
                }
            }
        }
    }
}

