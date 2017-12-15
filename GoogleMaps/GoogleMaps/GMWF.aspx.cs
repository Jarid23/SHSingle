using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace GoogleMaps
{
    public partial class GMWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string city = TextBox1.Text;
            string state = TextBox2.Text;
            string country = TextBox3.Text;

            StringBuilder add = new StringBuilder("https://www.google.com/maps?q=");

            add.Append(city);
            add.Append(state);
            add.Append(country);

            



        }
    }
}