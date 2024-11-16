
namespace AWF.Presentation.Utilidades
{
    public static class CustomDataGridView
    {
        public static void ImplementarConfiguracion(this DataGridView dataGrid, string txtEnBoton = "")
        {
            dataGrid.AllowUserToAddRows        = false;
            dataGrid.AllowUserToDeleteRows     = false;
            dataGrid.AllowUserToResizeColumns  = true;
            dataGrid.AllowUserToResizeRows     = false;
            dataGrid.AllowUserToOrderColumns   = false;
            dataGrid.ColumnHeadersBorderStyle  = DataGridViewHeaderBorderStyle.Single;
            dataGrid.SelectionMode             = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.MultiSelect               = false;
            dataGrid.RowHeadersVisible         = false;
            dataGrid.ReadOnly                  = true;
            dataGrid.BackgroundColor           = Color.White;
            dataGrid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor           = Color.FromArgb(58, 49, 69),
                SelectionBackColor  = Color.FromArgb(58, 49, 69),
                ForeColor           = Color.FromArgb(255, 255, 255)
            };
            dataGrid.DefaultCellStyle = new DataGridViewCellStyle
            {
                SelectionBackColor = Color.FromArgb(191, 176, 209),
                SelectionForeColor = Color.FromArgb(0, 0, 0)
            };
            dataGrid.ColumnHeadersHeight         = 30;
            dataGrid.EnableHeadersVisualStyles   = false;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            if(!string.IsNullOrEmpty(txtEnBoton)){
                var btnEditarColumn = new DataGridViewButtonColumn();
                btnEditarColumn.Text         = txtEnBoton;
                btnEditarColumn.Name         = "ColumnaAccion";
                btnEditarColumn.HeaderText   = "";
                btnEditarColumn.UseColumnTextForButtonValue = true;
                btnEditarColumn.Width        = 50;
                btnEditarColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dataGrid.Columns.Add(btnEditarColumn);
            }

        }
    }
}