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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoAutomovil
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int resp;
            resp = Conexion.ProbarContra(txUsuario.Text, txPassword.Text);
            if (resp == 1)
            {
                Operaciones o = new Operaciones();
                o.Show();
            }
            else
            {
                if (resp == 2)

                    MessageBox.Show("Contraseña incorrecta");
                else
                    MessageBox.Show("Usuario no encontrado");

            }
        }
    }
    }


