﻿using System;
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
    /// Lógica de interacción para Baja.xaml
    /// </summary>
    public partial class Baja : Window
    {
        public Baja()
        {
            InitializeComponent();
        }

        private void btBaja_Click(object sender, RoutedEventArgs e)
        {
            Auto a = new Auto();
            int res = a.eliminaAuto(Int16.Parse(tbFolio.Text));

            if (res > 0)
                MessageBox.Show("alumno eliminado");
        }

        private void btRegresar_Click(object sender, RoutedEventArgs e)
        {
            Operaciones o = new Operaciones();
            o.Show();
        }
    }
}
