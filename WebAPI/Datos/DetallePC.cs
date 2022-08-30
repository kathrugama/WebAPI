using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Datos
{
    public class DetallePC
    {      
        public static List<DetallesCompu> Mostrar()
        {
            List<DetallesCompu> detallesCompu = new List<DetallesCompu>();
            using (SqlConnection Con = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("MostrarProductos", Con);
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
                                codigo = Convert.ToInt32(dr["Codigo"]),
                                tipo_de_Computadora = dr["Tipo_de_Computadora"].ToString(),
                                procesador = dr["Procesador"].ToString(),
                                memoria_RAM = dr["Memoria_RAM"].ToString(),
                                tipo_de_disco_duro = dr["Tipo_de_disco_duro"].ToString(),
                                almacenamiento = dr["Almacenamiento"].ToString(),
                            });
                        }

                    }



                    return detallesCompu;
                }
                catch (Exception)
                {
                    return detallesCompu;
                }
            }
        }
        public static bool Insertar(DetallesCompu detallesCompu)
        {
            using (SqlConnection Con = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand Comando = new SqlCommand("InsetarProductos", Con);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@Codigo", detallesCompu.codigo);
                Comando.Parameters.AddWithValue("@Tipo_de_Computadora", detallesCompu.tipo_de_Computadora);
                Comando.Parameters.AddWithValue("@Procesador", detallesCompu.procesador);
                Comando.Parameters.AddWithValue("@Memoria_RAM", detallesCompu.memoria_RAM);
                Comando.Parameters.AddWithValue("@Tipo_de_disco_duro", detallesCompu.tipo_de_disco_duro);
                Comando.Parameters.AddWithValue("@Almacenamiento", detallesCompu.almacenamiento);

               
                try
                {
                    Con.Open();
                    Comando.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
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
                Comando.Parameters.AddWithValue("@Codigo", detallesCompu.codigo);
                Comando.Parameters.AddWithValue("@Tipo_de_Computadora", detallesCompu.tipo_de_Computadora);
                Comando.Parameters.AddWithValue("@Procesador", detallesCompu.procesador);
                Comando.Parameters.AddWithValue("@Memoria_RAM", detallesCompu.memoria_RAM);
                Comando.Parameters.AddWithValue("@Tipo_de_disco_duro", detallesCompu.tipo_de_disco_duro);
                Comando.Parameters.AddWithValue("@Almacenamiento", detallesCompu.almacenamiento);


              
                try
                {
                    Con.Open();
                    Comando.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }
        public static bool Eliminar(int id)
        {
            using (SqlConnection Con = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand Comando = new SqlCommand("EliminarProducto", Con);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@Codigo", id);


                try
                {
                    Con.Open();
                    Comando.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
 

        public static DetallesCompu Buscar(int codigo)
        {
            DetallesCompu detallesCompu = new DetallesCompu();
            using (SqlConnection Con = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("BuscarProductos", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", codigo);

                try
                {
                    Con.Open();
                    //cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            detallesCompu = new DetallesCompu()
                            {
                                codigo = Convert.ToInt32(dr["Codigo"]),
                                tipo_de_Computadora = dr["Tipo_de_Computadora"].ToString(),
                                procesador = dr["Procesador"].ToString(),
                                memoria_RAM = dr["Memoria_RAM"].ToString(),
                                tipo_de_disco_duro = dr["Tipo_de_disco_duro"].ToString(),
                                almacenamiento = dr["Almacenamiento"].ToString(),
                            };
                        }

                    }

                    return detallesCompu;
                }
                catch (Exception)
                {
                    return detallesCompu;
                }
            }
        }
    }
}