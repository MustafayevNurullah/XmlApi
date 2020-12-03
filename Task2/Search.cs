using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2
{
    public static class Search
    {
        public static void SearchDate(string item)
        {

            CreateTools.dataGrid.Rows.Clear();
            if (CreateTools.ComboBox.SelectedItem != "All")
            {
                List<Valute> row = RequestApi.result.ValType[1].Valute.FindAll(x => x.Code == item);
                string[] rowa = new string[] { $"{row[0].Name}", $"{row[0].Code}", $"{row[0].Value}" };
                CreateTools.dataGrid.Rows.Add(rowa);
            }
            else
            {
                foreach (var items in RequestApi.result.ValType[1].Valute)
                {
                    string[] row = new string[] { $"{items.Name}", $"{items.Code}", $"{items.Value}" };
                    CreateTools.dataGrid.Rows.Add(row);
                }
            }
        }
    }
}
