using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           Controls.Add( CreateTools.CreateGrid());
            RequestApi.Request("https://www.cbar.az/currencies/03.12.2020.xml","All");
            Controls.Add(CreateTools.CreateComboBox());
            Controls.Add(CreateTools.CreatedateTimePicker());
            Controls.Add(CreateTools.CreateButton());
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
