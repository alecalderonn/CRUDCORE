using CRUDCORE.Models;
using System.Data;
using System.Data.SqlClient;


namespace CRUDCORE.Datos
{
    public class ContactoDatos
    {
        ///instancias 
        public List<ContactoModel> Listar()
        {
            var oLista = new List<ContactoModel>();

            var cn = new Conexion();
            //establecer la cadena de conexion 

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion); //procedimiento almacenado y pasar conexion 
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader()) //dr se refiere al objeto SqlDataReader, que se utiliza para leer las filas
                                                     //devueltas por una consulta SQL ejecutada en la base de datos.
                {
                    while (dr.Read()) //dr recorre los registros del sp listado 
                        oLista.Add(new ContactoModel()

                        {
                            idContacto = Convert.ToInt32(dr["IdContacto"]), //convirtiendo a entero
                            Nombre = dr["Nombre"].ToString(), //
                            Telefono = dr["Telefono"].ToString(), //
                            Correo = dr["Correo"].ToString() //

                        });
                    {

                    }
                }

            }
            return oLista; //error que tenia en lista de arriba 
        }
        public ContactoModel Obtener(int idContacto)
        {
            var oContacto = new ContactoModel();

            var cn = new Conexion();
            //establecer la cadena de conexion 

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion); //procedimiento almacenado y pasar conexion 

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idContacto", idContacto);
                using (var dr = cmd.ExecuteReader()) //dr se refiere al objeto SqlDataReader, que se utiliza para leer las filas
                                                     //devueltas por una consulta SQL ejecutada en la base de datos.
                {
                    while (dr.Read()) //dr recorre los registros del sp listado 

                    {
                        oContacto.idContacto = Convert.ToInt32(dr["IdContacto"]);//convirtiendo a entero
                        oContacto.Nombre = dr["Nombre"].ToString(); // la o es de objeto 
                        oContacto.Telefono = dr["Telefono"].ToString(); //
                        oContacto.Correo = dr["Correo"].ToString(); //
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
                var cn = new Conexion(); //abro a la conexion
                //establecer la cadena de conexion 

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guadar", conexion); //procedimiento almacenado y pasar conexion 

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Nombre", oContacto.Nombre); // enviando los valores a los parametros 
                    cmd.Parameters.AddWithValue("Correo", oContacto.Correo);
                    cmd.Parameters.AddWithValue("Telefono", oContacto.Telefono);
                    cmd.ExecuteNonQuery();//dr se refiere al objeto SqlDataReader, que se utiliza para leer las filas
                                          //devueltas por una consulta SQL ejecutada en la base de datos.
                    rpta = true;    //soluciono el error en el return 


                }
            }

            catch (Exception e)  // necesario en caso de algun error 
            {
                string error = e.Message; //mensaje de error
                rpta = false; // va dentro

                throw;
            }
            return rpta;


        }
        public bool Editar(ContactoModel oContacto)
        {
            bool rpta;
            try
            {
                var cn = new Conexion(); //abro a la conexion
                //establecer la cadena de conexion 

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion); //procedimiento almacenado y pasar conexion 

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Nombre", oContacto.Nombre); // enviando los valores a los parametros 
                    cmd.Parameters.AddWithValue("Correo", oContacto.Correo);
                    cmd.Parameters.AddWithValue("Telefono", oContacto.Telefono);
                    cmd.ExecuteNonQuery();//dr se refiere al objeto SqlDataReader, que se utiliza para leer las filas
                                          //devueltas por una consulta SQL ejecutada en la base de datos.
                    rpta = true;    //soluciono el error en el return 


                }
            }

            catch (Exception e)  // necesario en caso de algun error 
            {
                string error = e.Message; //mensaje de error en caso de error al editar
                rpta = false; // va dentro

                throw;
            }
            return rpta;
        }
        public bool Eliminar(int idContacto)
        {
            bool rpta;
            try
            {
                var cn = new Conexion(); //abro a la conexion
                //establecer la cadena de conexion 

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion); //procedimiento almacenado y pasar conexion 

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idContacto", idContacto); // enviando los valores a los parametros 

                    cmd.ExecuteNonQuery();//dr se refiere al objeto SqlDataReader, que se utiliza para leer las filas
                                          //devueltas por una consulta SQL ejecutada en la base de datos.
                    rpta = true;    //soluciono el error en el return 


                }
            }

            catch (Exception e)  // necesario en caso de algun error 
            {
                string error = e.Message; //mensaje de error en caso de error al editar
                rpta = false; // va dentro

                throw;
            }
            return rpta;
        }
    }
}
