using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public static class CreateTools
    {
        static string Url= "https://www.cbar.az/currencies/03.12.2020.xml";
        static string olddate = "03.12.2020";
        public static DataGridView dataGrid;
        public static Button Button;
        public static ComboBox ComboBox;
        public static DateTimePicker DateTimePicker;
       public static DataGridView CreateGrid()
        {
            dataGrid = new DataGridView();
            dataGrid.Location = new System.Drawing.Point(34, 116);
            dataGrid.Name = "dataGridView1";
            dataGrid.Size = new System.Drawing.Size(723, 318);
            dataGrid.TabIndex = 3;
            dataGrid.ColumnCount = 3;
            dataGrid.Columns[0].Name = "Valyuta";
            dataGrid.Columns[1].Name = "Kod";
            dataGrid.Columns[2].Name = "Kurs";

            return dataGrid;
        }
        public static Button CreateButton()
        {
            Button = new Button();
            Button.Click += new EventHandler(BtnClick);
            Button.Location = new System.Drawing.Point(701, 17);
            Button.Name = "button1";
           Button.Size = new System.Drawing.Size(75, 23);
            Button.TabIndex = 2;
           
            Button.UseVisualStyleBackColor = true;
            Button.Text = "Search";
            return Button;
        }
        private static void BtnClick(object sender, EventArgs e)
        {
            if (olddate == DateTimePicker.Value.ToString("dd.MM.yyyy"))
            {
                Search.SearchDate(ComboBox.SelectedItem.ToString());
            }
            else
            {
                string a = Url.Replace(olddate, CreateTools.DateTimePicker.Value.ToString("dd.MM.yyyy"));
               if( ComboBox.SelectedItem !="All")
                RequestApi.Request(a, ComboBox.SelectedItem.ToString());
                if (ComboBox.SelectedItem == "All")
                    RequestApi.Request(a, "All") ;


            }
            olddate = CreateTools.DateTimePicker.Value.ToString("dd.MM.yyyy");
        }

        public static ComboBox CreateComboBox()
        {
            ComboBox = new ComboBox();
           ComboBox.FormattingEnabled = true;
            ComboBox.Location = new System.Drawing.Point(34, 19);
            ComboBox.Name = "comboBox1";
            ComboBox.Size = new System.Drawing.Size(121, 21);
            ComboBox.TabIndex = 1;
            ComboBox.Items.Add("All");
            ComboBox.SelectedItem = "All";
            foreach (var item in RequestApi.result.ValType[1].Valute)
            {
                ComboBox.Items.Add(item.Code);
            }

                return ComboBox;

        }
        public static DateTimePicker CreatedateTimePicker()
        {

            DateTimePicker = new DateTimePicker();
            DateTimePicker.Location = new System.Drawing.Point(366, 21);
            DateTimePicker.Name = "dateTimePicker1";
            DateTimePicker.Size = new System.Drawing.Size(200, 20);
            

            return DateTimePicker;
        }


    }
}
