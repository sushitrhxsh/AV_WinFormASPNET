namespace AWF.Presentation.Formularios
{
    partial class frmActualizarClave
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
            txbClave = new TextBox();
            txbNuevaClave = new TextBox();
            lblValidacion = new Label();
            btnGuardar = new Button();
            btnVolver = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 0;
            label1.Text = "Contraseña:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 61);
            label2.Name = "label2";
            label2.Size = new Size(107, 15);
            label2.TabIndex = 1;
            label2.Text = "Nueva Contraseña:";
            // 
            // txbClave
            // 
            txbClave.Location = new Point(12, 27);
            txbClave.Name = "txbClave";
            txbClave.Size = new Size(244, 23);
            txbClave.TabIndex = 2;
            // 
            // txbNuevaClave
            // 
            txbNuevaClave.Location = new Point(12, 79);
            txbNuevaClave.Name = "txbNuevaClave";
            txbNuevaClave.Size = new Size(244, 23);
            txbNuevaClave.TabIndex = 3;
            // 
            // lblValidacion
            // 
            lblValidacion.AutoSize = true;
            lblValidacion.ForeColor = Color.Red;
            lblValidacion.Location = new Point(12, 152);
            lblValidacion.Name = "lblValidacion";
            lblValidacion.Size = new Size(165, 15);
            lblValidacion.TabIndex = 4;
            lblValidacion.Text = "Las contraseñas no coinciden.";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.White;
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = SystemColors.Highlight;
            btnGuardar.Location = new Point(165, 112);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(91, 26);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Cursor = Cursors.Hand;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.ForeColor = Color.DarkRed;
            btnVolver.Location = new Point(12, 112);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(91, 26);
            btnVolver.TabIndex = 9;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // frmActualizarClave
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(268, 179);
            Controls.Add(btnVolver);
            Controls.Add(btnGuardar);
            Controls.Add(lblValidacion);
            Controls.Add(txbNuevaClave);
            Controls.Add(txbClave);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MaximumSize = new Size(284, 218);
            MinimizeBox = false;
            MinimumSize = new Size(284, 218);
            Name = "frmActualizarClave";
            Text = "Actualizar";
            Load += frmActualizarClave_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txbClave;
        private TextBox txbNuevaClave;
        private Label lblValidacion;
        private Button btnGuardar;
        private Button btnVolver;
    }
}