using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoAutomovil
{
    /// <summary>
    /// Lógica de interacción para Alta.xaml
    /// </summary>
    public partial class Alta : Window
    {
        public Alta()
        {
            InitializeComponent();
        }

        private void btRegresar_Click(object sender, RoutedEventArgs e)
        {
            Operaciones o = new Operaciones();
            o.Show();
        }

        private void btAlta_Click(object sender, RoutedEventArgs e)
        {
            int res, anioModelo;
            string idAut, marca, submarca;
            float emisionCO2, emisionNOx, emisionAnualCO2;

            marca = txtMarca.Text;
            submarca = txtSubmarca.Text;
            anioModelo = int.Parse(txtAnio.Text);
            //el id se genera con las tres primeras letras de la marca + submarca + anio
            idAut = marca.Substring(0, 3) + "-"+ submarca + "-" + anioModelo;
            emisionCO2 = float.Parse(txtECO2.Text);
            emisionNOx = float.Parse(txtNOx.Text);
            emisionAnualCO2 = float.Parse(txtEACO2.Text);
            Auto a = new Auto(idAut, marca, submarca, anioModelo, emisionCO2, emisionNOx, emisionAnualCO2);
            res = a.agregarAuto(a);
            if(res > 0)
            {
                MessageBox.Show("Alta exitosa");
                txtMarca.Text = "";
                txtSubmarca.Text = "";
                txtAnio.Text = "";
                txtECO2.Text = "";
                txtNOx.Text = "";
                txtEACO2.Text = "";
            }
            else
            {
                MessageBox.Show("Error en el alta");
            }
        }
    }
}
