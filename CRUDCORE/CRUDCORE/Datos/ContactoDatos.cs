using CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUDCORE.Datos
{
    public class ContactoDatos
    {
        public List<ContactoModel> Listar()
        {
            var oLista = new List<ContactoModel>();
            var conn = new Conexion();

            using (var conexion = new SqlConnection(conn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using(var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ContactoModel()
                        {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombres = dr["Nombres"].ToString(),
                            Apellidos = dr["Apellidos"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }

        public ContactoModel Obtener(int IdContacto)
        {
            var oContacto = new ContactoModel();
            var conn = new Conexion();

            using(var conexion = new SqlConnection(conn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = cmd.ExecuteReader()) 
                {
                    while (dr.Read())
                    {
                        oContacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        oContacto.Nombres = dr["Nombres"].ToString();
                        oContacto.Apellidos = dr["Apellidos"].ToString();
                        oContacto.Telefono = dr["Telefono"].ToString();
                        oContacto.Correo = dr["Correo"].ToString();
                    }
                }
            }

            return oContacto;
        }


        public bool Guardar(ContactoModel oContacto)
        {
            bool rpta;
            try
            {
                var conn = new Conexion();

                using (var conexion = new SqlConnection(conn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombres", oContacto.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oContacto.Apellidos);
                    cmd.Parameters.AddWithValue("Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", oContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta=false;
            }
            return rpta;
        }

        public bool Editar(ContactoModel oContacto)
        {
            bool rpta;
            try
            {
                var conn = new Conexion();

                using (var conexion = new SqlConnection(conn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("IdContacto", oContacto.IdContacto);
                    cmd.Parameters.AddWithValue("Nombres", oContacto.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oContacto.Apellidos);
                    cmd.Parameters.AddWithValue("Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", oContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Eliminar(int IdContacto)
        {
            bool rpta;
            try
            {
                var conn = new Conexion();

                using (var conexion = new SqlConnection(conn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }
            return rpta;
        }


    }
}
