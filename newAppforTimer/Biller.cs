using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace newAppforTimer
{
    public partial class Biller : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Zoha\source\repos\newAppforTimer\newAppforTimer\Database1.mdf;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        public Biller()
        {
            InitializeComponent();
            con = new SqlConnection(connectionString);
        }

        private void Biller_Load(object sender, EventArgs e)
        {
            DataTable dt = null;
            con.Open();
            string strCmd = "select Category from Items";
            using (cmd = new SqlCommand(strCmd, con))
            {
                SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
                dt = new DataTable("catList");
                da.Fill(dt);
            }
            cboxCategory.DisplayMember = "Category";
            cboxCategory.ValueMember = "Category";
            cboxCategory.DataSource = dt;
            cboxCategory.SelectedIndex = -1;
            con.Close();
        }
    }
}
