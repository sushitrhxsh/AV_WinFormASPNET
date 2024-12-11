namespace AWF.Presentation.Formularios
{
    partial class frmVenta
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
            btnGuardar = new Button();
            btnBuscar = new Button();
            txbPagoCon = new TextBox();
            label7 = new Label();
            txbCambio = new TextBox();
            label6 = new Label();
            txbNombreCliente = new TextBox();
            label4 = new Label();
            txbCodigoProducto = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label5 = new Label();
            label8 = new Label();
            dgvDetalleVenta = new DataGridView();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).BeginInit();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = SystemColors.MenuHighlight;
            btnGuardar.Location = new Point(625, 350);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(91, 26);
            btnGuardar.TabIndex = 38;
            btnGuardar.Text = "Registrar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.White;
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Location = new Point(471, 75);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(91, 26);
            btnBuscar.TabIndex = 36;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            // 
            // txbPagoCon
            // 
            txbPagoCon.Location = new Point(465, 353);
            txbPagoCon.Name = "txbPagoCon";
            txbPagoCon.ReadOnly = true;
            txbPagoCon.Size = new Size(147, 23);
            txbPagoCon.TabIndex = 31;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Location = new Point(175, 353);
            label7.Name = "label7";
            label7.Size = new Size(62, 15);
            label7.TabIndex = 30;
            label7.Text = "Pago Con:";
            // 
            // txbCambio
            // 
            txbCambio.Location = new Point(243, 353);
            txbCambio.Name = "txbCambio";
            txbCambio.Size = new Size(147, 23);
            txbCambio.TabIndex = 29;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Location = new Point(407, 350);
            label6.Name = "label6";
            label6.Size = new Size(52, 15);
            label6.TabIndex = 28;
            label6.Text = "Cambio:";
            // 
            // txbNombreCliente
            // 
            txbNombreCliente.Location = new Point(12, 134);
            txbNombreCliente.Name = "txbNombreCliente";
            txbNombreCliente.Size = new Size(550, 23);
            txbNombreCliente.TabIndex = 25;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Location = new Point(12, 116);
            label4.Name = "label4";
            label4.Size = new Size(94, 15);
            label4.TabIndex = 24;
            label4.Text = "Nombre Cliente:";
            // 
            // txbCodigoProducto
            // 
            txbCodigoProducto.Location = new Point(12, 75);
            txbCodigoProducto.Name = "txbCodigoProducto";
            txbCodigoProducto.Size = new Size(453, 23);
            txbCodigoProducto.TabIndex = 23;
            txbCodigoProducto.KeyDown += txbCodigoProducto_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Location = new Point(12, 57);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 22;
            label3.Text = "Codigo Producto:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 17);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 21;
            label2.Text = "Nueva Venta";
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.Location = new Point(12, 49);
            label1.Name = "label1";
            label1.Size = new Size(740, 340);
            label1.TabIndex = 20;
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(58, 49, 69);
            label5.Location = new Point(568, 60);
            label5.Name = "label5";
            label5.Size = new Size(145, 97);
            label5.TabIndex = 39;
            // 
            // label8
            // 
            label8.BackColor = Color.FromArgb(58, 49, 69);
            label8.Font = new Font("Segoe UI", 18F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(605, 75);
            label8.Name = "label8";
            label8.Size = new Size(70, 32);
            label8.TabIndex = 40;
            label8.Text = "Total:";
            // 
            // dgvDetalleVenta
            // 
            dgvDetalleVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleVenta.Location = new Point(12, 178);
            dgvDetalleVenta.Name = "dgvDetalleVenta";
            dgvDetalleVenta.Size = new Size(701, 152);
            dgvDetalleVenta.TabIndex = 41;
            // 
            // label9
            // 
            label9.BackColor = Color.FromArgb(58, 49, 69);
            label9.Font = new Font("Segoe UI", 18F);
            label9.ForeColor = Color.White;
            label9.Location = new Point(568, 116);
            label9.Name = "label9";
            label9.Size = new Size(145, 32);
            label9.TabIndex = 42;
            label9.Text = "0";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 407);
            Controls.Add(label9);
            Controls.Add(dgvDetalleVenta);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(btnGuardar);
            Controls.Add(btnBuscar);
            Controls.Add(txbPagoCon);
            Controls.Add(label7);
            Controls.Add(txbCambio);
            Controls.Add(label6);
            Controls.Add(txbNombreCliente);
            Controls.Add(label4);
            Controls.Add(txbCodigoProducto);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmVenta";
            Load += frmVenta_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGuardar;
        private Button btnBuscar;
        private TextBox txbPagoCon;
        private Label label7;
        private TextBox txbCambio;
        private Label label6;
        private TextBox txbNombreCliente;
        private Label label4;
        private TextBox txbCodigoProducto;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label5;
        private Label label8;
        private DataGridView dgvDetalleVenta;
        private Label label9;
    }
}