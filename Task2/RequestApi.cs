using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Task2.Models;

namespace Task2
{
   public class RequestApi
    {
       private DataGridView dataGrid;

        public RequestApi(DataGridView dataGrid)
        {
            this.dataGrid = dataGrid;
        }

       public void Request()
        {
            ValCurs result;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://www.cbar.az/currencies/03.12.2020.xml");
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ValCurs));
                    using (TextReader reader1 = new StringReader(reader.ReadToEnd()))
                    {
                         result = (ValCurs)serializer.Deserialize(reader1);
                        AddGird(result);
                    }
                }
            }
        }

        private void AddGird(ValCurs result)
        {
            string[] row;
            foreach (var item in result.ValType[1].Valute)
            {
                row = new string[] { $"{item.Name}", $"{item.Code}", $"{item.Value}"};
                dataGrid.Rows.Add(row);
            }
        }
    }
}
