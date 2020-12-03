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
   public static class RequestApi
    {
        static int  count;
      public static ValCurs result;

        public static void Request(string Url,string selecteditem)
        {
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {

                    XmlSerializer serializer = new XmlSerializer(typeof(ValCurs));
                    using (TextReader reader1 = new StringReader(reader.ReadToEnd()))
                    {
                         result = (ValCurs)serializer.Deserialize(reader1);
                        string[] row;
                        CreateTools.dataGrid.Rows.Clear();
                        foreach (var item in result.ValType[1].Valute)
                        {
                            
                            if (selecteditem != "All")
                            {
                                if (selecteditem == item.Code)
                                {
                                    row = new string[] { $"{item.Name}", $"{item.Code}", $"{item.Value}" };
                                    CreateTools.dataGrid.Rows.Add(row);
                                }
                            }else
                            {
                                row = new string[] { $"{item.Name}", $"{item.Code}", $"{item.Value}" };
                                CreateTools.dataGrid.Rows.Add(row);
                            }

                        }
                    }
                }
            }
        }

    
    }
}
