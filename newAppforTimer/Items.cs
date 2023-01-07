using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newAppforTimer
{
    public partial class Items : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Zoha\source\repos\newAppforTimer\newAppforTimer\Database1.mdf;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        public Items()
        {
            InitializeComponent();
            clearFields();
            con = new SqlConnection(connectionString);
            truncatedb();
        }

        private void Items_Load(object sender, EventArgs e)
        {

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            double salePrice = 0;
            double disc = 0;
            double totAmount = 0;
            if (txtSalePrice.Text == "")
            {
                salePrice = 0;
            }
            else {
                salePrice = Convert.ToDouble(txtSalePrice.Text);
            }
            if (txtDiscount.Text == "")
            {
                disc = 0;
            }
            else
            {
                disc = Convert.ToDouble(txtDiscount.Text);
            }   
            if (rbtAmount.Checked == true)
            {
                totAmount = salePrice - disc;
            }
            else
            {
                totAmount = salePrice - Math.Round((salePrice * disc) / 100);
            }
            txtSellingAmt.Text = totAmount.ToString();
        }

        private bool insertIntoStockTable(string prodName, int qty, string discount, double purchasePrice, double salePrice, double sellingPrice)
        {
            bool isInserted = false;
            con.Open();
            cmd = new SqlCommand("INSERT INTO Items (ItemName,Quantity,Discount,PurchasePrice,SalePrice,SellPrice,DateAdded) VALUES(@ItemName,@Quantity,@Discount,@PurchasePrice,@SalePrice,@SellPrice,@DateAdded)", con);
            cmd.Parameters.AddWithValue("@ItemName", prodName);
            cmd.Parameters.AddWithValue("@Quantity", qty);
            cmd.Parameters.AddWithValue("@Discount", discount);
            cmd.Parameters.AddWithValue("@PurchasePrice", purchasePrice);
            cmd.Parameters.AddWithValue("@SalePrice", salePrice);
            cmd.Parameters.AddWithValue("@SellPrice", sellingPrice);
            cmd.Parameters.AddWithValue("@DateAdded", DateTime.Now.ToShortDateString());
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Records Inserted Successfully");
            isInserted = true;
            return isInserted;
        }

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            if (txtItemName.Text == "" || txtItemQty.Text == "" || txtDiscount.Text == "" || txtPurchaseAmt.Text == "" || txtSalePrice.Text == "" || txtSellingAmt.Text == "" )
            {
                MessageBox.Show("Please Enter all the fields.");
            }
            else
            {
                string itemName = txtItemName.Text;
                int iqty = Convert.ToInt32(txtItemQty.Text);
                string idisc = txtDiscount.Text;
                bool isPercent = rbtPercent.Checked;
                bool isAmount = rbtAmount.Checked;
                if (isPercent)
                {
                    idisc = idisc + "%";
                }
                double ipurPrice = Math.Round(Convert.ToDouble(txtPurchaseAmt.Text),2);
                double isalePrice = Math.Round(Convert.ToDouble(txtSalePrice.Text), 2);
                double iselPrice = Math.Round(Convert.ToDouble(txtSellingAmt.Text),2);
                insertIntoStockTable(itemName, iqty, idisc, ipurPrice, isalePrice, iselPrice);
                clearFields();
           }
        }

        private void txtPurchaseAmt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtItemQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only Numbers allowed");
                txtDiscount.Text = "";
            }
        }

        private void clearFields()
        {
            txtItemName.Text = "";
            txtItemQty.Text = "";
            txtDiscount.Text = "0";
            txtPurchaseAmt.Text = "";
            txtSalePrice.Text = "";
            txtSellingAmt.Text = "";
            rbtPercent.Checked = true;
        }

        private void truncatedb()
        {
            con.Open();
            string query1 = "TRUNCATE TABLE Items";
            cmd = new SqlCommand(query1, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void txtSalePrice_TextChanged(object sender, EventArgs e)
        {
            txtSellingAmt.Text = txtSalePrice.Text;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
