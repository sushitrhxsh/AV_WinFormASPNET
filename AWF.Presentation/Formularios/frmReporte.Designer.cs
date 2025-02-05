namespace AWF.Presentation.Formularios
{
    partial class frmReporte
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
            dgvReporte = new DataGridView();
            dtpFechaFin = new DateTimePicker();
            dtpFechaInicio = new DateTimePicker();
            btnBuscar = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnExcel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            SuspendLayout();
            // 
            // dgvReporte
            // 
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Location = new Point(12, 111);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.Size = new Size(732, 260);
            dgvReporte.TabIndex = 49;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(203, 79);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(159, 23);
            dtpFechaFin.TabIndex = 48;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(12, 79);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(164, 23);
            dtpFechaInicio.TabIndex = 47;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.White;
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Location = new Point(379, 76);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(91, 26);
            btnBuscar.TabIndex = 46;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Location = new Point(203, 61);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 43;
            label4.Text = "Fecha Fin:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Location = new Point(12, 61);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 42;
            label3.Text = "Fecha Inicio:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 21);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 41;
            label2.Text = "Reporte Ventas";
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.Location = new Point(12, 45);
            label1.Name = "label1";
            label1.Size = new Size(740, 340);
            label1.TabIndex = 40;
            // 
            // btnExcel
            // 
            btnExcel.BackColor = Color.White;
            btnExcel.Cursor = Cursors.Hand;
            btnExcel.FlatStyle = FlatStyle.Flat;
            btnExcel.Location = new Point(653, 76);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(91, 26);
            btnExcel.TabIndex = 50;
            btnExcel.Text = "Excel";
            btnExcel.UseVisualStyleBackColor = false;
            btnExcel.Click += btnExcel_Click;
            // 
            // frmReporte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 407);
            Controls.Add(btnExcel);
            Controls.Add(dgvReporte);
            Controls.Add(dtpFechaFin);
            Controls.Add(dtpFechaInicio);
            Controls.Add(btnBuscar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmReporte";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmReporte";
            Load += frmReporte_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvReporte;
        private DateTimePicker dtpFechaFin;
        private DateTimePicker dtpFechaInicio;
        private Button btnBuscar;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnExcel;
    }
}