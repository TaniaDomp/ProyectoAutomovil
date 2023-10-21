using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProyectoAutomovil
{
    class Conexion
    {
        public static SqlConnection agregarConexion()
        {
            SqlConnection cnn;
            try
            {
                cnn = new SqlConnection("Data Source=LAPTOP-5V05KTCM;Initial Catalog=DBPAuto;Integrated Security=True");
                cnn.Open();
                //mensaje para revisar si la conexion a la base fue exitosa
                //MessageBox.Show("conectado");
            }
            catch (Exception ex)
            {
                cnn = null;
                //mensaje para revisar si la conexion a la base tuvo problemas 
                //MessageBox.Show("no se pudo conectar" + ex);
            }
            return cnn;
        }
        public static int ProbarContra(String usu, String pwd)
        {
            int resp = 0;
            SqlConnection con;
            SqlDataReader dr;
            SqlCommand cmd;
            try
            {
                con = agregarConexion();
                cmd = new SqlCommand(String.Format("select contrasenia from usuarioAdmin where nombreUsu='{0}'", usu), con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                    if (dr.GetString(0).Equals(pwd))
                        resp = 1;// correcto todo

                    else
                        resp = 2;//contraseña incorrecta
                else
                    resp = 3;//usuario no encontrado
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);

            }

            return resp;
        }

    }
}
