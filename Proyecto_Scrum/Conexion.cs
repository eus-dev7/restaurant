using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;

namespace Proyecto_Scrum
{
    class Conexion
    {
        private string cadena = "SERVER=localhost;DATABASE=rest_valle;UID=root;PASSWORD=;";
        public MySqlConnection cn;
        private MySqlCommandBuilder cmb;
        public DataSet ds = new DataSet();
        public MySqlDataAdapter da;
        public MySqlCommand comando;
        private void conectar()
        {
            cn = new MySqlConnection(cadena);
        }

        public Conexion()
        {
            conectar();
        }
        //consultar
        public void consultar(string sql, string tabla)
        {
            ds.Tables.Clear();
            da = new MySqlDataAdapter(sql, cn);
            cmb = new MySqlCommandBuilder(da);
            da.Fill(ds, tabla);
        }
        //elimminar
        public bool eliminar(string tabla, string condicion)
        {
            cn.Open();
            string sql = "delete from " + tabla + " where " + condicion;
            comando = new MySqlCommand(sql, cn);
            int i = comando.ExecuteNonQuery();
            cn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //actualizar
        public bool actualizar(string tabla, string campos, string condicion)
        {
            cn.Open();
            string sql = "update " + tabla + " set " + campos + " where " + condicion;
            comando = new MySqlCommand(sql, cn);
            int i = comando.ExecuteNonQuery();
            cn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable consultar2(string tabla)
        {
            string sql = "select *  from " + tabla;
            da = new MySqlDataAdapter(sql, cn);
            DataSet dts = new DataSet();
            da.Fill(dts, tabla);
            DataTable dt = new DataTable();
            dt = dts.Tables[tabla];
            return dt;
        }
        //insertar
        public bool insertar(string sql)
        {
            cn.Open();
            comando = new MySqlCommand(sql, cn);
            int i = comando.ExecuteNonQuery();
            cn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
