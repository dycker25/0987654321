namespace almacen_telar
{
    partial class maquilaView
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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
         this.comboBox1 = new System.Windows.Forms.ComboBox();
         this.label4 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.btnTerminado = new System.Windows.Forms.Button();
         this.cbbLugarEntrega = new System.Windows.Forms.ComboBox();
         this.cbbCorte = new System.Windows.Forms.ComboBox();
         this.btneliminar = new System.Windows.Forms.Button();
         this.btnagregar = new System.Windows.Forms.Button();
         this.txtIdmaquila = new System.Windows.Forms.TextBox();
         this.label7 = new System.Windows.Forms.Label();
         this.label9 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.dgvMaquila = new System.Windows.Forms.DataGridView();
         this.imagenIR = new System.Windows.Forms.PictureBox();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.btnimprimirmaquila = new System.Windows.Forms.Button();
         this.btnsubirfotomaq = new System.Windows.Forms.Button();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dgvMaquila)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.imagenIR)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.groupBox2.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.textBox1);
         this.groupBox1.Controls.Add(this.label5);
         this.groupBox1.Controls.Add(this.dateTimePicker1);
         this.groupBox1.Controls.Add(this.comboBox1);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.btnTerminado);
         this.groupBox1.Controls.Add(this.cbbLugarEntrega);
         this.groupBox1.Controls.Add(this.cbbCorte);
         this.groupBox1.Controls.Add(this.btneliminar);
         this.groupBox1.Controls.Add(this.btnagregar);
         this.groupBox1.Controls.Add(this.txtIdmaquila);
         this.groupBox1.Controls.Add(this.label7);
         this.groupBox1.Controls.Add(this.label9);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.groupBox1.Location = new System.Drawing.Point(12, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(838, 272);
         this.groupBox1.TabIndex = 1;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Maquila";
         // 
         // textBox1
         // 
         this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.textBox1.Location = new System.Drawing.Point(198, 174);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(200, 26);
         this.textBox1.TabIndex = 26;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(111, 174);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(81, 18);
         this.label5.TabIndex = 25;
         this.label5.Text = "Cantidad:";
         // 
         // dateTimePicker1
         // 
         this.dateTimePicker1.Location = new System.Drawing.Point(576, 100);
         this.dateTimePicker1.Name = "dateTimePicker1";
         this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
         this.dateTimePicker1.TabIndex = 24;
         // 
         // comboBox1
         // 
         this.comboBox1.FormattingEnabled = true;
         this.comboBox1.Location = new System.Drawing.Point(576, 60);
         this.comboBox1.Name = "comboBox1";
         this.comboBox1.Size = new System.Drawing.Size(200, 26);
         this.comboBox1.TabIndex = 23;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.ForeColor = System.Drawing.Color.Crimson;
         this.label4.Location = new System.Drawing.Point(450, 103);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(120, 18);
         this.label4.TabIndex = 22;
         this.label4.Text = "Fecha entrega:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.ForeColor = System.Drawing.Color.Crimson;
         this.label3.Location = new System.Drawing.Point(418, 63);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(152, 18);
         this.label3.TabIndex = 21;
         this.label3.Text = "Nombre maquilero:";
         // 
         // btnTerminado
         // 
         this.btnTerminado.BackColor = System.Drawing.Color.LightSkyBlue;
         this.btnTerminado.Location = new System.Drawing.Point(712, 226);
         this.btnTerminado.Name = "btnTerminado";
         this.btnTerminado.Size = new System.Drawing.Size(107, 34);
         this.btnTerminado.TabIndex = 7;
         this.btnTerminado.Text = "Terminado";
         this.btnTerminado.UseVisualStyleBackColor = false;
         this.btnTerminado.Visible = false;
         this.btnTerminado.Click += new System.EventHandler(this.btnTerminado_Click);
         // 
         // cbbLugarEntrega
         // 
         this.cbbLugarEntrega.FormattingEnabled = true;
         this.cbbLugarEntrega.Items.AddRange(new object[] {
            "Maquila1",
            "Maquila2",
            "Maquila3",
            "Maquila4",
            "Maquila5",
            "Maquila6",
            "Maquila7"});
         this.cbbLugarEntrega.Location = new System.Drawing.Point(198, 95);
         this.cbbLugarEntrega.Name = "cbbLugarEntrega";
         this.cbbLugarEntrega.Size = new System.Drawing.Size(200, 26);
         this.cbbLugarEntrega.TabIndex = 20;
         // 
         // cbbCorte
         // 
         this.cbbCorte.FormattingEnabled = true;
         this.cbbCorte.Location = new System.Drawing.Point(198, 134);
         this.cbbCorte.Name = "cbbCorte";
         this.cbbCorte.Size = new System.Drawing.Size(200, 26);
         this.cbbCorte.TabIndex = 19;
         // 
         // btneliminar
         // 
         this.btneliminar.BackColor = System.Drawing.Color.LightSkyBlue;
         this.btneliminar.Location = new System.Drawing.Point(616, 226);
         this.btneliminar.Name = "btneliminar";
         this.btneliminar.Size = new System.Drawing.Size(90, 34);
         this.btneliminar.TabIndex = 4;
         this.btneliminar.Text = "Eliminar";
         this.btneliminar.UseVisualStyleBackColor = false;
         this.btneliminar.Visible = false;
         this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
         // 
         // btnagregar
         // 
         this.btnagregar.BackColor = System.Drawing.Color.LightSkyBlue;
         this.btnagregar.Location = new System.Drawing.Point(514, 226);
         this.btnagregar.Name = "btnagregar";
         this.btnagregar.Size = new System.Drawing.Size(96, 34);
         this.btnagregar.TabIndex = 2;
         this.btnagregar.Text = "Agregar";
         this.btnagregar.UseVisualStyleBackColor = false;
         this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
         // 
         // txtIdmaquila
         // 
         this.txtIdmaquila.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.txtIdmaquila.Location = new System.Drawing.Point(198, 57);
         this.txtIdmaquila.Name = "txtIdmaquila";
         this.txtIdmaquila.Size = new System.Drawing.Size(200, 26);
         this.txtIdmaquila.TabIndex = 9;
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(114, 134);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(76, 18);
         this.label7.TabIndex = 8;
         this.label7.Text = "Bordado:";
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(48, 99);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(137, 18);
         this.label9.TabIndex = 6;
         this.label9.Text = "Lugar de Entrega:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(114, 60);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(73, 18);
         this.label2.TabIndex = 0;
         this.label2.Text = "Maquila:";
         // 
         // dgvMaquila
         // 
         this.dgvMaquila.BackgroundColor = System.Drawing.Color.RoyalBlue;
         this.dgvMaquila.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.dgvMaquila.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dgvMaquila.Location = new System.Drawing.Point(12, 313);
         this.dgvMaquila.Name = "dgvMaquila";
         this.dgvMaquila.Size = new System.Drawing.Size(919, 201);
         this.dgvMaquila.TabIndex = 2;
         this.dgvMaquila.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaquila_CellDoubleClick);
         // 
         // imagenIR
         // 
         this.imagenIR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
         this.imagenIR.Image = global::almacen_telar.Properties.Resources.btnentrar1;
         this.imagenIR.Location = new System.Drawing.Point(356, 19);
         this.imagenIR.Name = "imagenIR";
         this.imagenIR.Size = new System.Drawing.Size(54, 52);
         this.imagenIR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.imagenIR.TabIndex = 16;
         this.imagenIR.TabStop = false;
         this.imagenIR.Click += new System.EventHandler(this.pbIrMaquila_Click);
         // 
         // pictureBox1
         // 
         this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.pictureBox1.Location = new System.Drawing.Point(21, 20);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(233, 240);
         this.pictureBox1.TabIndex = 24;
         this.pictureBox1.TabStop = false;
         // 
         // btnimprimirmaquila
         // 
         this.btnimprimirmaquila.BackColor = System.Drawing.Color.LightSkyBlue;
         this.btnimprimirmaquila.Location = new System.Drawing.Point(292, 183);
         this.btnimprimirmaquila.Name = "btnimprimirmaquila";
         this.btnimprimirmaquila.Size = new System.Drawing.Size(121, 38);
         this.btnimprimirmaquila.TabIndex = 23;
         this.btnimprimirmaquila.Text = "Imprimir";
         this.btnimprimirmaquila.UseVisualStyleBackColor = false;
         // 
         // btnsubirfotomaq
         // 
         this.btnsubirfotomaq.BackColor = System.Drawing.Color.LightSkyBlue;
         this.btnsubirfotomaq.Location = new System.Drawing.Point(292, 227);
         this.btnsubirfotomaq.Name = "btnsubirfotomaq";
         this.btnsubirfotomaq.Size = new System.Drawing.Size(121, 39);
         this.btnsubirfotomaq.TabIndex = 22;
         this.btnsubirfotomaq.Text = "Subir imagen";
         this.btnsubirfotomaq.UseVisualStyleBackColor = false;
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.pictureBox1);
         this.groupBox2.Controls.Add(this.btnimprimirmaquila);
         this.groupBox2.Controls.Add(this.imagenIR);
         this.groupBox2.Controls.Add(this.btnsubirfotomaq);
         this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.groupBox2.Location = new System.Drawing.Point(857, 12);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(427, 272);
         this.groupBox2.TabIndex = 25;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Subir foto";
         // 
         // maquila
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.RoyalBlue;
         this.ClientSize = new System.Drawing.Size(1296, 535);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.dgvMaquila);
         this.Controls.Add(this.groupBox1);
         this.Name = "maquila";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Maquila";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dgvMaquila)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.imagenIR)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.groupBox2.ResumeLayout(false);
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIdmaquila;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.Button btnTerminado;
        private System.Windows.Forms.ComboBox cbbCorte;
        private System.Windows.Forms.ComboBox cbbLugarEntrega;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.DataGridView dgvMaquila;
        private System.Windows.Forms.PictureBox imagenIR;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnimprimirmaquila;
        private System.Windows.Forms.Button btnsubirfotomaq;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}