using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public static class CreateGridView
    {
       public static void CreateGrid(DataGridView dataGridView)
        {
            dataGridView.Width = 200;
            dataGridView.Height = 150;
            dataGridView.ColumnCount = 3;
            dataGridView.Columns[0].Name = "Valyuta";
            dataGridView.Columns[1].Name = "Kod";
            dataGridView.Columns[2].Name = "Kurs";
        }
    }
}
