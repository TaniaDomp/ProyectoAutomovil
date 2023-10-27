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
    /// Lógica de interacción para Modificar.xaml
    /// </summary>
    public partial class Modificar : Window
    {
        public Modificar()
        {
            InitializeComponent();
        }

        private void btRegresar_Click(object sender, RoutedEventArgs e)
        {
            Operaciones o = new Operaciones();
            o.Show();
            Hide();
        }

        private void btModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Auto a;
                float emisionCO2, emisionNOx, emisionAnualCO2;
                String idAut;
                int res;

                idAut = cbIdAu.SelectedValue.ToString();
                emisionCO2 = float.Parse(txCO2.Text);
                emisionNOx = float.Parse(txNOx.Text);
                emisionAnualCO2 = float.Parse(txCO2Anual.Text);
                a = new Auto(idAut, emisionCO2, emisionNOx, emisionAnualCO2);
                res = a.modificaDatos(a);
                if (res > 0)
                {
                    MessageBox.Show("Modificacion exitosa");
                    Auto au = new Auto();
                    cbIdAu.Items.Clear();
                    au.autosSinDatos(dgDatAu, cbIdAu);
                }
                else
                {
                    MessageBox.Show("Error en la modificacion");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Campos vacíos");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Auto a = new Auto();

            a.autosSinDatos(dgDatAu, cbIdAu);
        }
    }
}
