using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SheetIndex
{
    public partial class PDFResults : Form
    {
        public DialogResult DialogResult { get; set; }
        public int ID_Selected { get; set; }

        public PDFResults()
        {
            InitializeComponent();
            bindGrid();
            bindCombo();
        }

        private void bindCombo()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = Command.listRev;
            comboBox1.DataSource = bs.DataSource;
            comboBox1.DisplayMember = "DateAndDescription";
            comboBox1.ValueMember = "ID";
        }

        private void bindGrid()
        {
            dataGridView1.AutoGenerateColumns = true;
            BindingSource bs = new BindingSource();
            bs.DataSource = typeof(SheetData);
            foreach (SheetData sheet in Command.listSheet)
            {
                if (sheet.excludeArch == false)
                {
                    bs.Add(sheet);
                    Command.filteredListSheet.Add(sheet);
                }
            }

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                dataGridView1.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
            }

            dataGridView1.DataSource = Command.filteredListSheet;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex != 0)
                {

                    for (int i = 0; i < 15; i++)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[i].Style.BackColor = Color.White;
                    }
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightGreen;
                    //int indexNumber = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    Command.filteredListSheet.ElementAt(e.RowIndex).ColumnSelected = e.ColumnIndex;
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //int indexNumber = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[].Value.ToString());
            if (e.ColumnIndex == Command.filteredListSheet.ElementAt(e.RowIndex).ColumnSelected)
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightGreen;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            foreach (SheetData sheet in Command.filteredListSheet)
            {
                sheet.setSheetNumberAndName();
  
            }
            this.DialogResult = DialogResult.OK;
            //return DialogResult.OK;
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                this.ID_Selected = Int32.Parse(comboBox1.SelectedValue.ToString());
            }
        }
    }
}
