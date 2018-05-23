using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proyecto_Scrum
{
    public partial class Empleado : Form
    {
        public Empleado()
        {
            InitializeComponent();
        }
        private MySqlConnection cn;
        private MessageBoxButtons aceptar;
        Conexion obDatos;
        DataSet resultados = new DataSet();
        DataView mifiltro;
        private void Empleado_Load(object sender, EventArgs e)
        {
            //Constructor de la conexion.
            cn = new MySqlConnection();
            //Definir la cadena de coneccion.
            cn.ConnectionString = "SERVER=localhost;DATABASE=rest_valle;UID=root;PASSWORD=;";
            //Abrir la conexion.
            try
            {
                cn.Open();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            cargar_dataGrid();
        }
        public void leer_datos(string query, ref DataSet dstprincipal, string tabla)
        {
            try
            {
                string cadena = "SERVER=localhost;DATABASE=rest_valle;UID=root;PASSWORD=;";
                cn = new MySqlConnection(cadena);
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dstprincipal, tabla);
                da.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void cargar_dataGrid()
        {
            while (dataGridView1.RowCount > 1)
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
            this.leer_datos("select * from empleado", ref resultados, "empleado");
            this.mifiltro = ((DataTable)resultados.Tables["empleado"]).DefaultView;
            this.dataGridView1.DataSource = mifiltro;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string salida_datos = "";
            string[] palabras_busqueda = textBox1.Text.Split(' ');
            foreach (string palabra in palabras_busqueda)
            {
                if (salida_datos.Length == 0)
                {
                    salida_datos = "(ci LIKE '*" + palabra + "*')";
                }
                else
                {
                    salida_datos += "and (ci LIKE '*" + palabra + "*')";
                }
            }
            this.mifiltro.RowFilter = salida_datos;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int filaseleccionada = dataGridView1.CurrentRow.Index;
            ciemp.Text = Convert.ToString(dataGridView1.Rows[filaseleccionada].Cells[0].Value);
            MySqlCommand comando = new MySqlCommand();
            comando.CommandText = "select ci,nombre,apellidos,cargo,contraseña,telefono,direccion from empleado where ci='" + ciemp.Text + "'";
            comando.Connection = cn;
            MySqlDataReader reader;
            reader = comando.ExecuteReader();
            if (reader.Read())
            {
                ciemp.Enabled = false;
                nomemp.Text = reader[1].ToString();
                apemp.Text = reader[2].ToString();
                cargoemp.Text = reader[3].ToString();
                contraseña.Text = reader[4].ToString();
                telfemp.Text = reader[5].ToString();
                diremp.Text = reader[6].ToString();
            }
            else
            {
                MessageBox.Show("el cliente" + reader[0].ToString() + " no existe");

            }
            reader.Close();
        }
        void vaciar()
        {
            ciemp.Text = "";
            nomemp.Text = "";
            apemp.Text = "";
            cargoemp.Text = "";
            contraseña.Text = "";
            telfemp.Text = "";
            diremp.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            obDatos = new Conexion();
            if (ciemp.Text == "" || nomemp.Text == "" || apemp.Text == "" || cargoemp.Text == ""||telfemp.Text==""||diremp.Text=="")
            {
                MessageBox.Show("Ingrese todos los datos requeridos");
            }
            else
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "select ci,nombre,apellidos,telefono from empleado where ci='" + ciemp.Text + "'";
                comando.Connection = cn;
                MySqlDataReader reader;
                reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    string campos = "nombre='" + nomemp.Text + "',apellidos='" + apemp.Text + "',cargo='"+cargoemp.Text+"',contraseña='"+contraseña.Text+"',telefono='"+telfemp.Text+"',direccion='"+diremp.Text+"'";
                    if (obDatos.actualizar("empleado", campos, " ci = '" + ciemp.Text + "'"))
                    {

                    }
                    else
                    {
                    }
                }
                else
                {
                    obDatos = new Conexion();
                    string cli = "insert into empleado(ci,nombre,apellidos,cargo,contraseña,telefono,direccion) values('" + ciemp.Text + "','" + nomemp.Text + "','" + apemp.Text + "','" + cargoemp.Text + "','"+contraseña.Text+"','"+telfemp.Text+"','"+diremp.Text+"')";
                    if (obDatos.insertar(cli))
                    {
                    }
                    else
                    {
                    }
                }
                vaciar();
                cargar_dataGrid();
                reader.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ciemp.Enabled = true;
            vaciar();
        }

        private void ciemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void telfemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void nomemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void apemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
    }
}
