namespace almacen_telar
{
    partial class bordadoView
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
            this.components = new System.ComponentModel.Container();
            this.dgvBordado = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIdbordado = new System.Windows.Forms.TextBox();
            this.txtParteBordad = new System.Windows.Forms.RichTextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.cbbCortes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTerminado = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fechaSalida = new System.Windows.Forms.DateTimePicker();
            this.fechaEntrada = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumeroPuntadas = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pbIrMaquila = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnSubirfoto = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBordado)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIrMaquila)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBordado
            // 
            this.dgvBordado.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.dgvBordado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBordado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBordado.Location = new System.Drawing.Point(12, 288);
            this.dgvBordado.Name = "dgvBordado";
            this.dgvBordado.Size = new System.Drawing.Size(868, 198);
            this.dgvBordado.TabIndex = 3;
            
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Num. Bordado:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(91, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 18);
            this.label10.TabIndex = 6;
            this.label10.Text = "Núm. Puntadas:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(470, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 18);
            this.label8.TabIndex = 8;
            this.label8.Text = "Parte bordada:";
            // 
            // txtIdbordado
            // 
            this.txtIdbordado.Location = new System.Drawing.Point(217, 40);
            this.txtIdbordado.Name = "txtIdbordado";
            this.txtIdbordado.Size = new System.Drawing.Size(199, 26);
            this.txtIdbordado.TabIndex = 0;
            // 
            // txtParteBordad
            // 
            this.txtParteBordad.Location = new System.Drawing.Point(472, 60);
            this.txtParteBordad.Name = "txtParteBordad";
            this.txtParteBordad.Size = new System.Drawing.Size(200, 52);
            this.txtParteBordad.TabIndex = 2;
            this.txtParteBordad.Text = "";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnEliminar.Location = new System.Drawing.Point(571, 206);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(95, 36);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Visible = false;
            
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAgregar.Location = new System.Drawing.Point(477, 206);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(89, 36);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Aceptar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            
            // 
            // cbbCortes
            // 
            this.cbbCortes.FormattingEnabled = true;
            this.cbbCortes.Location = new System.Drawing.Point(472, 147);
            this.cbbCortes.Name = "cbbCortes";
            this.cbbCortes.Size = new System.Drawing.Size(200, 26);
            this.cbbCortes.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(469, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 18);
            this.label3.TabIndex = 21;
            this.label3.Text = "Cortes en espera:";
            // 
            // btnTerminado
            // 
            this.btnTerminado.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnTerminado.Location = new System.Drawing.Point(672, 205);
            this.btnTerminado.Name = "btnTerminado";
            this.btnTerminado.Size = new System.Drawing.Size(103, 36);
            this.btnTerminado.TabIndex = 6;
            this.btnTerminado.Text = "Terminado";
            this.btnTerminado.UseVisualStyleBackColor = false;
            this.btnTerminado.Visible = false;
            
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(678, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 18);
            this.label4.TabIndex = 23;
            this.label4.Text = "?";
            
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fechaSalida);
            this.groupBox1.Controls.Add(this.fechaEntrada);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNumeroPuntadas);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnTerminado);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbbCortes);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.txtParteBordad);
            this.groupBox1.Controls.Add(this.txtIdbordado);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(791, 250);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bordado";
            // 
            // fechaSalida
            // 
            this.fechaSalida.Location = new System.Drawing.Point(218, 153);
            this.fechaSalida.Name = "fechaSalida";
            this.fechaSalida.Size = new System.Drawing.Size(200, 26);
            this.fechaSalida.TabIndex = 28;
            // 
            // fechaEntrada
            // 
            this.fechaEntrada.Location = new System.Drawing.Point(218, 116);
            this.fechaEntrada.Name = "fechaEntrada";
            this.fechaEntrada.Size = new System.Drawing.Size(200, 26);
            this.fechaEntrada.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Crimson;
            this.label7.Location = new System.Drawing.Point(109, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 18);
            this.label7.TabIndex = 26;
            this.label7.Text = "Fecha salida:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Crimson;
            this.label6.Location = new System.Drawing.Point(92, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 18);
            this.label6.TabIndex = 25;
            this.label6.Text = "Fecha entrada:";
            // 
            // txtNumeroPuntadas
            // 
            this.txtNumeroPuntadas.Location = new System.Drawing.Point(217, 78);
            this.txtNumeroPuntadas.Name = "txtNumeroPuntadas";
            this.txtNumeroPuntadas.Size = new System.Drawing.Size(199, 26);
            this.txtNumeroPuntadas.TabIndex = 24;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            
            // 
            // pbIrMaquila
            // 
            this.pbIrMaquila.Image = global::almacen_telar.Properties.Resources.btnentrar1;
            this.pbIrMaquila.Location = new System.Drawing.Point(382, 14);
            this.pbIrMaquila.Name = "pbIrMaquila";
            this.pbIrMaquila.Size = new System.Drawing.Size(54, 52);
            this.pbIrMaquila.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIrMaquila.TabIndex = 15;
            this.pbIrMaquila.TabStop = false;
            
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(21, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 222);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnImprimir.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Location = new System.Drawing.Point(305, 164);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(121, 36);
            this.btnImprimir.TabIndex = 23;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            // 
            // btnSubirfoto
            // 
            this.btnSubirfoto.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSubirfoto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubirfoto.Location = new System.Drawing.Point(305, 206);
            this.btnSubirfoto.Name = "btnSubirfoto";
            this.btnSubirfoto.Size = new System.Drawing.Size(121, 33);
            this.btnSubirfoto.TabIndex = 22;
            this.btnSubirfoto.Text = "Subir imagen";
            this.btnSubirfoto.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.btnImprimir);
            this.groupBox2.Controls.Add(this.btnSubirfoto);
            this.groupBox2.Controls.Add(this.pbIrMaquila);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(810, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(442, 250);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Subir foto";
            // 
            // bordadoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(1264, 498);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvBordado);
            this.Controls.Add(this.groupBox1);
            this.Name = "bordadoView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bordado";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvBordado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIrMaquila)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBordado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtIdbordado;
        private System.Windows.Forms.RichTextBox txtParteBordad;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ComboBox cbbCortes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTerminado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNumeroPuntadas;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pbIrMaquila;
        private System.Windows.Forms.DateTimePicker fechaSalida;
        private System.Windows.Forms.DateTimePicker fechaEntrada;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnSubirfoto;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}