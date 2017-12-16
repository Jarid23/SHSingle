using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleMaps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string city = textBox1.Text;
            string state = textBox2.Text;
            string country = textBox3.Text;

            try
            {
                StringBuilder queryadddress = new StringBuilder();
                queryadddress.Append("http://maps.google.com/maps?q=");

                if (city != string.Empty)
                {
                    queryadddress.Append(city + "," + "+");
                }
                if (state != string.Empty)
                {
                    queryadddress.Append(state + "," + "+");
                }
                if (country != string.Empty)
                {
                    queryadddress.Append(country + "," + "+");
                }

                webBrowser1.Navigate(queryadddress.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
    }
}
