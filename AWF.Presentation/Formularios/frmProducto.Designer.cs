namespace AWF.Presentation.Formularios
{
    partial class frmProducto
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
            btnGuardarNuevo = new Button();
            btnVolverNuevo = new Button();
            cbbCategoriaNuevo = new ComboBox();
            label3 = new Label();
            txbDescripcionNuevo = new TextBox();
            tabNuevo = new TabPage();
            label10 = new Label();
            txbCantidadNuevo = new NumericUpDown();
            txbPrecioVentaNuevo = new TextBox();
            label9 = new Label();
            txbPrecioCompraNuevo = new TextBox();
            label8 = new Label();
            txbCodigoNuevo = new TextBox();
            label7 = new Label();
            label2 = new Label();
            dgvProductos = new DataGridView();
            btnBuscar = new Button();
            txbBuscar = new TextBox();
            btnNuevoLista = new Button();
            tabLista = new TabPage();
            tabControlMain = new TabControl();
            tabEditar = new TabPage();
            cbbHabilitado = new ComboBox();
            label14 = new Label();
            label4 = new Label();
            txbCantidadEditar = new NumericUpDown();
            txbPrecioVentaEditar = new TextBox();
            label5 = new Label();
            txbPrecioCompraEditar = new TextBox();
            label6 = new Label();
            txbCodigoEditar = new TextBox();
            label11 = new Label();
            cbbCategoriaEditar = new ComboBox();
            label12 = new Label();
            txbDescripcionEditar = new TextBox();
            label13 = new Label();
            btnGuardarEditar = new Button();
            btnVolverEditar = new Button();
            tabNuevo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txbCantidadNuevo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            tabLista.SuspendLayout();
            tabControlMain.SuspendLayout();
            tabEditar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txbCantidadEditar).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 16);
            label1.Name = "label1";
            label1.Size = new Size(120, 15);
            label1.TabIndex = 3;
            label1.Text = "Inventario / Producto";
            // 
            // btnGuardarNuevo
            // 
            btnGuardarNuevo.BackColor = Color.Gainsboro;
            btnGuardarNuevo.Cursor = Cursors.Hand;
            btnGuardarNuevo.FlatStyle = FlatStyle.Flat;
            btnGuardarNuevo.ForeColor = SystemColors.MenuHighlight;
            btnGuardarNuevo.Location = new Point(621, 284);
            btnGuardarNuevo.Name = "btnGuardarNuevo";
            btnGuardarNuevo.Size = new Size(91, 26);
            btnGuardarNuevo.TabIndex = 5;
            btnGuardarNuevo.Text = "Guardar";
            btnGuardarNuevo.UseVisualStyleBackColor = false;
            btnGuardarNuevo.Click += btnGuardarNuevo_Click;
            // 
            // btnVolverNuevo
            // 
            btnVolverNuevo.BackColor = Color.Gainsboro;
            btnVolverNuevo.Cursor = Cursors.Hand;
            btnVolverNuevo.FlatStyle = FlatStyle.Flat;
            btnVolverNuevo.Location = new Point(17, 284);
            btnVolverNuevo.Name = "btnVolverNuevo";
            btnVolverNuevo.Size = new Size(91, 26);
            btnVolverNuevo.TabIndex = 4;
            btnVolverNuevo.Text = "Volver";
            btnVolverNuevo.UseVisualStyleBackColor = false;
            btnVolverNuevo.Click += btnVolverNuevo_Click;
            // 
            // cbbCategoriaNuevo
            // 
            cbbCategoriaNuevo.Cursor = Cursors.Hand;
            cbbCategoriaNuevo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbCategoriaNuevo.FormattingEnabled = true;
            cbbCategoriaNuevo.Location = new Point(17, 31);
            cbbCategoriaNuevo.Name = "cbbCategoriaNuevo";
            cbbCategoriaNuevo.Size = new Size(278, 23);
            cbbCategoriaNuevo.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 7);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 2;
            label3.Text = "Categoria:";
            // 
            // txbDescripcionNuevo
            // 
            txbDescripcionNuevo.Location = new Point(17, 133);
            txbDescripcionNuevo.Name = "txbDescripcionNuevo";
            txbDescripcionNuevo.Size = new Size(278, 23);
            txbDescripcionNuevo.TabIndex = 1;
            // 
            // tabNuevo
            // 
            tabNuevo.Controls.Add(label10);
            tabNuevo.Controls.Add(txbCantidadNuevo);
            tabNuevo.Controls.Add(txbPrecioVentaNuevo);
            tabNuevo.Controls.Add(label9);
            tabNuevo.Controls.Add(txbPrecioCompraNuevo);
            tabNuevo.Controls.Add(label8);
            tabNuevo.Controls.Add(txbCodigoNuevo);
            tabNuevo.Controls.Add(label7);
            tabNuevo.Controls.Add(btnGuardarNuevo);
            tabNuevo.Controls.Add(btnVolverNuevo);
            tabNuevo.Controls.Add(cbbCategoriaNuevo);
            tabNuevo.Controls.Add(label3);
            tabNuevo.Controls.Add(txbDescripcionNuevo);
            tabNuevo.Controls.Add(label2);
            tabNuevo.Location = new Point(4, 24);
            tabNuevo.Name = "tabNuevo";
            tabNuevo.Padding = new Padding(3);
            tabNuevo.Size = new Size(732, 316);
            tabNuevo.TabIndex = 1;
            tabNuevo.Text = "Nuevo";
            tabNuevo.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(397, 7);
            label10.Name = "label10";
            label10.Size = new Size(58, 15);
            label10.TabIndex = 13;
            label10.Text = "Cantidad:";
            // 
            // txbCantidadNuevo
            // 
            txbCantidadNuevo.Location = new Point(397, 31);
            txbCantidadNuevo.Name = "txbCantidadNuevo";
            txbCantidadNuevo.Size = new Size(315, 23);
            txbCantidadNuevo.TabIndex = 12;
            // 
            // txbPrecioVentaNuevo
            // 
            txbPrecioVentaNuevo.Location = new Point(17, 237);
            txbPrecioVentaNuevo.Name = "txbPrecioVentaNuevo";
            txbPrecioVentaNuevo.Size = new Size(278, 23);
            txbPrecioVentaNuevo.TabIndex = 11;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(20, 222);
            label9.Name = "label9";
            label9.Size = new Size(75, 15);
            label9.TabIndex = 10;
            label9.Text = "Precio Venta:";
            // 
            // txbPrecioCompraNuevo
            // 
            txbPrecioCompraNuevo.Location = new Point(17, 188);
            txbPrecioCompraNuevo.Name = "txbPrecioCompraNuevo";
            txbPrecioCompraNuevo.Size = new Size(278, 23);
            txbPrecioCompraNuevo.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(20, 173);
            label8.Name = "label8";
            label8.Size = new Size(89, 15);
            label8.TabIndex = 8;
            label8.Text = "Precio Compra:";
            // 
            // txbCodigoNuevo
            // 
            txbCodigoNuevo.Location = new Point(17, 82);
            txbCodigoNuevo.Name = "txbCodigoNuevo";
            txbCodigoNuevo.Size = new Size(278, 23);
            txbCodigoNuevo.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(20, 67);
            label7.Name = "label7";
            label7.Size = new Size(49, 15);
            label7.TabIndex = 6;
            label7.Text = "Codigo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 118);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 0;
            label2.Text = "Descripcion:";
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(15, 55);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new Size(687, 255);
            dgvProductos.TabIndex = 3;
            dgvProductos.CellContentClick += dgvProductos_CellContentClick;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.Gainsboro;
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Location = new Point(611, 23);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(91, 26);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txbBuscar
            // 
            txbBuscar.Location = new Point(399, 23);
            txbBuscar.Name = "txbBuscar";
            txbBuscar.Size = new Size(184, 23);
            txbBuscar.TabIndex = 1;
            // 
            // btnNuevoLista
            // 
            btnNuevoLista.BackColor = Color.Gainsboro;
            btnNuevoLista.Cursor = Cursors.Hand;
            btnNuevoLista.FlatStyle = FlatStyle.Flat;
            btnNuevoLista.Location = new Point(15, 23);
            btnNuevoLista.Name = "btnNuevoLista";
            btnNuevoLista.Size = new Size(91, 26);
            btnNuevoLista.TabIndex = 0;
            btnNuevoLista.Text = "Nuevo";
            btnNuevoLista.UseVisualStyleBackColor = false;
            btnNuevoLista.Click += btnNuevoLista_Click;
            // 
            // tabLista
            // 
            tabLista.Controls.Add(dgvProductos);
            tabLista.Controls.Add(btnBuscar);
            tabLista.Controls.Add(txbBuscar);
            tabLista.Controls.Add(btnNuevoLista);
            tabLista.Location = new Point(4, 24);
            tabLista.Name = "tabLista";
            tabLista.Padding = new Padding(3);
            tabLista.Size = new Size(732, 316);
            tabLista.TabIndex = 0;
            tabLista.Text = "Lista";
            tabLista.UseVisualStyleBackColor = true;
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabLista);
            tabControlMain.Controls.Add(tabNuevo);
            tabControlMain.Controls.Add(tabEditar);
            tabControlMain.ItemSize = new Size(80, 20);
            tabControlMain.Location = new Point(12, 46);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(740, 344);
            tabControlMain.SizeMode = TabSizeMode.Fixed;
            tabControlMain.TabIndex = 2;
            // 
            // tabEditar
            // 
            tabEditar.Controls.Add(cbbHabilitado);
            tabEditar.Controls.Add(label14);
            tabEditar.Controls.Add(label4);
            tabEditar.Controls.Add(txbCantidadEditar);
            tabEditar.Controls.Add(txbPrecioVentaEditar);
            tabEditar.Controls.Add(label5);
            tabEditar.Controls.Add(txbPrecioCompraEditar);
            tabEditar.Controls.Add(label6);
            tabEditar.Controls.Add(txbCodigoEditar);
            tabEditar.Controls.Add(label11);
            tabEditar.Controls.Add(cbbCategoriaEditar);
            tabEditar.Controls.Add(label12);
            tabEditar.Controls.Add(txbDescripcionEditar);
            tabEditar.Controls.Add(label13);
            tabEditar.Controls.Add(btnGuardarEditar);
            tabEditar.Controls.Add(btnVolverEditar);
            tabEditar.Location = new Point(4, 24);
            tabEditar.Name = "tabEditar";
            tabEditar.Padding = new Padding(3);
            tabEditar.Size = new Size(732, 316);
            tabEditar.TabIndex = 2;
            tabEditar.Text = "Editar";
            tabEditar.UseVisualStyleBackColor = true;
            // 
            // cbbHabilitado
            // 
            cbbHabilitado.Cursor = Cursors.Hand;
            cbbHabilitado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbHabilitado.FormattingEnabled = true;
            cbbHabilitado.Location = new Point(399, 91);
            cbbHabilitado.Name = "cbbHabilitado";
            cbbHabilitado.Size = new Size(278, 23);
            cbbHabilitado.TabIndex = 27;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(402, 67);
            label14.Name = "label14";
            label14.Size = new Size(65, 15);
            label14.TabIndex = 26;
            label14.Text = "Habilitado:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(399, 7);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 25;
            label4.Text = "Cantidad:";
            // 
            // txbCantidadEditar
            // 
            txbCantidadEditar.Location = new Point(399, 31);
            txbCantidadEditar.Name = "txbCantidadEditar";
            txbCantidadEditar.Size = new Size(315, 23);
            txbCantidadEditar.TabIndex = 24;
            // 
            // txbPrecioVentaEditar
            // 
            txbPrecioVentaEditar.Location = new Point(19, 237);
            txbPrecioVentaEditar.Name = "txbPrecioVentaEditar";
            txbPrecioVentaEditar.Size = new Size(278, 23);
            txbPrecioVentaEditar.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 222);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 22;
            label5.Text = "Precio Venta:";
            // 
            // txbPrecioCompraEditar
            // 
            txbPrecioCompraEditar.Location = new Point(19, 188);
            txbPrecioCompraEditar.Name = "txbPrecioCompraEditar";
            txbPrecioCompraEditar.Size = new Size(278, 23);
            txbPrecioCompraEditar.TabIndex = 21;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 173);
            label6.Name = "label6";
            label6.Size = new Size(89, 15);
            label6.TabIndex = 20;
            label6.Text = "Precio Compra:";
            // 
            // txbCodigoEditar
            // 
            txbCodigoEditar.Location = new Point(19, 82);
            txbCodigoEditar.Name = "txbCodigoEditar";
            txbCodigoEditar.Size = new Size(278, 23);
            txbCodigoEditar.TabIndex = 19;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(22, 67);
            label11.Name = "label11";
            label11.Size = new Size(49, 15);
            label11.TabIndex = 18;
            label11.Text = "Codigo:";
            // 
            // cbbCategoriaEditar
            // 
            cbbCategoriaEditar.Cursor = Cursors.Hand;
            cbbCategoriaEditar.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbCategoriaEditar.FormattingEnabled = true;
            cbbCategoriaEditar.Location = new Point(19, 31);
            cbbCategoriaEditar.Name = "cbbCategoriaEditar";
            cbbCategoriaEditar.Size = new Size(278, 23);
            cbbCategoriaEditar.TabIndex = 17;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(22, 7);
            label12.Name = "label12";
            label12.Size = new Size(61, 15);
            label12.TabIndex = 16;
            label12.Text = "Categoria:";
            // 
            // txbDescripcionEditar
            // 
            txbDescripcionEditar.Location = new Point(19, 133);
            txbDescripcionEditar.Name = "txbDescripcionEditar";
            txbDescripcionEditar.Size = new Size(278, 23);
            txbDescripcionEditar.TabIndex = 15;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(22, 118);
            label13.Name = "label13";
            label13.Size = new Size(72, 15);
            label13.TabIndex = 14;
            label13.Text = "Descripcion:";
            // 
            // btnGuardarEditar
            // 
            btnGuardarEditar.BackColor = Color.Gainsboro;
            btnGuardarEditar.Cursor = Cursors.Hand;
            btnGuardarEditar.FlatStyle = FlatStyle.Flat;
            btnGuardarEditar.ForeColor = SystemColors.MenuHighlight;
            btnGuardarEditar.Location = new Point(623, 274);
            btnGuardarEditar.Name = "btnGuardarEditar";
            btnGuardarEditar.Size = new Size(91, 26);
            btnGuardarEditar.TabIndex = 11;
            btnGuardarEditar.Text = "Guardar";
            btnGuardarEditar.UseVisualStyleBackColor = false;
            btnGuardarEditar.Click += btnGuardarEditar_Click;
            // 
            // btnVolverEditar
            // 
            btnVolverEditar.BackColor = Color.Gainsboro;
            btnVolverEditar.Cursor = Cursors.Hand;
            btnVolverEditar.FlatStyle = FlatStyle.Flat;
            btnVolverEditar.Location = new Point(19, 274);
            btnVolverEditar.Name = "btnVolverEditar";
            btnVolverEditar.Size = new Size(91, 26);
            btnVolverEditar.TabIndex = 10;
            btnVolverEditar.Text = "Volver";
            btnVolverEditar.UseVisualStyleBackColor = false;
            btnVolverEditar.Click += btnVolverEditar_Click;
            // 
            // frmProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 407);
            Controls.Add(label1);
            Controls.Add(tabControlMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmProducto";
            Load += frmProducto_Load;
            tabNuevo.ResumeLayout(false);
            tabNuevo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txbCantidadNuevo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            tabLista.ResumeLayout(false);
            tabLista.PerformLayout();
            tabControlMain.ResumeLayout(false);
            tabEditar.ResumeLayout(false);
            tabEditar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txbCantidadEditar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnGuardarNuevo;
        private Button btnVolverNuevo;
        private ComboBox cbbCategoriaNuevo;
        private Label label3;
        private TextBox txbDescripcionNuevo;
        private TabPage tabNuevo;
        private TextBox txbCodigoNuevo;
        private Label label7;
        private Label label2;
        private DataGridView dgvProductos;
        private Button btnBuscar;
        private TextBox txbBuscar;
        private Button btnNuevoLista;
        private TabPage tabLista;
        private TabControl tabControlMain;
        private TextBox txbPrecioVentaNuevo;
        private Label label9;
        private TextBox txbPrecioCompraNuevo;
        private Label label8;
        private Label label10;
        private NumericUpDown txbCantidadNuevo;
        private TabPage tabEditar;
        private ComboBox cbbHabilitado;
        private Label label14;
        private Label label4;
        private NumericUpDown txbCantidadEditar;
        private TextBox txbPrecioVentaEditar;
        private Label label5;
        private TextBox txbPrecioCompraEditar;
        private Label label6;
        private TextBox txbCodigoEditar;
        private Label label11;
        private ComboBox cbbCategoriaEditar;
        private Label label12;
        private TextBox txbDescripcionEditar;
        private Label label13;
        private Button btnGuardarEditar;
        private Button btnVolverEditar;
    }
}