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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }
        private MySqlConnection cn;
        private MessageBoxButtons aceptar;
        Conexion obDatos;
        DataSet resultados = new DataSet();
        DataView mifiltro;
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
            this.leer_datos("select * from cliente", ref resultados, "cliente");
            this.mifiltro = ((DataTable)resultados.Tables["cliente"]).DefaultView;
            this.dataGridView1.DataSource = mifiltro;
        }

        private void Clientes_Load(object sender, EventArgs e)
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
            int filaseleccionada = dataGridView1.CurrentRow.Index;
            cicliente.Text = Convert.ToString(dataGridView1.Rows[filaseleccionada].Cells[0].Value);
            MySqlCommand comando = new MySqlCommand();
            comando.CommandText = "select ci,nombre,apellidos,telefono from cliente where ci='" +cicliente.Text+"'";
            comando.Connection = cn;
            MySqlDataReader reader;
            reader = comando.ExecuteReader();
            if (reader.Read())
            {
                cicliente.Enabled = false;
                nomcliente.Text = reader[1].ToString();
                apcliente.Text = reader[2].ToString();
                telfcli.Text = reader[3].ToString();
            }
            else
            {
                MessageBox.Show("el cliente" + reader[0].ToString() + " no existe");

            }
            reader.Close();
        }
        void vaciar()
        {
            cicliente.Text = "";
            nomcliente.Text = "";
            telfcli.Text = "";
            apcliente.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            obDatos = new Conexion();
            if (cicliente.Text == "" || nomcliente.Text == "" || apcliente.Text == "" || telfcli.Text == "")
            {
                MessageBox.Show("Ingrese todos los datos requeridos");
            }
            else
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "select ci,nombre,apellidos,telefono from cliente where ci='" + cicliente.Text + "'";
                comando.Connection = cn;
                MySqlDataReader reader;
                reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    string campos = "nombre='" + nomcliente.Text + "',apellidos='" + apcliente.Text + "',telefono='" + telfcli.Text + "'";
                    if (obDatos.actualizar("cliente", campos, " ci = '" + cicliente.Text + "'"))
                    {

                    }
                    else
                    {
                    }
                }
                else
                {
                    obDatos = new Conexion();
                    string cli = "insert into cliente(ci,nombre,apellidos,telefono) values('" + cicliente.Text + "','" + nomcliente.Text + "','" + apcliente.Text + "','" + telfcli.Text + "')";
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

        private void button3_Click(object sender, EventArgs e)
        {
            cicliente.Enabled = true;
            vaciar();
        }

        private void telfcli_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cicliente_KeyPress(object sender, KeyPressEventArgs e)
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

        private void nomcliente_KeyPress(object sender, KeyPressEventArgs e)
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

        private void apcliente_KeyPress(object sender, KeyPressEventArgs e)
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
