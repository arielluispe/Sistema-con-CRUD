using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace sistemaClientes
{
    class BasedeDatos
    {
        SqlConnection conexion = new SqlConnection("server=(local);initial catalog=SISTEMA;integrated security=true");

        public void enviar(String consulta)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = consulta;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public DataSet recibir(String consulta)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = consulta;
            DataSet datos = new DataSet();
            SqlDataAdapter adaptador_de_datos = new SqlDataAdapter(comando);
            adaptador_de_datos.Fill(datos);
            return datos;
        }
    }

}
