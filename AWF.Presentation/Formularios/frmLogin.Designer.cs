namespace AWF.Presentation.Formularios
{
    partial class frmLogin
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txbUsuario = new TextBox();
            txbPassword = new TextBox();
            linkOlvidePassword = new LinkLabel();
            btnEntrar = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.DarkSeaGreen;
            label1.Font = new Font("JetBrains Mono", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(270, 307);
            label1.TabIndex = 0;
            label1.Text = "Sistema de venta";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.ButtonFace;
            label2.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.ImageAlign = ContentAlignment.TopLeft;
            label2.Location = new Point(320, 9);
            label2.Name = "label2";
            label2.Size = new Size(183, 51);
            label2.TabIndex = 1;
            label2.Text = "Iniciar Sesion";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.BackColor = SystemColors.ButtonFace;
            label3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.ImageAlign = ContentAlignment.TopLeft;
            label3.Location = new Point(285, 77);
            label3.Name = "label3";
            label3.Size = new Size(109, 24);
            label3.TabIndex = 2;
            label3.Text = "Usuario:";
            // 
            // label4
            // 
            label4.BackColor = SystemColors.ButtonFace;
            label4.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.ImageAlign = ContentAlignment.TopLeft;
            label4.Location = new Point(285, 151);
            label4.Name = "label4";
            label4.Size = new Size(109, 24);
            label4.TabIndex = 3;
            label4.Text = "Contraseña:";
            // 
            // txbUsuario
            // 
            txbUsuario.Location = new Point(285, 104);
            txbUsuario.Name = "txbUsuario";
            txbUsuario.Size = new Size(246, 23);
            txbUsuario.TabIndex = 4;
            // 
            // txbPassword
            // 
            txbPassword.Location = new Point(285, 178);
            txbPassword.Name = "txbPassword";
            txbPassword.Size = new Size(246, 23);
            txbPassword.TabIndex = 5;
            // 
            // linkOlvidePassword
            // 
            linkOlvidePassword.AutoSize = true;
            linkOlvidePassword.Location = new Point(413, 267);
            linkOlvidePassword.Name = "linkOlvidePassword";
            linkOlvidePassword.Size = new Size(118, 15);
            linkOlvidePassword.TabIndex = 6;
            linkOlvidePassword.TabStop = true;
            linkOlvidePassword.Text = "Olvido su contraseña";
            linkOlvidePassword.LinkClicked += linkOlvidePassword_LinkClicked;
            // 
            // btnEntrar
            // 
            btnEntrar.BackColor = Color.White;
            btnEntrar.Cursor = Cursors.Hand;
            btnEntrar.FlatStyle = FlatStyle.Flat;
            btnEntrar.Location = new Point(440, 224);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(91, 26);
            btnEntrar.TabIndex = 7;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = false;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.DarkRed;
            btnSalir.Location = new Point(285, 224);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(91, 26);
            btnSalir.TabIndex = 8;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(543, 307);
            Controls.Add(btnSalir);
            Controls.Add(btnEntrar);
            Controls.Add(linkOlvidePassword);
            Controls.Add(txbPassword);
            Controls.Add(txbUsuario);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmLogin";
            Load += frmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txbUsuario;
        private TextBox txbPassword;
        private LinkLabel linkOlvidePassword;
        private Button btnEntrar;
        private Button btnSalir;
    }
}