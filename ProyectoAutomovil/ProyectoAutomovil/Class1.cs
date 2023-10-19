using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAutomovil
{
    internal class Class1
    {
        //atributos 
        public String IDAut { get; set; }
        public String marca { get; set; }
        public String subMarca { get; set; }
        public Int16 anio { get; set; }
        public float emisionCO2 { get; set; }
        public float emisionNOx {  get; set; }
        public float emisionCO2Anual { get; set; }

        public Class1()
        {
        }

        public Class1(string IDAut, string marca, string subMarca, short anio, float emisionCO2, float emisionNOx, float emisionCO2Anual)
        {
            this.IDAut = IDAut;
            this.marca = marca;
            this.subMarca = subMarca;
            this.anio = anio;
            this.emisionCO2 = emisionCO2;
            this.emisionNOx = emisionNOx;
            this.emisionCO2Anual = emisionCO2Anual;
        }

        public Class1(string IDAut)
        {
            this.IDAut = IDAut;
        }

        public List<Class1> buscarCoche()
        {
            List<Class1> lis = new List<Class1>();
            Class1 a;
            SqlConnection con = Conexion.agregarConexion();
            SqlCommand cmd = new SqlCommand(String.Format("select marca, submarca, AnioModelo, EmisionCO2, EmisionNOx, EmisionCO2Anual from Automovil where idAut like '%{0}%'", IDAut), con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                a = new Class1();
                a.marca = dr.GetString(0);
                a.subMarca = dr.GetString(1);
                a.anio = dr.GetInt16(2);
                a.emisionCO2 = dr.GetFloat(3);
                a.emisionNOx = dr.GetFloat(4);
                a.emisionCO2Anual = dr.GetFloat(5);
                lis.Add(a);
            }
            con.Close();
            return lis;
        }
    }
}
