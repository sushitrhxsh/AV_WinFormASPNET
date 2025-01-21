namespace AWF.Presentation.Formularios
{
    partial class frmHistorial
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
            btnBuscar = new Button();
            txbBuscar = new TextBox();
            label8 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dtpFechaInicio = new DateTimePicker();
            dtpFechaFin = new DateTimePicker();
            dgvVenta = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvVenta).BeginInit();
            SuspendLayout();
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.White;
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Location = new Point(645, 64);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(91, 26);
            btnBuscar.TabIndex = 36;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            // 
            // txbBuscar
            // 
            txbBuscar.Location = new Point(385, 64);
            txbBuscar.Name = "txbBuscar";
            txbBuscar.Size = new Size(241, 23);
            txbBuscar.TabIndex = 33;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.Location = new Point(385, 46);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 32;
            label8.Text = "Buscar:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Location = new Point(195, 46);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 24;
            label4.Text = "Fecha Fin:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Location = new Point(4, 46);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 22;
            label3.Text = "Fecha Inicio:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 6);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 21;
            label2.Text = "Historial Venta";
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.Location = new Point(4, 30);
            label1.Name = "label1";
            label1.Size = new Size(740, 340);
            label1.TabIndex = 20;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(4, 64);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(164, 23);
            dtpFechaInicio.TabIndex = 37;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(195, 64);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(159, 23);
            dtpFechaFin.TabIndex = 38;
            // 
            // dgvVenta
            // 
            dgvVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVenta.Location = new Point(4, 96);
            dgvVenta.Name = "dgvVenta";
            dgvVenta.Size = new Size(732, 260);
            dgvVenta.TabIndex = 39;
            // 
            // frmHistorial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(748, 368);
            Controls.Add(dgvVenta);
            Controls.Add(dtpFechaFin);
            Controls.Add(dtpFechaInicio);
            Controls.Add(btnBuscar);
            Controls.Add(txbBuscar);
            Controls.Add(label8);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmHistorial";
            Text = "frmHistorial";
            Load += frmHistorial_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVenta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnBuscar;
        private TextBox txbBuscar;
        private Label label8;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaFin;
        private DataGridView dgvVenta;
    }
}