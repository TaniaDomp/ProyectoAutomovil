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
                //Aqui cada quien tiene que poner su direccion de la base de datos guardada en su computadora
                //esta es la mia
                cnn = new SqlConnection("Data Source=LAPTOP-5V05KTCM;Initial Catalog=DBPAuto;Integrated Security=True");
                cnn.Open();
                MessageBox.Show("conectado");
            }
            catch (Exception ex)
            {
                cnn = null;
                MessageBox.Show("no se pudo conectar" + ex);
            }
            return cnn;
        }
    }
}
