namespace almacen_telar
{
    partial class loginView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginView));
         this.pbxinicio = new System.Windows.Forms.PictureBox();
         this.txtUsuario = new System.Windows.Forms.TextBox();
         this.txtPassword = new System.Windows.Forms.TextBox();
         ((System.ComponentModel.ISupportInitialize)(this.pbxinicio)).BeginInit();
         this.SuspendLayout();
         // 
         // pbxinicio
         // 
         this.pbxinicio.BackColor = System.Drawing.Color.Transparent;
         this.pbxinicio.BackgroundImage = global::almacen_telar.Properties.Resources.btnentrar1;
         this.pbxinicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.pbxinicio.Location = new System.Drawing.Point(441, 99);
         this.pbxinicio.Name = "pbxinicio";
         this.pbxinicio.Size = new System.Drawing.Size(75, 79);
         this.pbxinicio.TabIndex = 0;
         this.pbxinicio.TabStop = false;
         this.pbxinicio.Click += new System.EventHandler(this.pbxinicio_Click);
         // 
         // txtUsuario
         // 
         this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.txtUsuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txtUsuario.Location = new System.Drawing.Point(184, 98);
         this.txtUsuario.Name = "txtUsuario";
         this.txtUsuario.Size = new System.Drawing.Size(225, 20);
         this.txtUsuario.TabIndex = 1;
         this.txtUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsuario_KeyDown);
         // 
         // txtPassword
         // 
         this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
         this.txtPassword.Location = new System.Drawing.Point(184, 151);
         this.txtPassword.Name = "txtPassword";
         this.txtPassword.Size = new System.Drawing.Size(225, 23);
         this.txtPassword.TabIndex = 2;
         this.txtPassword.UseSystemPasswordChar = true;
         this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
         // 
         // Login
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackgroundImage = global::almacen_telar.Properties.Resources.loginfondo;
         this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.ClientSize = new System.Drawing.Size(550, 279);
         this.Controls.Add(this.txtPassword);
         this.Controls.Add(this.txtUsuario);
         this.Controls.Add(this.pbxinicio);
         this.DoubleBuffered = true;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Login";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Enter += new System.EventHandler(this.pbxinicio_Click);
         ((System.ComponentModel.ISupportInitialize)(this.pbxinicio)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxinicio;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtPassword;
    }
}

