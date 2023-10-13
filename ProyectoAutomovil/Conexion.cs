using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
    }
}
