namespace Proyecto_Scrum
{
    partial class Empleado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ciemp = new System.Windows.Forms.TextBox();
            this.nomemp = new System.Windows.Forms.TextBox();
            this.apemp = new System.Windows.Forms.TextBox();
            this.contraseña = new System.Windows.Forms.TextBox();
            this.telfemp = new System.Windows.Forms.TextBox();
            this.diremp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cargoemp = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(536, 329);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(106, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(204, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Buscar CI";
            // 
            // ciemp
            // 
            this.ciemp.Location = new System.Drawing.Point(638, 63);
            this.ciemp.Name = "ciemp";
            this.ciemp.Size = new System.Drawing.Size(162, 20);
            this.ciemp.TabIndex = 12;
            this.ciemp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ciemp_KeyPress);
            // 
            // nomemp
            // 
            this.nomemp.Location = new System.Drawing.Point(642, 112);
            this.nomemp.Name = "nomemp";
            this.nomemp.Size = new System.Drawing.Size(158, 20);
            this.nomemp.TabIndex = 13;
            this.nomemp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nomemp_KeyPress);
            // 
            // apemp
            // 
            this.apemp.Location = new System.Drawing.Point(642, 155);
            this.apemp.Name = "apemp";
            this.apemp.Size = new System.Drawing.Size(158, 20);
            this.apemp.TabIndex = 14;
            this.apemp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.apemp_KeyPress);
            // 
            // contraseña
            // 
            this.contraseña.Location = new System.Drawing.Point(654, 230);
            this.contraseña.Name = "contraseña";
            this.contraseña.Size = new System.Drawing.Size(146, 20);
            this.contraseña.TabIndex = 16;
            // 
            // telfemp
            // 
            this.telfemp.Location = new System.Drawing.Point(645, 270);
            this.telfemp.Name = "telfemp";
            this.telfemp.Size = new System.Drawing.Size(155, 20);
            this.telfemp.TabIndex = 17;
            this.telfemp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.telfemp_KeyPress);
            // 
            // diremp
            // 
            this.diremp.Location = new System.Drawing.Point(645, 308);
            this.diremp.Name = "diremp";
            this.diremp.Size = new System.Drawing.Size(155, 20);
            this.diremp.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(587, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "CI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(587, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(587, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Apellidos";
            // 
            // cargoemp
            // 
            this.cargoemp.FormattingEnabled = true;
            this.cargoemp.Items.AddRange(new object[] {
            "Administrador",
            "Mesero",
            "Cosinero",
            "Limpieza"});
            this.cargoemp.Location = new System.Drawing.Point(654, 195);
            this.cargoemp.Name = "cargoemp";
            this.cargoemp.Size = new System.Drawing.Size(146, 21);
            this.cargoemp.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(587, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Cargo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(587, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Contraseña";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(587, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Telefono";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(587, 311);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Direccion";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(589, 355);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Vaciar casilleros";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(725, 355);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 28;
            this.button2.Text = "Gurdar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Empleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 409);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cargoemp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.diremp);
            this.Controls.Add(this.telfemp);
            this.Controls.Add(this.contraseña);
            this.Controls.Add(this.apemp);
            this.Controls.Add(this.nomemp);
            this.Controls.Add(this.ciemp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Empleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empleado";
            this.Load += new System.EventHandler(this.Empleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ciemp;
        private System.Windows.Forms.TextBox nomemp;
        private System.Windows.Forms.TextBox apemp;
        private System.Windows.Forms.TextBox contraseña;
        private System.Windows.Forms.TextBox telfemp;
        private System.Windows.Forms.TextBox diremp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cargoemp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}