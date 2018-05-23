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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }
        private MySqlConnection cn;
        private Conexion obDatos;
        System.Windows.Forms.Button[] A = new System.Windows.Forms.Button[15];
        //Form load.
        private void Principal_Load(object sender, EventArgs e)
        {
            cn = new MySqlConnection();
            cn.ConnectionString = "SERVER=localhost;DATABASE=rest_valle;UID=root;PASSWORD=;";
            try
            {
                cn.Open();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            estadomesa.Enabled = false;
            capmesa.Enabled = false;
            groupBox3.Visible = false;
            cargar_mesas();
            Cargar_Tables();
        }
        //Menu cerrar ventana principal.
        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Menu Cerrar cesion para cambio de usrario.
        private void cerrarCesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 seguridad = new Form1();
            this.Hide();
            seguridad.ShowDialog();
        }
        //Timer controla el tiempo.
        private void timer1_Tick(object sender, EventArgs e)
        {
            hora.Text = DateTime.Now.ToLongTimeString();
            fecha.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        }
        //Funcion cargar mesas desde un arreglo.
        void cargar_mesas()
        {
            int x = 0;
            int y = 0;
            int p = 0;
            MySqlCommand comando = new MySqlCommand();
            comando.CommandText = "select n,x,y from mesa";
            comando.Connection = cn;
            MySqlDataReader reader;
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                x = Convert.ToInt32(reader[1].ToString());
                y = Convert.ToInt32(reader[2].ToString());
                //intialize new button 
                A[p] = new Button();
                A[p].Size = new System.Drawing.Size(70, 65);
                A[p].BackColor = Color.Gray;
                A[p].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                A[p].Location = new System.Drawing.Point(x, y);
                A[p].Text = reader[0].ToString();
                A[p].Click += new System.EventHandler(this.buttons_Click);
                this.Controls.AddRange(new System.Windows.Forms.Control[] { A[p] });
                p++;
            }
            reader.Close();
        }
        //Funcion para cargar mesas desde BD.
        void Cargar_Tables()
        {
            int i = 0;
            MySqlCommand co = new MySqlCommand();
            co.CommandText = "select id_estado,n from mesa";
            co.Connection = cn;
            MySqlDataReader re;
            re = co.ExecuteReader();
            while (re.Read())
            {
                if (re[0].ToString() == "1")
                {
                    A[i].BackColor = Color.Gray;
                }
                if (re[0].ToString() == "2")
                {
                    A[i].BackColor = Color.Green;
                }
                if (re[0].ToString() == "3")
                {
                    A[i].BackColor = Color.Yellow;
                }
                if (re[0].ToString() == "4")
                {
                    A[i].BackColor = Color.Red;
                }
                i = i + 1;
            }
            re.Close();
            totmesa.Text = "15";
            totmesa.Enabled = false;
            MySqlCommand comando = new MySqlCommand();
            comando.CommandText = "select count(n) from mesa where id_estado='2'";
            comando.Connection = cn;
            MySqlDataReader reader;
            reader = comando.ExecuteReader();
            if (reader.Read())
            {
                totlibre.Text = reader[0].ToString();
            }
            else
            {

            }
            reader.Close();
            comando.CommandText = "select count(n) from mesa where id_estado='4'";
            comando.Connection = cn;
            MySqlDataReader ocup;
            ocup = comando.ExecuteReader();
            if (ocup.Read())
            {
                totocupada.Text = ocup[0].ToString();
            }
            else
            {

            }
            ocup.Close();
            comando.CommandText = "select count(n) from mesa where id_estado='3'";
            comando.Connection = cn;
            MySqlDataReader res;
            res = comando.ExecuteReader();
            if (res.Read())
            {
                totreservada.Text = res[0].ToString();
            }
            else
            {

            }
            res.Close();
            comando.CommandText = "select count(n) from mesa where id_estado='1'";
            comando.Connection = cn;
            MySqlDataReader des;
            des = comando.ExecuteReader();
            if (des.Read())
            {
                totdesactivada.Text = des[0].ToString();
            }
            else
            {

            }
            des.Close();
        }
        //Opciones al dar un click en las mesas.
        private void buttons_Click(Object sender1, EventArgs e1)
        {
            obDatos = new Conexion();
            Button btn = sender1 as Button;
            groupBox3.Visible = false;
            MySqlCommand comando = new MySqlCommand();
            comando.CommandText = "select n,id_estado,capacidad from mesa where n='"+btn.Text+"'";
            comando.Connection = cn;
            MySqlDataReader leer;
            leer = comando.ExecuteReader();
            if (leer.Read())
            {
                Nmesa.Text = leer[0].ToString();
                capmesa.Text = leer[2].ToString();
                if (leer[1].ToString() == "1")
                    estadomesa.Text = "desactivado";
                if (leer[1].ToString() == "2")
                    estadomesa.Text = "libre";
                if (leer[1].ToString() == "3")
                    estadomesa.Text = "reservado";
                if(leer[1].ToString()=="4")
                    estadomesa.Text="ocupado";
            }
            else
            {

            }
            leer.Close();
            //Abilitando las mesas
            if (estado.Text == "habilitar" && lblcargo.Text == "Administrador")
            {
                if (btn.BackColor == Color.Gray)
                {
                    btn.BackColor = Color.Green;
                }
                else
                {
                    btn.BackColor = Color.Gray;
                }
            }
            //Efecto de boton de reservar mesa.
            if (estado.Text == "_" && btn.BackColor == Color.Green)
            {
                groupBox3.Visible = true;
                ac.Text = "nuevo";
                cicliente.Enabled = true;
                nomcliente.Enabled = true;
                apcliente.Enabled = true;
                telfcli.Enabled = true;
                cant.Enabled = true;
                cicliente.Text = "";
                nomcliente.Text = "";
                apcliente.Text = "";
                telfcli.Text="";
                cant.Text = "0";
                reservacancel.Visible = false;
            }
            if (estado.Text == "_" && btn.BackColor == Color.Yellow)
            {
                groupBox3.Visible = true;
                
                MySqlCommand com = new MySqlCommand();
                com.CommandText = "select c.ci,c.nombre,c.apellidos,c.telefono,r.n_personas,r.hora_fin,r.id from cliente c,reserva r,mesa_reserva mr where mr.n='" + btn.Text + "' and mr.id_reserva=r.id and r.ci_cliente=c.ci and mr.id_reserva=(select max(id_reserva) from mesa_reserva where n='"+btn.Text+"')";
                com.Connection = cn;
                MySqlDataReader r;
                r = com.ExecuteReader();
                if (r.Read())
                {
                    cicliente.Enabled = false;
                    nomcliente.Enabled = false;
                    apcliente.Enabled = false;
                    telfcli.Enabled = false;
                    cant.Enabled = false;
                    cicliente.Text = r[0].ToString();
                    nomcliente.Text = r[1].ToString();
                    apcliente.Text = r[2].ToString();
                    telfcli.Text = r[3].ToString();
                    cant.Text = r[4].ToString();
                    id_res.Text = r[6].ToString();
                    DateTime f;
                    f = Convert.ToDateTime(r[5].ToString());
                    HH.Text = f.ToString("HH");
                    MM.Text = f.ToString("min");
                    ac.Text = "up";
                    reservacancel.Visible = true;
                    //idres = Convert.ToString(Convert.ToInt32(leer[0].ToString()) + 1);
                }
                else
                {

                }

                r.Close();
            }

           /* if (btn.BackColor == Color.Green && estado.Text == "agregar")
            {
                this.Refresh();
                Cantidad.Text = Convert.ToString(Convert.ToInt32(Cantidad.Text) - 1);
                obDatos = new Conexion();
                string mr = "insert into mesa_reserva(id_reserva,n) values('" + idres + "','" + btn.Text + "')";
                if (obDatos.insertar(mr))
                {
                    MessageBox.Show("Registro insertado");
                }
                else
                {
                    MessageBox.Show("error al insertar");
                }
                if (Cantidad.Text == "0")
                {
                    Cantidad.Text = "_";
                    idres.Text = "_";
                    estado.Text = "_";
                }
            }*/
        }
        //Menù control de administracion de mesas.
        private void distribucionDeMesasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lblcargo.Text == "Administrador")
            {
                estado.Text = "habilitar";
                this.btnguardar.Visible = true;
                this.ccancelar.Visible = true;
                MessageBox.Show("Por favor pinte las mesas que estaran disponibles...Con un clik sobre la mesa");
            }
            else
            {
                MessageBox.Show("Solo acceso al administrador");
            }
        }
        //Boton guardar configuracion de mesas.
        private void btnguardar_Click(object sender, EventArgs e)
        {
            obDatos = new Conexion();
            for (int i = 0; i < 15; i++)
            {
                if (A[i].BackColor == Color.Green)
                {
                    string campos = "id_estado = '2'";
                    if (obDatos.actualizar("mesa", campos, " n = '" + A[i].Text + "'"))
                    {
                    }
                    else
                    {
                    }
                }
                if (A[i].BackColor == Color.Gray)
                {
                    string campos = "id_estado = '1'";
                    if (obDatos.actualizar("mesa", campos, " n = '" + A[i].Text + "'"))
                    {
                    }
                    else
                    {
                    }
                }
            }
            estado.Text = "_";
            this.btnguardar.Visible = false;
            this.ccancelar.Visible = false;
            Cargar_Tables();
        }
        //Boton cancelar la configuracion de mesas.
        private void ccancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No se guardò la configuracion de mesas");
            this.btnguardar.Visible = false;
            this.ccancelar.Visible = false;
            Cargar_Tables();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            if (ac.Text == "nuevo")
            {
                if (Convert.ToInt32(cant.Text) > Convert.ToInt32(capmesa.Text) || cicliente.Text == "" || nomcliente.Text == "" || apcliente.Text == "" || telfcli.Text == "" || cant.Text == "0" || HH.Text == "" || MM.Text == "")
                {
                    if (cicliente.Text == "" || nomcliente.Text == "" || apcliente.Text == "" || telfcli.Text == "" || cant.Text == "0" || HH.Text == "" || MM.Text == "")
                        MessageBox.Show("Ingrese los datos completos y correctos");
                    else
                        MessageBox.Show("La capacidad de la mesa no es para: " + cant.Text);
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

                    }
                    else
                    {
                        obDatos = new Conexion();
                        string cli = "insert into cliente(ci,nombre,apellidos,telefono) values('" + cicliente.Text + "','" + nomcliente.Text + "','" + apcliente.Text + "','" + telfcli.Text + "')";
                        if (obDatos.insertar(cli))
                        {
                            MessageBox.Show("Registro insertado");
                        }
                        else
                        {
                            MessageBox.Show("error al insertar");
                        }
                    }
                    reader.Close();
                    string idres = "";
                    MySqlCommand com = new MySqlCommand();
                    com.CommandText = "select max(id) from reserva ";
                    com.Connection = cn;
                    MySqlDataReader leer;
                    leer = com.ExecuteReader();
                    if (leer.Read())
                    {
                        idres = Convert.ToString(Convert.ToInt32(leer[0].ToString()) + 1);
                    }
                    else
                    {

                    }
                    leer.Close();
                    obDatos = new Conexion();
                    string bol = "insert into reserva(id,fecha,hora_fin,ci_cliente,ci_empleado,n_personas) values(" + idres + ",curdate(),'" + HH.Text + p.Text + MM.Text + "','" + cicliente.Text + "','" + lblusuario.Text + "','" + cant.Text + "')";
                    if (obDatos.insertar(bol))
                    {
                    }
                    else
                    {
                    }
                    obDatos = new Conexion();
                    string mr = "insert into mesa_reserva(id_reserva,n) values(" + idres + ",'" + Nmesa.Text + "')";
                    if (obDatos.insertar(mr))
                    {
                    }
                    else
                    {
                    }
                    string campos = "id_estado = '3'";
                    if (obDatos.actualizar("mesa", campos, " n = '" + Nmesa.Text + "'"))
                    {

                    }
                    else
                    {
                    }
                    groupBox3.Visible = false;
                }
            }
            if (ac.Text == "up")
            {
                if (Convert.ToInt32(cant.Text) > Convert.ToInt32(capmesa.Text) || cicliente.Text == "" || nomcliente.Text == "" || apcliente.Text == "" || telfcli.Text == "" || cant.Text == "" || HH.Text == "" || MM.Text == "")
                {
                    if (cicliente.Text == "" || nomcliente.Text == "" || apcliente.Text == "" || telfcli.Text == "" || cant.Text == "" || HH.Text == "" || MM.Text == "")
                        MessageBox.Show("Ingrese los datos completos");
                    else
                        MessageBox.Show("La capacidad de la mesa no es para: " + cant.Text);
                }
                else
                {
                    obDatos = new Conexion();
                    string campos = "hora_fin='" + HH.Text + p.Text + MM.Text + "',n_personas=" + cant.Text + "";
                    if (obDatos.actualizar("reserva", campos, " id = " + id_res.Text + ""))
                    {

                    }
                    else
                    {
                    }
                    groupBox3.Visible = false;
                    Cargar_Tables();
                }
            }
            Cargar_Tables();
        }
        private MessageBoxButtons aceptar;
        private void reservacancel_Click(object sender, EventArgs e)
        {
            obDatos = new Conexion();
            aceptar = MessageBoxButtons.OKCancel;
            DialogResult result =
            MessageBox.Show("Cancelarà la sererva... ¿desea seguir con la operacion...?", "Advertencia", aceptar);
            switch (result)
            {
                case DialogResult.OK:
                        string campos = "id_estado = '2'";
                        if (obDatos.actualizar("mesa", campos, " n = '" + Nmesa.Text + "'"))
                        {
                        }
                        else
                        {
                        }
                    break;
            }
            Cargar_Tables();
            groupBox3.Visible = false;
        }

        private void desactivarTodasLasMesasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lblcargo.Text == "Administrador")
            {
                aceptar = MessageBoxButtons.OKCancel;
                DialogResult result =
                MessageBox.Show("Desactivarâ todas las mesas...¿Quieres seguir con esta operacion?...", "Advertencia", aceptar);
                switch (result)
                {
                    case DialogResult.OK:
                        obDatos = new Conexion();
                        for (int i = 0; i < 15; i++)
                        {
                            string campos = "id_estado = '1'";
                            if (obDatos.actualizar("mesa", campos, " n = '" + A[i].Text + "'"))
                            {
                            }
                            else
                            {
                            }
                        }
                        break;
                }
                Cargar_Tables();
            }
            else
            {
                MessageBox.Show("Acceso solo para el administrador");
            }
        }

        private void cicliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "select ci,nombre,apellidos,telefono from cliente where ci='" + cicliente.Text + "'";
                comando.Connection = cn;
                MySqlDataReader reader;
                reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    nomcliente.Text = reader[1].ToString();
                    apcliente.Text = reader[2].ToString();
                    telfcli.Text=reader[3].ToString();
                }
                else
                {

                }
                reader.Close();
            }
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            aceptar = MessageBoxButtons.OKCancel;
            DialogResult result =
            MessageBox.Show("Cancelar reserva??...", "Advertencia", aceptar);
            switch (result)
            {
                case DialogResult.OK:
                    groupBox3.Visible = false;
                    break;
            }
        }

        private void verClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lblcargo.Text == "Administrador")
            {
                Clientes cl = new Clientes();
                cl.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso solo para el administrador");
            }
        }

        private void verificarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lblcargo.Text == "Administrador")
            {
                Empleado emp=new Empleado();
                emp.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso solo para el administrador");
            }
        }

        private void cant_KeyPress(object sender, KeyPressEventArgs e)
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

        private void HH_KeyPress(object sender, KeyPressEventArgs e)
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

        private void MM_KeyPress(object sender, KeyPressEventArgs e)
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
