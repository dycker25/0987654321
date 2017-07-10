namespace almacen_telar
{
    partial class ventaView
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
         this.dgvVentasRealizadas = new System.Windows.Forms.DataGridView();
         this.btnCancelar = new System.Windows.Forms.Button();
         this.btnTerminarVenta = new System.Windows.Forms.Button();
         this.btnAceptar = new System.Windows.Forms.Button();
         this.dataGridView1 = new System.Windows.Forms.DataGridView();
         this.txtCodigo = new System.Windows.Forms.TextBox();
         this.label8 = new System.Windows.Forms.Label();
         this.txtCantidad = new System.Windows.Forms.TextBox();
         this.label9 = new System.Windows.Forms.Label();
         this.cbbIdTalla = new System.Windows.Forms.ComboBox();
         this.label10 = new System.Windows.Forms.Label();
         this.listVentas = new System.Windows.Forms.DataGridView();
         this.btnQuitar = new System.Windows.Forms.Button();
         this.btnModificar = new System.Windows.Forms.Button();
         this.label2 = new System.Windows.Forms.Label();
         this.comboBoxVendedor = new System.Windows.Forms.ComboBox();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dgvVentasRealizadas)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.listVentas)).BeginInit();
         this.groupBox2.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.dgvVentasRealizadas);
         this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.groupBox1.Location = new System.Drawing.Point(604, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(639, 222);
         this.groupBox1.TabIndex = 1;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Ventas realizadas";
         // 
         // dgvVentasRealizadas
         // 
         this.dgvVentasRealizadas.BackgroundColor = System.Drawing.Color.DodgerBlue;
         this.dgvVentasRealizadas.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.dgvVentasRealizadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dgvVentasRealizadas.Location = new System.Drawing.Point(6, 18);
         this.dgvVentasRealizadas.Name = "dgvVentasRealizadas";
         this.dgvVentasRealizadas.Size = new System.Drawing.Size(627, 198);
         this.dgvVentasRealizadas.TabIndex = 18;
         this.dgvVentasRealizadas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVentasRealizadas_CellDoubleClick);
         // 
         // btnCancelar
         // 
         this.btnCancelar.BackColor = System.Drawing.Color.Silver;
         this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnCancelar.Location = new System.Drawing.Point(1152, 240);
         this.btnCancelar.Name = "btnCancelar";
         this.btnCancelar.Size = new System.Drawing.Size(91, 36);
         this.btnCancelar.TabIndex = 19;
         this.btnCancelar.Text = "Cancelar";
         this.btnCancelar.UseVisualStyleBackColor = false;
         this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
         // 
         // btnTerminarVenta
         // 
         this.btnTerminarVenta.BackColor = System.Drawing.Color.Silver;
         this.btnTerminarVenta.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnTerminarVenta.Location = new System.Drawing.Point(1055, 241);
         this.btnTerminarVenta.Name = "btnTerminarVenta";
         this.btnTerminarVenta.Size = new System.Drawing.Size(91, 36);
         this.btnTerminarVenta.TabIndex = 18;
         this.btnTerminarVenta.Text = "Terminar";
         this.btnTerminarVenta.UseVisualStyleBackColor = false;
         this.btnTerminarVenta.Click += new System.EventHandler(this.btnTerminarVenta_Click);
         // 
         // btnAceptar
         // 
         this.btnAceptar.BackColor = System.Drawing.Color.Silver;
         this.btnAceptar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnAceptar.Location = new System.Drawing.Point(570, 40);
         this.btnAceptar.Name = "btnAceptar";
         this.btnAceptar.Size = new System.Drawing.Size(86, 33);
         this.btnAceptar.TabIndex = 8;
         this.btnAceptar.Text = "Agregar";
         this.btnAceptar.UseVisualStyleBackColor = false;
         this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
         // 
         // dataGridView1
         // 
         this.dataGridView1.BackgroundColor = System.Drawing.Color.DodgerBlue;
         this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView1.Location = new System.Drawing.Point(12, 367);
         this.dataGridView1.Name = "dataGridView1";
         this.dataGridView1.Size = new System.Drawing.Size(831, 209);
         this.dataGridView1.TabIndex = 9;
         // 
         // txtCodigo
         // 
         this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.txtCodigo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txtCodigo.Location = new System.Drawing.Point(99, 26);
         this.txtCodigo.Name = "txtCodigo";
         this.txtCodigo.Size = new System.Drawing.Size(154, 26);
         this.txtCodigo.TabIndex = 13;
         this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label8.Location = new System.Drawing.Point(25, 29);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(68, 18);
         this.label8.TabIndex = 12;
         this.label8.Text = "Código:";
         // 
         // txtCantidad
         // 
         this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.txtCantidad.Cursor = System.Windows.Forms.Cursors.No;
         this.txtCantidad.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txtCantidad.Location = new System.Drawing.Point(385, 26);
         this.txtCantidad.Name = "txtCantidad";
         this.txtCantidad.Size = new System.Drawing.Size(154, 26);
         this.txtCantidad.TabIndex = 15;
         this.txtCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyDown);
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label9.Location = new System.Drawing.Point(298, 29);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(81, 18);
         this.label9.TabIndex = 14;
         this.label9.Text = "Cantidad:";
         // 
         // cbbIdTalla
         // 
         this.cbbIdTalla.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.cbbIdTalla.FormattingEnabled = true;
         this.cbbIdTalla.Location = new System.Drawing.Point(99, 62);
         this.cbbIdTalla.Name = "cbbIdTalla";
         this.cbbIdTalla.Size = new System.Drawing.Size(154, 26);
         this.cbbIdTalla.TabIndex = 16;
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label10.Location = new System.Drawing.Point(47, 65);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(46, 18);
         this.label10.TabIndex = 17;
         this.label10.Text = "Talla:";
         // 
         // listVentas
         // 
         this.listVentas.BackgroundColor = System.Drawing.Color.DodgerBlue;
         this.listVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.listVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.listVentas.Location = new System.Drawing.Point(6, 19);
         this.listVentas.Name = "listVentas";
         this.listVentas.Size = new System.Drawing.Size(474, 197);
         this.listVentas.TabIndex = 19;
         this.listVentas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listVentas_CellDoubleClick);
         // 
         // btnQuitar
         // 
         this.btnQuitar.BackColor = System.Drawing.Color.Silver;
         this.btnQuitar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnQuitar.Location = new System.Drawing.Point(519, 30);
         this.btnQuitar.Name = "btnQuitar";
         this.btnQuitar.Size = new System.Drawing.Size(70, 35);
         this.btnQuitar.TabIndex = 20;
         this.btnQuitar.Text = "Quitar";
         this.btnQuitar.UseVisualStyleBackColor = false;
         this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
         // 
         // btnModificar
         // 
         this.btnModificar.BackColor = System.Drawing.Color.Silver;
         this.btnModificar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnModificar.Location = new System.Drawing.Point(662, 40);
         this.btnModificar.Name = "btnModificar";
         this.btnModificar.Size = new System.Drawing.Size(88, 33);
         this.btnModificar.TabIndex = 21;
         this.btnModificar.Text = "Aceptar";
         this.btnModificar.UseVisualStyleBackColor = false;
         this.btnModificar.Visible = false;
         this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.ForeColor = System.Drawing.Color.Crimson;
         this.label2.Location = new System.Drawing.Point(292, 65);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(87, 18);
         this.label2.TabIndex = 22;
         this.label2.Text = "Vendedor:";
         // 
         // comboBoxVendedor
         // 
         this.comboBoxVendedor.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.comboBoxVendedor.FormattingEnabled = true;
         this.comboBoxVendedor.Location = new System.Drawing.Point(385, 62);
         this.comboBoxVendedor.Name = "comboBoxVendedor";
         this.comboBoxVendedor.Size = new System.Drawing.Size(154, 26);
         this.comboBoxVendedor.TabIndex = 23;
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.listVentas);
         this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.groupBox2.Location = new System.Drawing.Point(12, 12);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(490, 222);
         this.groupBox2.TabIndex = 24;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Piezas seleccionadas";
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this.label8);
         this.groupBox3.Controls.Add(this.txtCodigo);
         this.groupBox3.Controls.Add(this.btnModificar);
         this.groupBox3.Controls.Add(this.comboBoxVendedor);
         this.groupBox3.Controls.Add(this.label10);
         this.groupBox3.Controls.Add(this.label2);
         this.groupBox3.Controls.Add(this.cbbIdTalla);
         this.groupBox3.Controls.Add(this.label9);
         this.groupBox3.Controls.Add(this.btnAceptar);
         this.groupBox3.Controls.Add(this.txtCantidad);
         this.groupBox3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.groupBox3.Location = new System.Drawing.Point(12, 252);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(831, 100);
         this.groupBox3.TabIndex = 25;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Agregar a Piezas seleccionadas";
         // 
         // ventas
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.DodgerBlue;
         this.ClientSize = new System.Drawing.Size(1255, 588);
         this.Controls.Add(this.groupBox3);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.btnQuitar);
         this.Controls.Add(this.btnTerminarVenta);
         this.Controls.Add(this.btnCancelar);
         this.Controls.Add(this.dataGridView1);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "ventas";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = " Ventas";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.Load += new System.EventHandler(this.ventas_Load);
         this.groupBox1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dgvVentasRealizadas)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.listVentas)).EndInit();
         this.groupBox2.ResumeLayout(false);
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbbIdTalla;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnTerminarVenta;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvVentasRealizadas;
        private System.Windows.Forms.DataGridView listVentas;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxVendedor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}