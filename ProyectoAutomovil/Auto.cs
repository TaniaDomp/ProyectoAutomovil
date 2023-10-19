using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAutomovil
{
    class Auto
    {
        //atributos
        public String idAut { get; set; }
        public String marca { get; set; }
        public String submarca { get; set; }
        public int anioModelo { get; set; }
        public float emisionCO2 { get; set; }
        public float emisionNOx { get; set; }
        public float emisionAnualCO2 { get; set; }

        public Auto()
        {
        }

        public Auto(string idAut)
        {
            this.idAut = idAut;
        }

        public Auto(string idAut, string marca, string submarca, int anioModelo, float emisionCO2, float emisionNOx, float emisionAnualCO2)
        {
            this.idAut = idAut;
            this.marca = marca;
            this.submarca = submarca;
            this.anioModelo = anioModelo;
            this.emisionCO2 = emisionCO2;
            this.emisionNOx = emisionNOx;
            this.emisionAnualCO2 = emisionAnualCO2;
        }

        public int agregarAuto(Auto a)
        {
            int res = 0;
            SqlConnection con;
            SqlCommand cmd;

            con = Conexion.agregarConexion();
            cmd = new SqlCommand(String.Format("INSERT INTO Automovil (idAut, marca, submarca, anioModelo, emisionCO2, emisionNOx, emisionAnualCO2) VALUES ('{0}', '{1}', '{2}', {3}, {4}, {5}, {6})", a.idAut, a.marca, a.submarca, a.anioModelo, a.emisionCO2, a.emisionNOx, a.emisionAnualCO2), con);
            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int eliminaAuto(String idA)
        {
            int res = 0;
            SqlConnection con;
            con = Conexion.agregarConexion();
            SqlCommand cmd = new SqlCommand(String.Format(("delete from Automovil where idAut='{0}'"), idA), con);
            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public List<Auto> buscarCoche(Auto au)
        {
            List<Auto> lis = new List<Auto>();
            Auto a;
            SqlConnection con = Conexion.agregarConexion();
            SqlCommand cmd = new SqlCommand(String.Format("select marca, submarca, AnioModelo, emisionCO2, emisionNOx, emisionAnualCO2 from Automovil where idAut = '{0}'", au.idAut), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                a = new Auto();
                a.idAut = au.idAut;
                a.marca = dr.GetString(0);
                a.submarca = dr.GetString(1);
                a.anioModelo = dr.GetInt32(2);
                a.emisionCO2 = (float)dr.GetDouble(3);
                a.emisionNOx = (float)dr.GetDouble(4);
                a.emisionAnualCO2 = (float)dr.GetDouble(5);
                lis.Add(a);
            }
            con.Close();
            return lis;
        }
    }
}
